# M00 — Planning Baseline

- **Milestone ID:** M00
- **Release:** Internal Alpha
- **Status:** PLANNED
- **Estimate:** 16–24h

## Purpose

Triển khai phạm vi Planning Baseline theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Bộ kế hoạch chi tiết sẵn sàng để Product Owner review; không có thay đổi ứng dụng.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

None — planning/release work is governed by roadmap and operations criteria.

## User Story IDs

None explicitly mapped in the current baseline.

## Acceptance Criteria IDs

None explicitly mapped; use Acceptance Gate and Operations criteria.

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Planning

## Dependencies

None

## Entry Criteria

sáu `.tex` khả dụng.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

code/schema/infra.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

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

### M00-DOC-001 — Inventory nguồn

- **Objective:** Đọc đủ nguồn, lập section/ID/screen inventory và repo status.
- **Công việc cụ thể:** Đọc đủ nguồn, lập section/ID/screen inventory và repo status.
- **Dependency:** None
- **Expected files/modules:** `Docs/01..06`
- **Traceability:** all IDs
- **Verification:** So khớp unique ID/count/path;
- **Definition of Done:** ghi tên overview thực tế.
- **Risk:** LaTeX escaped IDs
- **Estimate:** 4h

### M00-DOC-002 — Analysis A–L

- **Objective:** Đối chiếu product/module/dependency/conflict/gap/risk/scope.
- **Công việc cụ thể:** Đối chiếu product/module/dependency/conflict/gap/risk/scope.
- **Dependency:** 001
- **Expected files/modules:** `07`, `09`
- **Traceability:** all
- **Verification:** Review từng mục A–L có dẫn section; không tự xử lý conflict.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M00-DOC-003 — Milestone/trace

- **Objective:** Chuyển roadmap thành M00–M20, release/gate/migration/test/trace.
- **Công việc cụ thể:** Chuyển roadmap thành M00–M20, release/gate/migration/test/trace.
- **Dependency:** 001–002
- **Expected files/modules:** `07`
- **Traceability:** all P0/P1/P2
- **Verification:** Query không còn P0 orphan; dependency không vòng.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h

### M00-DOC-004 — Backlog/agent rules

- **Objective:** Viết task 2–8h, DoR/DoD và repository rules.
- **Công việc cụ thể:** Viết task 2–8h, DoR/DoD và repository rules.
- **Dependency:** 003
- **Expected files/modules:** `08`, `AGENTS.md`
- **Traceability:** Roadmap §24–28
- **Verification:** Required fields/ID uniqueness/link check.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

analysis A–L, plan/backlog/decision/agent guidance nhất quán; P0 có milestone. **Deliverable:** tài liệu review độc lập.

## Rollback/Recovery Considerations

revert file riêng.

## Risks

Xem từng task và Docs/09_Open_Decisions.md. Không vượt gate khi còn BLOCKER required-by milestone; không sửa trực tiếp ledger/balance, assessment thành công hoặc audit history để recovery.

## Estimate

16–24h

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

