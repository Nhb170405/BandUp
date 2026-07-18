# M18 — Public MVP

- **Milestone ID:** M18
- **Release:** Public MVP
- **Status:** PLANNED
- **Estimate:** 24–40h

## Purpose

Triển khai phạm vi Public MVP theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Public launch có monitoring, support và rollback readiness.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-OBS

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

None explicitly mapped; use Acceptance Gate and Operations criteria.

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Cross-module

## Dependencies

M17

## Entry Criteria

M17 go.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

None — không có schema/migration trong milestone.

## Backend Tasks

None — không có backend task trong milestone.

## Frontend Tasks

None — không có frontend task trong milestone.

## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

### M18-OPS-001 — Go-live preparation

- **Objective:** Backup, capacity/budget, DNS/HTTPS, secrets, support/incident schedule.
- **Công việc cụ thể:** Backup, capacity/budget, DNS/HTTPS, secrets, support/incident schedule.
- **Dependency:** DOC-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §Go-Live
- **Verification:** Checklist signed; restore evidence current.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M18-OPS-002 — Production release

- **Objective:** Apply runbook, migration, deploy same artifact, health/smoke.
- **Công việc cụ thể:** Apply runbook, migration, deploy same artifact, health/smoke.
- **Dependency:** OPS-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Gate 6
- **Verification:** All core/commerce/admin smoke pass.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M18-OPS-003 — Launch monitoring

- **Objective:** Watch 30m+ and defined heightened window.
- **Công việc cụ thể:** Watch 30m+ and defined heightened window; capture metrics/incidents.
- **Dependency:** OPS-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-OBS-*
- **Verification:** Threshold alerts and rollback decision recorded.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

None — không có test task độc lập; task verification và gate vẫn bắt buộc.

## Documentation Tasks

### M18-DOC-001 — Scope/release freeze

- **Objective:** Confirm every P0 Verified/Accepted, known issues, version/notes/owners.
- **Công việc cụ thể:** Confirm every P0 Verified/Accepted, known issues, version/notes/owners.
- **Dependency:** M17
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** PRD §MVP criteria
- **Verification:** No orphan P0 or blocker decision.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M18-DOC-002 — Release/postmortem record

- **Objective:** Record result, deviations, issues, next actions without sensitive data.
- **Công việc cụ thể:** Record result, deviations, issues, next actions without sensitive data.
- **Dependency:** OPS-003
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §Release/Postmortem
- **Verification:** Owner acknowledges close or incident process begins.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

Gate 6/public monitoring stable.

## Rollback/Recovery Considerations

maintenance/kill switch/rollback/communications.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

24–40h

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

