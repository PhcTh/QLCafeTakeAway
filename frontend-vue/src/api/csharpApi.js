const API_BASE_URL = import.meta.env.VITE_CSHARP_API_URL || 'http://localhost:5155/api'

async function request(path, options = {}) {
  let response

  try {
    response = await fetch(`${API_BASE_URL}${path}`, {
      headers: {
        'Content-Type': 'application/json',
        ...(options.headers || {})
      },
      ...options
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

  getLoaiDoUong(keyword = '') {
    return request(`/loai-do-uong${buildQuery(keyword)}`)
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

  getDoUong(keyword = '') {
    return request(`/do-uong${buildQuery(keyword)}`)
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

  getNguyenLieu(keyword = '') {
    return request(`/nguyen-lieu${buildQuery(keyword)}`)
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

  getNguoiDung(keyword = '') {
    return request(`/nguoi-dung${buildQuery(keyword)}`)
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
    return request(`/nhom-nguoi-dung${buildQuery(keyword)}`)
  },

  getDonNguyenLieuMua(keyword = '') {
    return request(`/don-nguyen-lieu-mua${buildQuery(keyword)}`)
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

  getDoUongBanChay(thang, nam) {
    return request(`/bao-cao/do-uong-ban-chay?thang=${encodeURIComponent(thang)}&nam=${encodeURIComponent(nam)}`)
  },

  getDoanhThuNgay(ngay) {
    return request(`/bao-cao/doanh-thu-ngay?ngay=${encodeURIComponent(ngay)}`)
  }
}

function buildQuery(keyword) {
  const value = keyword.trim()
  return value ? `?keyword=${encodeURIComponent(value)}` : ''
}
