# M01 — Repository and Foundation

- **Milestone ID:** M01
- **Release:** Internal Alpha
- **Status:** PLANNED
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

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

local build/test, migration, health, Compose và CI chạy.

## Rollback/Recovery Considerations

xóa/recreate disposable dev artifacts; không có user data.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

40–56h

## Progress Checklist

- [ ] Entry Criteria verified.
- [ ] Required BLOCKER closed hoặc có owner-approved disposition.
- [ ] Tất cả task đạt Definition of Done.
- [ ] Verification và traceability pass.
- [ ] Acceptance Gate được Product Owner/reviewer chấp nhận.
- [ ] Project Status và handoff được cập nhật.

## Decision Log

- 18/07/2026 — PLANNED: giữ milestone number/scope từ master plan; chưa có implementation decision mới.

## Surprises and Discoveries

None recorded — discovery ảnh hưởng architecture, money, privacy/security hoặc scope phải vào Open Decisions trước khi tiếp tục.

## Completion Summary

Not completed. Chỉ điền evidence, commit/PR, verified requirements, residual risks và accepted deviations sau gate.

## Handoff to Next Milestone

Sau gate, cập nhật Docs/10_Project_Status.md và chuyển artifacts, decisions, migration/recovery notes, test evidence cho milestone phụ thuộc trực tiếp trong master plan. Không bắt đầu kế tiếp nếu dependency hoặc blocker còn mở.

