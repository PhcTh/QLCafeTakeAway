<template>
  <div>
    <div class="duong-dan">QUẢN LÝ DANH MỤC</div>

    <div class="hop-noi-dung">
      <div class="tieu-de-khu">
        <h1 class="tieu-de-trang">THÔNG TIN ĐỒ UỐNG</h1>
      </div>

      <div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">{{ thongBao }}</div>

      <div class="thanh-cong-cu">
        <div class="khu-tim-kiem">
          <input v-model="tuKhoa" type="text" placeholder="Nhập mã, tên đồ uống hoặc loại">
          <button @click="taiDuLieu"><span class="icon-nut">⌕</span>Tìm kiếm</button>
        </div>

        <div class="khu-nut">
          <button @click="batDauThem"><span class="icon-nut">+</span>Thêm</button>
          <button @click="lamMoi"><span class="icon-nut">↻</span>Làm mới</button>
        </div>
      </div>

      <table class="bang-du-lieu">
        <thead>
          <tr>
            <th>Mã đồ uống</th>
            <th>Tên đồ uống</th>
            <th>Mã loại</th>
            <th>Loại đồ uống</th>
            <th>Đơn giá</th>
            <th class="cot-thao-tac">Thao tác</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="du in dsDoUong" :key="du.maDu">
            <td>{{ du.maDu }}</td>
            <td>{{ du.tenDoUong }}</td>
            <td>{{ du.maLdu }}</td>
            <td>{{ du.tenLoaiDoUong }}</td>
            <td>{{ dinhDangTien(du.donGia) }}</td>
            <td>
              <div class="nhom-thao-tac">
                <button class="nut-bang nut-xem" @click="xemChiTiet(du)"><span class="icon-nut">i</span>Xem</button>
                <button class="nut-bang" @click="batDauSua(du)"><span class="icon-nut">✎</span>Sửa</button>
                <button class="nut-bang nut-xoa" @click="xoaDuLieu(du.maDu)"><span class="icon-nut">×</span>Xóa</button>
              </div>
            </td>
          </tr>

          <tr v-if="!dsDoUong.length">
            <td colspan="6" class="dong-rong">Không có dữ liệu đồ uống.</td>
          </tr>
        </tbody>
      </table>
    </div>

    <div v-if="hopThoaiDangMo === 'form'" class="lop-phu" @click.self="dongHopThoai">
      <section class="hop-thoai">
        <div class="dau-hop-thoai">
          <strong>{{ dangSua ? 'Cập nhật đồ uống' : 'Thêm đồ uống' }}</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <form class="form-danh-muc form-tach-rieng" @submit.prevent="luuDuLieu">
          <div class="o-nhap">
            <label>Mã đồ uống</label>
            <input v-model.trim="form.maDu" readonly maxlength="10" required>
          </div>

          <div class="o-nhap">
            <label>Tên đồ uống</label>
            <input v-model.trim="form.tenDoUong" maxlength="50" required>
          </div>

          <div class="o-nhap">
            <label>Loại đồ uống</label>
            <select v-model="form.maLdu" required>
              <option value="">-- Chọn loại --</option>
              <option v-for="loai in dsLoaiDoUong" :key="loai.maLdu" :value="loai.maLdu">
                {{ loai.maLdu }} - {{ loai.tenLoaiDoUong }}
              </option>
            </select>
          </div>

          <div class="o-nhap">
            <label>Đơn giá</label>
            <input v-model.number="form.donGia" type="number" min="0" required>
          </div>

          <div class="khu-nut form-actions">
            <button type="submit"><span class="icon-nut">✓</span>{{ dangSua ? 'Cập nhật' : 'Lưu' }}</button>
            <button type="button" @click="dongHopThoai"><span class="icon-nut">×</span>Hủy</button>
          </div>
        </form>
      </section>
    </div>

    <div v-if="hopThoaiDangMo === 'detail' && dongDangXem" class="lop-phu" @click.self="dongHopThoai">
      <section class="hop-thoai">
        <div class="dau-hop-thoai">
          <strong>Chi tiết đồ uống</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <div class="noi-dung-hop-thoai">
          <div class="luoi-chi-tiet">
            <div><span>Mã đồ uống</span><strong>{{ dongDangXem.maDu }}</strong></div>
            <div><span>Tên đồ uống</span><strong>{{ dongDangXem.tenDoUong }}</strong></div>
            <div><span>Mã loại</span><strong>{{ dongDangXem.maLdu }}</strong></div>
            <div><span>Loại đồ uống</span><strong>{{ dongDangXem.tenLoaiDoUong }}</strong></div>
            <div><span>Đơn giá</span><strong>{{ dinhDangTien(dongDangXem.donGia) }}</strong></div>
          </div>

          <div class="khu-nut">
            <button @click="batDauSua(dongDangXem)"><span class="icon-nut">✎</span>Sửa thông tin</button>
            <button @click="dongHopThoai"><span class="icon-nut">×</span>Đóng</button>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>

<script setup>
import { onMounted, reactive, ref } from 'vue'
import { csharpApi } from '../../api/csharpApi'

const dsDoUong = ref([])
const dsLoaiDoUong = ref([])
const tuKhoa = ref('')
const thongBao = ref('')
const coLoi = ref(false)
const dangSua = ref(false)
const hopThoaiDangMo = ref('')
const dongDangXem = ref(null)

const form = reactive({
  maDu: '',
  maLdu: '',
  tenDoUong: '',
  donGia: 0
})

onMounted(async () => {
  await taiLoaiDoUong()
  await taiDuLieu()
})

async function taiLoaiDoUong() {
  try {
    dsLoaiDoUong.value = await csharpApi.getLoaiDoUong()
  } catch (error) {
    baoLoi(`Không tải được loại đồ uống: ${error.message}`)
  }
}

async function taiDuLieu() {
  try {
    dsDoUong.value = await csharpApi.getDoUong(tuKhoa.value)
    baoThanhCong('Tải dữ liệu đồ uống thành công.')
  } catch (error) {
    baoLoi(error.message)
  }
}

async function batDauThem() {
  dangSua.value = false
  dongDangXem.value = null
  if (tuKhoa.value) {
    tuKhoa.value = ''
    await taiDuLieu()
  }
  ganForm()
  form.maDu = taoMaDoUong()
  thongBao.value = ''
  hopThoaiDangMo.value = 'form'
}

function batDauSua(du) {
  dangSua.value = true
  dongDangXem.value = null
  ganForm(du)
  thongBao.value = ''
  hopThoaiDangMo.value = 'form'
}

function xemChiTiet(du) {
  dongDangXem.value = du
  thongBao.value = ''
  hopThoaiDangMo.value = 'detail'
}

async function luuDuLieu() {
  try {
    const duLieu = { ...form, donGia: Number(form.donGia) }

    if (dangSua.value) {
      await csharpApi.updateDoUong(form.maDu, duLieu)
      baoThanhCong('Cập nhật đồ uống thành công.')
    } else {
      await csharpApi.createDoUong(duLieu)
      baoThanhCong('Thêm đồ uống thành công.')
    }

    await taiDuLieu()
    dongHopThoai(false)
  } catch (error) {
    baoLoi(error.message)
  }
}

async function xoaDuLieu(maDu) {
  if (!confirm(`Xóa đồ uống ${maDu}?`)) return

  try {
    await csharpApi.deleteDoUong(maDu)
    baoThanhCong('Xóa đồ uống thành công.')
    await taiDuLieu()
  } catch (error) {
    baoLoi(error.message)
  }
}

function lamMoi() {
  tuKhoa.value = ''
  dongHopThoai()
  taiLoaiDoUong()
  taiDuLieu()
}

function dongHopThoai(resetThongBao = true) {
  ganForm()
  dangSua.value = false
  dongDangXem.value = null
  hopThoaiDangMo.value = ''
  if (resetThongBao) thongBao.value = ''
}

function ganForm(du = null) {
  form.maDu = du?.maDu || ''
  form.maLdu = du?.maLdu || ''
  form.tenDoUong = du?.tenDoUong || ''
  form.donGia = du?.donGia || 0
}

function taoMaDoUong() {
  return taoMaTiepTheo(dsDoUong.value, 'maDu', 'DU')
}

function taoMaTiepTheo(items, field, prefix) {
  const max = items.reduce((current, item) => {
    const number = Number(String(item[field] || '').replace(/\D/g, ''))
    return Number.isFinite(number) ? Math.max(current, number) : current
  }, 0)

  return `${prefix}${String(max + 1).padStart(3, '0')}`
}

function dinhDangTien(value) {
  return Number(value || 0).toLocaleString('vi-VN') + ' đ'
}

function baoThanhCong(message) {
  thongBao.value = message
  coLoi.value = false
}

function baoLoi(message) {
  thongBao.value = message
  coLoi.value = true
}
</script>
