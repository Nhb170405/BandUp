# M11 — payOS and Wallet

- **Milestone ID:** M11
- **Release:** Closed Beta
- **Status:** PLANNED
- **Estimate:** 64–80h

## Purpose

Triển khai phạm vi payOS and Wallet theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User mua credit qua VietQR; chỉ payment verified cộng credit một lần.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-BILL, NFR-REL

## User Story IDs

US-015, US-014

## Acceptance Criteria IDs

AC-PAY

## UI Screen IDs

USER-17

## System Modules

Payment; Credit

## Dependencies

M05; OD-003; OD-004

## Entry Criteria

Credit module; OD-003/004.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M11-DB-001 — Payment schema

- **Objective:** Packages/orders/events/grants/refunds with provider uniques and snapshots.
- **Công việc cụ thể:** Packages/orders/events/grants/refunds with provider uniques and snapshots.
- **Dependency:** DOC-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-BILL-*
- **Verification:** Duplicate event/grant constraints and migration test.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Backend Tasks

### M11-BE-001 — payOS adapter/checkout

- **Objective:** Create order/QR, secret handling, configured URLs.
- **Công việc cụ thể:** Create order/QR, secret handling, configured URLs; no grant on return.
- **Dependency:** DB-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-015; USER-17/18
- **Verification:** Sandbox/stub contract and amount snapshot tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M11-BE-002 — Signed webhook

- **Objective:** Verify raw signature before parse trust, idempotent state/grant transaction, audit event.
- **Công việc cụ thể:** Verify raw signature before parse trust, idempotent state/grant transaction, audit event.
- **Dependency:** BE-001, M05 Credit
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-PAY-001/002
- **Verification:** valid/invalid/duplicate/concurrent webhook tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M11-BE-003 — Reconciliation

- **Objective:** Query provider backend, resolve pending/mismatch safely, scheduled retry/alert.
- **Công việc cụ thể:** Query provider backend, resolve pending/mismatch safely, scheduled retry/alert.
- **Dependency:** BE-001/002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §Payment reconciliation
- **Verification:** Stub outage/late paid/mismatch/replay tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

### M11-FE-001 — Wallet/packages/checkout

- **Objective:** USER-16.
- **Công việc cụ thể:** USER-16..20 balances/history/package/QR/pending/result; return is display-only.
- **Dependency:** BE-001..003
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-014/015; AC-PAY-003
- **Verification:** E2E pending→paid/expired and spoofed return.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

### M11-OPS-001 — Commerce runbook

- **Objective:** Disable checkout, investigate missing credit, reconcile and compensate with audit.
- **Công việc cụ thể:** Disable checkout, investigate missing credit, reconcile and compensate with audit.
- **Dependency:** TEST-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §payOS/Credit
- **Verification:** Tabletop sandbox case completed.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

### M11-TEST-001 — Payment race suite

- **Objective:** Event ordering, duplicate provider ID, webhook+reconcile concurrency and ledger checksum.
- **Công việc cụ thể:** Event ordering, duplicate provider ID, webhook+reconcile concurrency and ledger checksum.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-PAY-*; NFR-REL/SEC-*
- **Verification:** Credit granted exactly once in every interleaving.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

### M11-DOC-001 — Payment state/contract

- **Objective:** Chốt package snapshot, amount/order/event, late/expiry/refund/reconcile transitions.
- **Công việc cụ thể:** Chốt package snapshot, amount/order/event, late/expiry/refund/reconcile transitions.
- **Dependency:** OD-003/004
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-BILL-*; System §payOS
- **Verification:** Transition table covers out-of-order events.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-PAY-001..003 and Gate 4 commerce.

## Rollback/Recovery Considerations

disable checkout/reconcile/compensate.

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-BILL-001, FR-BILL-002, FR-BILL-003, FR-BILL-004, FR-BILL-005, FR-BILL-006, FR-BILL-007, FR-BILL-008, FR-BILL-009, FR-BILL-010, FR-BILL-011, FR-BILL-012, FR-BILL-013, FR-BILL-014, FR-BILL-015, FR-BILL-016, FR-BILL-017, FR-BILL-018, FR-BILL-019, FR-BILL-020.
