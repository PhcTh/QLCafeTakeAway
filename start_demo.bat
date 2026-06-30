@echo off
cd /d "%~dp0"

start "QLBH C# API" cmd /k "cd /d backend-csharp && dotnet run"
start "QLBH PHP API" cmd /k "cd /d backend-laravel && start_php.bat"
start "QLBH Vue" cmd /k "cd /d frontend-vue && npm run dev -- --host 127.0.0.1 --port 5173"

echo Da mo 3 cua so: C# API, PHP API, Vue.
echo Frontend: http://127.0.0.1:5173/
pause
