//cầu nối giữa vue và php
import { dangXuat, layTokenDangNhap } from '../auth/session'

const API_BASE_URL =
  import.meta.env.VITE_PHP_API_URL || "http://127.0.0.1:8093/api.php";

async function request(path, options = {}) {
  let response;
  const token = layTokenDangNhap()

  try {
    response = await fetch(buildUrl(path), {
      ...options,
      headers: {
        "Content-Type": "application/json",
        ...(token ? { Authorization: `Bearer ${token}` } : {}),
        ...(options.headers || {})
      }
    });
  } catch {
    throw new Error(
      "Khong ket noi duoc backend PHP. Hay chay PHP server o port 8093."
    );
  }

  if (!response.ok) {
    let message = `Loi goi API PHP (${response.status})`;

    try {
      const error = await response.json();
      message = error.message || message;
    } catch {
      // API khong tra JSON thi giu thong bao mac dinh.
    }

    if (response.status === 401) {
      dangXuat()
      chuyenVeDangNhap()
    }

    throw new Error(message);
  }

  if (response.status === 204) {
    return null;
  }

  return response.json();
}

export const phpApi = {
  getKhachHang(keyword = "") {
    return request(`/khach-hang${buildQuery(keyword)}`);
  },

  createKhachHang(data) {
    return request("/khach-hang", {
      method: "POST",
      body: JSON.stringify(data)
    });
  },

  updateKhachHang(id, data) {
    return request(`/khach-hang/${id}`, {
      method: "PUT",
      body: JSON.stringify(data)
    });
  },

  deleteKhachHang(id) {
    return request(`/khach-hang/${id}`, {
      method: "DELETE"
    });
  },

  getNhaCungCap(keyword = "") {
    return request(`/nha-cung-cap${buildQuery(keyword)}`);
  },

  createNhaCungCap(data) {
    return request("/nha-cung-cap", {
      method: "POST",
      body: JSON.stringify(data)
    });
  },

  updateNhaCungCap(id, data) {
    return request(`/nha-cung-cap/${id}`, {
      method: "PUT",
      body: JSON.stringify(data)
    });
  },

  deleteNhaCungCap(id) {
    return request(`/nha-cung-cap/${id}`, {
      method: "DELETE"
    });
  }
};

function buildQuery(keyword) {
  const value = keyword.trim();
  return value ? `?keyword=${encodeURIComponent(value)}` : "";
}

function buildUrl(path) {
  const [routePath, queryString = ""] = path.split("?");
  const params = new URLSearchParams(queryString);
  params.set("route", `/api${routePath}`);
  return `${API_BASE_URL}?${params.toString()}`;
}

function chuyenVeDangNhap() {
  if (window.location.pathname === '/dang-nhap') return

  const redirect = `${window.location.pathname}${window.location.search}`
  window.location.href = `/dang-nhap?redirect=${encodeURIComponent(redirect)}`
}
