# Publish AutoLicensing packages to nuget.org.
#
# Usage:
#   .\scripts\publish.ps1                              # uses $env:NUGET_API_KEY
#   .\scripts\publish.ps1 -ApiKey <your-api-key>
#
# Get an API key at https://www.nuget.org/account/apikeys
# Push is permanent: same version + same package ID cannot be re-uploaded.

param(
    [Parameter(Mandatory = $false)]
    [string]$ApiKey = $env:NUGET_API_KEY
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$out = Join-Path $root "packages"
$source = "https://api.nuget.org/v3/index.json"

if ([string]::IsNullOrWhiteSpace($ApiKey)) {
    throw "No API key. Set env var NUGET_API_KEY or pass -ApiKey."
}

# 1. Build + pack the library packages
& (Join-Path $PSScriptRoot "build.ps1")
if ($LASTEXITCODE -ne 0) { throw "Pack failed." }

# 2. Push the library packages
$packages = @(
    "AutoLicensing.*.nupkg",
    "AutoLicensing.Generator.*.nupkg",
    "AutoLicensing.AspNetCore.*.nupkg"
)

foreach ($pattern in $packages) {
    $file = Get-ChildItem $out -Filter $pattern | Sort-Object LastWriteTime -Descending | Select-Object -First 1
    if (-not $file) { throw "Package not found: $pattern" }

    Write-Host "Pushing $($file.Name) ..." -ForegroundColor Yellow
    dotnet nuget push $file.FullName --api-key $ApiKey --source $source
    if ($LASTEXITCODE -ne 0) { throw "Push failed for $($file.Name)." }
}

Write-Host "All packages pushed." -ForegroundColor Green


PAUSE