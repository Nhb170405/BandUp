# M06 — Hangfire and Fake Grading

- **Milestone ID:** M06
- **Release:** Internal Alpha
- **Status:** PLANNED
- **Estimate:** 48–64h

## Purpose

Triển khai phạm vi Hangfire and Fake Grading theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Luồng async fake grading chạy qua Worker và chịu retry/replay.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

NFR-REL, FR-AI, FR-SUB

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

AC-BILL, AC-SUB

## UI Screen IDs

USER-07

## System Modules

Grading; Credit; Writing Practice

## Dependencies

M05; OD-017

## Entry Criteria

queued submission.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M06-DB-001 — Grading attempt/assessment

- **Objective:** Attempts and assessment skeleton.
- **Công việc cụ thể:** Attempts and assessment skeleton; unique attempt and successful assessment.
- **Dependency:** OPS-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-AI-*
- **Verification:** Migration/unique race tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Backend Tasks

None — không có backend task trong milestone.

## Frontend Tasks

### M06-FE-001 — Async polling states

- **Objective:** QUEUED/PROCESSING/COMPLETED/FAILED copy and leave/return behavior.
- **Công việc cụ thể:** QUEUED/PROCESSING/COMPLETED/FAILED copy and leave/return behavior.
- **Dependency:** BE-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** USER-07; UI §Submission Status
- **Verification:** E2E background completion/failure.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Worker/Background Tasks

### M06-OPS-001 — Worker/Hangfire storage spike

- **Objective:** Add Worker host, PostgreSQL storage, queue/config/dashboard auth stub.
- **Công việc cụ thể:** Add Worker host, PostgreSQL storage, queue/config/dashboard auth stub.
- **Dependency:** M05, OD-017
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** System §Hangfire; NFR-REL-*
- **Verification:** Enqueue/restart/multi-worker/lock integration; blocker if fails.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M06-BE-001 — Job contract/enqueue

- **Objective:** Identifier-only job args and after-commit enqueue/recovery strategy.
- **Công việc cụ thể:** Identifier-only job args and after-commit enqueue/recovery strategy.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-SUB/AI-*
- **Verification:** API/Worker serialization contract and lost-enqueue recovery test.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M06-BE-002 — Fake grader pipeline

- **Objective:** State checks, deterministic structured result, save then consume.
- **Công việc cụ thể:** State checks, deterministic structured result, save then consume; terminal release.
- **Dependency:** BE-001, M05 Credit
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-BILL-002/003
- **Verification:** Duplicate executions yield one result/transition.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M06-OPS-002 — Retry/recovery jobs

- **Objective:** Bounded retry, stale reservation/submission scan, alert categories.
- **Công việc cụ thể:** Bounded retry, stale reservation/submission scan, alert categories.
- **Dependency:** BE-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-REL/OBS-*
- **Verification:** Timeout/restart/dead job fault tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Infrastructure Tasks

None — không có infrastructure task trong milestone.

## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

### M06-TEST-001 — Replay suite

- **Objective:** Concurrent duplicate, retry after save, worker crash boundaries.
- **Công việc cụ thể:** Concurrent duplicate, retry after save, worker crash boundaries.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-SUB-004; BR invariants
- **Verification:** Assessment and credit exactly once.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

None — không có documentation task riêng; traceability update vẫn thuộc DoD.

## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

fake async exactly-once logical result; OD-017 passed.

## Rollback/Recovery Considerations

pause/requeue by ID.

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

