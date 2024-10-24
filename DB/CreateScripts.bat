@echo off
:: Thay đổi mã hóa thành UTF-8
chcp 65001 >nul

:: Chạy PowerShell script với quyền chạy file .ps1
powershell -ExecutionPolicy Bypass -File "merge_sql_files.ps1"

pause
