<template>
  <div>
    <div class="duong-dan">QUẢN LÝ DANH MỤC</div>

    <div class="hop-noi-dung">
      <h1 class="tieu-de-trang">THÔNG TIN KHÁCH HÀNG</h1>

      <div class="thanh-cong-cu">
        <div class="khu-tim-kiem">
          <input v-model="tuKhoa" type="text" placeholder="Nhập mã, tên hoặc số điện thoại">
          <button @click="taiDuLieu">Tìm kiếm</button>
        </div>

        <div class="khu-nut">
          <button @click="batDauThem">+ Thêm mới</button>
          <button @click="lamMoi">Làm mới</button>
        </div>
      </div>

      <div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">{{ thongBao }}</div>

      <form class="form-danh-muc" @submit.prevent="luuDuLieu">
        <div class="o-nhap">
          <label>Mã khách hàng</label>
          <input v-model="form.maKh" readonly maxlength="10" required>
        </div>

        <div class="o-nhap">
          <label>Tên khách hàng</label>
          <input v-model="form.tenKhachHang" maxlength="50" required>
        </div>

        <div class="o-nhap">
          <label>Số điện thoại</label>
          <input v-model="form.soDienThoai" maxlength="11">
        </div>

        <div class="o-nhap">
          <label>Giới tính</label>
          <select v-model="form.gioiTinh">
            <option value="">-- Chọn --</option>
            <option value="Nam">Nam</option>
            <option value="Nữ">Nữ</option>
          </select>
        </div>

        <div class="o-nhap rong">
          <label>Địa chỉ</label>
          <input v-model="form.diaChi" maxlength="100">
        </div>

        <div class="khu-nut form-actions">
          <button type="submit">{{ dangSua ? 'Cập nhật' : 'Lưu' }}</button>
          <button type="button" @click="huyForm">Hủy</button>
        </div>
      </form>

      <table class="bang-du-lieu">
        <thead>
          <tr>
            <th>Mã khách hàng</th>
            <th>Tên khách hàng</th>
            <th>Số điện thoại</th>
            <th>Địa chỉ</th>
            <th>Giới tính</th>
            <th>Sửa</th>
            <th>Xóa</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="kh in dsKhachHang" :key="kh.maKh">
            <td>{{ kh.maKh }}</td>
            <td>{{ kh.tenKhachHang }}</td>
            <td>{{ kh.soDienThoai }}</td>
            <td>{{ kh.diaChi }}</td>
            <td>{{ kh.gioiTinh }}</td>
            <td><button class="nut-bang" @click="batDauSua(kh)">Sửa</button></td>
            <td><button class="nut-bang nut-xoa" @click="xoaDuLieu(kh.maKh)">Xóa</button></td>
          </tr>

          <tr v-if="!dsKhachHang.length">
            <td colspan="7" class="dong-rong">Không có dữ liệu khách hàng.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { onMounted, reactive, ref } from 'vue'
import { phpApi } from '../../api/phpApi'

const dsKhachHang = ref([])
const tuKhoa = ref('')
const thongBao = ref('')
const coLoi = ref(false)
const dangSua = ref(false)

const form = reactive({
  maKh: '',
  tenKhachHang: '',
  soDienThoai: '',
  diaChi: '',
  gioiTinh: ''
})

onMounted(taiDuLieu)

async function taiDuLieu() {
  try {
    dsKhachHang.value = await phpApi.getKhachHang(tuKhoa.value)
    baoThanhCong('Tải dữ liệu khách hàng từ backend PHP thành công.')
  } catch (error) {
    baoLoi(error.message)
  }
}

async function batDauThem() {
  dangSua.value = false
  if (tuKhoa.value) {
    tuKhoa.value = ''
    await taiDuLieu()
  }
  ganForm()
  form.maKh = taoMaKhachHang()
  thongBao.value = ''
}

function batDauSua(kh) {
  dangSua.value = true
  ganForm(kh)
  thongBao.value = ''
}

async function luuDuLieu() {
  try {
    const duLieu = { ...form }

    if (dangSua.value) {
      await phpApi.updateKhachHang(form.maKh, duLieu)
      baoThanhCong('Cập nhật khách hàng thành công.')
    } else {
      await phpApi.createKhachHang(duLieu)
      baoThanhCong('Thêm khách hàng thành công.')
    }

    ganForm()
    dangSua.value = false
    await taiDuLieu()
  } catch (error) {
    baoLoi(error.message)
  }
}

async function xoaDuLieu(maKh) {
  if (!confirm(`Xóa khách hàng ${maKh}?`)) return

  try {
    await phpApi.deleteKhachHang(maKh)
    baoThanhCong('Xóa khách hàng thành công.')
    await taiDuLieu()
  } catch (error) {
    baoLoi(error.message)
  }
}

function lamMoi() {
  tuKhoa.value = ''
  ganForm()
  dangSua.value = false
  taiDuLieu()
}

function huyForm() {
  ganForm()
  dangSua.value = false
}

function ganForm(kh = null) {
  form.maKh = kh?.maKh || ''
  form.tenKhachHang = kh?.tenKhachHang || ''
  form.soDienThoai = kh?.soDienThoai || ''
  form.diaChi = kh?.diaChi || ''
  form.gioiTinh = kh?.gioiTinh || ''
}

function taoMaKhachHang() {
  return taoMaTiepTheo(dsKhachHang.value, 'maKh', 'KH')
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
