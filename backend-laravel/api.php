<?php

declare(strict_types=1);

header('Content-Type: application/json; charset=utf-8');
header('Access-Control-Allow-Origin: *');
header('Access-Control-Allow-Headers: Content-Type, Authorization');
header('Access-Control-Allow-Methods: GET, POST, PUT, DELETE, OPTIONS');

if (($_SERVER['REQUEST_METHOD'] ?? 'GET') === 'OPTIONS') {
    http_response_code(204);
    exit;
}

// Vue -> PHP proxy port 8093 -> C# backend port 5155 -> SQL Server.
// The extra routes keep compatibility with the Laravel controller routes from QLBH_TAKEAWAY.rar.
const CSHARP_API_BASE = 'http://localhost:5155/api';

$method = $_SERVER['REQUEST_METHOD'] ?? 'GET';
$route = $_GET['route'] ?? '/api/health';
$route = '/' . ltrim((string)$route, '/');

if ($route === '/api/health' || $route === '/health') {
    json_response([
        'service' => 'QLBH Take Away PHP API',
        'status' => 'running',
        'mode' => 'proxy-to-csharp',
        'csharpApi' => CSHARP_API_BASE,
    ]);
}

if ($route === '/api/dang-nhap') {
    handle_legacy_login($method);
}

if ($route === '/api/nguoi-dung/nhom') {
    proxy_to_csharp('/api/nhom-nguoi-dung', 'GET');
}

if (preg_match('#^/api/(khach-hang|nha-cung-cap|nguoi-dung|nhom-nguoi-dung)/ma-moi$#', $route, $matches)) {
    handle_next_code($matches[1], $method);
}

$allowedRoutes = [
    '/api/khach-hang',
    '/api/nha-cung-cap',
    '/api/nguoi-dung',
    '/api/nhom-nguoi-dung',
];

$matched = false;
foreach ($allowedRoutes as $allowedRoute) {
    if ($route === $allowedRoute || str_starts_with($route, $allowedRoute . '/')) {
        $matched = true;
        break;
    }
}

if (!$matched) {
    json_error('Khong tim thay endpoint PHP.', 404);
}

proxy_to_csharp($route, $method);

function proxy_to_csharp(string $route, string $method): void
{
    $body = file_get_contents('php://input') ?: '';
    [$status, $response] = call_csharp($route, $method, normalize_request_body($route, $method, $body));

    http_response_code($status);
    echo $response;
    exit;
}

function call_csharp(string $route, string $method, string $body = ''): array
{
    $targetPath = preg_replace('#^/api#', '', $route);
    $url = CSHARP_API_BASE . $targetPath;

    $query = $_GET;
    unset($query['route']);
    if (count($query) > 0) {
        $url .= '?' . http_build_query($query);
    }

    $headers = "Content-Type: application/json\r\n";
    $authorization = $_SERVER['HTTP_AUTHORIZATION'] ?? $_SERVER['REDIRECT_HTTP_AUTHORIZATION'] ?? '';
    if ($authorization !== '') {
        $headers .= "Authorization: {$authorization}\r\n";
    }

    $options = [
        'http' => [
            'method' => $method,
            'header' => $headers,
            'content' => in_array($method, ['POST', 'PUT'], true) ? $body : '',
            'ignore_errors' => true,
            'timeout' => 15,
        ],
    ];

    $response = @file_get_contents($url, false, stream_context_create($options));
    if ($response === false) {
        return [502, json_encode([
            'message' => 'PHP khong ket noi duoc backend C#. Hay chay C# o http://localhost:5155.',
            'status' => 502,
        ], JSON_UNESCAPED_UNICODE)];
    }

    $status = 200;
    foreach ($http_response_header ?? [] as $header) {
        if (preg_match('/^HTTP\/\S+\s+(\d{3})/', $header, $matches)) {
            $status = (int)$matches[1];
            break;
        }
    }

    return [$status, $response];
}

function handle_legacy_login(string $method): void
{
    if ($method !== 'POST') {
        json_error('Endpoint dang nhap chi ho tro POST.', 405);
    }

    $data = read_json_body();
    $payload = [
        'username' => $data['username'] ?? $data['tenDangNhap'] ?? $data['usr'] ?? '',
        'password' => $data['password'] ?? $data['matKhau'] ?? $data['pwd_hash'] ?? '',
    ];

    [$status, $response] = call_csharp('/api/auth/login', 'POST', json_encode($payload, JSON_UNESCAPED_UNICODE));
    if ($status < 200 || $status >= 300) {
        http_response_code($status);
        echo $response;
        exit;
    }

    $result = json_decode($response, true);
    if (!is_array($result)) {
        http_response_code($status);
        echo $response;
        exit;
    }

    $result['nguoiDung'] = [
        'ma_nd' => $result['maNd'] ?? '',
        'tennd' => $result['tenNd'] ?? '',
        'usr' => $result['userName'] ?? '',
        'vitri' => $result['viTri'] ?? null,
        'trangthai' => 1,
    ];

    json_response($result, $status);
}

function handle_next_code(string $entity, string $method): void
{
    if ($method !== 'GET') {
        json_error('Endpoint tao ma moi chi ho tro GET.', 405);
    }

    $code = generate_next_code($entity);
    $legacyFields = [
        'khach-hang' => 'ma_kh',
        'nha-cung-cap' => 'ma_ncc',
        'nguoi-dung' => 'ma_nd',
        'nhom-nguoi-dung' => 'ma_nhom',
    ];
    $camelFields = [
        'khach-hang' => 'maKh',
        'nha-cung-cap' => 'maNcc',
        'nguoi-dung' => 'maNd',
        'nhom-nguoi-dung' => 'maNhom',
    ];

    json_response([
        $legacyFields[$entity] => $code,
        $camelFields[$entity] => $code,
    ]);
}

function normalize_request_body(string $route, string $method, string $body): string
{
    if (!in_array($method, ['POST', 'PUT'], true) || trim($body) === '') {
        return $body;
    }

    $data = json_decode($body, true);
    if (!is_array($data)) {
        return $body;
    }

    if (preg_match('#^/api/khach-hang(?:/([^/]+))?$#', $route, $matches)) {
        $data = map_fields($data, [
            'ma_kh' => 'maKh',
            'tenkhachhang' => 'tenKhachHang',
            'sodienthoai' => 'soDienThoai',
            'diachi' => 'diaChi',
            'gioitinh' => 'gioiTinh',
        ]);
        $data['maKh'] = $data['maKh'] ?? ($matches[1] ?? generate_next_code('khach-hang'));
    } elseif (preg_match('#^/api/nha-cung-cap(?:/([^/]+))?$#', $route, $matches)) {
        $data = map_fields($data, [
            'ma_ncc' => 'maNcc',
            'tennhacungcap' => 'tenNhaCungCap',
            'diachincc' => 'diaChiNcc',
            'sodienthoaincc' => 'soDienThoaiNcc',
        ]);
        $data['maNcc'] = $data['maNcc'] ?? ($matches[1] ?? generate_next_code('nha-cung-cap'));
    } elseif (preg_match('#^/api/nguoi-dung(?:/([^/]+))?$#', $route, $matches)) {
        $data = map_fields($data, [
            'ma_nd' => 'maNd',
            'tennd' => 'tenNd',
            'usr' => 'userName',
            'pwd_hash' => 'password',
            'vitri' => 'viTri',
            'trangthai' => 'trangThai',
            'ma_nhom' => 'maNhom',
        ]);
        $data['maNd'] = $data['maNd'] ?? ($matches[1] ?? generate_next_code('nguoi-dung'));
    }

    return json_encode($data, JSON_UNESCAPED_UNICODE);
}

function map_fields(array $data, array $fieldMap): array
{
    foreach ($fieldMap as $legacy => $modern) {
        if (array_key_exists($legacy, $data) && !array_key_exists($modern, $data)) {
            $data[$modern] = $data[$legacy];
        }
    }

    return $data;
}

function generate_next_code(string $entity): string
{
    $configs = [
        'khach-hang' => ['/api/khach-hang', ['maKh', 'ma_kh'], 'KH', 3],
        'nha-cung-cap' => ['/api/nha-cung-cap', ['maNcc', 'ma_ncc'], 'NCC', 3],
        'nguoi-dung' => ['/api/nguoi-dung', ['maNd', 'ma_nd'], 'ND', 3],
        'nhom-nguoi-dung' => ['/api/nhom-nguoi-dung', ['maNhom', 'ma_nhom'], 'N', 2],
    ];

    if (!isset($configs[$entity])) {
        json_error('Khong ho tro tao ma moi cho endpoint nay.', 404);
    }

    [$route, $fields, $prefix, $digits] = $configs[$entity];
    [$status, $response] = call_csharp($route, 'GET');
    if ($status < 200 || $status >= 300) {
        http_response_code($status);
        echo $response;
        exit;
    }

    $decoded = json_decode($response, true);
    $items = is_array($decoded) && isset($decoded['items']) && is_array($decoded['items'])
        ? $decoded['items']
        : (is_array($decoded) ? $decoded : []);

    $max = 0;
    foreach ($items as $item) {
        if (!is_array($item)) {
            continue;
        }

        $code = '';
        foreach ($fields as $field) {
            if (isset($item[$field])) {
                $code = (string)$item[$field];
                break;
            }
        }

        if (preg_match('/^' . preg_quote($prefix, '/') . '(\d+)$/i', $code, $matches)) {
            $max = max($max, (int)$matches[1]);
        }
    }

    return $prefix . str_pad((string)($max + 1), $digits, '0', STR_PAD_LEFT);
}

function read_json_body(): array
{
    $body = file_get_contents('php://input') ?: '';
    $data = json_decode($body, true);
    return is_array($data) ? $data : [];
}

function json_response(array $data, int $status = 200): void
{
    http_response_code($status);
    echo json_encode($data, JSON_UNESCAPED_UNICODE);
    exit;
}

function json_error(string $message, int $status): void
{
    json_response(['message' => $message, 'status' => $status], $status);
}
