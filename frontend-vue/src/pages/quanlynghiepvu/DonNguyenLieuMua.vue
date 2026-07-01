<template>
  <div>
    <div class="duong-dan">QUẢN LÝ NGHIỆP VỤ</div>

    <div class="hop-noi-dung">
      <div class="tieu-de-khu">
        <h1 class="tieu-de-trang">LẬP ĐƠN NGUYÊN LIỆU MUA</h1>
      </div>

      <div v-if="canhBaoPhp" class="thong-bao loi">{{ canhBaoPhp }}</div>
      <div v-if="thongBao" class="thong-bao" :class="{ loi: coLoi }">{{ thongBao }}</div>

      <div class="thanh-cong-cu">
        <div class="khu-tim-kiem">
          <input v-model="tuKhoa" type="text" placeholder="Nhập số đơn, nhà cung cấp hoặc người lập">
          <button @click="timKiem"><span class="icon-nut">⌕</span>Tìm kiếm</button>
        </div>

        <div class="khu-nut">
          <button @click="batDauThem"><span class="icon-nut">+</span>Lập đơn</button>
          <button @click="lamMoi"><span class="icon-nut">↻</span>Làm mới</button>
        </div>
      </div>

      <table class="bang-du-lieu">
        <thead>
          <tr>
            <th>Số đơn</th>
            <th>Ngày lập</th>
            <th>Nhà cung cấp</th>
            <th>Người lập</th>
            <th>Trạng thái</th>
            <th>Tổng dự kiến</th>
            <th class="cot-thao-tac cot-thao-tac-rong">Thao tác</th>
          </tr>
        </thead>

        <tbody>
          <tr v-for="don in dsDon" :key="don.soDnlm">
            <td>{{ don.soDnlm }}</td>
            <td>{{ dinhDangNgay(don.ngayLapDon) }}</td>
            <td>{{ don.nhaCungCap }}</td>
            <td>{{ don.nguoiLapDon }}</td>
            <td>{{ hienThiTrangThai(don.trangThai) }}</td>
            <td>{{ dinhDangTien(tinhTongDon(don)) }}</td>
            <td>
              <div class="nhom-thao-tac">
                <button class="nut-bang nut-xem" @click="xemChiTiet(don)"><span class="icon-nut">i</span>Xem</button>
                <button class="nut-bang" :disabled="!coTheSuaDon(don)" @click="batDauSua(don)"><span class="icon-nut">✎</span>Sửa</button>
                <button class="nut-bang" @click="xuatMauBieu(don)"><span class="icon-nut">⎙</span>In</button>
                <button class="nut-bang nut-xoa" :disabled="!coTheSuaDon(don)" @click="xoaDon(don.soDnlm)"><span class="icon-nut">×</span>Xóa</button>
              </div>
            </td>
          </tr>

          <tr v-if="!dsDon.length">
            <td colspan="7" class="dong-rong">Không có đơn nguyên liệu mua.</td>
          </tr>
        </tbody>
      </table>

      <div v-if="phanTrang.totalPages > 1" class="khu-nut form-actions">
        <button :disabled="phanTrang.page <= 1" @click="doiTrang(phanTrang.page - 1)">Trước</button>
        <span>Trang {{ phanTrang.page }} / {{ phanTrang.totalPages }}</span>
        <button :disabled="phanTrang.page >= phanTrang.totalPages" @click="doiTrang(phanTrang.page + 1)">Sau</button>
      </div>
    </div>

    <div v-if="hopThoaiDangMo === 'form'" class="lop-phu" @click.self="dongHopThoai">
      <section class="hop-thoai hop-thoai-rong">
        <div class="dau-hop-thoai">
          <strong>{{ dangSua ? 'Cập nhật đơn nguyên liệu mua' : 'Lập đơn nguyên liệu mua' }}</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <form class="form-danh-muc form-rong form-tach-rieng" @submit.prevent="luuDuLieu">
          <div class="o-nhap">
            <label>Số đơn</label>
            <input v-model.trim="form.soDnlm" readonly maxlength="10" required>
          </div>

          <div class="o-nhap">
            <label>Ngày lập</label>
            <input v-model="form.ngayLapDon" type="date" required>
          </div>

          <div class="o-nhap">
            <label>Chọn NCC từ PHP</label>
            <select v-model="maNccDangChon" @change="chonNhaCungCap">
              <option value="">-- Chọn nhà cung cấp --</option>
              <option v-for="ncc in dsNhaCungCap" :key="ncc.maNcc" :value="ncc.maNcc">
                {{ ncc.maNcc }} - {{ ncc.tenNhaCungCap }}
              </option>
            </select>
          </div>

          <div class="o-nhap">
            <label>Nhà cung cấp</label>
            <input v-model.trim="form.nhaCungCap" maxlength="100" required>
          </div>

          <div class="o-nhap">
            <label>Địa chỉ</label>
            <input v-model.trim="form.diaChi" maxlength="100">
          </div>

          <div class="o-nhap">
            <label>Số điện thoại</label>
            <input v-model.trim="form.soDienThoai" maxlength="11">
          </div>

          <div class="o-nhap">
            <label>Bộ phận</label>
            <input v-model.trim="form.boPhan" readonly maxlength="50" required>
          </div>

          <div class="o-nhap">
            <label>Người lập đơn</label>
            <input v-model.trim="form.nguoiLapDon" readonly maxlength="50" required>
          </div>

          <div class="o-nhap">
            <label>Quản lý</label>
            <input v-model.trim="form.quanLy" readonly maxlength="50">
          </div>

          <div class="o-nhap">
            <label>Nhân viên hệ thống</label>
            <input v-model.trim="form.tenNhanVien" readonly maxlength="50" required>
          </div>

          <div class="o-nhap">
            <label>Mã nhân viên</label>
            <input v-model.trim="form.maNd" readonly maxlength="10" required>
          </div>

          <div class="o-nhap rong">
            <label>Ghi chú</label>
            <input v-model.trim="form.ghiChu" maxlength="200">
          </div>

          <div class="khu-chi-tiet">
            <div class="tieu-de-phu">
              <strong>Chi tiết nguyên liệu</strong>
              <button type="button" class="nut-phu" @click="themDongChiTiet"><span class="icon-nut">+</span>Dòng nguyên liệu</button>
            </div>

            <table class="bang-du-lieu bang-nho">
              <thead>
                <tr>
                  <th>Nguyên liệu</th>
                  <th>Đơn vị tính</th>
                  <th>Số lượng đề nghị</th>
                  <th>Đơn giá dự kiến</th>
                  <th>Thành tiền</th>
                  <th class="cot-thao-tac">Thao tác</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="(ct, index) in form.chiTiet" :key="index">
                  <td>
                    <select v-model="ct.maNl" required @change="chonNguyenLieuChiTiet(ct)">
                      <option value="">-- Chọn nguyên liệu --</option>
                      <option v-for="nl in dsNguyenLieu" :key="nl.maNl" :value="nl.maNl">
                        {{ nl.maNl }} - {{ nl.tenNguyenLieu }}
                      </option>
                    </select>
                  </td>
                  <td><input v-model="ct.donViTinh" readonly></td>
                  <td><input v-model.number="ct.soLuongDeNghi" type="number" min="1" required></td>
                  <td><input v-model.number="ct.donGiaDuKien" type="number" min="0" required></td>
                  <td>{{ dinhDangTien(tinhThanhTienDong(ct)) }}</td>
                  <td>
                    <button type="button" class="nut-bang nut-xoa" @click="xoaDongChiTiet(index)">
                      <span class="icon-nut">×</span>Xóa
                    </button>
                  </td>
                </tr>
              </tbody>
            </table>

            <div class="tong-don">Tổng tiền dự kiến: <strong>{{ dinhDangTien(tinhTongForm()) }}</strong></div>
          </div>

          <div class="khu-nut form-actions">
            <button type="submit"><span class="icon-nut">✓</span>{{ dangSua ? 'Cập nhật' : 'Lưu đơn' }}</button>
            <button type="button" @click="dongHopThoai"><span class="icon-nut">×</span>Hủy</button>
          </div>
        </form>
      </section>
    </div>

    <div v-if="hopThoaiDangMo === 'detail' && donDangXem" class="lop-phu" @click.self="dongHopThoai">
      <section class="hop-thoai hop-thoai-rong">
        <div class="dau-hop-thoai">
          <strong>Chi tiết đơn {{ donDangXem.soDnlm }}</strong>
          <button type="button" class="nut-dong" @click="dongHopThoai">×</button>
        </div>

        <div class="noi-dung-hop-thoai">
          <div class="luoi-chi-tiet">
            <div><span>Số đơn</span><strong>{{ donDangXem.soDnlm }}</strong></div>
            <div><span>Ngày lập</span><strong>{{ dinhDangNgay(donDangXem.ngayLapDon) }}</strong></div>
            <div><span>Nhà cung cấp</span><strong>{{ donDangXem.nhaCungCap }}</strong></div>
            <div><span>Số điện thoại</span><strong>{{ donDangXem.soDienThoai || '-' }}</strong></div>
            <div class="rong"><span>Địa chỉ</span><strong>{{ donDangXem.diaChi || '-' }}</strong></div>
            <div><span>Bộ phận</span><strong>{{ donDangXem.boPhan }}</strong></div>
            <div><span>Người lập</span><strong>{{ donDangXem.nguoiLapDon }}</strong></div>
            <div><span>Quản lý</span><strong>{{ donDangXem.quanLy || '-' }}</strong></div>
            <div><span>Trạng thái</span><strong>{{ hienThiTrangThai(donDangXem.trangThai) }}</strong></div>
            <div><span>Nhân viên hệ thống</span><strong>{{ donDangXem.tenNhanVien }}</strong></div>
            <div><span>Mã nhân viên</span><strong>{{ donDangXem.maNd }}</strong></div>
            <div class="rong"><span>Ghi chú</span><strong>{{ donDangXem.ghiChu || '-' }}</strong></div>
          </div>

          <table class="bang-du-lieu bang-nho">
            <thead>
              <tr>
            <th>STT</th>
            <th>Mã nguyên liệu</th>
            <th>Tên nguyên liệu</th>
            <th>Đơn vị tính</th>
            <th>Số lượng đề nghị</th>
            <th>Đơn giá dự kiến</th>
            <th>Thành tiền</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="(ct, index) in donDangXem.chiTiet" :key="`${donDangXem.soDnlm}-${ct.maNl}`">
                <td>{{ index + 1 }}</td>
                <td>{{ ct.maNl }}</td>
                <td>{{ ct.tenNguyenLieu }}</td>
                <td>{{ ct.donViTinh }}</td>
                <td>{{ ct.soLuongDeNghi }}</td>
                <td>{{ dinhDangTien(ct.donGiaDuKien) }}</td>
                <td>{{ dinhDangTien(ct.thanhTienDuKien) }}</td>
              </tr>
            </tbody>
          </table>

          <div class="mau-bieu-actions">
            <div class="tong-don">Tổng giá trị đơn dự kiến: <strong>{{ dinhDangTien(tinhTongDon(donDangXem)) }}</strong></div>
            <div class="khu-nut">
              <select :value="donDangXem.trangThai || 'MoiLap'" :disabled="!coTheSuaDon(donDangXem)" @change="doiTrangThaiDon(donDangXem, $event.target.value)">
                <option value="MoiLap">Mới lập</option>
                <option value="DaGuiNCC">Đã gửi NCC</option>
                <option value="DaNhapHang">Đã nhập hàng</option>
                <option value="DaHuy">Đã hủy</option>
              </select>
              <button :disabled="!coTheSuaDon(donDangXem)" @click="batDauSua(donDangXem)"><span class="icon-nut">✎</span>Sửa đơn</button>
              <button @click="xuatMauBieu(donDangXem)"><span class="icon-nut">⎙</span>Xuất mẫu</button>
              <button @click="dongHopThoai"><span class="icon-nut">×</span>Đóng</button>
            </div>
          </div>
        </div>
      </section>
    </div>
  </div>
</template>

<script setup>
import { onMounted, reactive, ref } from 'vue'
import { csharpApi } from '../../api/csharpApi'
import { phpApi } from '../../api/phpApi'
import { layNguoiDungDangNhap, layQuanLyMacDinh } from '../../auth/session'

const dsDon = ref([])
const dsNguyenLieu = ref([])
const dsNhaCungCap = ref([])
const tuKhoa = ref('')
const thongBao = ref('')
const canhBaoPhp = ref('')
const coLoi = ref(false)
const maNccDangChon = ref('')
const hopThoaiDangMo = ref('')
const dangSua = ref(false)
const donDangXem = ref(null)
const phanTrang = reactive({
  page: 1,
  pageSize: 10,
  totalItems: 0,
  totalPages: 0
})

const form = reactive(taoFormMacDinh())

onMounted(async () => {
  await Promise.all([taiNguyenLieu(), taiNhaCungCap()])
  await taiDuLieu()
})

async function taiDuLieu() {
  try {
    const response = await csharpApi.getDonNguyenLieuMua(tuKhoa.value, {
      page: phanTrang.page,
      pageSize: phanTrang.pageSize
    })
    ganDuLieuPhanTrang(response)
    baoThanhCong('Tải đơn nguyên liệu mua thành công.')
  } catch (error) {
    baoLoi(error.message)
  }
}

async function timKiem() {
  phanTrang.page = 1
  await taiDuLieu()
}

async function taiNguyenLieu() {
  try {
    dsNguyenLieu.value = await csharpApi.getNguyenLieu()
  } catch (error) {
    baoLoi(error.message)
  }
}

async function taiNhaCungCap() {
  try {
    dsNhaCungCap.value = await phpApi.getNhaCungCap()
    canhBaoPhp.value = ''
  } catch (error) {
    canhBaoPhp.value = `${error.message}. Bạn vẫn có thể nhập nhà cung cấp thủ công để lập đơn.`
  }
}

async function luuDuLieu() {
  const payload = taoDuLieuGuiLenApi()
  if (!payload) return

  try {
    if (dangSua.value) {
      await csharpApi.updateDonNguyenLieuMua(form.soDnlm, payload)
      baoThanhCong('Cập nhật đơn nguyên liệu mua thành công.')
    } else {
      await csharpApi.createDonNguyenLieuMua(payload)
      baoThanhCong('Lập đơn nguyên liệu mua thành công.')
    }

    await taiDuLieu()
    dongHopThoai(false)
  } catch (error) {
    baoLoi(error.message)
  }
}

async function xoaDon(soDnlm) {
  const don = dsDon.value.find((item) => item.soDnlm === soDnlm)
  if (don && !coTheSuaDon(don)) {
    baoLoi('Đơn đã nhập hàng không được xóa.')
    return
  }

  if (!confirm(`Xóa đơn ${soDnlm}?`)) return

  try {
    await csharpApi.deleteDonNguyenLieuMua(soDnlm)
    baoThanhCong('Xóa đơn nguyên liệu mua thành công.')
    await taiDuLieu()
    if (donDangXem.value?.soDnlm === soDnlm) {
      dongHopThoai(false)
    }
  } catch (error) {
    baoLoi(error.message)
  }
}

function taoDuLieuGuiLenApi() {
  const chiTiet = form.chiTiet
    .filter((ct) => ct.maNl)
    .map((ct) => ({
      maNl: ct.maNl,
      soLuongDeNghi: Number(ct.soLuongDeNghi),
      donGiaDuKien: Number(ct.donGiaDuKien)
    }))

  if (!chiTiet.length) {
    baoLoi('Đơn phải có ít nhất một nguyên liệu.')
    return null
  }

  if (chiTiet.some((ct) => ct.soLuongDeNghi <= 0 || ct.donGiaDuKien < 0)) {
    baoLoi('Số lượng phải lớn hơn 0 và đơn giá không được âm.')
    return null
  }

  const dsMaNl = chiTiet.map((ct) => ct.maNl)
  if (new Set(dsMaNl).size !== dsMaNl.length) {
    baoLoi('Mỗi nguyên liệu chỉ được chọn một lần trong cùng một đơn.')
    return null
  }

  return {
    soDnlm: form.soDnlm,
    ngayLapDon: form.ngayLapDon,
    nhaCungCap: form.nhaCungCap,
    diaChi: form.diaChi,
    soDienThoai: form.soDienThoai,
    boPhan: form.boPhan,
    ghiChu: form.ghiChu,
    nguoiLapDon: form.nguoiLapDon,
    quanLy: form.quanLy,
    tenNhanVien: form.tenNhanVien,
    maNd: form.maNd,
    trangThai: form.trangThai,
    chiTiet
  }
}

function batDauThem() {
  dangSua.value = false
  donDangXem.value = null
  ganFormMacDinh()
  thongBao.value = ''
  hopThoaiDangMo.value = 'form'
}

function batDauSua(don) {
  if (!coTheSuaDon(don)) {
    baoLoi('Đơn đã nhập hàng không được sửa.')
    return
  }

  dangSua.value = true
  donDangXem.value = null
  ganFormTuDon(don)
  thongBao.value = ''
  hopThoaiDangMo.value = 'form'
}

function xemChiTiet(don) {
  donDangXem.value = don
  thongBao.value = ''
  hopThoaiDangMo.value = 'detail'
}

function dongHopThoai(resetThongBao = true) {
  hopThoaiDangMo.value = ''
  donDangXem.value = null
  dangSua.value = false
  ganFormMacDinh()
  if (resetThongBao) thongBao.value = ''
}

function chonNhaCungCap() {
  const ncc = dsNhaCungCap.value.find((item) => item.maNcc === maNccDangChon.value)
  if (!ncc) return

  form.nhaCungCap = ncc.tenNhaCungCap
  form.diaChi = ncc.diaChiNcc || ''
  form.soDienThoai = ncc.soDienThoaiNcc || ''
}

function themDongChiTiet() {
  form.chiTiet.push({
    maNl: '',
    donViTinh: '',
    soLuongDeNghi: 1,
    donGiaDuKien: 0
  })
}

function xoaDongChiTiet(index) {
  if (form.chiTiet.length === 1) {
    ganDongChiTiet(form.chiTiet[0])
    return
  }

  form.chiTiet.splice(index, 1)
}

function lamMoi() {
  tuKhoa.value = ''
  phanTrang.page = 1
  dongHopThoai()
  taiDuLieu()
}

function taoFormMacDinh() {
  const nguoiDung = layNguoiDungChoForm()

  return {
    soDnlm: taoSoDon(),
    ngayLapDon: ngayHienTai(),
    nhaCungCap: '',
    diaChi: '',
    soDienThoai: '',
    boPhan: nguoiDung.viTri,
    ghiChu: '',
    nguoiLapDon: nguoiDung.tenNd,
    quanLy: layQuanLyMacDinh(),
    tenNhanVien: nguoiDung.tenNd,
    maNd: nguoiDung.maNd,
    trangThai: 'MoiLap',
    chiTiet: [
      {
        maNl: '',
        donViTinh: '',
        soLuongDeNghi: 1,
        donGiaDuKien: 0
      }
    ]
  }
}

function layNguoiDungChoForm() {
  const nguoiDung = layNguoiDungDangNhap()

  return {
    maNd: nguoiDung?.maNd || '',
    tenNd: nguoiDung?.tenNd || '',
    viTri: nguoiDung?.viTri || ''
  }
}

function ganFormMacDinh() {
  const macDinh = taoFormMacDinh()
  Object.assign(form, macDinh)
  maNccDangChon.value = ''
}

function ganFormTuDon(don) {
  form.soDnlm = don.soDnlm
  form.ngayLapDon = chuanHoaNgayInput(don.ngayLapDon)
  form.nhaCungCap = don.nhaCungCap || ''
  form.diaChi = don.diaChi || ''
  form.soDienThoai = don.soDienThoai || ''
  form.boPhan = don.boPhan || ''
  form.ghiChu = don.ghiChu || ''
  form.nguoiLapDon = don.nguoiLapDon || ''
  form.quanLy = don.quanLy || ''
  form.tenNhanVien = don.tenNhanVien || ''
  form.maNd = don.maNd || ''
  form.trangThai = don.trangThai || 'MoiLap'
  const chiTietDon = don.chiTiet || []
  form.chiTiet = chiTietDon.length
    ? chiTietDon.map((ct) => ({
        maNl: ct.maNl,
        donViTinh: ct.donViTinh || layDonViTinhNguyenLieu(ct.maNl),
        soLuongDeNghi: Number(ct.soLuongDeNghi),
        donGiaDuKien: Number(ct.donGiaDuKien)
      }))
    : [{ maNl: '', donViTinh: '', soLuongDeNghi: 1, donGiaDuKien: 0 }]

  const ncc = dsNhaCungCap.value.find((item) => item.tenNhaCungCap === don.nhaCungCap)
  maNccDangChon.value = ncc?.maNcc || ''
}

function chonNguyenLieuChiTiet(ct) {
  ct.donViTinh = layDonViTinhNguyenLieu(ct.maNl)
}

function layDonViTinhNguyenLieu(maNl) {
  const nguyenLieu = dsNguyenLieu.value.find((item) => item.maNl === maNl)
  return nguyenLieu?.donViTinh || ''
}

function ganDongChiTiet(ct) {
  ct.maNl = ''
  ct.donViTinh = ''
  ct.soLuongDeNghi = 1
  ct.donGiaDuKien = 0
}

function taoSoDon() {
  return `DN${Date.now().toString().slice(-8)}`
}

function ngayHienTai() {
  const now = new Date()
  const year = now.getFullYear()
  const month = String(now.getMonth() + 1).padStart(2, '0')
  const day = String(now.getDate()).padStart(2, '0')
  return `${year}-${month}-${day}`
}

function chuanHoaNgayInput(value) {
  if (!value) return ngayHienTai()
  return String(value).slice(0, 10)
}

function tinhThanhTienDong(ct) {
  return Number(ct.soLuongDeNghi || 0) * Number(ct.donGiaDuKien || 0)
}

function tinhTongForm() {
  return form.chiTiet.reduce((sum, ct) => sum + tinhThanhTienDong(ct), 0)
}

function tinhTongDon(don) {
  return (don.chiTiet || []).reduce((sum, ct) => sum + Number(ct.thanhTienDuKien || 0), 0)
}

function dinhDangTien(value) {
  return Number(value || 0).toLocaleString('vi-VN') + ' đ'
}

function dinhDangNgay(value) {
  return value || ''
}

function ganDuLieuPhanTrang(response) {
  if (Array.isArray(response)) {
    dsDon.value = response
    phanTrang.totalItems = response.length
    phanTrang.totalPages = response.length ? 1 : 0
    return
  }

  dsDon.value = response.items || []
  phanTrang.page = response.page || 1
  phanTrang.pageSize = response.pageSize || phanTrang.pageSize
  phanTrang.totalItems = response.totalItems || 0
  phanTrang.totalPages = response.totalPages || 0
}

async function doiTrang(page) {
  phanTrang.page = page
  await taiDuLieu()
}

function coTheSuaDon(don) {
  return (don?.trangThai || 'MoiLap') !== 'DaNhapHang'
}

async function doiTrangThaiDon(don, trangThai) {
  try {
    await csharpApi.updateTrangThaiDonNguyenLieuMua(don.soDnlm, trangThai)
    baoThanhCong('Cập nhật trạng thái đơn thành công.')
    await taiDuLieu()
    const donMoi = dsDon.value.find((item) => item.soDnlm === don.soDnlm)
    donDangXem.value = donMoi || { ...don, trangThai }
  } catch (error) {
    baoLoi(error.message)
  }
}

function hienThiTrangThai(trangThai) {
  const labels = {
    MoiLap: 'Mới lập',
    DaGuiNCC: 'Đã gửi NCC',
    DaNhapHang: 'Đã nhập hàng',
    DaHuy: 'Đã hủy'
  }

  return labels[trangThai] || trangThai || 'Mới lập'
}

function xuatMauBieu(don) {
  moCuaSoIn(taoHtmlDonNguyenLieuMua(don))
  return

  const rows = don.chiTiet.map((ct, index) => `
    <tr>
      <td>${index + 1}</td>
      <td>${escapeHtml(ct.maNl)}</td>
      <td>${escapeHtml(ct.tenNguyenLieu)}</td>
      <td>${escapeHtml(ct.donViTinh || '')}</td>
      <td>${ct.soLuongDeNghi}</td>
      <td>${dinhDangTien(ct.donGiaDuKien)}</td>
      <td>${dinhDangTien(ct.thanhTienDuKien)}</td>
    </tr>
  `).join('')

  const html = `
    <!doctype html>
    <html lang="vi">
      <head>
        <meta charset="utf-8">
        <title>Đơn nguyên liệu mua ${escapeHtml(don.soDnlm)}</title>
        <style>
          body { font-family: "Times New Roman", serif; margin: 32px; color: #111; }
          .top { display: flex; justify-content: space-between; gap: 20px; font-size: 14px; }
          h1 { text-align: center; font-size: 22px; margin: 28px 0 4px; }
          .ma-bieu { text-align: center; font-weight: bold; margin-bottom: 24px; }
          .info { display: grid; grid-template-columns: 1fr 1fr; gap: 8px 28px; margin-bottom: 18px; }
          .info div { border-bottom: 1px dotted #777; padding: 5px 0; }
          table { width: 100%; border-collapse: collapse; margin-top: 12px; }
          th, td { border: 1px solid #333; padding: 8px; font-size: 14px; }
          th { text-align: center; background: #f0f0f0; }
          .right { text-align: right; margin-top: 12px; font-weight: bold; }
          .sign { display: grid; grid-template-columns: repeat(3, 1fr); text-align: center; margin-top: 48px; gap: 24px; }
          .sign strong { display: block; margin-bottom: 70px; }
          @media print { button { display: none; } body { margin: 20mm; } }
        </style>
      </head>
      <body>
        <div class="top">
          <div><strong>QLBH Take Away</strong><br>Quản lý bán cafe takeaway</div>
          <div><strong>Mẫu biểu:</strong> MB.05<br><strong>Số:</strong> ${escapeHtml(don.soDnlm)}</div>
        </div>

        <h1>ĐƠN NGUYÊN LIỆU MUA</h1>
        <div class="ma-bieu">Ngày lập: ${escapeHtml(dinhDangNgay(don.ngayLapDon))}</div>

        <div class="info">
          <div><strong>Nhà cung cấp:</strong> ${escapeHtml(don.nhaCungCap)}</div>
          <div><strong>Số điện thoại:</strong> ${escapeHtml(don.soDienThoai || '')}</div>
          <div><strong>Địa chỉ:</strong> ${escapeHtml(don.diaChi || '')}</div>
          <div><strong>Bộ phận:</strong> ${escapeHtml(don.boPhan)}</div>
          <div><strong>Người lập:</strong> ${escapeHtml(don.nguoiLapDon)}</div>
          <div><strong>Quản lý:</strong> ${escapeHtml(don.quanLy || '')}</div>
          <div><strong>Nhân viên hệ thống:</strong> ${escapeHtml(don.tenNhanVien)}</div>
          <div><strong>Mã nhân viên:</strong> ${escapeHtml(don.maNd)}</div>
        </div>

        <p><strong>Ghi chú:</strong> ${escapeHtml(don.ghiChu || '')}</p>

        <table>
          <thead>
            <tr>
              <th>STT</th>
              <th>Mã NL</th>
              <th>Tên nguyên liệu</th>
              <th>Đơn vị tính</th>
              <th>Số lượng đề nghị</th>
              <th>Đơn giá dự kiến</th>
              <th>Thành tiền nguyên liệu dự kiến</th>
            </tr>
          </thead>
          <tbody>${rows}</tbody>
        </table>

        <div class="right">Tổng giá trị đơn dự kiến: ${dinhDangTien(tinhTongDon(don))}</div>

        <div class="sign">
          <div><strong>Người lập đơn</strong><span>${escapeHtml(don.nguoiLapDon)}</span></div>
          <div><strong>Quản lý</strong><span>${escapeHtml(don.quanLy || '')}</span></div>
          <div><strong>Nhà cung cấp</strong><span>${escapeHtml(don.nhaCungCap)}</span></div>
        </div>

        <script>
          window.onload = function () {
            window.print()
          }
        <\/script>
      </body>
    </html>
  `

  const printWindow = window.open('', '_blank')
  if (!printWindow) {
    baoLoi('Trình duyệt đang chặn cửa sổ in. Hãy cho phép popup rồi thử lại.')
    return
  }

  printWindow.document.open()
  printWindow.document.write(html)
  printWindow.document.close()
}

function taoHtmlDonNguyenLieuMua(don) {
  const rows = taoDongChiTietDon(don)

  return `
    <!doctype html>
    <html lang="vi">
      <head>
        <meta charset="utf-8">
        <title>Đơn nguyên liệu mua ${escapeHtml(don.soDnlm)}</title>
        <style>
          @page { size: A4; margin: 0; }
          body { margin: 0; font-family: "Times New Roman", serif; color: #111; background: #fff; }
          .page { width: 210mm; min-height: 297mm; border: 2px solid #222; padding: 21mm 18mm; box-sizing: border-box; margin: 0 auto; }
          .brand { margin-left: 6mm; font-size: 15pt; line-height: 1.75; }
          .brand strong { display: block; font-size: 18pt; }
          h1 { text-align: center; font-size: 30pt; margin: 20mm 0 8mm; }
          .info { font-size: 14pt; line-height: 1.55; margin-left: 6mm; }
          .line { display: inline-block; min-width: 70mm; border-bottom: 1px dotted #333; padding: 0 4px 1px; }
          .line.short { min-width: 38mm; }
          .table-title { text-align: center; font-size: 14pt; font-weight: bold; margin: 7mm 0 3mm; }
          table { width: 82%; margin: 0 auto; border-collapse: collapse; font-size: 13pt; }
          th, td { border: 1.5px solid #222; padding: 5px 6px; text-align: center; vertical-align: middle; }
          th { font-weight: bold; }
          td.text { text-align: left; }
          .total, .note { font-size: 14pt; margin: 8mm 0 0 6mm; }
          .total .line { min-width: 55mm; text-align: right; }
          .note .line { min-width: 96mm; }
          .sign { display: grid; grid-template-columns: 1fr 1fr; margin: 16mm 4mm 0; font-size: 14pt; font-weight: bold; }
          .sign div:last-child { text-align: right; }
          .hint { display: block; font-weight: normal; font-style: italic; }
        </style>
      </head>
      <body>
        <div class="page">
          ${taoHeaderCongTy()}

          <h1>ĐƠN NGUYÊN LIỆU MUA</h1>

          <div class="info">
            <div>Số đơn: <span class="line short">${escapeHtml(don.soDnlm)}</span></div>
            <div>Ngày lập đơn: <span class="line short">${escapeHtml(dinhDangNgayIn(don.ngayLapDon))}</span></div>
            <br>
            <div>Tên nhà cung cấp: <span class="line">${escapeHtml(don.nhaCungCap)}</span></div>
            <div>Địa chỉ nhà cung cấp: <span class="line">${escapeHtml(don.diaChi || '')}</span></div>
            <div>Số điện thoại nhà cung cấp: <span class="line">${escapeHtml(don.soDienThoai || '')}</span></div>
            <div>Bộ phận: <span class="line">${escapeHtml(don.boPhan)}</span></div>
          </div>

          <div class="table-title">Danh sách nguyên liệu đề nghị mua</div>
          <table>
            <thead>
              <tr>
                <th>STT</th>
                <th>Tên nguyên liệu</th>
                <th>Đơn vị tính</th>
                <th>Số lượng<br>đề nghị</th>
                <th>Đơn giá<br>dự kiến<br>(VNĐ)</th>
                <th>Thành tiền<br>(VNĐ)</th>
              </tr>
            </thead>
            <tbody>${rows}</tbody>
          </table>

          <div class="total">Tổng giá trị đơn dự kiến: <span class="line">${dinhDangSo(tinhTongDon(don))}</span> VNĐ</div>
          <div class="note">Ghi chú: <span class="line">${escapeHtml(don.ghiChu || '')}</span></div>

          <div class="sign">
            <div>Người lập đơn mua<span class="hint">(Ký, ghi rõ họ tên)</span></div>
            <div>Quản lý<span class="hint">(Ký, ghi rõ họ tên)</span></div>
          </div>
        </div>
        <script>window.onload = function () { window.print() }<\/script>
      </body>
    </html>
  `
}

function taoDongChiTietDon(don) {
  const rows = (don.chiTiet || []).map((ct, index) => `
    <tr>
      <td>${index + 1}</td>
      <td class="text">${escapeHtml(ct.tenNguyenLieu)}</td>
      <td>${escapeHtml(ct.donViTinh || '')}</td>
      <td>${ct.soLuongDeNghi}</td>
      <td>${dinhDangSo(ct.donGiaDuKien)}</td>
      <td>${dinhDangSo(ct.thanhTienDuKien)}</td>
    </tr>
  `)

  while (rows.length < 5) {
    rows.push('<tr><td>&nbsp;</td><td></td><td></td><td></td><td></td><td></td></tr>')
  }

  return rows.join('')
}

function taoHeaderCongTy() {
  return `
    <div class="brand">
      <strong>THUẬN COFFEE TAKE AWAY</strong>
      <div>Địa chỉ: 334 Lê Đại Hành, Cao Lãnh, Đồng Tháp</div>
      <div>Số điện thoại: 0889753379</div>
      <div>Website: www.thuancoffeetakeaway.com.vn</div>
    </div>
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

function dinhDangSo(value) {
  return Number(value || 0).toLocaleString('vi-VN')
}

function dinhDangNgayIn(value) {
  if (!value) return ''
  const [year, month, day] = String(value).slice(0, 10).split('-')
  return day && month && year ? `${day}/${month}/${year}` : value
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
