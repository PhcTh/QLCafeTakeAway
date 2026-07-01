const SESSION_KEY = 'nguoiDungDangNhap'

export function luuNguoiDungDangNhap(nguoiDung) {
  sessionStorage.setItem(SESSION_KEY, JSON.stringify(nguoiDung))
}

export function layNguoiDungDangNhap() {
  const raw = sessionStorage.getItem(SESSION_KEY)
  if (!raw) return null

  try {
    return JSON.parse(raw)
  } catch {
    sessionStorage.removeItem(SESSION_KEY)
    return null
  }
}

export function daDangNhap() {
  return Boolean(layTokenDangNhap())
}

export function dangXuat() {
  sessionStorage.removeItem(SESSION_KEY)
}

export function layTokenDangNhap() {
  return layNguoiDungDangNhap()?.token || ''
}

export function coQuyen(maQuyen) {
  const nguoiDung = layNguoiDungDangNhap()
  return Boolean(nguoiDung?.maQuyen?.includes(maQuyen) || nguoiDung?.maNhom?.includes('N04'))
}

export function thuocNhom(maNhom) {
  return Boolean(layNguoiDungDangNhap()?.maNhom?.includes(maNhom))
}

export function layQuanLyMacDinh() {
  return layNguoiDungDangNhap()?.quanLyMacDinh || 'Phạm Thị Dung'
}
