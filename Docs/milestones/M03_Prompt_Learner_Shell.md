# M03 — Prompt and Learner Shell

- **Milestone ID:** M03
- **Release:** Internal Alpha
- **Status:** PLANNED
- **Estimate:** 40–56h

## Purpose

Triển khai phạm vi Prompt and Learner Shell theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User duyệt, lọc, chọn hoặc random đề active.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-PROMPT, FR-DASH

## User Story IDs

US-004, US-018

## Acceptance Criteria IDs

AC-PROMPT

## UI Screen IDs

USER-03, USER-02

## System Modules

Writing Content; User Profile

## Dependencies

M02

## Entry Criteria

M02.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

model essay/full CMS.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M03-DB-001 — Prompt schema

- **Objective:** Prompts/tags/status/publish fields.
- **Công việc cụ thể:** Prompts/tags/status/publish fields; unique PromptNumber and active indexes.
- **Dependency:** M02
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-PROMPT-*; WritingContent
- **Verification:** Migration constraint/query plan tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Backend Tasks

### M03-BE-001 — Prompt queries

- **Objective:** Paginated filter/detail/random active-only.
- **Công việc cụ thể:** Paginated filter/detail/random active-only; avoid near repeat when possible.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-PROMPT-001..011; AC-PROMPT-001/002; US-004/005
- **Verification:** Unit random policy + integration active/archived.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M03-BE-002 — Controlled content seed

- **Objective:** Small reviewed prompt dataset and repeatable seed/update rule.
- **Công việc cụ thể:** Small reviewed prompt dataset and repeatable seed/update rule.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** UI USER-03/04
- **Verification:** Seed twice stable; source/review recorded.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Frontend Tasks

### M03-FE-001 — Learner shell/dashboard

- **Objective:** App nav and dashboard next-action/new-user states.
- **Công việc cụ thể:** App nav and dashboard next-action/new-user states.
- **Dependency:** M02-FE
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-DASH-*; USER-02
- **Verification:** Component/manual UX/accessibility states.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M03-FE-002 — Prompt library/detail

- **Objective:** Filters, pagination, random, detail, empty/error/loading.
- **Công việc cụ thể:** Filters, pagination, random, detail, empty/error/loading.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** USER-03/04
- **Verification:** E2E select/random/archived unavailable.
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

### M03-TEST-001 — Content acceptance

- **Objective:** Permission, active-only, deterministic test fixtures, UI flow.
- **Công việc cụ thể:** Permission, active-only, deterministic test fixtures, UI flow.
- **Dependency:** all M03
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-PROMPT-*
- **Verification:** Gate evidence and trace updated.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Documentation Tasks

### M03-DOC-001 — Content workflow

- **Objective:** Document PromptNumber/status/seed/archive/review.
- **Công việc cụ thể:** Document PromptNumber/status/seed/archive/review.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-018 future admin
- **Verification:** Reviewer can publish seed without SQL.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-PROMPT-001/002 and authenticated learner reaches active prompt.

## Rollback/Recovery Considerations

archive used content.

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-DASH-001, FR-DASH-002, FR-DASH-003, FR-DASH-004, FR-DASH-005, FR-DASH-006, FR-DASH-007, FR-DASH-008, FR-DASH-009, FR-DASH-010, FR-PROMPT-001, FR-PROMPT-002, FR-PROMPT-003, FR-PROMPT-004, FR-PROMPT-005, FR-PROMPT-006, FR-PROMPT-007, FR-PROMPT-008, FR-PROMPT-009, FR-PROMPT-010, FR-PROMPT-011.
