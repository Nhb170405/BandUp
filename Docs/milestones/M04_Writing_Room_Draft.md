# M04 — Writing Room and Draft

- **Milestone ID:** M04
- **Release:** Internal Alpha
- **Status:** PLANNED
- **Estimate:** 56–72h

## Purpose

Triển khai phạm vi Writing Room and Draft theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User viết với timer, autosave, pause và recovery không ghi đè âm thầm.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-WRITE, NFR-REL, NFR-PRIV

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

AC-WRITE

## UI Screen IDs

USER-05

## System Modules

Writing Practice

## Dependencies

M03

## Entry Criteria

selected prompt.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

submission/credit.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M04-DB-001 — Draft schema

- **Objective:** Draft owner/prompt/content/timing/status/version.
- **Công việc cụ thể:** Draft owner/prompt/content/timing/status/version; indexes/active policy.
- **Dependency:** DOC-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-WRITE-*
- **Verification:** Migration/concurrency token test. Essay never logged.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Backend Tasks

### M04-BE-001 — Draft API

- **Objective:** Create/read/autosave/pause/resume with ownership and optimistic concurrency.
- **Công việc cụ thể:** Create/read/autosave/pause/resume with ownership and optimistic concurrency.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-WRITE-001..018
- **Verification:** Integration stale-version/IDOR/pause tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

### M04-FE-001 — Editor/timer

- **Objective:** Desktop Writing Room, canonical count, timer/pause, exit warning.
- **Công việc cụ thể:** Desktop Writing Room, canonical count, timer/pause, exit warning.
- **Dependency:** DOC/BE
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** USER-05; AC-WRITE-002
- **Verification:** Component clock tests + manual keyboard/refresh.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M04-FE-002 — Autosave/recovery

- **Objective:** Debounce/idle save, visible states, retry, local recovery, conflict UI.
- **Công việc cụ thể:** Debounce/idle save, visible states, retry, local recovery, conflict UI.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-WRITE-001; UI §Autosave/Mất kết nối
- **Verification:** Fake-clock/network E2E; no silent overwrite.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

None — không có infrastructure task trong milestone.

## Security Tasks

### M04-SEC-001 — Draft privacy

- **Objective:** Log/analytics redaction, payload limits, owner checks.
- **Công việc cụ thể:** Log/analytics redaction, payload limits, owner checks.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-PRIV/SEC-*
- **Verification:** Log capture has no essay; cross-user suite passes.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Testing Tasks

### M04-TEST-001 — Two-tab/offline

- **Objective:** Automate two-tab edit, dropped responses, reload/crash recovery and loss measurement.
- **Công việc cụ thể:** Automate two-tab edit, dropped responses, reload/crash recovery and loss measurement.
- **Dependency:** FE-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-REL/UX-*
- **Verification:** Evidence ≤10s under defined test; stale tab blocked.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

### M04-DOC-001 — Draft contract

- **Objective:** Chốt word algorithm, autosave/version/conflict/offline contract.
- **Công việc cụ thể:** Chốt word algorithm, autosave/version/conflict/offline contract.
- **Dependency:** M03
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-WRITE-*; AC-WRITE-*; USER-05
- **Verification:** Examples incl. Unicode/punctuation; no unresolved merge choice.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-WRITE-001/002; no silent overwrite; ≤10s target.

## Rollback/Recovery Considerations

previous server/local copy.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

56–72h

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-WRITE-001, FR-WRITE-002, FR-WRITE-003, FR-WRITE-004, FR-WRITE-005, FR-WRITE-006, FR-WRITE-007, FR-WRITE-008, FR-WRITE-009, FR-WRITE-010, FR-WRITE-011, FR-WRITE-012, FR-WRITE-013, FR-WRITE-014, FR-WRITE-015, FR-WRITE-016, FR-WRITE-017, FR-WRITE-018.
