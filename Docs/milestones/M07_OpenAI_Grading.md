# M07 — OpenAI Grading

- **Milestone ID:** M07
- **Release:** Internal Alpha
- **Status:** PLANNED
- **Estimate:** 64–80h

## Purpose

Triển khai phạm vi OpenAI Grading theo master plan, giữ module boundary, traceability và release gate.

## User-visible Outcome

Bài được chấm bởi OpenAI với structured output đã validate.

## Source Documents

AGENTS.md; Docs/01_BandUp_Overview.tex; Docs/02_Product_Requirements.tex; Docs/03_UI_UX_Design.tex; Docs/04_System_Design.tex; Docs/05_Development_Roadmap.tex; Docs/06_Operations.tex; Docs/07_Implementation_Plan.md; Docs/08_Milestone_Backlog.md; Docs/09_Open_Decisions.md.

## Requirement IDs

FR-AI, NFR-SCALE, NFR-SEC, NFR-PERF

## User Story IDs

US-022

## Acceptance Criteria IDs

AC-AI, AC-ADMIN

## UI Screen IDs

None — no direct UI screen is introduced.

## System Modules

Grading; Security

## Dependencies

M06; OD-001; OD-002

## Entry Criteria

M06; OD-001/002 closed.

## Current Repository Context

M00 documentation exists; application code is not started. Verify Project Status, branch, completed predecessors and affected decisions before execution. This document does not authorize early implementation.

## In Scope

All tasks below and only behavior required by the Acceptance Gate.

## Out of Scope

Ngoài phạm vi master plan.. Mobile App, Teacher Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED unless M20 discovery.

## Technical Decisions đã chốt

Desktop Web-first; Modular Monolith; backend-owned rules; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire; structured AI output; ledger/reservation; verified payOS webhook; VPS/Compose; no secret or essay logging. Exception requires Open Decision/ADR.

## Database Changes

### M07-DB-001 — Version/usage schema

- **Objective:** PromptVersions, schema/model/version, token/cost/latency metadata.
- **Công việc cụ thể:** PromptVersions, schema/model/version, token/cost/latency metadata.
- **Dependency:** DOC-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-AI/OBS-*
- **Verification:** Immutable version and correlation constraints.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Backend Tasks

### M07-BE-001 — OpenAI adapter

- **Objective:** Typed request/response, timeouts, secrets, model config.
- **Công việc cụ thể:** Typed request/response, timeouts, secrets, model config; no domain SDK dependency.
- **Dependency:** DOC/DB
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** US-022; NFR-SCALE-*
- **Verification:** Contract tests with stub; key/payload absent logs.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M07-BE-002 — Structured validator

- **Objective:** Parse/schema/business-range validation and safe mapping.
- **Công việc cụ thể:** Parse/schema/business-range validation and safe mapping.
- **Dependency:** BE-001
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-AI-001/003
- **Verification:** Invalid/missing/extra/range fixture suite.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h

### M07-BE-003 — Retry/circuit/kill

- **Objective:** Transient ≤3, one corrective retry, permanent fail, budget and kill switch.
- **Công việc cụ thể:** Transient ≤3, one corrective retry, permanent fail, budget and kill switch.
- **Dependency:** BE-002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-AI-002..004, AC-ADMIN-002
- **Verification:** Fake provider 429/5xx/4xx/timeout sequences.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Frontend Tasks

None — không có frontend task trong milestone.

## Worker/Background Tasks

None — không có Worker/background task riêng.

## Infrastructure Tasks

### M07-OPS-001 — Provider runbook

- **Objective:** Incident, key rotate, budget alert, prompt rollback procedure.
- **Công việc cụ thể:** Incident, key rotate, budget alert, prompt rollback procedure.
- **Dependency:** BE-003/TEST
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** Ops §OpenAI
- **Verification:** Tabletop drill; no raw essay in evidence.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 4h


## Security Tasks

### M07-SEC-001 — Injection/data controls

- **Objective:** Delimit essay as untrusted content, output sanitization boundary, redacted telemetry.
- **Công việc cụ thể:** Delimit essay as untrusted content, output sanitization boundary, redacted telemetry.
- **Dependency:** BE-001/002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** AC-AI-005; NFR-SEC/PRIV-*
- **Verification:** Adversarial golden tests and log inspection.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 6h


## Testing Tasks

### M07-TEST-001 — Benchmark

- **Objective:** Run golden set.
- **Công việc cụ thể:** Run golden set; record schema pass, latency, cost, reviewer quality baseline.
- **Dependency:** all
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** NFR-PERF/OBS-*
- **Verification:** Meets owner threshold; model/version recorded.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Documentation Tasks

### M07-DOC-001 — Rubric/schema/golden set

- **Objective:** Version rubric, prompt, JSON schema and benchmark fixtures.
- **Công việc cụ thể:** Version rubric, prompt, JSON schema and benchmark fixtures.
- **Dependency:** OD-001/002
- **Expected files/modules:** Module nêu trong System Modules; path chính xác được xác nhận khi task Ready.
- **Traceability:** FR-AI-*; AC-AI-*
- **Verification:** Owner review; representative/injection cases.
- **Definition of Done:** Đạt verification và DoD chung trong AGENTS.md; cập nhật traceability/tài liệu.
- **Risk:** Thay đổi phạm vi hoặc boundary; dừng và cập nhật Decision Log/Open Decisions nếu phát hiện.
- **Estimate:** 8h


## Verification Commands

Not available until M01. Repository chưa có build/test command hợp lệ; không tự bịa lệnh. Khi M01 hoàn tất, thay bằng commands CI thực sự dùng. Trước đó chỉ review tài liệu, ID, dependency, traceability và acceptance evidence.

## Acceptance Gate

AC-AI-001..005 and kill switch.

## Rollback/Recovery Considerations

disable provider/queue; preserve or release by policy.

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

Milestone này chịu trách nhiệm ánh xạ và verification các P0 sau: FR-AI-001, FR-AI-002, FR-AI-003, FR-AI-004, FR-AI-005, FR-AI-006, FR-AI-007, FR-AI-008, FR-AI-009, FR-AI-010, FR-AI-011, FR-AI-012, FR-AI-013, FR-AI-014, FR-AI-015, FR-AI-016, FR-AI-017, FR-AI-018, FR-AI-019, FR-AI-020.
