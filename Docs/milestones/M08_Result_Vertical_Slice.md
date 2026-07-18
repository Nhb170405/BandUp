# M08 — Result Vertical Slice

- **Milestone ID:** M08
- **Release:** Internal Alpha
- **Status:** PLANNED
- **Estimate:** 40–56h

## Purpose

Triển khai phạm vi Result Vertical Slice theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User hoàn thành vertical slice từ login đến Result Page và credit terminal state.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-RESULT

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

AC-RESULT, AC-BILL

## UI Screen IDs

USER-08, USER-07

## System Modules

Grading; Credit; Notification

## Dependencies

M07

## Entry Criteria

real assessment.

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

### M08-BE-001 — Result query

- **Objective:** Owner-only structured DTO, terminal state and version metadata.
- **Công việc cụ thể:** Owner-only structured DTO, terminal state and version metadata.
- **Dependency:** M07
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-RESULT-*; AC-RESULT-001
- **Verification:** Integration owner/cross-user/incomplete.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M08-BE-002 — Atomic terminal transition

- **Objective:** Persist result + capture or terminal fail + release exactly once.
- **Công việc cụ thể:** Persist result + capture or terminal fail + release exactly once.
- **Dependency:** M07, M05
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-BILL-002/003
- **Verification:** Crash-boundary/replay transaction tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

### M08-FE-001 — Result page

- **Objective:** Overall/criteria/summary/strength/weakness/corrections/vocab/plan progressive UI.
- **Công việc cụ thể:** Overall/criteria/summary/strength/weakness/corrections/vocab/plan progressive UI.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** USER-08; USER-08 screen
- **Verification:** Component/E2E complete/partial optional fields.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M08-FE-002 — Poll/deep link

- **Objective:** Poll with bounded cadence, terminal stop, refresh/leave/return.
- **Công việc cụ thể:** Poll with bounded cadence, terminal stop, refresh/leave/return.
- **Dependency:** M06-FE/M08-BE
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** USER-07/08
- **Verification:** E2E slow/success/fail/refresh.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

None — không có infrastructure task trong milestone.

## Security Tasks

### M08-SEC-001 — Safe render

- **Objective:** Escape/sanitize AI/user markup and safe links.
- **Công việc cụ thể:** Escape/sanitize AI/user markup and safe links.
- **Dependency:** FE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-RESULT-002
- **Verification:** XSS corpus executes no script.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Testing Tasks

### M08-TEST-001 — Vertical slice gate

- **Objective:** Full browser flow with fake OIDC and provider plus staging-like DB/worker.
- **Công việc cụ thể:** Full browser flow with fake OIDC and provider plus staging-like DB/worker.
- **Dependency:** all M01–08
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Gate 2/3
- **Verification:** Video/log evidence without essay; no P0 defect.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

### M08-DOC-001 — Alpha runbook/release notes

- **Objective:** Document demo, known limits, kill/recovery.
- **Công việc cụ thể:** Document demo, known limits, kill/recovery.
- **Dependency:** TEST-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Internal Alpha
- **Verification:** Independent reviewer reproduces flow.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

Gate 3 and login→result demo.

## Rollback/Recovery Considerations

safe status/retry; no assessment overwrite.

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

## Exact P0 Requirement Coverage

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-RESULT-001, FR-RESULT-002, FR-RESULT-003, FR-RESULT-004, FR-RESULT-005, FR-RESULT-006, FR-RESULT-007, FR-RESULT-008, FR-RESULT-009, FR-RESULT-010, FR-RESULT-011, FR-RESULT-012.
