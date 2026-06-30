import { createRouter, createWebHistory } from 'vue-router'

import DangNhap from '../pages/DangNhap.vue'
import TrangChu from '../pages/TrangChu.vue'
import DoUong from '../pages/quanlydanhmuc/DoUong.vue'
import KhachHang from '../pages/quanlydanhmuc/KhachHang.vue'
import LoaiDoUong from '../pages/quanlydanhmuc/LoaiDoUong.vue'
import NguyenLieu from '../pages/quanlydanhmuc/NguyenLieu.vue'
import NhaCungCap from '../pages/quanlydanhmuc/NhaCungCap.vue'
import DonNguyenLieuMua from '../pages/quanlynghiepvu/DonNguyenLieuMua.vue'
import DoanhThuNgay from '../pages/quanlynghiepvu/DoanhThuNgay.vue'
import DoUongBanChay from '../pages/quanlynghiepvu/DoUongBanChay.vue'
import QuanLyTaiKhoan from '../pages/quantrihethong/QuanLyTaiKhoan.vue'
import { daDangNhap } from '../auth/session'

const routes = [
  {
    path: '/dang-nhap',
    component: DangNhap,
    meta: { public: true }
  },
  {
    path: '/',
    component: TrangChu
  },
  {
    path: '/do-uong',
    component: DoUong
  },
  {
    path: '/loai-do-uong',
    component: LoaiDoUong
  },
  {
    path: '/nguyen-lieu',
    component: NguyenLieu
  },
  {
    path: '/khach-hang',
    component: KhachHang
  },
  {
    path: '/nha-cung-cap',
    component: NhaCungCap
  },
  {
    path: '/don-nguyen-lieu-mua',
    component: DonNguyenLieuMua
  },
  {
    path: '/bao-cao-doanh-thu-ngay',
    component: DoanhThuNgay
  },
  {
    path: '/do-uong-ban-chay',
    component: DoUongBanChay
  },
  {
    path: '/quan-ly-tai-khoan',
    component: QuanLyTaiKhoan
  }
]

const router = createRouter({
  history: createWebHistory(),
  routes: routes
})

router.beforeEach((to) => {
  const loggedIn = daDangNhap()

  if (!to.meta.public && !loggedIn) {
    return {
      path: '/dang-nhap',
      query: { redirect: to.fullPath }
    }
  }

  if (to.path === '/dang-nhap' && loggedIn) {
    return '/'
  }

  return true
})

export default router
