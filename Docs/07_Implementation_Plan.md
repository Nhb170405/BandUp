# BandUp — Implementation Master Plan

Baseline: 18/07/2026. Master navigation only; details live in milestone files and the backlog registry.

## Architecture Summary

Desktop Web-first Modular Monolith: React/TypeScript/Vite; ASP.NET Core API; PostgreSQL/EF Core; Google OIDC plus BandUp cookie; role/permission/policy/ownership; Hangfire API/Worker split; one configured OpenAI model with validated structured output; immutable credit ledger/reservation; verified payOS webhook/reconciliation; VPS Docker Compose behind Caddy/Nginx. Backend owns business rules. No microservices, Kubernetes, Kafka or mandatory Redis in MVP.

## Milestone Overview

| ID | Milestone | Purpose | Estimate | Release | Detail |
|---|---|---|---:|---|---|
| M00 | Planning Baseline | Decision-complete planning. | 2–3d | Internal Alpha | [Detail](milestones/M00_Planning_Baseline.md) |
| M01 | Repository and Foundation | Local build/test/health foundation. | 5–7d | Internal Alpha | [Detail](milestones/M01_Repository_Foundation.md) |
| M02 | Google Login and Authorization | Identity, cookie, policies, onboarding. | 7–9d | Internal Alpha | [Detail](milestones/M02_Google_Login_Authorization.md) |
| M03 | Prompt and Learner Shell | Active prompt selection. | 5–7d | Internal Alpha | [Detail](milestones/M03_Prompt_Learner_Shell.md) |
| M04 | Writing Room and Draft | Autosave, pause and conflict recovery. | 7–9d | Internal Alpha | [Detail](milestones/M04_Writing_Room_Draft.md) |
| M05 | Submission and Credit Reservation | Idempotent submit and reserve. | 7–9d | Internal Alpha | [Detail](milestones/M05_Submission_Credit_Reservation.md) |
| M06 | Hangfire and Fake Grading | Reliable async fake flow. | 6–8d | Internal Alpha | [Detail](milestones/M06_Hangfire_Fake_Grading.md) |
| M07 | OpenAI Grading | Validated versioned AI grading. | 8–10d | Internal Alpha | [Detail](milestones/M07_OpenAI_Grading.md) |
| M08 | Result Vertical Slice | Complete login-to-result slice. | 5–7d | Internal Alpha | [Detail](milestones/M08_Result_Vertical_Slice.md) |
| M09 | Model Essay and History | Approved references and history. | 5–7d | Closed Beta | [Detail](milestones/M09_Model_Essay_History.md) |
| M10 | Mistake Progress and Redo | Long-term learning loop. | 8–10d | Closed Beta | [Detail](milestones/M10_Mistake_Progress_Redo.md) |
| M11 | payOS and Wallet | Verified payment/exact-once grant. | 8–10d | Closed Beta | [Detail](milestones/M11_PayOS_Wallet.md) |
| M12 | Support and Notifications | Context-rich issue resolution. | 6–8d | Closed Beta | [Detail](milestones/M12_Support_Notifications.md) |
| M13 | Admin Portal | Least-privilege operations/audit. | 9–12d | Closed Beta | [Detail](milestones/M13_Admin_Portal.md) |
| M14 | Security Privacy and Deletion | Hardening, retention, deletion. | 8–10d | Closed Beta | [Detail](milestones/M14_Security_Privacy_Deletion.md) |
| M15 | Quality and Operational Readiness | Reliability/cost/restore evidence. | 7–10d | Closed Beta | [Detail](milestones/M15_Quality_Operational_Readiness.md) |
| M16 | VPS and Staging Deployment | Repeatable staging deployment. | 6–8d | Closed Beta | [Detail](milestones/M16_VPS_Staging_Deployment.md) |
| M17 | Closed Beta | Cohort/go-no-go evidence. | 5–8d eng. | Closed Beta | [Detail](milestones/M17_Closed_Beta.md) |
| M18 | Public MVP | Controlled public launch. | 3–5d | Public MVP | [Detail](milestones/M18_Public_MVP.md) |
| M19 | Version 1.0 | Metrics-driven stabilization. | Re-estimate | Version 1.0 | [Detail](milestones/M19_Version_1_0.md) |
| M20 | Post-MVP | Deferred discovery only. | Discovery | Post-MVP | [Detail](milestones/M20_Post_MVP.md) |

## Dependency Graph

~~~mermaid
flowchart LR
 M00-->M01-->M02-->M03-->M04-->M05-->M06-->M07-->M08
 M08-->M09-->M10
 M05-->M11-->M12
 M02-->M13
 M10-->M13
 M12-->M13-->M14-->M15-->M16-->M17-->M18-->M19-->M20
~~~

Graph is acyclic. Multi-parent dependencies and decision blockers in milestone files are authoritative.

## Critical Path

M00 → M01 → M02 → M03 → M04 → M05 → M06 → M07 → M08 → M11 → M12 → M13 → M14 → M15 → M16 → M17 → M18. M09/M10 finish before M13/Beta.

## Release Mapping

- Internal Alpha: M00–M08, core vertical slice.
- Closed Beta: M09–M17, learning differentiation, commerce, support, admin, security and operations.
- Public MVP: M00–M18, all P0 and accepted beta thresholds.
- Version 1.0: M19 after observation.
- Post-MVP: M20 discovery. Mobile, Classroom, Community, Flashcards, Gamification, multi-provider AI and advanced analytics are DEFERRED.

## Release Gates

| Gate | Evidence |
|---|---|
| Gate 1 — Foundation Ready | Build, local topology, CI, migration mechanism and health check. |
| Gate 2 — Core Writing Ready | Login, prompt, draft/autosave, fake submit and fake result. |
| Gate 3 — AI Ready | Hangfire, structured OpenAI, retry, credit and real result stable. |
| Gate 4 — Commerce Ready | Packages, signed webhook, idempotency, reconciliation and support. |
| Gate 5 — Beta Ready | Admin, security, legal, restore, monitoring and AI benchmark. |
| Gate 6 — Public Ready | Beta thresholds accepted; no P0 defect; cost/capacity/support controlled. |

## P0 Coverage Summary

| P0 area | Milestones |
|---|---|
| Login/session/authorization | M02, M14 |
| Prompt/Writing/autosave | M03–M04 |
| Submission/credit/Hangfire/grading/result | M05–M08 |
| payOS/reconciliation/support | M11–M12 |
| Basic admin/security/privacy/deletion | M13–M14 |
| Test/monitor/backup/deploy/release | M15–M18 |

Every P0 group maps to a milestone. Exact IDs are in milestone files; wildcard trace becomes exact before READY.

## Change Control

Architecture, finance, provider, privacy/security or P0 scope changes require Open Decision, owner disposition, ADR when closed, and same-PR updates to milestone/backlog/traceability/tests. Milestone numbering cannot change silently.
