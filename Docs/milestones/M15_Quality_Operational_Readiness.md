# M15 — Quality and Operational Readiness

- **Milestone ID:** M15
- **Release:** Closed Beta
- **Status:** PLANNED
- **Estimate:** 56–80h

## Purpose

Triển khai phạm vi Quality and Operational Readiness theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Có bằng chứng reliability, performance, cost, backup và restore.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

NFR-PERF, FR-OBS, NFR-OBS, NFR-REL, NFR-SEC

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

AC-AI

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Operations; Security; Analytics

## Dependencies

M08; M11; M14; OD-006; OD-008

## Entry Criteria

core/commerce/privacy complete; OD-006/008.

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

### M15-OPS-001 — Observability/alerts

- **Objective:** Structured metrics/dashboards/alerts for API/DB/jobs/AI/payment/product.
- **Công việc cụ thể:** Structured metrics/dashboards/alerts for API/DB/jobs/AI/payment/product.
- **Dependency:** M13
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-OBS-*; NFR-OBS-*
- **Verification:** Synthetic fault triggers actionable alert without sensitive data.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M15-OPS-002 — Backup/restore rehearsal

- **Objective:** Offsite encrypted backup and isolated full restore with evidence.
- **Công việc cụ thể:** Offsite encrypted backup and isolated full restore with evidence.
- **Dependency:** OD-006
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-REL/PRIV-*; Ops §Backup
- **Verification:** Measured RPO/RTO, checksum and smoke.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M15-OPS-003 — Reconciliation/recovery

- **Objective:** Credit/payment/orphan reservation/stale job/deletion health reports.
- **Công việc cụ thể:** Credit/payment/orphan reservation/stale job/deletion health reports.
- **Dependency:** M11/M14
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-REL-*
- **Verification:** Inject mismatch then repair safely/audited.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Security Tasks

### M15-SEC-001 — Security review

- **Objective:** Dependency scan, auth/config/admin/provider threat review and remediation.
- **Công việc cụ thể:** Dependency scan, auth/config/admin/provider threat review and remediation.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-SEC-*
- **Verification:** No critical/high unaccepted finding.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Testing Tasks

### M15-TEST-001 — Regression matrix

- **Objective:** Consolidate unit/integration/E2E/auth/transaction/security/smoke CI tiers.
- **Công việc cụ thể:** Consolidate unit/integration/E2E/auth/transaction/security/smoke CI tiers.
- **Dependency:** M14
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** all P0 AC
- **Verification:** Trace report has no P0 orphan; stable retry policy.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M15-TEST-002 — Load/concurrency

- **Objective:** Autosave, submit, last-credit, worker concurrency, webhook and reads under target load.
- **Công việc cụ thể:** Autosave, submit, last-credit, worker concurrency, webhook and reads under target load.
- **Dependency:** OD-008
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-PERF/REL-*
- **Verification:** p95/error/DB/queue baseline recorded.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M15-TEST-003 — AI benchmark gate

- **Objective:** Blind/reviewer golden run, schema/retry/cost/latency report.
- **Công việc cụ thể:** Blind/reviewer golden run, schema/retry/cost/latency report.
- **Dependency:** M07
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-AI-*
- **Verification:** Owner accepts threshold/model/version.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

### M15-DOC-001 — Runbook catalog

- **Objective:** Incident, AI outage, missing credit, rollback, restore, deletion and escalation.
- **Công việc cụ thể:** Incident, AI outage, missing credit, rollback, restore, deletion and escalation.
- **Dependency:** OPS tasks
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §Runbook
- **Verification:** Tabletop top scenarios; owner/contact assigned.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

Beta evidence, measured restore/performance/cost.

## Rollback/Recovery Considerations

disposable/sanitized tests.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

56–80h

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

## Exact P0 Requirement Coverage

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-ANALYTICS-001, FR-ANALYTICS-002, FR-ANALYTICS-003, FR-ANALYTICS-004, FR-ANALYTICS-005.
