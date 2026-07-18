# M20 — Post-MVP

- **Milestone ID:** M20
- **Release:** Post-MVP
- **Status:** PLANNED
- **Estimate:** 1d + 1d + 1d

## Purpose

Triển khai phạm vi Post-MVP theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Discovery riêng cho mobile/classroom/community/provider; chưa tự động triển khai.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

None — planning/release work is governed by roadmap and operations criteria.

## User Story IDs

US-022

## Acceptance Criteria IDs

None explicitly mapped; use Acceptance Gate and Operations criteria.

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Future discovery

## Dependencies

M19

## Entry Criteria

Web stable and separate business case.

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

None — không có test task độc lập; task verification và gate vẫn bắt buộc.

## Documentation Tasks

### M20-DOC-001 — Mobile discovery

- **Objective:** Validate mobile jobs, shared API/auth/security and Web stability prerequisites.
- **Công việc cụ thể:** Validate mobile jobs, shared API/auth/security and Web stability prerequisites.
- **Dependency:** M19
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** P2; Roadmap §Mobile
- **Verification:** Research decision; no app scaffold.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 1d

### M20-DOC-002 — Classroom/community discovery

- **Objective:** Validate personas, moderation/privacy/business model and module impact.
- **Công việc cụ thể:** Validate personas, moderation/privacy/business model and module impact.
- **Dependency:** M19
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** P2 future
- **Verification:** Separate PRD/architecture proposal.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 1d

### M20-DOC-003 — Provider/analytics discovery

- **Objective:** Use incident/cost evidence before multi-provider/advanced analytics.
- **Công việc cụ thể:** Use incident/cost evidence before multi-provider/advanced analytics.
- **Dependency:** M19 metrics
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-022/P2
- **Verification:** ADR only if measured benefit exceeds complexity.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 1d


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

discovery decision, not automatic implementation.

## Rollback/Recovery Considerations

no production mutation during discovery.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

1d + 1d + 1d

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

