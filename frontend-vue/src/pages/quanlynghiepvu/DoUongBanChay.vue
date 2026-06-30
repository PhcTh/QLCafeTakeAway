<template>
  <div>
    <div class="duong-dan">QUẢN LÝ NGHIỆP VỤ</div>

    <div class="hop-noi-dung">
      <div class="tieu-de-khu">
        <h1 class="tieu-de-trang">ĐỒ UỐNG BÁN CHẠY TRONG THÁNG</h1>
      </div>

      <div class="thanh-cong-cu">
        <div class="khu-tim-kiem">
          <input v-model.number="thang" type="number" min="1" max="12" placeholder="Tháng">
          <input v-model.number="nam" type="number" min="2000" placeholder="Năm">
          <button @click="taiBaoCao"><span class="icon-nut">⌕</span>Xem báo cáo</button>
        </div>

        <div class="khu-nut">
          <button @click="inMauBieu"><span class="icon-nut">⎙</span>In mẫu</button>
        </div>
      </div>

      <div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">{{ thongBao }}</div>

      <div class="tong-hop">
        <div>
          <strong>Tháng</strong>
          <span>{{ baoCao?.thang || thang }}/{{ baoCao?.nam || nam }}</span>
        </div>
        <div>
          <strong>Số món có phát sinh</strong>
          <span>{{ baoCao?.chiTiet?.length || 0 }}</span>
        </div>
        <div>
          <strong>Tổng số lượng</strong>
          <span>{{ baoCao?.tongSoLuongBan || tongSoLuong }}</span>
        </div>
        <div>
          <strong>Tổng doanh thu</strong>
          <span>{{ dinhDangTien(baoCao?.tongDoanhThu ?? tongDoanhThu) }}</span>
        </div>
      </div>

      <table class="bang-du-lieu">
        <thead>
          <tr>
            <th>Hạng</th>
            <th>Mã đồ uống</th>
            <th>Tên đồ uống</th>
            <th>Đơn vị tính</th>
            <th>Tổng số lượng bán</th>
            <th>Tổng doanh thu</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="(item, index) in baoCao?.chiTiet || []" :key="item.maDu">
            <td>
              <span class="rank-badge" :class="`rank-${index < 3 ? index + 1 : 'other'}`">
                {{ index + 1 }}
              </span>
            </td>
            <td>{{ item.maDu }}</td>
            <td>
              <span class="ten-san-pham">{{ item.tenDoUong }}</span>
              <span v-if="index === 0" class="hot-tag">Hot</span>
            </td>
            <td>{{ item.donViTinh || 'Ly' }}</td>
            <td>
              <div class="quantity-cell">
                <strong>{{ item.tongSoLuongBan }}</strong>
                <div class="progress-mini">
                  <span :style="{ width: `${tiLeSoLuong(item)}%` }"></span>
                </div>
              </div>
            </td>
            <td>{{ dinhDangTien(item.tongDoanhThu) }}</td>
          </tr>

          <tr v-if="!(baoCao?.chiTiet || []).length">
            <td colspan="6" class="dong-rong">Không có dữ liệu bán hàng trong tháng này.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { computed, onMounted, ref } from 'vue'
import { csharpApi } from '../../api/csharpApi'

const now = new Date()
const thang = ref(now.getMonth() + 1)
const nam = ref(now.getFullYear())
const baoCao = ref(null)
const thongBao = ref('')
const coLoi = ref(false)

const tongDoanhThu = computed(() => {
  return (baoCao.value?.chiTiet || []).reduce((sum, item) => sum + Number(item.tongDoanhThu || 0), 0)
})

const tongSoLuong = computed(() => {
  return (baoCao.value?.chiTiet || []).reduce((sum, item) => sum + Number(item.tongSoLuongBan || 0), 0)
})

onMounted(taiBaoCao)

async function taiBaoCao() {
  try {
    baoCao.value = await csharpApi.getDoUongBanChay(thang.value, nam.value)
    baoThanhCong('Tải báo cáo đồ uống bán chạy thành công.')
  } catch (error) {
    baoLoi(error.message)
  }
}

function inMauBieu() {
  const duLieuIn = baoCao.value || {
    thang: thang.value,
    nam: nam.value,
    tongSoLuongBan: 0,
    tongDoanhThu: 0,
    chiTiet: []
  }

  moCuaSoIn(taoHtmlBaoCaoDoUongBanChay(duLieuIn))
  return

  const report = baoCao.value || {
    thang: thang.value,
    nam: nam.value,
    tongSoLuongBan: 0,
    tongDoanhThu: 0,
    chiTiet: []
  }

  const rows = (report.chiTiet || []).map((item, index) => `
    <tr>
      <td>${index + 1}</td>
      <td>${escapeHtml(item.maDu)}</td>
      <td>${escapeHtml(item.tenDoUong)}</td>
      <td>${escapeHtml(item.donViTinh || 'Ly')}</td>
      <td>${item.tongSoLuongBan}</td>
      <td>${dinhDangTien(item.tongDoanhThu)}</td>
    </tr>
  `).join('')

  const html = `
    <!doctype html>
    <html lang="vi">
      <head>
        <meta charset="utf-8">
        <title>Báo cáo đồ uống bán chạy trong tháng</title>
        <style>
          body { font-family: "Times New Roman", serif; margin: 28px; color: #111; }
          .top { display: flex; justify-content: space-between; gap: 18px; font-size: 14px; }
          h1 { text-align: center; font-size: 22px; margin: 26px 0 6px; }
          .code { text-align: center; font-weight: bold; margin-bottom: 18px; }
          .meta { display: grid; grid-template-columns: 1fr 1fr; gap: 7px 24px; margin-bottom: 14px; }
          .meta div { border-bottom: 1px dotted #777; padding: 4px 0; }
          table { width: 100%; border-collapse: collapse; margin-top: 10px; }
          th, td { border: 1px solid #333; padding: 7px; font-size: 13px; }
          th { text-align: center; background: #f0f0f0; }
          .summary { margin-top: 12px; text-align: right; font-weight: bold; line-height: 1.7; }
          .sign { display: grid; grid-template-columns: 1fr 1fr; text-align: center; margin-top: 42px; gap: 48px; }
          .sign strong { display: block; margin-bottom: 68px; }
          @media print { body { margin: 14mm; } }
        </style>
      </head>
      <body>
        <div class="top">
          <div><strong>QLBH Take Away</strong><br>Quản lý bán cafe takeaway</div>
          <div><strong>Mẫu biểu:</strong> MB.10<br><strong>Khổ giấy:</strong> A4</div>
        </div>
        <h1>BÁO CÁO ĐỒ UỐNG BÁN CHẠY TRONG THÁNG</h1>
        <div class="code">MB.10</div>

        <div class="meta">
          <div><strong>Tháng báo cáo:</strong> ${report.thang || thang.value}/${report.nam || nam.value}</div>
          <div><strong>Người lập báo cáo:</strong> Nhân viên thu ngân</div>
          <div><strong>Nhiệm vụ:</strong> Thống kê đồ uống bán chạy trong tháng</div>
          <div><strong>Nơi nhận:</strong> Người quản lý</div>
        </div>

        <table>
          <thead>
            <tr>
              <th>Hạng</th>
              <th>Mã đồ uống</th>
              <th>Tên đồ uống</th>
              <th>Đơn vị tính</th>
              <th>Tổng số lượng bán</th>
              <th>Tổng doanh thu</th>
            </tr>
          </thead>
          <tbody>${rows || '<tr><td colspan="6">Không có dữ liệu</td></tr>'}</tbody>
        </table>

        <div class="summary">
          <div>Tổng số lượng bán: ${report.tongSoLuongBan ?? tongSoLuong.value}</div>
          <div>Tổng doanh thu: ${dinhDangTien(report.tongDoanhThu ?? tongDoanhThu.value)}</div>
        </div>

        <div class="sign">
          <div><strong>Người lập báo cáo</strong><span>Nhân viên thu ngân</span></div>
          <div><strong>Người quản lý</strong><span></span></div>
        </div>

        <script>window.onload = function () { window.print() }<\/script>
      </body>
    </html>
  `

  moCuaSoIn(html)
}

function taoHtmlBaoCaoDoUongBanChay(report) {
  const rows = taoDongBaoCaoBanChay(report)

  return `
    <!doctype html>
    <html lang="vi">
      <head>
        <meta charset="utf-8">
        <title>Báo cáo đồ uống bán chạy trong tháng</title>
        <style>
          @page { size: A4; margin: 0; }
          body { margin: 0; font-family: "Times New Roman", serif; color: #111; background: #fff; }
          .page { width: 210mm; min-height: 297mm; border: 2px solid #222; padding: 21mm 18mm; box-sizing: border-box; margin: 0 auto; }
          .brand { margin-left: 6mm; font-size: 15pt; line-height: 1.75; }
          .brand strong { display: block; font-size: 18pt; }
          h1 { text-align: center; font-size: 29pt; line-height: 1.25; margin: 17mm 0 7mm; }
          .info { font-size: 14pt; line-height: 1.7; margin-left: 6mm; }
          .line { display: inline-block; min-width: 72mm; border-bottom: 1px dotted #333; padding: 0 4px 1px; }
          .line.short { min-width: 45mm; }
          .section-title { width: 84%; margin: 15mm auto 4mm; display: grid; grid-template-columns: 18mm 1fr; font-size: 14pt; font-weight: bold; }
          table { width: 84%; margin: 0 auto; border-collapse: collapse; font-size: 13pt; }
          th, td { border: 1.5px solid #222; padding: 5px 6px; text-align: center; vertical-align: middle; }
          th { font-weight: bold; }
          td.text { text-align: left; }
          .notes { margin: 10mm 0 0 6mm; font-size: 14pt; line-height: 1.9; }
          .notes strong { font-weight: bold; }
          .notes .line { min-width: 52mm; }
          .notes .wide-line { display: block; width: 122mm; border-bottom: 1px dotted #333; height: 8mm; }
          .sign { display: grid; grid-template-columns: 1fr 1fr; margin: 16mm 4mm 0; font-size: 14pt; font-weight: bold; }
          .sign div:last-child { text-align: right; }
          .hint { display: block; font-weight: normal; font-style: italic; }
        </style>
      </head>
      <body>
        <div class="page">
          ${taoHeaderCongTyIn()}

          <h1>BÁO CÁO ĐỒ UỐNG BÁN CHẠY<br>TRONG THÁNG</h1>

          <div class="info">
            <div>Ngày lập báo cáo: <span class="line short">${escapeHtml(dinhDangNgayIn(ngayHienTaiIn()))}</span></div>
            <div>Người lập báo cáo: <span class="line">${escapeHtml(report.nguoiLapBaoCao || '')}</span></div>
          </div>

          <div class="section-title">
            <span>I.</span>
            <span>Thống kê tổng hợp theo sản phẩm</span>
          </div>

          <table>
            <thead>
              <tr>
                <th>STT</th>
                <th>Mã đồ uống</th>
                <th>Tên đồ uống</th>
                <th>Tổng số<br>lượng bán<br>trong tháng</th>
                <th>Doanh thu của<br>sản phẩm trong<br>tháng (VNĐ)</th>
                <th>Tỷ lệ (%)</th>
              </tr>
            </thead>
            <tbody>${rows}</tbody>
          </table>

          <div class="notes">
            <div><strong>Nhận xét xu hướng:</strong> <span class="line"></span></div>
            <div><strong>Đề xuất điều chỉnh:</strong> <span class="line"></span></div>
            <div>Ghi chú thêm:</div>
            <span class="wide-line"></span>
          </div>

          <div class="sign">
            <div>Người lập báo cáo<span class="hint">(Ký, ghi rõ họ tên)</span></div>
            <div>Quản lý<span class="hint">(Ký, ghi rõ họ tên)</span></div>
          </div>
        </div>
        <script>window.onload = function () { window.print() }<\/script>
      </body>
    </html>
  `
}

function taoDongBaoCaoBanChay(report) {
  const tongDoanhThuBaoCao = Number(report.tongDoanhThu ?? tongDoanhThu.value ?? 0)
  const rows = (report.chiTiet || []).map((item, index) => {
    const doanhThu = Number(item.tongDoanhThu || 0)
    const tyLe = tongDoanhThuBaoCao > 0 ? (doanhThu / tongDoanhThuBaoCao) * 100 : 0

    return `
      <tr>
        <td>${index + 1}</td>
        <td>${escapeHtml(item.maDu)}</td>
        <td class="text">${escapeHtml(item.tenDoUong)}</td>
        <td>${item.tongSoLuongBan || 0}</td>
        <td>${dinhDangSo(doanhThu)}</td>
        <td>${dinhDangTyLe(tyLe)}</td>
      </tr>
    `
  })

  while (rows.length < 5) {
    rows.push('<tr><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>')
  }

  return rows.join('')
}

function taoHeaderCongTyIn() {
  return `
    <div class="brand">
      <strong>THUẬN COFFEE TAKE AWAY</strong>
      <div>Địa chỉ: 334 Lê Đại Hành, Cao Lãnh, Đồng Tháp</div>
      <div>Số điện thoại: 0889753379</div>
      <div>Website: www.thuancoffeetakeaway.com.vn</div>
    </div>
  `
}

function dinhDangSo(value) {
  return Number(value || 0).toLocaleString('vi-VN')
}

function dinhDangTyLe(value) {
  return Number(value || 0).toLocaleString('vi-VN', {
    maximumFractionDigits: 2
  })
}

function dinhDangNgayIn(value) {
  if (!value) return ''
  const [year, month, day] = String(value).slice(0, 10).split('-')
  return day && month && year ? `${day}/${month}/${year}` : value
}

function ngayHienTaiIn() {
  const date = new Date()
  const year = date.getFullYear()
  const month = String(date.getMonth() + 1).padStart(2, '0')
  const day = String(date.getDate()).padStart(2, '0')
  return `${year}-${month}-${day}`
}

function dinhDangTien(value) {
  return Number(value || 0).toLocaleString('vi-VN') + ' đ'
}

function tiLeSoLuong(item) {
  const total = Number(baoCao.value?.tongSoLuongBan || tongSoLuong.value || 0)
  if (!total) return 0
  return Math.min(100, Math.round((Number(item.tongSoLuongBan || 0) / total) * 100))
}

function moCuaSoIn(html) {
  const printWindow = window.open('', '_blank')
  if (!printWindow) {
    baoLoi('Trình duyệt đang chặn cửa sổ in. Hãy cho phép popup rồi thử lại.')
    return
  }

  printWindow.document.open()
  printWindow.document.write(html)
  printWindow.document.close()
}

function escapeHtml(value) {
  return String(value ?? '')
    .replace(/&/g, '&amp;')
    .replace(/</g, '&lt;')
    .replace(/>/g, '&gt;')
    .replace(/"/g, '&quot;')
    .replace(/'/g, '&#039;')
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
