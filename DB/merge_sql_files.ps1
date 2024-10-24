$sourceFolder = ".\Entity SQL scripts"
$outputFolder = ".\Full Database Scripts"
$outputFile = "$outputFolder\create_view_proc_func.sql"

# Create output folder if it doesn't exist
if (-Not (Test-Path $outputFolder)) {
    New-Item -Path $outputFolder -ItemType Directory
}

# Delete output file if it already exists
if (Test-Path $outputFile) {
    Remove-Item $outputFile
}

# Get all .sql files from the source folder
Get-ChildItem -Path $sourceFolder -Filter *.sql | ForEach-Object {
    # Append the content of each file to the output file with UTF-8 encoding
    Get-Content $_.FullName | Out-File -Append -Encoding utf8 $outputFile
    Add-Content $outputFile "`n"  # Add a newline after each file
}

Write-Host "Successfully merged SQL files into $outputFile."
