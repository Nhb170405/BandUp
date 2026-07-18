# M05 — Submission and Credit Reservation

- **Milestone ID:** M05
- **Release:** Internal Alpha
- **Status:** PLANNED
- **Estimate:** 56–72h

## Purpose

Triển khai phạm vi Submission and Credit Reservation theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User submit idempotent và credit được reserve nguyên tử.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-BILL, FR-SUB, NFR-REL

## User Story IDs

US-007

## Acceptance Criteria IDs

AC-BILL, AC-SUB

## UI Screen IDs

USER-06

## System Modules

Writing Practice; Credit

## Dependencies

M04

## Entry Criteria

saved draft.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M05-DB-001 — Ledger/wallet schema

- **Objective:** Wallet, append-only transactions, reservations.
- **Công việc cụ thể:** Wallet, append-only transactions, reservations; unique refs/check constraints.
- **Dependency:** DOC-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-BILL-*; AC-BILL-001
- **Verification:** Migration + invariant/reconciliation queries.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M05-DB-002 — Submission/idempotency schema

- **Objective:** Submission snapshot/status/request key and one reservation relation.
- **Công việc cụ thể:** Submission snapshot/status/request key and one reservation relation.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-SUB-*
- **Verification:** Unique request race test.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Backend Tasks

### M05-BE-001 — Credit service

- **Objective:** Grant/reserve/consume/release APIs with transaction and idempotency.
- **Công việc cụ thể:** Grant/reserve/consume/release APIs with transaction and idempotency.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-BILL-*; AC-BILL-001..003
- **Verification:** Unit transitions + concurrent last-credit integration.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M05-BE-002 — Submit transaction

- **Objective:** Validate owner/word/AI gate, reserve+submission atomically, return status.
- **Công việc cụ thể:** Validate owner/word/AI gate, reserve+submission atomically, return status.
- **Dependency:** BE-001/DB-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-SUB-*; AC-SUB-001..004; US-007/014
- **Verification:** <200/200–249/valid/double submit/rollback tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

### M05-FE-001 — Submit/status/wallet basic

- **Objective:** Confirmation, warnings, insufficient credit, disable duplicate click, status shell.
- **Công việc cụ thể:** Confirmation, warnings, insufficient credit, disable duplicate click, status shell.
- **Dependency:** BE-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** USER-06/07/16
- **Verification:** E2E all AC-SUB cases; server remains authoritative.
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

### M05-TEST-001 — Transaction/concurrency

- **Objective:** Fault injection between reserve/submission and parallel retry.
- **Công việc cụ thể:** Fault injection between reserve/submission and parallel retry.
- **Dependency:** all M05
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-REL-*
- **Verification:** No orphan/negative/duplicate; reconciliation clean.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Documentation Tasks

### M05-DOC-001 — State/invariant spec

- **Objective:** Finalize submission/reservation transitions, idempotency and lock order.
- **Công việc cụ thể:** Finalize submission/reservation transitions, idempotency and lock order.
- **Dependency:** M04
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** BR credit/submission; System §State/Reserve
- **Verification:** Transition table covers retries/terminal states.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h

### M05-DOC-002 — Recovery runbook draft

- **Objective:** Detect/release orphan reservation without ledger edits.
- **Công việc cụ thể:** Detect/release orphan reservation without ledger edits.
- **Dependency:** TEST-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §Credit
- **Verification:** Dry-run query and audited procedure documented.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-SUB-001..004, AC-BILL-001 and balanced ledger.

## Rollback/Recovery Considerations

explicit idempotent release.

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-SUB-001, FR-SUB-002, FR-SUB-003, FR-SUB-004, FR-SUB-005, FR-SUB-006, FR-SUB-007, FR-SUB-008, FR-SUB-009, FR-SUB-010, FR-SUB-011, FR-SUB-012.
