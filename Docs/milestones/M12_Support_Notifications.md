# M12 — Support and Notifications

- **Milestone ID:** M12
- **Release:** Closed Beta
- **Status:** PLANNED
- **Estimate:** 48–64h

## Purpose

Triển khai phạm vi Support and Notifications theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User nhận thông báo và xử lý sự cố qua ticket có context.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-SUPPORT, FR-NOTIFY, NFR-PRIV

## User Story IDs

US-016

## Acceptance Criteria IDs

AC-SUPPORT

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Support; Notification

## Dependencies

M08; M11; OD-004

## Entry Criteria

grading/payment contexts; OD-004.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M12-DB-001 — Support schema

- **Objective:** Tickets/messages/context links/resolution and notification/delivery tables.
- **Công việc cụ thể:** Tickets/messages/context links/resolution and notification/delivery tables.
- **Dependency:** M08/M11
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-SUPPORT/NOTIFY-*
- **Verification:** Ownership/status/idempotency constraints.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Backend Tasks

### M12-BE-001 — User ticket API

- **Objective:** Create/list/detail/reply with allowed submission/payment links and categories.
- **Công việc cụ thể:** Create/list/detail/reply with allowed submission/payment links and categories.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-SUPPORT-001; US-016
- **Verification:** IDOR/link ownership/status tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M12-BE-002 — Resolution service

- **Objective:** Re-grade/refund/reject routed to module services with permission/reason/audit.
- **Công việc cụ thể:** Re-grade/refund/reject routed to module services with permission/reason/audit.
- **Dependency:** BE-001, M05/M11
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-SUPPORT-002
- **Verification:** No auto-refund quality dispute; duplicate action safe.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M12-BE-003 — Notification pipeline

- **Objective:** In-app events for grading/payment/ticket.
- **Công việc cụ thể:** In-app events for grading/payment/ticket; idempotent delivery.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-NOTIFY-*
- **Verification:** Replay and unread/read integration.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Frontend Tasks

### M12-FE-001 — Support UI

- **Objective:** USER-22/23 create/list/conversation/status/resolution.
- **Công việc cụ thể:** USER-22/23 create/list/conversation/status/resolution.
- **Dependency:** BE-001/002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-016
- **Verification:** E2E failed grading/payment/quality cases.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M12-FE-002 — Notification UI

- **Objective:** USER-21 badge/list/deep link/error states.
- **Công việc cụ thể:** USER-21 badge/list/deep link/error states.
- **Dependency:** BE-003
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-NOTIFY-*
- **Verification:** Component/E2E replay does not duplicate.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

None — không có infrastructure task trong milestone.

## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

### M12-TEST-001 — Support permission audit

- **Objective:** User/admin roles, essay privacy, refund/regrade trace.
- **Công việc cụ thể:** User/admin roles, essay privacy, refund/regrade trace.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-PRIV/SEC-*
- **Verification:** Least-privilege matrix and audit record verified.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Documentation Tasks

None — không có documentation task riêng; traceability update vẫn thuộc DoD.

## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-SUPPORT-001/002.

## Rollback/Recovery Considerations

disable external delivery; retain in-app record.

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

## Exact P0 Requirement Coverage

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-SUPPORT-001, FR-SUPPORT-002, FR-SUPPORT-003, FR-SUPPORT-004, FR-SUPPORT-005, FR-SUPPORT-006, FR-SUPPORT-007, FR-SUPPORT-008, FR-SUPPORT-009, FR-SUPPORT-010, FR-SUPPORT-011, FR-SUPPORT-012.
