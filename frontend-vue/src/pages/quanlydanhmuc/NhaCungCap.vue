<template>
  <div>
    <div class="duong-dan">QUẢN LÝ DANH MỤC</div>

    <div class="hop-noi-dung">
      <h1 class="tieu-de-trang">THÔNG TIN NHÀ CUNG CẤP</h1>

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
          <label>Mã nhà cung cấp</label>
          <input v-model="form.maNcc" readonly maxlength="10" required>
        </div>

        <div class="o-nhap">
          <label>Tên nhà cung cấp</label>
          <input v-model="form.tenNhaCungCap" maxlength="100" required>
        </div>

        <div class="o-nhap">
          <label>Số điện thoại</label>
          <input v-model="form.soDienThoaiNcc" maxlength="11">
        </div>

        <div class="o-nhap rong">
          <label>Địa chỉ</label>
          <input v-model="form.diaChiNcc" maxlength="100">
        </div>

        <div class="khu-nut form-actions">
          <button type="submit">{{ dangSua ? 'Cập nhật' : 'Lưu' }}</button>
          <button type="button" @click="huyForm">Hủy</button>
        </div>
      </form>

      <table class="bang-du-lieu">
        <thead>
          <tr>
            <th>Mã NCC</th>
            <th>Tên nhà cung cấp</th>
            <th>Địa chỉ</th>
            <th>Số điện thoại</th>
            <th>Sửa</th>
            <th>Xóa</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="ncc in dsNhaCungCap" :key="ncc.maNcc">
            <td>{{ ncc.maNcc }}</td>
            <td>{{ ncc.tenNhaCungCap }}</td>
            <td>{{ ncc.diaChiNcc }}</td>
            <td>{{ ncc.soDienThoaiNcc }}</td>
            <td><button class="nut-bang" @click="batDauSua(ncc)">Sửa</button></td>
            <td><button class="nut-bang nut-xoa" @click="xoaDuLieu(ncc.maNcc)">Xóa</button></td>
          </tr>

          <tr v-if="!dsNhaCungCap.length">
            <td colspan="6" class="dong-rong">Không có dữ liệu nhà cung cấp.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { onMounted, reactive, ref } from 'vue'
import { phpApi } from '../../api/phpApi'

const dsNhaCungCap = ref([])
const tuKhoa = ref('')
const thongBao = ref('')
const coLoi = ref(false)
const dangSua = ref(false)

const form = reactive({
  maNcc: '',
  tenNhaCungCap: '',
  diaChiNcc: '',
  soDienThoaiNcc: ''
})

onMounted(taiDuLieu)

async function taiDuLieu() {
  try {
    dsNhaCungCap.value = await phpApi.getNhaCungCap(tuKhoa.value)
    baoThanhCong('Tải dữ liệu nhà cung cấp từ backend PHP thành công.')
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
  form.maNcc = taoMaNhaCungCap()
  thongBao.value = ''
}

function batDauSua(ncc) {
  dangSua.value = true
  ganForm(ncc)
  thongBao.value = ''
}

async function luuDuLieu() {
  try {
    const duLieu = { ...form }

    if (dangSua.value) {
      await phpApi.updateNhaCungCap(form.maNcc, duLieu)
      baoThanhCong('Cập nhật nhà cung cấp thành công.')
    } else {
      await phpApi.createNhaCungCap(duLieu)
      baoThanhCong('Thêm nhà cung cấp thành công.')
    }

    ganForm()
    dangSua.value = false
    await taiDuLieu()
  } catch (error) {
    baoLoi(error.message)
  }
}

async function xoaDuLieu(maNcc) {
  if (!confirm(`Xóa nhà cung cấp ${maNcc}?`)) return

  try {
    await phpApi.deleteNhaCungCap(maNcc)
    baoThanhCong('Xóa nhà cung cấp thành công.')
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

function ganForm(ncc = null) {
  form.maNcc = ncc?.maNcc || ''
  form.tenNhaCungCap = ncc?.tenNhaCungCap || ''
  form.diaChiNcc = ncc?.diaChiNcc || ''
  form.soDienThoaiNcc = ncc?.soDienThoaiNcc || ''
}

function taoMaNhaCungCap() {
  return taoMaTiepTheo(dsNhaCungCap.value, 'maNcc', 'NCC')
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
