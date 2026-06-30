<?php

header('Content-Type: application/json; charset=utf-8');
echo json_encode([
    'service' => 'QLBH Take Away PHP static health',
    'status' => 'running',
]);
