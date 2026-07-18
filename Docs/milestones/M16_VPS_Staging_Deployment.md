# M16 — VPS and Staging Deployment

- **Milestone ID:** M16
- **Release:** Closed Beta
- **Status:** PLANNED
- **Estimate:** 48–64h

## Purpose

Triển khai phạm vi VPS and Staging Deployment theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Staging production-like deploy/rollback lặp lại được.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

NFR-MAINT

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

None explicitly mapped; use Acceptance Gate and Operations criteria.

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Infrastructure; Operations

## Dependencies

M15; OD-016

## Entry Criteria

M15; OD-016.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M16-DB-001 — Migration/rollback pipeline

- **Objective:** Backup, migrate-before-compatible-app, expand/contract and failure stop.
- **Công việc cụ thể:** Backup, migrate-before-compatible-app, expand/contract and failure stop.
- **Dependency:** OPS-004
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §Migration/Rollback
- **Verification:** Staging upgrade/app rollback/forward-fix rehearsal.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Backend Tasks

None — không có backend task trong milestone.

## Frontend Tasks

None — không có frontend task trong milestone.

## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

### M16-OPS-001 — Production images

- **Objective:** Reproducible non-root Web/API/Worker images, pinned runtime, health.
- **Công việc cụ thể:** Reproducible non-root Web/API/Worker images, pinned runtime, health.
- **Dependency:** M15
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-MAINT/SEC-*
- **Verification:** Image scan, immutable tag, local run.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M16-OPS-002 — Staging Compose/proxy

- **Objective:** Separate services, Caddy HTTPS/same-origin, networks/volumes/key ring.
- **Công việc cụ thể:** Separate services, Caddy HTTPS/same-origin, networks/volumes/key ring.
- **Dependency:** OPS-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** System §VPS; Ops §Compose
- **Verification:** Fresh VPS-like staging deploy and restart persistence.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M16-OPS-003 — Environment/secrets

- **Objective:** Dev/Staging/Prod config contract, secret injection/rotation checklist.
- **Công việc cụ thể:** Dev/Staging/Prod config contract, secret injection/rotation checklist.
- **Dependency:** OPS-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §Configuration
- **Verification:** Secret scan; missing config fails safely.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M16-OPS-004 — CI/CD deploy

- **Objective:** Versioned artifact, staging deploy, approval production flow, release record.
- **Công việc cụ thể:** Versioned artifact, staging deploy, approval production flow, release record.
- **Dependency:** OPS-001..003
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Roadmap §Git/CI
- **Verification:** Repeat deploy same artifact; no rebuild drift.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

### M16-TEST-001 — Staging smoke

- **Objective:** Login, prompt, autosave, submit, worker, result, payment sandbox, credit/support/admin.
- **Công việc cụ thể:** Login, prompt, autosave, submit, worker, result, payment sandbox, credit/support/admin.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops Release Checklist
- **Verification:** Automated/manual signed evidence.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

### M16-DOC-001 — Deployment runbook

- **Objective:** DNS/HTTPS/firewall/release/rollback/restore/access steps.
- **Công việc cụ thể:** DNS/HTTPS/firewall/release/rollback/restore/access steps.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §Go-Live
- **Verification:** Independent dry run; no secret values.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

Operations Acceptance Criteria on staging.

## Rollback/Recovery Considerations

versioned rollback/backup/forward-fix.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

48–64h

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

