# ADR-0001 — Foundation Structure and Toolchain

- **Status:** Accepted
- **Date:** 18/07/2026
- **Milestone:** M01

## Context

BandUp cần foundation đủ nhỏ cho solo developer nhưng giữ Modular Monolith boundaries. M01 không triển khai Identity, Worker hoặc business feature.

## Decision

- Dùng .NET 8 với `global.json` baseline 8.0.300 và `latestFeature` để local SDK 8.0.302 và container SDK 8.0.4xx cùng build.
- Bắt đầu với API, Contracts, SharedKernel, Modules và Infrastructure; chưa tách mỗi module thành project.
- Pin đồng bộ EF Core/dotnet-ef và Npgsql provider ở 8.0.11; các gói test/framework dùng bản vá .NET 8 mới nhất tương thích. NuGet scan không còn advisory đã biết.
- Frontend là React/Vite shell trong `apps/web`; không có business rule.
- Worker hoãn đúng M06. Compose M01 chỉ gồm Web, API và PostgreSQL.
- `/health/live` không phụ thuộc database; `/health/ready` kiểm tra database.
- Compose Web host port mặc định 5174, override bằng `WEB_PORT`.

## Consequences

Foundation đơn giản và boundary có architecture test. Assembly/provider abstraction mới cần evidence/ADR. API image cài `curl` cho health probe; `.dockerignore` giữ build context nhỏ.
