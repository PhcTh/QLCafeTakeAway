<template>
  <div>
    <div class="duong-dan">QUẢN LÝ NGHIỆP VỤ</div>

    <div class="hop-noi-dung">
      <div class="tieu-de-khu">
        <h1 class="tieu-de-trang">BÁO CÁO DOANH THU NGÀY</h1>
      </div>

      <div class="thanh-cong-cu">
        <div class="khu-tim-kiem">
          <input v-model="ngay" type="date">
          <button @click="taiBaoCao"><span class="icon-nut">⌕</span>Xem báo cáo</button>
        </div>

        <div class="khu-nut">
          <button @click="inMauBieu"><span class="icon-nut">⎙</span>In mẫu</button>
        </div>
      </div>

      <div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">{{ thongBao }}</div>

      <div class="tong-hop">
        <div>
          <strong>Ngày báo cáo</strong>
          <span>{{ dinhDangNgay(baoCao?.ngay || ngay) }}</span>
        </div>
        <div>
          <strong>Tổng hóa đơn</strong>
          <span>{{ baoCao?.tongSoHoaDon || 0 }}</span>
        </div>
        <div>
          <strong>Tổng số lượng</strong>
          <span>{{ baoCao?.tongSoLuongDoUong || 0 }}</span>
        </div>
        <div>
          <strong>Tổng doanh thu</strong>
          <span>{{ dinhDangTien(baoCao?.tongDoanhThu) }}</span>
        </div>
      </div>

      <table class="bang-du-lieu">
        <thead>
          <tr>
            <th>Số hóa đơn</th>
            <th>Giờ thanh toán</th>
            <th>Hình thức</th>
            <th>Mã đồ uống</th>
            <th>Tên đồ uống</th>
            <th>Đơn vị tính</th>
            <th>Size</th>
            <th>Số lượng</th>
            <th>Đơn giá</th>
            <th>Thành tiền</th>
            <th>Ghi chú</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="item in baoCao?.chiTiet || []" :key="`${item.soHoaDon}-${item.maDu}-${item.size}`">
            <td>{{ item.soHoaDon }}</td>
            <td>{{ item.thoiGianThanhToan }}</td>
            <td>
              <span class="payment-badge" :class="paymentBadgeClass(item.hinhThucThanhToan)">
                {{ item.hinhThucThanhToan }}
              </span>
            </td>
            <td>{{ item.maDu }}</td>
            <td>{{ item.tenDoUong }}</td>
            <td>{{ item.donViTinh || 'Ly' }}</td>
            <td>{{ item.size }}</td>
            <td>{{ item.soLuongBan }}</td>
            <td>{{ dinhDangTien(item.donGia) }}</td>
            <td>{{ dinhDangTien(item.thanhTien) }}</td>
            <td>{{ item.ghiChu || '' }}</td>
          </tr>

          <tr v-if="!(baoCao?.chiTiet || []).length">
            <td colspan="11" class="dong-rong">Không có doanh thu trong ngày này.</td>
          </tr>
        </tbody>
      </table>
    </div>
  </div>
</template>

<script setup>
import { onMounted, ref } from 'vue'
import { csharpApi } from '../../api/csharpApi'

const ngay = ref(ngayHienTai())
const baoCao = ref(null)
const thongBao = ref('')
const coLoi = ref(false)

onMounted(taiBaoCao)

async function taiBaoCao() {
  try {
    baoCao.value = await csharpApi.getDoanhThuNgay(ngay.value)
    baoThanhCong('Tải báo cáo doanh thu ngày thành công.')
  } catch (error) {
    baoLoi(error.message)
  }
}

function inMauBieu() {
  const duLieuIn = baoCao.value || {
    ngay: ngay.value,
    nguoiLapBaoCao: 'Nhân viên thu ngân',
    tongSoHoaDon: 0,
    tongSoLuongDoUong: 0,
    tongDoanhThu: 0,
    chiTiet: []
  }

  moCuaSoIn(taoHtmlBaoCaoDoanhThuNgay(duLieuIn))
  return

  const report = baoCao.value || {
    ngay: ngay.value,
    nguoiLapBaoCao: 'Nhân viên thu ngân',
    tongSoHoaDon: 0,
    tongSoLuongDoUong: 0,
    tongDoanhThu: 0,
    chiTiet: []
  }

  const rows = (report.chiTiet || []).map((item, index) => `
    <tr>
      <td>${index + 1}</td>
      <td>${escapeHtml(item.soHoaDon)}</td>
      <td>${escapeHtml(item.thoiGianThanhToan)}</td>
      <td>${escapeHtml(item.hinhThucThanhToan)}</td>
      <td>${escapeHtml(item.maDu)}</td>
      <td>${escapeHtml(item.tenDoUong)}</td>
      <td>${escapeHtml(item.donViTinh || 'Ly')}</td>
      <td>${item.soLuongBan}</td>
      <td>${dinhDangTien(item.donGia)}</td>
      <td>${dinhDangTien(item.thanhTien)}</td>
      <td>${escapeHtml(item.ghiChu || '')}</td>
    </tr>
  `).join('')

  const html = taoTrangIn({
    title: 'BÁO CÁO DOANH THU THEO NGÀY',
    code: 'MB.08',
    meta: `
      <div><strong>Ngày báo cáo:</strong> ${escapeHtml(dinhDangNgay(report.ngay || ngay.value))}</div>
      <div><strong>Người lập báo cáo:</strong> ${escapeHtml(report.nguoiLapBaoCao || 'Nhân viên thu ngân')}</div>
      <div><strong>Nhiệm vụ:</strong> Thống kê doanh thu trong ngày của quán cafe</div>
      <div><strong>Nơi nhận:</strong> Người quản lý</div>
    `,
    table: `
      <table>
        <thead>
          <tr>
            <th>STT</th>
            <th>Mã hóa đơn</th>
            <th>Thời gian thanh toán</th>
            <th>Hình thức thanh toán</th>
            <th>Mã đồ uống</th>
            <th>Tên đồ uống</th>
            <th>Đơn vị tính</th>
            <th>Số lượng bán</th>
            <th>Đơn giá</th>
            <th>Thành tiền</th>
            <th>Ghi chú</th>
          </tr>
        </thead>
        <tbody>${rows || '<tr><td colspan="11">Không có dữ liệu</td></tr>'}</tbody>
      </table>
    `,
    summary: `
      <div><strong>Tổng số hóa đơn:</strong> ${report.tongSoHoaDon || 0}</div>
      <div><strong>Tổng số lượng đồ uống bán ra:</strong> ${report.tongSoLuongDoUong || 0}</div>
      <div><strong>Tổng doanh thu trong ngày:</strong> ${dinhDangTien(report.tongDoanhThu)}</div>
    `,
    signer: report.nguoiLapBaoCao || 'Nhân viên thu ngân'
  })

  moCuaSoIn(html)
}

function taoHtmlBaoCaoDoanhThuNgay(report) {
  const hoaDon = layHoaDonDoanhThu(report)
  const rows = hoaDon.map((item, index) => `
    <tr>
      <td>${index + 1}</td>
      <td>${escapeHtml(item.soHoaDon)}</td>
      <td>${escapeHtml(item.thoiGianThanhToan)}</td>
      <td>${escapeHtml(item.hinhThucThanhToan)}</td>
      <td>${dinhDangSo(item.giaTriHoaDon)}</td>
      <td>${escapeHtml(item.ghiChu || '')}</td>
    </tr>
  `)

  while (rows.length < 2) {
    rows.push('<tr><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>')
  }

  rows.push(`
    <tr class="total-row">
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td><strong>Tổng doanh thu<br>trong ngày:</strong><br>${dinhDangSo(report.tongDoanhThu)}</td>
      <td></td>
    </tr>
  `)

  return `
    <!doctype html>
    <html lang="vi">
      <head>
        <meta charset="utf-8">
        <title>Báo cáo doanh thu theo ngày</title>
        <style>
          @page { size: A4; margin: 0; }
          body { margin: 0; font-family: "Times New Roman", serif; color: #111; background: #fff; }
          .page { width: 210mm; min-height: 297mm; border: 2px solid #222; padding: 21mm 18mm; box-sizing: border-box; margin: 0 auto; }
          .brand { margin-left: 6mm; font-size: 15pt; line-height: 1.75; }
          .brand strong { display: block; font-size: 18pt; }
          h1 { text-align: center; font-size: 28pt; margin: 13mm 0 7mm; }
          .info { font-size: 14pt; line-height: 1.55; margin-left: 6mm; }
          .line { display: inline-block; min-width: 72mm; border-bottom: 1px dotted #333; padding: 0 4px 1px; }
          .line.short { min-width: 45mm; }
          table { width: 86%; margin: 14mm auto 0; border-collapse: collapse; font-size: 13pt; }
          th, td { border: 1.5px solid #222; padding: 7px 6px; text-align: center; vertical-align: middle; }
          th { font-weight: bold; }
          .total-row td { height: 17mm; }
          .sign { display: grid; grid-template-columns: 1fr 1fr; margin: 34mm 4mm 0; font-size: 14pt; font-weight: bold; }
          .sign div:last-child { text-align: right; }
          .hint { display: block; font-weight: normal; font-style: italic; }
        </style>
      </head>
      <body>
        <div class="page">
          ${taoHeaderCongTyIn()}

          <h1>BÁO CÁO DOANH THU THEO NGÀY</h1>

          <div class="info">
            <div>Ngày báo cáo: <span class="line short">${escapeHtml(dinhDangNgayIn(report.ngay || ngay.value))}</span></div>
            <div>Người lập báo cáo: <span class="line">${escapeHtml(report.nguoiLapBaoCao || '')}</span></div>
          </div>

          <table>
            <thead>
              <tr>
                <th>STT</th>
                <th>Mã hóa<br>đơn</th>
                <th>Thời gian<br>thanh toán</th>
                <th>Hình thức<br>thanh toán</th>
                <th>Giá trị hóa đơn</th>
                <th>Ghi chú</th>
              </tr>
            </thead>
            <tbody>${rows.join('')}</tbody>
          </table>

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

function layHoaDonDoanhThu(report) {
  const map = new Map()

  for (const item of report.chiTiet || []) {
    const key = item.soHoaDon || `hoa-don-${map.size + 1}`
    const current = map.get(key) || {
      soHoaDon: item.soHoaDon || '',
      thoiGianThanhToan: item.thoiGianThanhToan || '',
      hinhThucThanhToan: item.hinhThucThanhToan || '',
      giaTriHoaDon: 0,
      ghiChu: item.ghiChu || ''
    }

    current.giaTriHoaDon += Number(item.thanhTien || 0)
    if (!current.ghiChu && item.ghiChu) current.ghiChu = item.ghiChu
    map.set(key, current)
  }

  return Array.from(map.values())
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

function dinhDangNgayIn(value) {
  if (!value) return ''
  const [year, month, day] = String(value).slice(0, 10).split('-')
  return day && month && year ? `${day}/${month}/${year}` : value
}

function ngayHienTai() {
  const now = new Date()
  const year = now.getFullYear()
  const month = String(now.getMonth() + 1).padStart(2, '0')
  const day = String(now.getDate()).padStart(2, '0')
  return `${year}-${month}-${day}`
}

function dinhDangTien(value) {
  return Number(value || 0).toLocaleString('vi-VN') + ' đ'
}

function dinhDangNgay(value) {
  return value || ''
}

function paymentBadgeClass(value) {
  const text = String(value || '').toLowerCase()
  if (text.includes('tiền') || text.includes('tien') || text.includes('cash')) return 'payment-cash'
  if (text.includes('thẻ') || text.includes('the') || text.includes('card')) return 'payment-card'
  if (text.includes('chuyển') || text.includes('chuyen') || text.includes('qr')) return 'payment-transfer'
  return 'payment-other'
}

function taoTrangIn({ title, code, meta, table, summary, signer }) {
  return `
    <!doctype html>
    <html lang="vi">
      <head>
        <meta charset="utf-8">
        <title>${title}</title>
        <style>
          body { font-family: "Times New Roman", serif; margin: 28px; color: #111; }
          .top { display: flex; justify-content: space-between; gap: 18px; font-size: 14px; }
          h1 { text-align: center; font-size: 22px; margin: 26px 0 6px; }
          .code { text-align: center; font-weight: bold; margin-bottom: 18px; }
          .meta { display: grid; grid-template-columns: 1fr 1fr; gap: 7px 24px; margin-bottom: 14px; }
          .meta div { border-bottom: 1px dotted #777; padding: 4px 0; }
          table { width: 100%; border-collapse: collapse; margin-top: 10px; }
          th, td { border: 1px solid #333; padding: 6px; font-size: 12px; }
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
          <div><strong>Mẫu biểu:</strong> ${code}<br><strong>Khổ giấy:</strong> A4</div>
        </div>
        <h1>${title}</h1>
        <div class="code">${code}</div>
        <div class="meta">${meta}</div>
        ${table}
        <div class="summary">${summary}</div>
        <div class="sign">
          <div><strong>Người lập báo cáo</strong><span>${escapeHtml(signer)}</span></div>
          <div><strong>Người quản lý</strong><span></span></div>
        </div>
        <script>window.onload = function () { window.print() }<\/script>
      </body>
    </html>
  `
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
