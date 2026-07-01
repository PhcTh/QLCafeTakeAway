<template>
  <div>
    <div class="duong-dan">QUẢN LÝ DANH MỤC</div>

    <div class="hop-noi-dung">
      <div class="tieu-de-khu">
        <h1 class="tieu-de-trang">THÔNG TIN NGUYÊN LIỆU</h1>
      </div>

      <div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">{{ thongBao }}</div>

      <div class="thanh-cong-cu">
        <div class="khu-tim-kiem">
          <input v-model="tuKhoa" type="text" placeholder="Nhập mã hoặc tên nguyên liệu">
          <button @click="timKiem"><span class="icon-nut">⌕</span>Tìm kiếm</button>
        </div>

        <div class="khu-nut">
          <button @click="batDauThem"><span class="icon-nut">+</span>Thêm</button>
          <button @click="lamMoi"><span class="icon-nut">↻</span>Làm mới</button>
        </div>
      </div>

      <table class="bang-du-lieu">
        <thead>
          <tr>
            <th>Mã nguyên liệu</th>
            <th>Tên nguyên liệu</th>
            <th>Đơn vị tính</th>
            <th class="cot-thao-tac">Thao tác</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="nl in dsNguyenLieu" :key="nl.maNl">
            <td>{{ nl.maNl }}</td>
            <td>{{ nl.tenNguyenLieu }}</td>
            <td>{{ nl.donViTinh }}</td>
            <td>
              <div class="nhom-thao-tac">
                <button class="nut-bang nut-xem" @click="xemChiTiet(nl)"><span class="icon-nut">i</span>Xem</button>
                <button class="nut-bang" @click="batDauSua(nl)"><span class="icon-nut">✎</span>Sửa</button>
                <button class="nut-bang nut-xoa" @click="xoaDuLieu(nl.maNl)"><span class="icon-nut">×</span>Xóa</button>
              </div>
            </td>
          </tr>

          <tr v-if="!dsNguyenLieu.length">
            <td colspan="4" class="dong-rong">Không có dữ liệu nguyên liệu.</td>
          </tr>
        </tbody>
      </table>

      <div v-if="phanTrang.totalPages > 1" class="khu-nut form-actions">
        <button :disabled="phanTrang.page <= 1" @click="doiTrang(phanTrang.page - 1)">Trước</button>
        <span>Trang {{ phanTrang.page }} / {{ phanTrang.totalPages }}</span>
        <button :disabled="phanTrang.page >= phanTrang.totalPages" @click="doiTrang(phanTrang.page + 1)">Sau</button>
      </div>
    </div>

    <div v-if="hopThoaiDangMo === 'form'" class="lop-phu" @click.self="dongHopThoai">
      <section class="hop-thoai">
        <div class="dau-hop-thoai">
          <strong>{{ dangSua ? 'Cập nhật nguyên liệu' : 'Thêm nguyên liệu' }}</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <form class="form-danh-muc form-tach-rieng" @submit.prevent="luuDuLieu">
          <div class="o-nhap">
            <label>Mã nguyên liệu</label>
            <input v-model.trim="form.maNl" readonly maxlength="10" required>
          </div>

          <div class="o-nhap">
            <label>Tên nguyên liệu</label>
            <input v-model.trim="form.tenNguyenLieu" maxlength="50" required>
          </div>

          <div class="o-nhap">
            <label>Đơn vị tính</label>
            <input v-model.trim="form.donViTinh" maxlength="20" required>
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
          <strong>Chi tiết nguyên liệu</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <div class="noi-dung-hop-thoai">
          <div class="luoi-chi-tiet">
            <div><span>Mã nguyên liệu</span><strong>{{ dongDangXem.maNl }}</strong></div>
            <div><span>Tên nguyên liệu</span><strong>{{ dongDangXem.tenNguyenLieu }}</strong></div>
            <div><span>Đơn vị tính</span><strong>{{ dongDangXem.donViTinh }}</strong></div>
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

const dsNguyenLieu = ref([])
const tuKhoa = ref('')
const thongBao = ref('')
const coLoi = ref(false)
const dangSua = ref(false)
const hopThoaiDangMo = ref('')
const dongDangXem = ref(null)
const phanTrang = reactive({
  page: 1,
  pageSize: 10,
  totalItems: 0,
  totalPages: 0
})

const form = reactive({
  maNl: '',
  tenNguyenLieu: '',
  donViTinh: ''
})

onMounted(taiDuLieu)

async function taiDuLieu() {
  try {
    const response = await csharpApi.getNguyenLieu(tuKhoa.value, {
      page: phanTrang.page,
      pageSize: phanTrang.pageSize
    })
    ganDuLieuPhanTrang(response)
    baoThanhCong('Tải dữ liệu nguyên liệu thành công.')
  } catch (error) {
    baoLoi(error.message)
  }
}

async function timKiem() {
  phanTrang.page = 1
  await taiDuLieu()
}

async function batDauThem() {
  dangSua.value = false
  dongDangXem.value = null
  if (tuKhoa.value) {
    tuKhoa.value = ''
    await taiDuLieu()
  }
  ganForm()
  form.maNl = await taoMaNguyenLieu()
  thongBao.value = ''
  hopThoaiDangMo.value = 'form'
}

function batDauSua(nl) {
  dangSua.value = true
  dongDangXem.value = null
  ganForm(nl)
  thongBao.value = ''
  hopThoaiDangMo.value = 'form'
}

function xemChiTiet(nl) {
  dongDangXem.value = nl
  thongBao.value = ''
  hopThoaiDangMo.value = 'detail'
}

async function luuDuLieu() {
  try {
    const duLieu = { ...form }

    if (dangSua.value) {
      await csharpApi.updateNguyenLieu(form.maNl, duLieu)
      baoThanhCong('Cập nhật nguyên liệu thành công.')
    } else {
      await csharpApi.createNguyenLieu(duLieu)
      baoThanhCong('Thêm nguyên liệu thành công.')
    }

    await taiDuLieu()
    dongHopThoai(false)
  } catch (error) {
    baoLoi(error.message)
  }
}

async function xoaDuLieu(maNl) {
  if (!confirm(`Xóa nguyên liệu ${maNl}?`)) return

  try {
    await csharpApi.deleteNguyenLieu(maNl)
    baoThanhCong('Xóa nguyên liệu thành công.')
    await taiDuLieu()
  } catch (error) {
    baoLoi(error.message)
  }
}

function lamMoi() {
  tuKhoa.value = ''
  phanTrang.page = 1
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

function ganForm(nl = null) {
  form.maNl = nl?.maNl || ''
  form.tenNguyenLieu = nl?.tenNguyenLieu || ''
  form.donViTinh = nl?.donViTinh || ''
}

async function taoMaNguyenLieu() {
  return taoMaTiepTheo(await layTatCaNguyenLieu(), 'maNl', 'NL')
}

function taoMaTiepTheo(items, field, prefix) {
  const max = items.reduce((current, item) => {
    const number = Number(String(item[field] || '').replace(/\D/g, ''))
    return Number.isFinite(number) ? Math.max(current, number) : current
  }, 0)

  return `${prefix}${String(max + 1).padStart(3, '0')}`
}

function ganDuLieuPhanTrang(response) {
  if (Array.isArray(response)) {
    dsNguyenLieu.value = response
    phanTrang.totalItems = response.length
    phanTrang.totalPages = response.length ? 1 : 0
    return
  }

  dsNguyenLieu.value = response.items || []
  phanTrang.page = response.page || 1
  phanTrang.pageSize = response.pageSize || phanTrang.pageSize
  phanTrang.totalItems = response.totalItems || 0
  phanTrang.totalPages = response.totalPages || 0
}

async function doiTrang(page) {
  phanTrang.page = page
  await taiDuLieu()
}

async function layTatCaNguyenLieu() {
  const response = await csharpApi.getNguyenLieu('')
  return Array.isArray(response) ? response : response.items || []
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
