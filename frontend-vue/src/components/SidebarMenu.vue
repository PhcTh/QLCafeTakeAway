<template>
  <aside class="thanh-ben">
    <div class="logo-he-thong">
      <span class="logo-icon">☕</span>
      <span class="ten-he-thong">
        QLBH Take Away
        <small>Quản lý bán hàng</small>
      </span>
    </div>

    <div v-if="nguoiDung" class="nguoi-dung-sidebar">
      <strong>{{ nguoiDung.tenNd }}</strong>
      <span>{{ nguoiDung.viTri || nguoiDung.userName }}</span>
    </div>

    <nav class="sidebar-nav">
      <router-link to="/" class="muc-menu">
        <span class="menu-icon">⌂</span>
        <span>Trang chủ</span>
      </router-link>

      <div class="nhom-menu">
        <button class="tieu-de-nhom nut-nhom" type="button" @click="daoTrangThaiNhom('danhMuc')">
          <span class="chevron">{{ nhomDangMo.danhMuc ? '▼' : '▶' }}</span>
          <span>Quản lý danh mục</span>
        </button>

        <div v-show="nhomDangMo.danhMuc" class="danh-sach-con">
          <router-link v-if="coQuyen('Q08')" to="/do-uong" class="muc-con">Đồ uống</router-link>
          <router-link v-if="coQuyen('Q08')" to="/loai-do-uong" class="muc-con">Loại đồ uống</router-link>
          <router-link v-if="coQuyen('Q08')" to="/nguyen-lieu" class="muc-con">Nguyên liệu</router-link>
          <router-link to="/khach-hang" class="muc-con">Khách hàng <span class="tag-php">PHP</span></router-link>
          <router-link to="/nha-cung-cap" class="muc-con">Nhà cung cấp <span class="tag-php">PHP</span></router-link>
        </div>
      </div>

      <div class="nhom-menu">
        <button class="tieu-de-nhom nut-nhom" type="button" @click="daoTrangThaiNhom('nghiepVu')">
          <span class="chevron">{{ nhomDangMo.nghiepVu ? '▼' : '▶' }}</span>
          <span>Quản lý nghiệp vụ</span>
        </button>

        <div v-show="nhomDangMo.nghiepVu" class="danh-sach-con">
          <router-link v-if="coQuyen('Q04')" to="/don-nguyen-lieu-mua" class="muc-con">Lập đơn nguyên liệu mua</router-link>
          <router-link v-if="coQuyen('Q05')" to="/bao-cao-doanh-thu-ngay" class="muc-con">Báo cáo doanh thu ngày</router-link>
          <router-link v-if="coQuyen('Q07')" to="/do-uong-ban-chay" class="muc-con">Đồ uống bán chạy</router-link>
        </div>
      </div>

      <div class="nhom-menu">
        <button class="tieu-de-nhom nut-nhom" type="button" @click="daoTrangThaiNhom('heThong')">
          <span class="chevron">{{ nhomDangMo.heThong ? '▼' : '▶' }}</span>
          <span>Quản trị hệ thống</span>
        </button>

        <div v-show="nhomDangMo.heThong" class="danh-sach-con">
          <router-link v-if="thuocNhom('N04')" to="/quan-ly-tai-khoan" class="muc-con">Quản lý tài khoản người dùng</router-link>
        </div>
      </div>
    </nav>

    <div class="sidebar-footer">
      <a href="#" class="muc-menu dang-xuat" @click.prevent="xuLyDangXuat">
        <span class="menu-icon">⎋</span>
        <span>Đăng xuất</span>
      </a>
    </div>
  </aside>
</template>

<script setup>
import { reactive } from 'vue'
import { useRouter } from 'vue-router'
import { coQuyen, dangXuat, layNguoiDungDangNhap, thuocNhom } from '../auth/session'

const router = useRouter()
const nguoiDung = layNguoiDungDangNhap()

const nhomDangMo = reactive({
  danhMuc: true,
  nghiepVu: true,
  heThong: false
})

function daoTrangThaiNhom(tenNhom) {
  nhomDangMo[tenNhom] = !nhomDangMo[tenNhom]
}

function xuLyDangXuat() {
  dangXuat()
  router.push('/dang-nhap')
}
</script>
