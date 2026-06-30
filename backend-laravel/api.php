<?php

declare(strict_types=1);

header('Content-Type: application/json; charset=utf-8');
header('Access-Control-Allow-Origin: *');// Cho Vue gọi từ port khác
header('Access-Control-Allow-Headers: Content-Type');
header('Access-Control-Allow-Methods: GET, POST, PUT, DELETE, OPTIONS');
// Gửi request OPTIONS để kiểm tra CORS
if (($_SERVER['REQUEST_METHOD'] ?? 'GET') === 'OPTIONS') {
    http_response_code(204);
    exit;
}
//php backend này chỉ là proxy để gọi sang backend C# 
//Vue -> PHP backend port 8093 -> C# backend port 5155 -> SQL Server
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

$allowedRoutes = [
    '/api/khach-hang',
    '/api/nha-cung-cap',
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
    $targetPath = preg_replace('#^/api#', '', $route);
    $url = CSHARP_API_BASE . $targetPath;

    $query = $_GET;
    unset($query['route']);
    if (count($query) > 0) {
        $url .= '?' . http_build_query($query);
    }

    $body = file_get_contents('php://input') ?: '';
    $options = [
        'http' => [
            'method' => $method,
            'header' => "Content-Type: application/json\r\n",
            'content' => in_array($method, ['POST', 'PUT'], true) ? $body : '',
            'ignore_errors' => true,
            'timeout' => 15,
        ],
    ];
//PHP gọi HTTP request sang backend C# và trả về response cho Vue. Nếu PHP không kết nối được backend C# thì trả về lỗi 502.
    $response = @file_get_contents($url, false, stream_context_create($options));
    if ($response === false) {
        json_error('PHP khong ket noi duoc backend C#. Hay chay C# o http://localhost:5155.', 502);
    }

    $status = 200;
    foreach ($http_response_header ?? [] as $header) {
        if (preg_match('/^HTTP\/\S+\s+(\d{3})/', $header, $matches)) {
            $status = (int)$matches[1];
            break;
        }
    }

    // Trả về response từ backend C# cho Vue
    http_response_code($status);
    echo $response;
    exit;
}

function json_response(array $data, int $status = 200): void
{
    http_response_code($status);
    echo json_encode($data, JSON_UNESCAPED_UNICODE);
    exit;
}

function json_error(string $message, int $status): void
{
    json_response(['message' => $message], $status);
}
