# Build + pack AutoLicensing NuGet packages. Does NOT push.
#
# Usage:
#   .\scripts\build.ps1            # default: Release
#   .\scripts\build.ps1 -Configuration Debug

param(
    [ValidateSet("Debug", "Release")]
    [string]$Configuration = "Release"
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$out = Join-Path $root "packages"

# 1. Build + pack all packages (GeneratePackageOnBuild is already on)
dotnet pack (Join-Path $root "AutoLicensing.slnx") -c $Configuration -o $out --nologo
if ($LASTEXITCODE -ne 0) { throw "dotnet pack failed." }

# 2. Remove the app package — only the three libraries are published
Remove-Item (Join-Path $out "AutoLicensing.Console.*.nupkg") -ErrorAction SilentlyContinue

Write-Host "Packages created in $out" -ForegroundColor Green
Get-ChildItem $out -Filter "*.nupkg" | Select-Object -ExpandProperty Name
