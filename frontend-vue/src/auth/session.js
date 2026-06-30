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
  return Boolean(layNguoiDungDangNhap())
}

export function dangXuat() {
  sessionStorage.removeItem(SESSION_KEY)
}

export function layQuanLyMacDinh() {
  return layNguoiDungDangNhap()?.quanLyMacDinh || 'Phạm Thị Dung'
}
