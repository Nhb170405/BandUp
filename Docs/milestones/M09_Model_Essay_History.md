# M09 — Model Essay and History

- **Milestone ID:** M09
- **Release:** Closed Beta
- **Status:** PLANNED
- **Estimate:** 40–56h

## Purpose

Triển khai phạm vi Model Essay and History theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User xem lịch sử và bài mẫu approved.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-MODEL, FR-HISTORY

## User Story IDs

US-010, US-007

## Acceptance Criteria IDs

AC-MODEL

## UI Screen IDs

USER-08

## System Modules

Writing Content; Writing Practice

## Dependencies

M08

## Entry Criteria

M08.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M09-DB-001 — Model essay/version

- **Objective:** ModelEssays with prompt, approval, source/license/version.
- **Công việc cụ thể:** ModelEssays with prompt, approval, source/license/version.
- **Dependency:** M03
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-MODEL-*
- **Verification:** One active-approved policy; archive test.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Backend Tasks

### M09-BE-001 — Approved model query

- **Objective:** Return approved-only reference content.
- **Công việc cụ thể:** Return approved-only reference content.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-MODEL-001; US-010
- **Verification:** Draft/inactive never leaks.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h

### M09-BE-002 — History queries

- **Objective:** Owner pagination/filter/status/detail with prompt snapshot.
- **Công việc cụ thể:** Owner pagination/filter/status/detail with prompt snapshot.
- **Dependency:** M08
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-HISTORY-*
- **Verification:** Query/index and cross-user integration.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Frontend Tasks

### M09-FE-001 — Model essay UI

- **Objective:** Result/detail reference section with source/license note.
- **Công việc cụ thể:** Result/detail reference section with source/license note.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** USER-08/04
- **Verification:** Manual UX/accessibility and approved-only E2E.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M09-FE-002 — History/detail UI

- **Objective:** USER-09/10 loading/empty/error/filter/deep link.
- **Công việc cụ thể:** USER-09/10 loading/empty/error/filter/deep link.
- **Dependency:** BE-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-007/008
- **Verification:** Browser pagination/filter/owner.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

None — không có infrastructure task trong milestone.

## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

### M09-TEST-001 — Content/history acceptance

- **Objective:** Archive prompt/model, old submission visibility, safe rendering.
- **Công việc cụ thể:** Archive prompt/model, old submission visibility, safe rendering.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-MODEL-001
- **Verification:** Regression pass; no mutable history.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Documentation Tasks

### M09-DOC-001 — Review/license workflow

- **Objective:** Define approval/source/license/archive process.
- **Công việc cụ thể:** Define approval/source/license/archive process.
- **Dependency:** DB/BE
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-MODEL-*
- **Verification:** Reviewer checklist complete.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-MODEL-001; USER-09/10 usable.

## Rollback/Recovery Considerations

archive/version.

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-HISTORY-001, FR-HISTORY-002, FR-HISTORY-003, FR-HISTORY-004, FR-HISTORY-005, FR-HISTORY-006, FR-MODEL-001, FR-MODEL-002, FR-MODEL-003, FR-MODEL-004, FR-MODEL-005, FR-MODEL-006.
