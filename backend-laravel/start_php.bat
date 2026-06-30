@echo off
set PHP_EXE=F:\php-8.5.7-nts-Win32-vs17-x64\php.exe

if exist "%PHP_EXE%" (
  "%PHP_EXE%" -S 127.0.0.1:8093 -t "%~dp0"
) else (
  php -S 127.0.0.1:8093 -t "%~dp0"
)
