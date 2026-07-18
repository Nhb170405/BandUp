# M19 — Version 1.0

- **Milestone ID:** M19
- **Release:** Version 1.0
- **Status:** PLANNED
- **Estimate:** 4h + 8h + TBD + 8h

## Purpose

Triển khai phạm vi Version 1.0 theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Chỉ các P1 được metrics chứng minh được hoàn thiện.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

NFR-UX

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

None explicitly mapped; use Acceptance Gate and Operations criteria.

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Cross-module

## Dependencies

M18

## Entry Criteria

Public MVP observation and frozen metric-driven scope.

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

None — không có backend task trong milestone.

## Frontend Tasks

None — không có frontend task trong milestone.

## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

None — không có infrastructure task trong milestone.

## Security Tasks

None — không có security task riêng; DoD bảo mật chung vẫn bắt buộc.

## Testing Tasks

### M19-TEST-001 — Accessibility audit

- **Objective:** WCAG 2.
- **Công việc cụ thể:** WCAG 2.1 AA audit of primary flows and remediation backlog.
- **Dependency:** scope
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-UX-*; UI §Accessibility
- **Verification:** Keyboard/screen-reader/contrast report.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M19-TEST-002 — V1 regression/release

- **Objective:** Full P0 + selected P1 regression, performance and release gate.
- **Công việc cụ thể:** Full P0 + selected P1 regression, performance and release gate.
- **Dependency:** slices
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** exact IDs
- **Verification:** No regression and release evidence.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

### M19-DOC-001 — Evidence-based scope

- **Objective:** Rank accessibility/performance/admin KPI/email/UX work from metrics.
- **Công việc cụ thể:** Rank accessibility/performance/admin KPI/email/UX work from metrics; explicitly reject unmeasured scope.
- **Dependency:** M18
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** P1 requirements
- **Verification:** Owner-approved bounded list and estimates.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h

### M19-DEV-001 — Selected P1 slices

- **Objective:** Implement only approved slices as separate 2–8h tasks generated from DOC-001.
- **Công việc cụ thể:** Implement only approved slices as separate 2–8h tasks generated from DOC-001.
- **Dependency:** DOC-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** exact IDs TBD
- **Verification:** Each slice receives full task record before Ready.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** TBD


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

selected P1/regression gate.

## Rollback/Recovery Considerations

feature flags/revert. Estimate only after selection.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

4h + 8h + TBD + 8h

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

