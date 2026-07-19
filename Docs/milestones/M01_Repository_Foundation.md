# M01 — Repository and Foundation

- **Milestone ID:** M01
- **Release:** Internal Alpha
- **Status:** GATE PENDING
- **Estimate:** 40–56h

## Purpose

Triển khai phạm vi Repository and Foundation theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Developer có skeleton local build/test và health check chạy được.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

NFR-MAINT, FR-COMPAT, NFR-UX, NFR-REL

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

None explicitly mapped; use Acceptance Gate and Operations criteria.

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Foundation

## Dependencies

M00

## Entry Criteria

M00; stack không còn blocker.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

feature/auth thật.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M01-DB-001 — PostgreSQL bootstrap

- **Objective:** EF/Npgsql, dev DB, migration convention, readiness.
- **Công việc cụ thể:** EF/Npgsql, dev DB, migration convention, readiness.
- **Dependency:** BE-001
- **Expected files/modules:** Persistence
- **Traceability:** NFR-REL/MAINT-*
- **Verification:** Empty DB migrate/up smoke; no business tables/seed.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Backend Tasks

### M01-BE-001 — Minimal solution

- **Objective:** Tạo API, Contracts, SharedKernel tối thiểu, Modules/Infrastructure boundary.
- **Công việc cụ thể:** Tạo API, Contracts, SharedKernel tối thiểu, Modules/Infrastructure boundary; config validation/Problem Details.
- **Dependency:** M00
- **Expected files/modules:** `src/*`
- **Traceability:** NFR-MAINT-*, FR-COMPAT-*
- **Verification:** Build + architecture dependency test.
- **Definition of Done:** không project explosion.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

### M01-FE-001 — Web shell

- **Objective:** React/TS/Vite shell, routing, API client boundary, error/loading primitives.
- **Công việc cụ thể:** React/TS/Vite shell, routing, API client boundary, error/loading primitives.
- **Dependency:** M00
- **Expected files/modules:** `apps/web`
- **Traceability:** NFR-UX/COMPAT-*, UI §Component/Global states
- **Verification:** Typecheck/lint/component smoke; keyboard baseline.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

### M01-OPS-001 — Local Compose

- **Objective:** Web/API/Postgres dev topology, env example, volumes and health.
- **Công việc cụ thể:** Web/API/Postgres dev topology, env example, volumes and health.
- **Dependency:** BE/FE/DB
- **Expected files/modules:** `deploy`
- **Traceability:** System §Topology; Ops §Environments
- **Verification:** Fresh clone-style start and health smoke. No secret committed.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M01-OPS-002 — CI baseline

- **Objective:** Build/type/lint/test/migration validation.
- **Công việc cụ thể:** Build/type/lint/test/migration validation; artifact conventions.
- **Dependency:** TEST-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-MAINT-*
- **Verification:** Clean pipeline pass; cache must not hide failures.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

### M01-TEST-001 — Test harness

- **Objective:** Unit/integration/architecture/E2E skeleton with isolated DB.
- **Công việc cụ thể:** Unit/integration/architecture/E2E skeleton with isolated DB.
- **Dependency:** BE/FE/DB
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Roadmap Gate 1
- **Verification:** Deliberate failing sample proves runners, then remove sample.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Documentation Tasks

### M01-DOC-001 — Commands/ADR

- **Objective:** README/AGENTS real commands, ADR stack/repo boundary.
- **Công việc cụ thể:** README/AGENTS real commands, ADR stack/repo boundary.
- **Dependency:** all M01
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** System §Decisions
- **Verification:** Commands copied from CI and rerun locally.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Verification Commands

```powershell
dotnet tool restore
dotnet restore BandUp.sln
dotnet build BandUp.sln -c Release --no-restore
dotnet test BandUp.sln -c Release --no-build
Push-Location apps/web
npm.cmd ci
npm.cmd run lint
npm.cmd test
npm.cmd run build
npm.cmd audit --audit-level=high
Pop-Location
docker compose --env-file .env -f deploy/compose.yml config
docker compose --env-file .env -f deploy/compose.yml up -d --build
```

Sau khi đặt `ConnectionStrings__Database`, chạy `dotnet ef database update --project src/BandUp.Infrastructure --startup-project src/BandUp.Api --configuration Release`, rồi kiểm tra Web, `/health/live` và `/health/ready`.

## Acceptance Gate

local build/test, migration, health, Compose và CI chạy.

## Rollback/Recovery Considerations

xóa/recreate disposable dev artifacts; không có user data.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

40–56h

## Progress Checklist

- [x] Entry Criteria verified; yêu cầu thực hiện M01 là owner approval cho M00.
- [x] Không có BLOCKER required-by M01.
- [x] M01-BE-001, M01-FE-001, M01-DB-001 hoàn tất.
- [x] M01-OPS-001, M01-TEST-001, M01-OPS-002, M01-DOC-001 hoàn tất.
- [x] Build, tests, migration, health, Compose và local CI-equivalent verification pass.
- [ ] Acceptance Gate đạt; local gate pass nhưng hosted GitHub Actions chưa chạy vì thay đổi chưa được push/PR.

## Decision Log

- 18/07/2026 — PLANNED: giữ milestone number/scope từ master plan; chưa có implementation decision mới.
- 18/07/2026 — ACCEPTED: yêu cầu trực tiếp triển khai M01 xác nhận M00 đã được owner approve dù Project Status chưa cập nhật.
- 18/07/2026 — ACCEPTED ADR-0001: .NET 8 feature-band roll-forward, five-assembly structure; Worker hoãn M06.
- 18/07/2026 — ACCEPTED: pin đồng bộ EF Core/dotnet-ef và Npgsql 8.0.11; Vite 8.1.5, Vitest 4.1.10, TypeScript 5.9.3.
- 18/07/2026 — ACCEPTED: Compose Web mặc định 5174, override bằng `WEB_PORT`; không can thiệp dịch vụ khác dùng 5173.

## Surprises and Discoveries

- Project Status còn ở M00 dù M00 đã merge; owner request M01 là approval evidence.
- PowerShell chặn `npm.ps1`; `npm.cmd` hoạt động mà không đổi execution policy.
- Dependency baseline cũ có npm advisory critical/high; nâng Vite/Vitest và audit còn 0 vulnerability.
- Npgsql và EF Core cần cùng baseline 8.0.11 để tránh assembly conflict.
- Biến `ConnectionStrings__Database` đặt cho migration trên host có độ ưu tiên cao hơn `.env` của Compose; phải xóa biến này trước khi dựng stack để API dùng DNS nội bộ `database`.
- Container SDK ở feature band mới hơn local; `latestFeature` cần cho local/container build.
- Thiếu `.dockerignore` làm context khoảng 173 MB; sau bổ sung còn khoảng 25 KB.
- ASP.NET runtime image không có `wget`; dùng `curl` health probe.
- Port 5173 bị stack ngoài BandUp dùng; Compose Web chuyển 5174 thay vì dừng dịch vụ ngoài phạm vi.
- `WebApplicationFactory` cần connection-string environment được đặt trước host creation vì API fail-fast ở startup; test đã được sửa và pass trong lần verification có exit-code enforcement.
- NuGet audit phát hiện transitive advisory High từ baseline EF/MvcTesting cũ; nâng test/framework packages, pin EF/Npgsql tương thích và yêu cầu vulnerability scan sạch trước Gate 1.

## Completion Summary

Implementation completed 18/07/2026; milestone chưa đóng do hosted CI chưa chạy. Bảy M01 tasks DONE. Backend Release build đạt 0 warning/0 error; architecture tests 2/2 và API integration test 1/1 pass. Empty Foundation migration được tạo và áp dụng vào PostgreSQL 16. Frontend lint, component test 1/1, production build, npm audit 0 vulnerability và NuGet vulnerability scan sạch. Compose builds Web/API; PostgreSQL và API healthy; Web/live/ready smoke đều HTTP 200.

Hosted GitHub Actions cần commit/push/PR nên chưa chạy trong local session; workflow mirror các command local đã pass. Acceptance Gate chỉ được đóng sau một hosted run thành công.

## Handoff to Next Milestone

M02 nhận solution/web/API foundation, PostgreSQL migration mechanism, health endpoints, Compose và CI workflow. Trước M02 phải đóng OD-009 (session/re-auth/account linking) và OD-010 (CSRF); chưa tạo Identity schema hoặc Google configuration.

