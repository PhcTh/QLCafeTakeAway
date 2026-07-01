<template>
  <div>
    <div class="duong-dan">QUẢN TRỊ HỆ THỐNG</div>

    <div class="hop-noi-dung">
      <div class="tieu-de-khu">
        <h1 class="tieu-de-trang">QUẢN LÝ TÀI KHOẢN NGƯỜI DÙNG</h1>
      </div>

      <div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">{{ thongBao }}</div>

      <div class="thanh-cong-cu">
        <div class="khu-tim-kiem">
          <input v-model="tuKhoa" type="text" placeholder="Nhập mã, tên, tài khoản hoặc nhóm">
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
            <th>Mã người dùng</th>
            <th>Họ tên</th>
            <th>Tài khoản</th>
            <th>Số điện thoại</th>
            <th>Vị trí</th>
            <th>Nhóm</th>
            <th>Trạng thái</th>
            <th class="cot-thao-tac">Thao tác</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="nd in dsNguoiDung" :key="nd.maNd">
            <td>{{ nd.maNd }}</td>
            <td>{{ nd.tenNd }}</td>
            <td>{{ nd.userName }}</td>
            <td>{{ nd.sdt || '' }}</td>
            <td>{{ nd.viTri || '' }}</td>
            <td>{{ nd.tenNhom || '' }}</td>
            <td>{{ nd.trangThai ? 'Đang hoạt động' : 'Đã khóa' }}</td>
            <td>
              <div class="nhom-thao-tac">
                <button class="nut-bang nut-xem" @click="xemChiTiet(nd)"><span class="icon-nut">i</span>Xem</button>
                <button class="nut-bang" @click="batDauSua(nd)"><span class="icon-nut">✎</span>Sửa</button>
                <button class="nut-bang nut-xoa" @click="xoaDuLieu(nd.maNd)"><span class="icon-nut">×</span>Khóa</button>
              </div>
            </td>
          </tr>

          <tr v-if="!dsNguoiDung.length">
            <td colspan="8" class="dong-rong">Không có dữ liệu tài khoản người dùng.</td>
          </tr>
        </tbody>
      </table>

      <div v-if="phanTrang.totalPages > 0" class="khu-nut form-actions khu-phan-trang">
        <button :disabled="phanTrang.page <= 1" @click="doiTrang(phanTrang.page - 1)">Trước</button>
        <span>Trang {{ phanTrang.page }} / {{ phanTrang.totalPages }}</span>
        <button :disabled="phanTrang.page >= phanTrang.totalPages" @click="doiTrang(phanTrang.page + 1)">Sau</button>
      </div>
    </div>

    <div v-if="hopThoaiDangMo === 'form'" class="lop-phu" @click.self="dongHopThoai">
      <section class="hop-thoai">
        <div class="dau-hop-thoai">
          <strong>{{ dangSua ? 'Cập nhật tài khoản người dùng' : 'Thêm tài khoản người dùng' }}</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <form class="form-danh-muc form-tach-rieng" @submit.prevent="luuDuLieu">
          <div class="o-nhap">
            <label>Mã người dùng</label>
            <input v-model.trim="form.maNd" readonly maxlength="10" required>
          </div>

          <div class="o-nhap">
            <label>Họ tên</label>
            <input v-model.trim="form.tenNd" maxlength="50" required>
          </div>

          <div class="o-nhap">
            <label>Số điện thoại</label>
            <input v-model.trim="form.sdt" maxlength="11">
          </div>

          <div class="o-nhap">
            <label>Tài khoản đăng nhập</label>
            <input v-model.trim="form.userName" maxlength="20" required>
          </div>

          <div class="o-nhap">
            <label>{{ dangSua ? 'Mật khẩu mới' : 'Mật khẩu' }}</label>
            <input v-model.trim="form.password" type="password" maxlength="64" :required="!dangSua">
          </div>

          <div class="o-nhap">
            <label>Vị trí</label>
            <input v-model.trim="form.viTri" maxlength="50">
          </div>

          <div class="o-nhap">
            <label>Nhóm người dùng</label>
            <select v-model="form.maNhom">
              <option value="">-- Chọn nhóm --</option>
              <option v-for="nhom in dsNhom" :key="nhom.maNhom" :value="nhom.maNhom">
                {{ nhom.maNhom }} - {{ nhom.tenNhom }}
              </option>
            </select>
          </div>

          <div class="o-nhap">
            <label>Trạng thái</label>
            <select v-model="form.trangThai">
              <option :value="true">Đang hoạt động</option>
              <option :value="false">Khóa tài khoản</option>
            </select>
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
          <strong>Chi tiết tài khoản người dùng</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <div class="noi-dung-hop-thoai">
          <div class="luoi-chi-tiet">
            <div><span>Mã người dùng</span><strong>{{ dongDangXem.maNd }}</strong></div>
            <div><span>Họ tên</span><strong>{{ dongDangXem.tenNd }}</strong></div>
            <div><span>Tài khoản</span><strong>{{ dongDangXem.userName }}</strong></div>
            <div><span>Số điện thoại</span><strong>{{ dongDangXem.sdt || '-' }}</strong></div>
            <div><span>Vị trí</span><strong>{{ dongDangXem.viTri || '-' }}</strong></div>
            <div><span>Nhóm</span><strong>{{ dongDangXem.tenNhom || '-' }}</strong></div>
            <div><span>Trạng thái</span><strong>{{ dongDangXem.trangThai ? 'Đang hoạt động' : 'Đã khóa' }}</strong></div>
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

const dsNguoiDung = ref([])
const dsNhom = ref([])
const tuKhoa = ref('')
const thongBao = ref('')
const coLoi = ref(false)
const dangSua = ref(false)
const hopThoaiDangMo = ref('')
const dongDangXem = ref(null)
const phanTrang = reactive({
  page: 1,
  pageSize: 5,
  totalItems: 0,
  totalPages: 0
})

const form = reactive(taoFormMacDinh())

onMounted(async () => {
  await Promise.all([taiNhom(), taiDuLieu()])
})

async function taiDuLieu() {
  try {
    const response = await csharpApi.getNguoiDung(tuKhoa.value, {
      page: phanTrang.page,
      pageSize: phanTrang.pageSize
    })
    ganDuLieuPhanTrang(response)
    baoThanhCong('Tải dữ liệu tài khoản người dùng thành công.')
  } catch (error) {
    baoLoi(error.message)
  }
}

async function timKiem() {
  phanTrang.page = 1
  await taiDuLieu()
}

async function taiNhom() {
  try {
    dsNhom.value = await csharpApi.getNhomNguoiDung()
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
  ganFormMacDinh()
  form.maNd = await taoMaNguoiDung()
  hopThoaiDangMo.value = 'form'
  thongBao.value = ''
}

function batDauSua(nd) {
  dangSua.value = true
  dongDangXem.value = null
  ganForm(nd)
  hopThoaiDangMo.value = 'form'
  thongBao.value = ''
}

function xemChiTiet(nd) {
  dongDangXem.value = nd
  hopThoaiDangMo.value = 'detail'
  thongBao.value = ''
}

async function luuDuLieu() {
  try {
    const payload = { ...form }

    if (dangSua.value) {
      await csharpApi.updateNguoiDung(form.maNd, payload)
      baoThanhCong('Cập nhật tài khoản người dùng thành công.')
    } else {
      await csharpApi.createNguoiDung(payload)
      baoThanhCong('Thêm tài khoản người dùng thành công.')
    }

    await taiDuLieu()
    dongHopThoai(false)
  } catch (error) {
    baoLoi(error.message)
  }
}

async function xoaDuLieu(maNd) {
  if (!confirm(`Khóa tài khoản ${maNd}?`)) return

  try {
    await csharpApi.deleteNguoiDung(maNd)
    baoThanhCong('Khóa tài khoản người dùng thành công.')
    await taiDuLieu()
  } catch (error) {
    baoLoi(error.message)
  }
}

function lamMoi() {
  tuKhoa.value = ''
  phanTrang.page = 1
  dongHopThoai()
  taiNhom()
  taiDuLieu()
}

function dongHopThoai(resetThongBao = true) {
  hopThoaiDangMo.value = ''
  dangSua.value = false
  dongDangXem.value = null
  ganFormMacDinh()
  if (resetThongBao) thongBao.value = ''
}

function taoFormMacDinh() {
  return {
    maNd: '',
    tenNd: '',
    sdt: '',
    userName: '',
    password: '',
    viTri: '',
    trangThai: true,
    maNhom: ''
  }
}

function ganFormMacDinh() {
  Object.assign(form, taoFormMacDinh())
}

function ganForm(nd) {
  form.maNd = nd.maNd || ''
  form.tenNd = nd.tenNd || ''
  form.sdt = nd.sdt || ''
  form.userName = nd.userName || ''
  form.password = ''
  form.viTri = nd.viTri || ''
  form.trangThai = Boolean(nd.trangThai)
  form.maNhom = nd.maNhom || ''
}

async function taoMaNguoiDung() {
  const dsTatCaNguoiDung = await layTatCaNguoiDung()
  const max = dsTatCaNguoiDung.reduce((current, item) => {
    const number = Number(String(item.maNd || '').replace(/\D/g, ''))
    return Number.isFinite(number) ? Math.max(current, number) : current
  }, 0)

  return `ND${String(max + 1).padStart(3, '0')}`
}

function ganDuLieuPhanTrang(response) {
  if (Array.isArray(response)) {
    dsNguoiDung.value = response
    phanTrang.totalItems = response.length
    phanTrang.totalPages = response.length ? 1 : 0
    return
  }

  dsNguoiDung.value = response.items || []
  phanTrang.page = response.page || 1
  phanTrang.pageSize = response.pageSize || phanTrang.pageSize
  phanTrang.totalItems = response.totalItems || 0
  phanTrang.totalPages = response.totalPages || 0
}

async function doiTrang(page) {
  phanTrang.page = page
  await taiDuLieu()
}

async function layTatCaNguoiDung() {
  const response = await csharpApi.getNguoiDung('')
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
