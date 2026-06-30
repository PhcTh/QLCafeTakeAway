<template>
  <main class="trang-dang-nhap">
    <section class="khung-dang-nhap">
      <div class="login-brand">
        <span class="login-logo">☕</span>
        <div>
          <h1>ĐĂNG NHẬP</h1>
          <p>QLBH Take Away</p>
        </div>
      </div>

      <div v-if="thongBaoLoi" class="thong-bao loi">{{ thongBaoLoi }}</div>

      <form class="form-login" @submit.prevent="dangNhap">
        <div class="o-nhap">
          <label>Tên đăng nhập</label>
          <input v-model.trim="tenDangNhap" type="text" placeholder="Ví dụ: thungan01" autofocus>
        </div>

        <div class="o-nhap">
          <label>Mật khẩu</label>
          <input v-model.trim="matKhau" type="password" placeholder="Ví dụ: 123456">
        </div>

        <button class="nut-login" type="submit" :disabled="dangXuLy">
          {{ dangXuLy ? 'Đang đăng nhập...' : 'Đăng nhập' }}
        </button>

        <p class="goi-y-login">Tài khoản demo: <strong>thungan01</strong> / <strong>123456</strong></p>
      </form>
    </section>
  </main>
</template>

<script setup>
import { ref } from 'vue'
import { useRoute, useRouter } from 'vue-router'
import { csharpApi } from '../api/csharpApi'
import { luuNguoiDungDangNhap } from '../auth/session'

const router = useRouter()
const route = useRoute()

const thongBaoLoi = ref('')
const tenDangNhap = ref('')
const matKhau = ref('')
const dangXuLy = ref(false)

async function dangNhap() {
  thongBaoLoi.value = ''

  if (!tenDangNhap.value) {
    thongBaoLoi.value = 'Tên đăng nhập không được để trống.'
    return
  }

  if (!matKhau.value) {
    thongBaoLoi.value = 'Mật khẩu không được để trống.'
    return
  }

  try {
    dangXuLy.value = true
    const nguoiDung = await csharpApi.login({
      username: tenDangNhap.value,
      password: matKhau.value
    })

    luuNguoiDungDangNhap(nguoiDung)
    await router.push(route.query.redirect || '/')
  } catch (error) {
    thongBaoLoi.value = error.message
  } finally {
    dangXuLy.value = false
  }
}
</script>
