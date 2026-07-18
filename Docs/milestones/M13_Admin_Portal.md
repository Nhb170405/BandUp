# M13 — Admin Portal

- **Milestone ID:** M13
- **Release:** Closed Beta
- **Status:** PLANNED
- **Estimate:** 72–96h; split PRs by task

## Purpose

Triển khai phạm vi Admin Portal theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Admin vận hành theo permission và mọi action nhạy cảm được audit.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-ADMIN, NFR-SEC

## User Story IDs

US-021, US-018, US-019

## Acceptance Criteria IDs

AC-ADMIN

## UI Screen IDs

ADM-01, ADM-02..07, ADM-08..13, ADM-14, ADM-22

## System Modules

Admin; Security; Analytics

## Dependencies

M02; M03; M07; M11; M12; OD-011; OD-012

## Entry Criteria

M02/03/07/11/12; OD-011/012.

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

### M13-BE-001 — Admin query boundary

- **Objective:** Permission-filtered dashboard/user activity.
- **Công việc cụ thể:** Permission-filtered dashboard/user activity; essays closed by default.
- **Dependency:** M02
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-ADMIN-*; AC-ADMIN-001
- **Verification:** Query/API direct access matrix.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M13-BE-002 — Content commands

- **Objective:** Prompt/model/taxonomy draft-review-publish-archive via module services.
- **Công việc cụ thể:** Prompt/model/taxonomy draft-review-publish-archive via module services.
- **Dependency:** M03/M09/M10
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-018; ADM-02..07
- **Verification:** Permission/status/version/audit integration.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M13-BE-003 — User/finance/support actions

- **Objective:** Scoped detail, credit adjustment, payment/refund and ticket orchestration.
- **Công việc cụ thể:** Scoped detail, credit adjustment, payment/refund and ticket orchestration.
- **Dependency:** M11/M12
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-019/020; ADM-08..13/16/17
- **Verification:** Reason/permission/idempotency/audit tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M13-BE-004 — AI/settings/security actions

- **Objective:** Failure view, kill switch/settings version, session revoke/security event.
- **Công việc cụ thể:** Failure view, kill switch/settings version, session revoke/security event.
- **Dependency:** M07/M02
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-ADMIN-002/003; ADM-14/15/18..21
- **Verification:** Concurrent setting/version/audit and revoke tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M13-BE-005 — Role/permission management

- **Objective:** Multi-role membership and preview.
- **Công việc cụ thể:** Multi-role membership and preview; Super Admin-only administration.
- **Dependency:** OD-011
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** ADM-22/23
- **Verification:** Union-of-permissions, last-admin safety and audit.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

### M13-FE-001 — Admin shell/dashboard

- **Objective:** Permission-aware nav, action alerts and minimal KPIs.
- **Công việc cụ thể:** Permission-aware nav, action alerts and minimal KPIs.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** ADM-01; US-021
- **Verification:** E2E multi-role menu plus direct-route denial.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M13-FE-002 — Content UI

- **Objective:** Lists/editors with validation/status/confirmation.
- **Công việc cụ thể:** Lists/editors with validation/status/confirmation.
- **Dependency:** BE-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** ADM-02..07
- **Verification:** Manual/E2E publish/archive.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M13-FE-003 — User/finance/support UI

- **Objective:** Required lists/details/actions.
- **Công việc cụ thể:** Required lists/details/actions; sensitive fields gated.
- **Dependency:** BE-003
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** ADM-08..13/16/17
- **Verification:** Role-specific E2E; essay not auto-open.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M13-FE-004 — Ops/security UI

- **Objective:** AI usage/failure, settings, security/audit screens in P0 cut.
- **Công việc cụ thể:** AI usage/failure, settings, security/audit screens in P0 cut.
- **Dependency:** BE-004
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** ADM-14/15/18..21
- **Verification:** Permission/confirmation/manual incident flow.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M13-FE-005 — Accounts/roles UI

- **Objective:** Account list, role assignment, permission matrix preview.
- **Công việc cụ thể:** Account list, role assignment, permission matrix preview.
- **Dependency:** BE-005
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** UI §Admin Accounts
- **Verification:** E2E multiple users/roles/direct API denial.
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

### M13-TEST-001 — Admin acceptance

- **Objective:** Full role/action/privacy matrix and AC-ADMIN suite.
- **Công việc cụ thể:** Full role/action/privacy matrix and AC-ADMIN suite.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-SEC/PRIV-*
- **Verification:** No unauthorized data/action; every sensitive success audited.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

None — không có documentation task riêng; traceability update vẫn thuộc DoD.

## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-ADMIN-001..003 and basic-admin P0.

## Rollback/Recovery Considerations

per-surface feature flags.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

72–96h; split PRs by task

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-ADMIN-001, FR-ADMIN-002, FR-ADMIN-003, FR-ADMIN-004, FR-ADMIN-005, FR-ADMIN-006, FR-ADMIN-007, FR-ADMIN-008, FR-ADMIN-009, FR-ADMIN-010, FR-ADMIN-011, FR-ADMIN-012, FR-ADMIN-013, FR-ADMIN-014.
