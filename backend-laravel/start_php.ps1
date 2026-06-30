$phpExe = 'F:\php-8.5.7-nts-Win32-vs17-x64\php.exe'

if (-not (Test-Path $phpExe)) {
  $phpExe = 'php'
}

& $phpExe -S 127.0.0.1:8093 -t $PSScriptRoot
