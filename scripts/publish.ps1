# Publish AutoLicensing packages to nuget.org.
#
# Usage:
#   .\scripts\publish.ps1                  # push current packages
#   .\scripts\publish.ps1 -Version 2.3.0   # bump, build, pack, push
#
# Uses the NuGet login already stored in NuGet.Config via `dotnet nuget login`,
# or the push is delegated to GitHub Actions (trusted publishing):
#   git tag v2.3.0 && git push origin v2.3.0
# Push is permanent: same version + same package ID cannot be re-uploaded.

param(
    [Parameter(Mandatory = $false)]
    [string]$Version
)

$ErrorActionPreference = "Stop"
$root = Split-Path -Parent $PSScriptRoot
$out = Join-Path $root "packages"
$source = "https://api.nuget.org/v3/index.json"

if ($Version) {
    # Bump version in all three csproj
    Get-ChildItem (Join-Path $root "src") -Recurse -Filter "*.csproj" |
        Where-Object { $_.FullName -notmatch "Console" } |
        ForEach-Object {
            $content = Get-Content $_.FullName -Raw
            $content = [regex]::Replace($content, '<Version>[^<]+</Version>', "<Version>$Version</Version>")
            $content = [regex]::Replace($content, '<AssemblyVersion>[^<]+</AssemblyVersion>', "<AssemblyVersion>$Version</AssemblyVersion>")
            $content = [regex]::Replace($content, '<FileVersion>[^<]+</FileVersion>', "<FileVersion>$Version</FileVersion>")
            Set-Content $_.FullName $content -NoNewline
        }
    Write-Host "Version bumped to $Version" -ForegroundColor Yellow
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
    dotnet nuget push $file.FullName --source $source
    if ($LASTEXITCODE -ne 0) { throw "Push failed for $($file.Name)." }
}

Write-Host "All packages pushed." -ForegroundColor Green
