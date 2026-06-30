<template>
  <div v-if="laTrangDangNhap">
    <router-view />
  </div>

  <div v-else class="khung-trang">
    <SidebarMenu />

    <div class="noi-dung-chinh">
      <router-view />
    </div>
  </div>
</template>

<script setup>
import { computed } from 'vue'
import { useRoute } from 'vue-router'
import SidebarMenu from './components/SidebarMenu.vue'

const route = useRoute()
const laTrangDangNhap = computed(() => route.path === '/dang-nhap')
</script>
