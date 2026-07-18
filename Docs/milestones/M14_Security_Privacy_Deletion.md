# M14 — Security Privacy and Deletion

- **Milestone ID:** M14
- **Release:** Closed Beta
- **Status:** PLANNED
- **Estimate:** 64–80h

## Purpose

Triển khai phạm vi Security Privacy and Deletion theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User có privacy/deletion flow; hệ thống hardening và retention có kiểm soát.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-PRIV, FR-SEC, NFR-SEC, FR-DELETE, NFR-PRIV, FR-LEGAL

## User Story IDs

US-017

## Acceptance Criteria IDs

AC-SEC

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Security; Identity; Analytics

## Dependencies

M13; OD-005; OD-015

## Entry Criteria

all data modules; OD-005/015.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M14-DB-001 — Deletion/retention metadata

- **Objective:** Requests/steps/tombstone/anonymization identifiers and cleanup indexes.
- **Công việc cụ thể:** Requests/steps/tombstone/anonymization identifiers and cleanup indexes.
- **Dependency:** BE design
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-DELETE/PRIV-*
- **Verification:** Unique active request; migration/recovery test.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Backend Tasks

### M14-BE-001 — Deletion workflow

- **Objective:** Re-auth request, pending/session revoke, resumable purge, finance anonymize, completion record.
- **Công việc cụ thể:** Re-auth request, pending/session revoke, resumable purge, finance anonymize, completion record.
- **Dependency:** DOC-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-DELETE-*; US-017
- **Verification:** Partial-failure/retry/idempotency integration.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

### M14-FE-001 — Privacy/legal/deletion UX

- **Objective:** PUB-03, USER-25/26 disclosure, typed confirmation, re-auth and status.
- **Công việc cụ thể:** PUB-03, USER-25/26 disclosure, typed confirmation, re-auth and status.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-LEGAL/DELETE-*
- **Verification:** E2E cancel/confirm/fail/complete; accessible copy.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

### M14-OPS-001 — Retention jobs

- **Objective:** Cleanup drafts/logs/attachments/backups metadata per matrix.
- **Công việc cụ thể:** Cleanup drafts/logs/attachments/backups metadata per matrix; dry-run/report.
- **Dependency:** DOC/DB
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-PRIV-*
- **Verification:** Clock-controlled boundary and rerun tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Security Tasks

### M14-SEC-001 — Web/API hardening

- **Objective:** CSP/security headers, CSRF/CORS/XSS, payload/rate/abuse controls and secret review.
- **Công việc cụ thể:** CSP/security headers, CSRF/CORS/XSS, payload/rate/abuse controls and secret review.
- **Dependency:** M13
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-SEC-*; NFR-SEC-*
- **Verification:** OWASP-focused automated/manual suite.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M14-SEC-002 — Privacy/log audit

- **Objective:** Scan logs/analytics/audit/support for essay, secret, excess PII.
- **Công việc cụ thể:** Scan logs/analytics/audit/support for essay, secret, excess PII.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-PRIV/OBS-*
- **Verification:** Seed canaries absent from prohibited sinks.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Testing Tasks

### M14-TEST-001 — IDOR/security regression

- **Objective:** All owner resources/admin permissions, injection and session revoke.
- **Công việc cụ thể:** All owner resources/admin permissions, injection and session revoke.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-SEC-*
- **Verification:** Negative matrix pass; findings triaged.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

### M14-DOC-001 — Retention/legal matrix

- **Objective:** Chốt data class, purpose, duration, deletion/anonymization/backup expiry and owner.
- **Công việc cụ thể:** Chốt data class, purpose, duration, deletion/anonymization/backup expiry and owner.
- **Dependency:** OD-005/015
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-PRIV/DELETE/LEGAL-*
- **Verification:** Legal/product sign-off; no unspecified financial linkage.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

security/privacy/deletion P0 and Gate 5 portion.

## Rollback/Recovery Considerations

deletion forward-only/resumable.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

64–80h

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-DELETE-001, FR-DELETE-002, FR-DELETE-003, FR-DELETE-004, FR-DELETE-005, FR-DELETE-006, FR-DELETE-007, FR-DELETE-008, FR-DELETE-009, FR-DELETE-010, FR-DELETE-011, FR-DELETE-012, FR-LAND-001, FR-LAND-002, FR-LAND-003, FR-LAND-004, FR-LAND-005, FR-LAND-006, FR-LAND-007, FR-LAND-008, FR-LAND-009, FR-LAND-010, FR-SEC-001, FR-SEC-002, FR-SEC-003, FR-SEC-004, FR-SEC-005, FR-SEC-006, FR-SEC-007, FR-SEC-008, FR-SEC-009, FR-SEC-010.
