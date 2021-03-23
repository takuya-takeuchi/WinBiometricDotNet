$Current = $PSScriptRoot

$WinBiometricDotNetRoot = Split-Path $Current -Parent
$SourceRoot = Join-Path $WinBiometricDotNetRoot sources
$WinBiometricDotNetProjectRoot = Join-Path $SourceRoot WinBiometricDotNet
$DocumentDir = Join-Path $WinBiometricDotNetProjectRoot docfx
$Json = Join-Path $Current docfx.json

docfx "${Json}" --serve
Set-Location $Current