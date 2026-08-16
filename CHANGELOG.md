# Changelog

All notable changes to this project will be documented in this file.

## [2.3.0] - 2026-08-16

### Added
- MVC authorization filter `LicenseFeatureAuthorizationFilter` with `AddLicenseFeatureGating()` extension — runs feature checks after the action resolves, so streaming/SSE responses are never buffered regardless of middleware placement
- CI workflow publishing packages to NuGet on version tag

### Changed
- Renamed `AutoLicensingMiddleWare` → `AutoLicensingMiddleware`; namespace `AutoLicensing.AspNetCore.MiddleWares` → `AutoLicensing.AspNetCore.Middlewares`

## [2.2.0] - 2026-08-16

### Changed
- Split pack/push into `build.ps1` / `publish.ps1`
- Embedded README into NuGet packages

## [2.1.0] - 2026-08-16

### Added
- Support for .NET 10.0

## Earlier

### 2.0.0
- Support for .NET 9.0
- Middleware buffers SSE responses into a single flush
- Signed license added to license provider
- Auto product-license expiry check on license provider initialization

### 1.0.x
- Split into `AutoLicensing`, `AutoLicensing.Generator`, `AutoLicensing.AspNetCore` packages
- License factory (replaces license generator); `SignedLicense` separated from `License`
- RSA verifier + generator, key generation
- Renamed to AutoLicensing
