$targets = @(
   "WinBiometricDotNet"
)

$ScriptPath = $PSScriptRoot
$WinBiometricDotNetRoot = Split-Path $ScriptPath -Parent

$source = Join-Path $WinBiometricDotNetRoot sources | `
          Join-Path -ChildPath WinBiometricDotNet
dotnet restore ${source}
dotnet build -c Release ${source}

foreach ($target in $targets)
{
   pwsh CreatePackage.ps1 $target
}