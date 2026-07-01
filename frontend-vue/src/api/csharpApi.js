import { dangXuat, layTokenDangNhap } from '../auth/session'

const API_BASE_URL = import.meta.env.VITE_CSHARP_API_URL || 'http://localhost:5155/api'

async function request(path, options = {}) {
  let response
  const token = layTokenDangNhap()

  try {
    response = await fetch(`${API_BASE_URL}${path}`, {
      ...options,
      headers: {
        'Content-Type': 'application/json',
        ...(token ? { Authorization: `Bearer ${token}` } : {}),
        ...(options.headers || {})
      }
    })
  } catch {
    throw new Error('Khong ket noi duoc backend C#. Hay chay: cd backend-csharp roi dotnet run --urls http://localhost:5155')
  }

  if (!response.ok) {
    let message = `Loi goi API C# (${response.status})`

    try {
      const error = await response.json()
      message = error.message || message
    } catch {
      // API khong tra JSON thi giu thong bao mac dinh.
    }

    if (response.status === 401) {
      dangXuat()
      chuyenVeDangNhap()
    }

    throw new Error(message)
  }

  if (response.status === 204) {
    return null
  }

  return response.json()
}

export const csharpApi = {
  login(data) {
    return request('/auth/login', {
      method: 'POST',
      body: JSON.stringify(data)
    })
  },

  getLoaiDoUong(keyword = '', paging = null) {
    return request(`/loai-do-uong${buildQuery({ keyword, ...(paging || {}) })}`)
  },

  createLoaiDoUong(data) {
    return request('/loai-do-uong', {
      method: 'POST',
      body: JSON.stringify(data)
    })
  },

  updateLoaiDoUong(id, data) {
    return request(`/loai-do-uong/${id}`, {
      method: 'PUT',
      body: JSON.stringify(data)
    })
  },

  deleteLoaiDoUong(id) {
    return request(`/loai-do-uong/${id}`, {
      method: 'DELETE'
    })
  },

  getDoUong(keyword = '', paging = null) {
    return request(`/do-uong${buildQuery({ keyword, ...(paging || {}) })}`)
  },

  createDoUong(data) {
    return request('/do-uong', {
      method: 'POST',
      body: JSON.stringify(data)
    })
  },

  updateDoUong(id, data) {
    return request(`/do-uong/${id}`, {
      method: 'PUT',
      body: JSON.stringify(data)
    })
  },

  deleteDoUong(id) {
    return request(`/do-uong/${id}`, {
      method: 'DELETE'
    })
  },

  getNguyenLieu(keyword = '', paging = null) {
    return request(`/nguyen-lieu${buildQuery({ keyword, ...(paging || {}) })}`)
  },

  createNguyenLieu(data) {
    return request('/nguyen-lieu', {
      method: 'POST',
      body: JSON.stringify(data)
    })
  },

  updateNguyenLieu(id, data) {
    return request(`/nguyen-lieu/${id}`, {
      method: 'PUT',
      body: JSON.stringify(data)
    })
  },

  deleteNguyenLieu(id) {
    return request(`/nguyen-lieu/${id}`, {
      method: 'DELETE'
    })
  },

  getNguoiDung(keyword = '', paging = null) {
    return request(`/nguoi-dung${buildQuery({ keyword, ...(paging || {}) })}`)
  },

  createNguoiDung(data) {
    return request('/nguoi-dung', {
      method: 'POST',
      body: JSON.stringify(data)
    })
  },

  updateNguoiDung(id, data) {
    return request(`/nguoi-dung/${id}`, {
      method: 'PUT',
      body: JSON.stringify(data)
    })
  },

  deleteNguoiDung(id) {
    return request(`/nguoi-dung/${id}`, {
      method: 'DELETE'
    })
  },

  getNhomNguoiDung(keyword = '') {
    return request(`/nhom-nguoi-dung${buildQuery({ keyword })}`)
  },

  getDonNguyenLieuMua(keyword = '', paging = null) {
    return request(`/don-nguyen-lieu-mua${buildQuery({ keyword, ...(paging || {}) })}`)
  },

  createDonNguyenLieuMua(data) {
    return request('/don-nguyen-lieu-mua', {
      method: 'POST',
      body: JSON.stringify(data)
    })
  },

  updateDonNguyenLieuMua(id, data) {
    return request(`/don-nguyen-lieu-mua/${id}`, {
      method: 'PUT',
      body: JSON.stringify(data)
    })
  },

  deleteDonNguyenLieuMua(id) {
    return request(`/don-nguyen-lieu-mua/${id}`, {
      method: 'DELETE'
    })
  },

  updateTrangThaiDonNguyenLieuMua(id, trangThai) {
    return request(`/don-nguyen-lieu-mua/${id}/trang-thai`, {
      method: 'PUT',
      body: JSON.stringify({ trangThai })
    })
  },

  getDoUongBanChay(thang, nam) {
    return request(`/bao-cao/do-uong-ban-chay?thang=${encodeURIComponent(thang)}&nam=${encodeURIComponent(nam)}`)
  },

  getDoanhThuNgay(ngay) {
    return request(`/bao-cao/doanh-thu-ngay?ngay=${encodeURIComponent(ngay)}`)
  }
}

function buildQuery(params = {}) {
  const searchParams = new URLSearchParams()

  for (const [key, rawValue] of Object.entries(params)) {
    if (rawValue === null || rawValue === undefined || rawValue === '') continue
    const value = typeof rawValue === 'string' ? rawValue.trim() : rawValue
    if (value === '') continue
    searchParams.set(key, value)
  }

  const query = searchParams.toString()
  return query ? `?${query}` : ''
}

function chuyenVeDangNhap() {
  if (window.location.pathname === '/dang-nhap') return

  const redirect = `${window.location.pathname}${window.location.search}`
  window.location.href = `/dang-nhap?redirect=${encodeURIComponent(redirect)}`
}
