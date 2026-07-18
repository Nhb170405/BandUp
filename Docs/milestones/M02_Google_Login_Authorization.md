# M02 — Google Login and Authorization

- **Milestone ID:** M02
- **Release:** Internal Alpha
- **Status:** PLANNED
- **Estimate:** 56–72h

## Purpose

Triển khai phạm vi Google Login and Authorization theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

User đăng nhập Google, có local account/session an toàn và onboarding.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-AUTH, NFR-SEC, FR-ADMIN

## User Story IDs

US-002, US-003

## Acceptance Criteria IDs

AC-AUTH, AC-DASH

## UI Screen IDs

AUTH-01, AUTH-01..03, USER-01

## System Modules

Identity; User Profile

## Dependencies

M01; OD-009; OD-010

## Entry Criteria

Gate 1; OD-009/010 resolved.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

full admin portal.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M02-DB-001 — Identity schema

- **Objective:** Users, ExternalLogins, Roles, Permissions, joins, Profiles.
- **Công việc cụ thể:** Users, ExternalLogins, Roles, Permissions, joins, Profiles; unique issuer+subject and join keys.
- **Dependency:** M01-DB
- **Expected files/modules:** Identity/Profile
- **Traceability:** FR-AUTH-003/005/009..015
- **Verification:** Migration/invariant tests. Risk: email-based linking forbidden.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** email-based linking forbidden
- **Estimate:** 8h


## Backend Tasks

### M02-BE-001 — OIDC login

- **Objective:** Challenge/callback, verified email policy, unique local user/link.
- **Công việc cụ thể:** Challenge/callback, verified email policy, unique local user/link.
- **Dependency:** DB-001, OD-009
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-AUTH-001..005/016; AC-AUTH-001/002; US-002; AUTH-01/02
- **Verification:** Fake OIDC integration; repeat callback no duplicate.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M02-BE-002 — Policy/ownership

- **Objective:** Role-permission claims/policies, USER/admin/owner checks, account status.
- **Công việc cụ thể:** Role-permission claims/policies, USER/admin/owner checks, account status.
- **Dependency:** DB-001
- **Expected files/modules:** Identity
- **Traceability:** FR-AUTH-009..013; AC-AUTH-003/004
- **Verification:** Permission matrix + cross-user IDOR tests.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M02-BE-003 — Profile/onboarding API

- **Objective:** Read/update learning profile with optional/validated fields.
- **Công việc cụ thể:** Read/update learning profile with optional/validated fields.
- **Dependency:** BE-001/002
- **Expected files/modules:** Profile
- **Traceability:** FR-AUTH-014; AC-DASH-001; US-003
- **Verification:** Integration validation/ownership.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Frontend Tasks

### M02-FE-001 — Auth/onboarding UI

- **Objective:** Login/callback/error/logout/onboarding/profile and permission-aware nav.
- **Công việc cụ thể:** Login/callback/error/logout/onboarding/profile and permission-aware nav.
- **Dependency:** BE-001..003
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AUTH-01..03, USER-01/24
- **Verification:** E2E first/repeat/blocked login; onboarding skip; UI states.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

None — không có infrastructure task trong milestone.

## Security Tasks

### M02-SEC-001 — Cookie/session/CSRF

- **Objective:** Secure/HttpOnly/SameSite, expiry/revoke, data-protection persistence plan, antiforgery.
- **Công việc cụ thể:** Secure/HttpOnly/SameSite, expiry/revoke, data-protection persistence plan, antiforgery.
- **Dependency:** BE-001, OD-010
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-AUTH-006..008; NFR-SEC-*
- **Verification:** Header/cookie/CSRF integration; logout invalidates session.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M02-SEC-002 — Admin bootstrap

- **Objective:** Versioned permission catalog and one-time Super Admin procedure with audit.
- **Công việc cụ thể:** Versioned permission catalog and one-time Super Admin procedure with audit.
- **Dependency:** BE-002, OD-011
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** UI §Roles/Permissions; FR-ADMIN-*
- **Verification:** Bootstrap twice is safe; secret not persisted/logged.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Testing Tasks

### M02-TEST-001 — Auth security suite

- **Objective:** Consolidate OIDC/cookie/CSRF/session/role/ownership negative cases.
- **Công việc cụ thể:** Consolidate OIDC/cookie/CSRF/session/role/ownership negative cases.
- **Dependency:** all M02
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-AUTH-*; NFR-SEC-*
- **Verification:** Suite passes against PostgreSQL; direct admin URL/API denied.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Documentation Tasks

None — không có documentation task riêng; traceability update vẫn thuộc DoD.

## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-AUTH-001..004, AC-DASH-001.

## Rollback/Recovery Considerations

disable auth route; additive schema only.

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-AUTH-001, FR-AUTH-002, FR-AUTH-003, FR-AUTH-004, FR-AUTH-005, FR-AUTH-006, FR-AUTH-007, FR-AUTH-008, FR-AUTH-009, FR-AUTH-010, FR-AUTH-011, FR-AUTH-012, FR-AUTH-013, FR-AUTH-014, FR-AUTH-015, FR-AUTH-016.
