<template>
  <div>
    <div class="duong-dan">QUẢN LÝ DANH MỤC</div>

    <div class="hop-noi-dung">
      <div class="tieu-de-khu">
        <h1 class="tieu-de-trang">THÔNG TIN LOẠI ĐỒ UỐNG</h1>
      </div>

      <div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">{{ thongBao }}</div>

      <div class="thanh-cong-cu">
        <div class="khu-tim-kiem">
          <input v-model="tuKhoa" type="text" placeholder="Nhập mã hoặc tên loại đồ uống">
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
            <th>Mã loại</th>
            <th>Tên loại đồ uống</th>
            <th>Mô tả</th>
            <th class="cot-thao-tac">Thao tác</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="loai in dsLoaiDoUong" :key="loai.maLdu">
            <td>{{ loai.maLdu }}</td>
            <td>{{ loai.tenLoaiDoUong }}</td>
            <td>{{ loai.moTa }}</td>
            <td>
              <div class="nhom-thao-tac">
                <button class="nut-bang nut-xem" @click="xemChiTiet(loai)"><span class="icon-nut">i</span>Xem</button>
                <button class="nut-bang" @click="batDauSua(loai)"><span class="icon-nut">✎</span>Sửa</button>
                <button class="nut-bang nut-xoa" @click="xoaDuLieu(loai.maLdu)"><span class="icon-nut">×</span>Xóa</button>
              </div>
            </td>
          </tr>

          <tr v-if="!dsLoaiDoUong.length">
            <td colspan="4" class="dong-rong">Không có dữ liệu loại đồ uống.</td>
          </tr>
        </tbody>
      </table>
    </div>

    <div v-if="hopThoaiDangMo === 'form'" class="lop-phu" @click.self="dongHopThoai">
      <section class="hop-thoai">
        <div class="dau-hop-thoai">
          <strong>{{ dangSua ? 'Cập nhật loại đồ uống' : 'Thêm loại đồ uống' }}</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <form class="form-danh-muc form-tach-rieng" @submit.prevent="luuDuLieu">
          <div class="o-nhap">
            <label>Mã loại</label>
            <input v-model.trim="form.maLdu" readonly maxlength="10" required>
          </div>

          <div class="o-nhap">
            <label>Tên loại đồ uống</label>
            <input v-model.trim="form.tenLoaiDoUong" maxlength="50" required>
          </div>

          <div class="o-nhap rong">
            <label>Mô tả</label>
            <input v-model.trim="form.moTa" maxlength="100">
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
          <strong>Chi tiết loại đồ uống</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <div class="noi-dung-hop-thoai">
          <div class="luoi-chi-tiet">
            <div><span>Mã loại</span><strong>{{ dongDangXem.maLdu }}</strong></div>
            <div><span>Tên loại</span><strong>{{ dongDangXem.tenLoaiDoUong }}</strong></div>
            <div class="rong"><span>Mô tả</span><strong>{{ dongDangXem.moTa || 'Không có' }}</strong></div>
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

const dsLoaiDoUong = ref([])
const tuKhoa = ref('')
const thongBao = ref('')
const coLoi = ref(false)
const dangSua = ref(false)
const hopThoaiDangMo = ref('')
const dongDangXem = ref(null)

const form = reactive({
  maLdu: '',
  tenLoaiDoUong: '',
  moTa: ''
})

onMounted(taiDuLieu)

async function taiDuLieu() {
  try {
    dsLoaiDoUong.value = await csharpApi.getLoaiDoUong(tuKhoa.value)
    baoThanhCong('Tải dữ liệu loại đồ uống thành công.')
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
  form.maLdu = taoMaLoaiDoUong()
  thongBao.value = ''
  hopThoaiDangMo.value = 'form'
}

function batDauSua(loai) {
  dangSua.value = true
  dongDangXem.value = null
  ganForm(loai)
  thongBao.value = ''
  hopThoaiDangMo.value = 'form'
}

function xemChiTiet(loai) {
  dongDangXem.value = loai
  thongBao.value = ''
  hopThoaiDangMo.value = 'detail'
}

async function luuDuLieu() {
  try {
    const duLieu = { ...form }

    if (dangSua.value) {
      await csharpApi.updateLoaiDoUong(form.maLdu, duLieu)
      baoThanhCong('Cập nhật loại đồ uống thành công.')
    } else {
      await csharpApi.createLoaiDoUong(duLieu)
      baoThanhCong('Thêm loại đồ uống thành công.')
    }

    await taiDuLieu()
    dongHopThoai(false)
  } catch (error) {
    baoLoi(error.message)
  }
}

async function xoaDuLieu(maLdu) {
  if (!confirm(`Xóa loại đồ uống ${maLdu}?`)) return

  try {
    await csharpApi.deleteLoaiDoUong(maLdu)
    baoThanhCong('Xóa loại đồ uống thành công.')
    await taiDuLieu()
  } catch (error) {
    baoLoi(error.message)
  }
}

function lamMoi() {
  tuKhoa.value = ''
  dongHopThoai()
  taiDuLieu()
}

function dongHopThoai(resetThongBao = true) {
  ganForm()
  dangSua.value = false
  dongDangXem.value = null
  hopThoaiDangMo.value = ''
  if (resetThongBao) thongBao.value = ''
}

function ganForm(loai = null) {
  form.maLdu = loai?.maLdu || ''
  form.tenLoaiDoUong = loai?.tenLoaiDoUong || ''
  form.moTa = loai?.moTa || ''
}

function taoMaLoaiDoUong() {
  return taoMaTiepTheo(dsLoaiDoUong.value, 'maLdu', 'LDU')
}

function taoMaTiepTheo(items, field, prefix) {
  const max = items.reduce((current, item) => {
    const number = Number(String(item[field] || '').replace(/\D/g, ''))
    return Number.isFinite(number) ? Math.max(current, number) : current
  }, 0)

  return `${prefix}${String(max + 1).padStart(3, '0')}`
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
