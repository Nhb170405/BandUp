# M10 — Mistake Progress and Redo

- **Milestone ID:** M10
- **Release:** Closed Beta
- **Status:** PLANNED
- **Estimate:** 64–80h

## Purpose

Triển khai phạm vi Mistake Progress and Redo theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User thấy lỗi, tiến bộ và làm lại bài để so sánh.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-MISTAKE, FR-PROGRESS, NFR-UX, FR-REDO, NFR-REL

## User Story IDs

US-011, US-012, US-013

## Acceptance Criteria IDs

AC-MISTAKE, AC-PROGRESS, AC-REDO

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Mistake Bank; Progress; Redo

## Dependencies

M08; M09

## Entry Criteria

M08/M09.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M10-DB-001 — Taxonomy/occurrence

- **Objective:** Version/archive taxonomy and immutable error occurrence snapshot.
- **Công việc cụ thể:** Version/archive taxonomy and immutable error occurrence snapshot.
- **Dependency:** M08
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-MISTAKE-*
- **Verification:** Unique occurrence/replay and archive tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M10-DB-002 — Redo linkage

- **Objective:** Source submission/recommendation/new attempt relationships.
- **Công việc cụ thể:** Source submission/recommendation/new attempt relationships.
- **Dependency:** M09
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-REDO-*
- **Verification:** No overwrite; owner/unique tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Backend Tasks

### M10-BE-001 — Mistake projection

- **Objective:** Idempotent assessment→occurrence and owner aggregate/detail.
- **Công việc cụ thể:** Idempotent assessment→occurrence and owner aggregate/detail.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-MISTAKE-001; US-011
- **Verification:** Replay same assessment no duplicate.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M10-BE-002 — Progress rules

- **Objective:** Aggregate overall/criteria/errors with sample-size caveat.
- **Công việc cụ thể:** Aggregate overall/criteria/errors with sample-size caveat; version rule.
- **Dependency:** M08
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-PROGRESS-*; AC-PROGRESS-001
- **Verification:** One/many/no assessment unit+integration.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M10-BE-003 — Redo service/comparison

- **Objective:** Create new flow and compare same-version-safe scores.
- **Công việc cụ thể:** Create new flow and compare same-version-safe scores.
- **Dependency:** DB-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-REDO-001/002; US-013
- **Verification:** Integration original/new/history.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

### M10-FE-001 — Mistake UI

- **Objective:** USER-11/12 filters, examples, actions and sparse states.
- **Công việc cụ thể:** USER-11/12 filters, examples, actions and sparse states.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-MISTAKE-*
- **Verification:** E2E owner/filter/detail.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M10-FE-002 — Progress UI

- **Objective:** USER-13 charts with text alternative/tooltip/empty/small-sample.
- **Công việc cụ thể:** USER-13 charts with text alternative/tooltip/empty/small-sample.
- **Dependency:** BE-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-012; NFR-UX-*
- **Verification:** Accessibility/manual chart test.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M10-FE-003 — Redo UI

- **Objective:** USER-14/15 recommendation/start/comparison states.
- **Công việc cụ thể:** USER-14/15 recommendation/start/comparison states.
- **Dependency:** BE-003
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-013
- **Verification:** E2E proactive redo and comparison.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

None — không có infrastructure task trong milestone.

## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

### M10-TEST-001 — Projection recovery

- **Objective:** Rebuild mistakes/progress from assessments and compare checksum.
- **Công việc cụ thể:** Rebuild mistakes/progress from assessments and compare checksum.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-REL-*
- **Verification:** Repeatable/no duplicates; runbook recorded.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Documentation Tasks

None — không có documentation task riêng; traceability update vẫn thuộc DoD.

## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-MISTAKE/PROGRESS/REDO.

## Rollback/Recovery Considerations

recompute projections.

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-MISTAKE-001, FR-MISTAKE-002, FR-MISTAKE-003, FR-MISTAKE-004, FR-MISTAKE-005, FR-MISTAKE-006, FR-MISTAKE-007, FR-MISTAKE-008, FR-MISTAKE-009, FR-MISTAKE-010, FR-PROGRESS-001, FR-PROGRESS-002, FR-PROGRESS-003, FR-PROGRESS-004, FR-PROGRESS-005, FR-PROGRESS-006, FR-PROGRESS-007, FR-REDO-001, FR-REDO-002, FR-REDO-003, FR-REDO-004, FR-REDO-005, FR-REDO-006.
