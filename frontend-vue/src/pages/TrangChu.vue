<template>
  <div>
    <div class="duong-dan">Trang chủ</div>

    <div class="hop-noi-dung trang-chu-card">
      <section class="hero-section">
        <div class="hero-icon">☕</div>
        <h1 class="tieu-de-trang">QUẢN LÝ BÁN HÀNG TAKE AWAY</h1>
        <p>Hệ thống quản lý đồ uống, nguyên liệu, đơn mua và báo cáo doanh thu của quán.</p>
      </section>

      <div class="quick-grid">
        <router-link to="/do-uong" class="quick-card">
          <span class="quick-icon">☕</span>
          <strong>Đồ uống</strong>
          <span>Quản lý menu và giá bán</span>
        </router-link>

        <router-link to="/loai-do-uong" class="quick-card">
          <span class="quick-icon">☰</span>
          <strong>Loại đồ uống</strong>
          <span>Phân nhóm sản phẩm</span>
        </router-link>

        <router-link to="/nguyen-lieu" class="quick-card">
          <span class="quick-icon">◈</span>
          <strong>Nguyên liệu</strong>
          <span>Danh mục nguyên liệu pha chế</span>
        </router-link>

        <router-link to="/don-nguyen-lieu-mua" class="quick-card quick-card-primary">
          <span class="quick-icon">▣</span>
          <strong>Lập đơn mua</strong>
          <span>Tạo đề nghị mua nguyên liệu</span>
        </router-link>

        <router-link to="/bao-cao-doanh-thu-ngay" class="quick-card">
          <span class="quick-icon">▤</span>
          <strong>Doanh thu ngày</strong>
          <span>Xem và in mẫu báo cáo</span>
        </router-link>

        <router-link to="/do-uong-ban-chay" class="quick-card">
          <span class="quick-icon">★</span>
          <strong>Đồ uống bán chạy</strong>
          <span>Top sản phẩm trong tháng</span>
        </router-link>
      </div>

      <div class="home-footer">
        <span class="api-tag api-cs">C# Backend</span>
        <span class="api-tag api-php">PHP Backend</span>
        <span>Vue 3 + Composition API, kết nối SQL Server.</span>
      </div>
    </div>
  </div>
</template>
