@echo off
setlocal enabledelayedexpansion

:: Đặt mã hóa thành UTF-8
chcp 65001 >nul

set "source_folder=.\Entity SQL scripts"
set "output_folder=.\Full Database Scripts"

:: Tên file output
set "output_file=%output_folder%\merged_output.sql"

:: Kiểm tra nếu thư mục Full Database Scripts không tồn tại thì tạo mới
if not exist "%output_folder%" mkdir "%output_folder%"

:: Xóa file output nếu đã tồn tại
if exist "%output_file%" del "%output_file%"

for %%f in ("%source_folder%\*.sql") do (
    type "%%f" >> "%output_file%"
    echo. >> "%output_file%" 
)

echo Đã hoàn tất nối các file SQL vào %output_file%.
pause
