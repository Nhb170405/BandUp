# BandUp — Milestone Backlog Registry

Baseline: 18/07/2026. Cập nhật trạng thái: 19/07/2026 sau M01 hosted CI [run 29682097093](https://github.com/Nhb170405/BandUp/actions/runs/29682097093). Registry tổng hợp; task detail và DoD nằm trong file milestone được link.

## Status Model

PLANNED → READY → IN PROGRESS → BLOCKED hoặc DONE. M00 giữ PLANNED cho đến Product Owner approval. Không task application nào được bắt đầu trong M00.

## Task Registry

| Task ID | Title | Milestone | Direct Dependency | Estimate | Status | Traceability |
|---|---|---|---|---:|---|---|
| M00-DOC-001 | Inventory nguồn | [M00](milestones/M00_Planning_Baseline.md) | None | 4h | DONE | all IDs |
| M00-DOC-002 | Analysis A–L | [M00](milestones/M00_Planning_Baseline.md) | 001 | 6h | DONE | all |
| M00-DOC-003 | Milestone/trace | [M00](milestones/M00_Planning_Baseline.md) | 001–002 | 6h | DONE | all P0/P1/P2 |
| M00-DOC-004 | Backlog/agent rules | [M00](milestones/M00_Planning_Baseline.md) | 003 | 4h | DONE | Roadmap §24–28 |
| M01-BE-001 | Minimal solution | [M01](milestones/M01_Repository_Foundation.md) | M00 | 8h | DONE | NFR-MAINT-*, FR-COMPAT-* |
| M01-FE-001 | Web shell | [M01](milestones/M01_Repository_Foundation.md) | M00 | 8h | DONE | NFR-UX/COMPAT-*, UI §Component/Global states |
| M01-DB-001 | PostgreSQL bootstrap | [M01](milestones/M01_Repository_Foundation.md) | BE-001 | 6h | DONE | NFR-REL/MAINT-* |
| M01-OPS-001 | Local Compose | [M01](milestones/M01_Repository_Foundation.md) | BE/FE/DB | 8h | DONE | System §Topology; Ops §Environments |
| M01-TEST-001 | Test harness | [M01](milestones/M01_Repository_Foundation.md) | BE/FE/DB | 6h | DONE | Roadmap Gate 1 |
| M01-OPS-002 | CI baseline | [M01](milestones/M01_Repository_Foundation.md) | TEST-001 | 6h | DONE | NFR-MAINT-* |
| M01-DOC-001 | Commands/ADR | [M01](milestones/M01_Repository_Foundation.md) | all M01 | 4h | DONE | System §Decisions |
| M02-DB-001 | Identity schema | [M02](milestones/M02_Google_Login_Authorization.md) | M01-DB | 8h | PLANNED | FR-AUTH-003/005/009..015 |
| M02-BE-001 | OIDC login | [M02](milestones/M02_Google_Login_Authorization.md) | DB-001, OD-009 | 8h | PLANNED | FR-AUTH-001..005/016; AC-AUTH-001/002; US-002; AUTH-01/02 |
| M02-SEC-001 | Cookie/session/CSRF | [M02](milestones/M02_Google_Login_Authorization.md) | BE-001, OD-010 | 8h | PLANNED | FR-AUTH-006..008; NFR-SEC-* |
| M02-BE-002 | Policy/ownership | [M02](milestones/M02_Google_Login_Authorization.md) | DB-001 | 8h | PLANNED | FR-AUTH-009..013; AC-AUTH-003/004 |
| M02-BE-003 | Profile/onboarding API | [M02](milestones/M02_Google_Login_Authorization.md) | BE-001/002 | 6h | PLANNED | FR-AUTH-014; AC-DASH-001; US-003 |
| M02-FE-001 | Auth/onboarding UI | [M02](milestones/M02_Google_Login_Authorization.md) | BE-001..003 | 8h | PLANNED | AUTH-01..03, USER-01/24 |
| M02-SEC-002 | Admin bootstrap | [M02](milestones/M02_Google_Login_Authorization.md) | BE-002, OD-011 | 6h | PLANNED | UI §Roles/Permissions; FR-ADMIN-* |
| M02-TEST-001 | Auth security suite | [M02](milestones/M02_Google_Login_Authorization.md) | all M02 | 6h | PLANNED | AC-AUTH-*; NFR-SEC-* |
| M03-DB-001 | Prompt schema | [M03](milestones/M03_Prompt_Learner_Shell.md) | M02 | 6h | PLANNED | FR-PROMPT-*; WritingContent |
| M03-BE-001 | Prompt queries | [M03](milestones/M03_Prompt_Learner_Shell.md) | DB-001 | 8h | PLANNED | FR-PROMPT-001..011; AC-PROMPT-001/002; US-004/005 |
| M03-BE-002 | Controlled content seed | [M03](milestones/M03_Prompt_Learner_Shell.md) | DB-001 | 4h | PLANNED | UI USER-03/04 |
| M03-FE-001 | Learner shell/dashboard | [M03](milestones/M03_Prompt_Learner_Shell.md) | M02-FE | 6h | PLANNED | FR-DASH-*; USER-02 |
| M03-FE-002 | Prompt library/detail | [M03](milestones/M03_Prompt_Learner_Shell.md) | BE-001 | 8h | PLANNED | USER-03/04 |
| M03-TEST-001 | Content acceptance | [M03](milestones/M03_Prompt_Learner_Shell.md) | all M03 | 4h | PLANNED | AC-PROMPT-* |
| M03-DOC-001 | Content workflow | [M03](milestones/M03_Prompt_Learner_Shell.md) | all | 4h | PLANNED | US-018 future admin |
| M04-DOC-001 | Draft contract | [M04](milestones/M04_Writing_Room_Draft.md) | M03 | 4h | PLANNED | FR-WRITE-*; AC-WRITE-*; USER-05 |
| M04-DB-001 | Draft schema | [M04](milestones/M04_Writing_Room_Draft.md) | DOC-001 | 6h | PLANNED | FR-WRITE-* |
| M04-BE-001 | Draft API | [M04](milestones/M04_Writing_Room_Draft.md) | DB-001 | 8h | PLANNED | FR-WRITE-001..018 |
| M04-FE-001 | Editor/timer | [M04](milestones/M04_Writing_Room_Draft.md) | DOC/BE | 8h | PLANNED | USER-05; AC-WRITE-002 |
| M04-FE-002 | Autosave/recovery | [M04](milestones/M04_Writing_Room_Draft.md) | BE-001 | 8h | PLANNED | AC-WRITE-001; UI §Autosave/Mất kết nối |
| M04-TEST-001 | Two-tab/offline | [M04](milestones/M04_Writing_Room_Draft.md) | FE-002 | 8h | PLANNED | NFR-REL/UX-* |
| M04-SEC-001 | Draft privacy | [M04](milestones/M04_Writing_Room_Draft.md) | BE-001 | 4h | PLANNED | NFR-PRIV/SEC-* |
| M05-DOC-001 | State/invariant spec | [M05](milestones/M05_Submission_Credit_Reservation.md) | M04 | 4h | PLANNED | BR credit/submission; System §State/Reserve |
| M05-DB-001 | Ledger/wallet schema | [M05](milestones/M05_Submission_Credit_Reservation.md) | DOC-001 | 8h | PLANNED | FR-BILL-*; AC-BILL-001 |
| M05-DB-002 | Submission/idempotency schema | [M05](milestones/M05_Submission_Credit_Reservation.md) | DB-001 | 6h | PLANNED | FR-SUB-* |
| M05-BE-001 | Credit service | [M05](milestones/M05_Submission_Credit_Reservation.md) | DB-001 | 8h | PLANNED | FR-BILL-*; AC-BILL-001..003 |
| M05-BE-002 | Submit transaction | [M05](milestones/M05_Submission_Credit_Reservation.md) | BE-001/DB-002 | 8h | PLANNED | FR-SUB-*; AC-SUB-001..004; US-007/014 |
| M05-FE-001 | Submit/status/wallet basic | [M05](milestones/M05_Submission_Credit_Reservation.md) | BE-002 | 8h | PLANNED | USER-06/07/16 |
| M05-TEST-001 | Transaction/concurrency | [M05](milestones/M05_Submission_Credit_Reservation.md) | all M05 | 6h | PLANNED | NFR-REL-* |
| M05-DOC-002 | Recovery runbook draft | [M05](milestones/M05_Submission_Credit_Reservation.md) | TEST-001 | 4h | PLANNED | Ops §Credit |
| M06-OPS-001 | Worker/Hangfire storage spike | [M06](milestones/M06_Hangfire_Fake_Grading.md) | M05, OD-017 | 8h | PLANNED | System §Hangfire; NFR-REL-* |
| M06-DB-001 | Grading attempt/assessment | [M06](milestones/M06_Hangfire_Fake_Grading.md) | OPS-001 | 6h | PLANNED | FR-AI-* |
| M06-BE-001 | Job contract/enqueue | [M06](milestones/M06_Hangfire_Fake_Grading.md) | DB-001 | 8h | PLANNED | FR-SUB/AI-* |
| M06-BE-002 | Fake grader pipeline | [M06](milestones/M06_Hangfire_Fake_Grading.md) | BE-001, M05 Credit | 8h | PLANNED | AC-BILL-002/003 |
| M06-OPS-002 | Retry/recovery jobs | [M06](milestones/M06_Hangfire_Fake_Grading.md) | BE-002 | 6h | PLANNED | NFR-REL/OBS-* |
| M06-FE-001 | Async polling states | [M06](milestones/M06_Hangfire_Fake_Grading.md) | BE-002 | 6h | PLANNED | USER-07; UI §Submission Status |
| M06-TEST-001 | Replay suite | [M06](milestones/M06_Hangfire_Fake_Grading.md) | all | 8h | PLANNED | AC-SUB-004; BR invariants |
| M07-DOC-001 | Rubric/schema/golden set | [M07](milestones/M07_OpenAI_Grading.md) | OD-001/002 | 8h | PLANNED | FR-AI-*; AC-AI-* |
| M07-DB-001 | Version/usage schema | [M07](milestones/M07_OpenAI_Grading.md) | DOC-001 | 6h | PLANNED | FR-AI/OBS-* |
| M07-BE-001 | OpenAI adapter | [M07](milestones/M07_OpenAI_Grading.md) | DOC/DB | 8h | PLANNED | US-022; NFR-SCALE-* |
| M07-BE-002 | Structured validator | [M07](milestones/M07_OpenAI_Grading.md) | BE-001 | 8h | PLANNED | AC-AI-001/003 |
| M07-BE-003 | Retry/circuit/kill | [M07](milestones/M07_OpenAI_Grading.md) | BE-002 | 8h | PLANNED | AC-AI-002..004, AC-ADMIN-002 |
| M07-SEC-001 | Injection/data controls | [M07](milestones/M07_OpenAI_Grading.md) | BE-001/002 | 6h | PLANNED | AC-AI-005; NFR-SEC/PRIV-* |
| M07-TEST-001 | Benchmark | [M07](milestones/M07_OpenAI_Grading.md) | all | 8h | PLANNED | NFR-PERF/OBS-* |
| M07-OPS-001 | Provider runbook | [M07](milestones/M07_OpenAI_Grading.md) | BE-003/TEST | 4h | PLANNED | Ops §OpenAI |
| M08-BE-001 | Result query | [M08](milestones/M08_Result_Vertical_Slice.md) | M07 | 6h | PLANNED | FR-RESULT-*; AC-RESULT-001 |
| M08-BE-002 | Atomic terminal transition | [M08](milestones/M08_Result_Vertical_Slice.md) | M07, M05 | 8h | PLANNED | AC-BILL-002/003 |
| M08-FE-001 | Result page | [M08](milestones/M08_Result_Vertical_Slice.md) | BE-001 | 8h | PLANNED | USER-08; USER-08 screen |
| M08-SEC-001 | Safe render | [M08](milestones/M08_Result_Vertical_Slice.md) | FE-001 | 4h | PLANNED | AC-RESULT-002 |
| M08-FE-002 | Poll/deep link | [M08](milestones/M08_Result_Vertical_Slice.md) | M06-FE/M08-BE | 6h | PLANNED | USER-07/08 |
| M08-TEST-001 | Vertical slice gate | [M08](milestones/M08_Result_Vertical_Slice.md) | all M01–08 | 8h | PLANNED | Gate 2/3 |
| M08-DOC-001 | Alpha runbook/release notes | [M08](milestones/M08_Result_Vertical_Slice.md) | TEST-001 | 4h | PLANNED | Internal Alpha |
| M09-DB-001 | Model essay/version | [M09](milestones/M09_Model_Essay_History.md) | M03 | 6h | PLANNED | FR-MODEL-* |
| M09-BE-001 | Approved model query | [M09](milestones/M09_Model_Essay_History.md) | DB-001 | 4h | PLANNED | AC-MODEL-001; US-010 |
| M09-FE-001 | Model essay UI | [M09](milestones/M09_Model_Essay_History.md) | BE-001 | 6h | PLANNED | USER-08/04 |
| M09-BE-002 | History queries | [M09](milestones/M09_Model_Essay_History.md) | M08 | 6h | PLANNED | FR-HISTORY-* |
| M09-FE-002 | History/detail UI | [M09](milestones/M09_Model_Essay_History.md) | BE-002 | 8h | PLANNED | US-007/008 |
| M09-TEST-001 | Content/history acceptance | [M09](milestones/M09_Model_Essay_History.md) | all | 4h | PLANNED | AC-MODEL-001 |
| M09-DOC-001 | Review/license workflow | [M09](milestones/M09_Model_Essay_History.md) | DB/BE | 4h | PLANNED | FR-MODEL-* |
| M10-DB-001 | Taxonomy/occurrence | [M10](milestones/M10_Mistake_Progress_Redo.md) | M08 | 8h | PLANNED | FR-MISTAKE-* |
| M10-BE-001 | Mistake projection | [M10](milestones/M10_Mistake_Progress_Redo.md) | DB-001 | 8h | PLANNED | AC-MISTAKE-001; US-011 |
| M10-FE-001 | Mistake UI | [M10](milestones/M10_Mistake_Progress_Redo.md) | BE-001 | 6h | PLANNED | FR-MISTAKE-* |
| M10-BE-002 | Progress rules | [M10](milestones/M10_Mistake_Progress_Redo.md) | M08 | 8h | PLANNED | FR-PROGRESS-*; AC-PROGRESS-001 |
| M10-FE-002 | Progress UI | [M10](milestones/M10_Mistake_Progress_Redo.md) | BE-002 | 6h | PLANNED | US-012; NFR-UX-* |
| M10-DB-002 | Redo linkage | [M10](milestones/M10_Mistake_Progress_Redo.md) | M09 | 4h | PLANNED | FR-REDO-* |
| M10-BE-003 | Redo service/comparison | [M10](milestones/M10_Mistake_Progress_Redo.md) | DB-002 | 8h | PLANNED | AC-REDO-001/002; US-013 |
| M10-FE-003 | Redo UI | [M10](milestones/M10_Mistake_Progress_Redo.md) | BE-003 | 6h | PLANNED | US-013 |
| M10-TEST-001 | Projection recovery | [M10](milestones/M10_Mistake_Progress_Redo.md) | all | 6h | PLANNED | NFR-REL-* |
| M11-DOC-001 | Payment state/contract | [M11](milestones/M11_PayOS_Wallet.md) | OD-003/004 | 6h | PLANNED | FR-BILL-*; System §payOS |
| M11-DB-001 | Payment schema | [M11](milestones/M11_PayOS_Wallet.md) | DOC-001 | 8h | PLANNED | FR-BILL-* |
| M11-BE-001 | payOS adapter/checkout | [M11](milestones/M11_PayOS_Wallet.md) | DB-001 | 8h | PLANNED | US-015; USER-17/18 |
| M11-BE-002 | Signed webhook | [M11](milestones/M11_PayOS_Wallet.md) | BE-001, M05 Credit | 8h | PLANNED | AC-PAY-001/002 |
| M11-BE-003 | Reconciliation | [M11](milestones/M11_PayOS_Wallet.md) | BE-001/002 | 8h | PLANNED | Ops §Payment reconciliation |
| M11-FE-001 | Wallet/packages/checkout | [M11](milestones/M11_PayOS_Wallet.md) | BE-001..003 | 8h | PLANNED | US-014/015; AC-PAY-003 |
| M11-TEST-001 | Payment race suite | [M11](milestones/M11_PayOS_Wallet.md) | all | 8h | PLANNED | AC-PAY-*; NFR-REL/SEC-* |
| M11-OPS-001 | Commerce runbook | [M11](milestones/M11_PayOS_Wallet.md) | TEST-001 | 4h | PLANNED | Ops §payOS/Credit |
| M12-DB-001 | Support schema | [M12](milestones/M12_Support_Notifications.md) | M08/M11 | 8h | PLANNED | FR-SUPPORT/NOTIFY-* |
| M12-BE-001 | User ticket API | [M12](milestones/M12_Support_Notifications.md) | DB-001 | 8h | PLANNED | AC-SUPPORT-001; US-016 |
| M12-BE-002 | Resolution service | [M12](milestones/M12_Support_Notifications.md) | BE-001, M05/M11 | 8h | PLANNED | AC-SUPPORT-002 |
| M12-BE-003 | Notification pipeline | [M12](milestones/M12_Support_Notifications.md) | DB-001 | 6h | PLANNED | FR-NOTIFY-* |
| M12-FE-001 | Support UI | [M12](milestones/M12_Support_Notifications.md) | BE-001/002 | 8h | PLANNED | US-016 |
| M12-FE-002 | Notification UI | [M12](milestones/M12_Support_Notifications.md) | BE-003 | 4h | PLANNED | FR-NOTIFY-* |
| M12-TEST-001 | Support permission audit | [M12](milestones/M12_Support_Notifications.md) | all | 6h | PLANNED | NFR-PRIV/SEC-* |
| M13-BE-001 | Admin query boundary | [M13](milestones/M13_Admin_Portal.md) | M02 | 8h | PLANNED | FR-ADMIN-*; AC-ADMIN-001 |
| M13-FE-001 | Admin shell/dashboard | [M13](milestones/M13_Admin_Portal.md) | BE-001 | 8h | PLANNED | ADM-01; US-021 |
| M13-BE-002 | Content commands | [M13](milestones/M13_Admin_Portal.md) | M03/M09/M10 | 8h | PLANNED | US-018; ADM-02..07 |
| M13-FE-002 | Content UI | [M13](milestones/M13_Admin_Portal.md) | BE-002 | 8h | PLANNED | ADM-02..07 |
| M13-BE-003 | User/finance/support actions | [M13](milestones/M13_Admin_Portal.md) | M11/M12 | 8h | PLANNED | US-019/020; ADM-08..13/16/17 |
| M13-FE-003 | User/finance/support UI | [M13](milestones/M13_Admin_Portal.md) | BE-003 | 8h | PLANNED | ADM-08..13/16/17 |
| M13-BE-004 | AI/settings/security actions | [M13](milestones/M13_Admin_Portal.md) | M07/M02 | 8h | PLANNED | AC-ADMIN-002/003; ADM-14/15/18..21 |
| M13-FE-004 | Ops/security UI | [M13](milestones/M13_Admin_Portal.md) | BE-004 | 8h | PLANNED | ADM-14/15/18..21 |
| M13-BE-005 | Role/permission management | [M13](milestones/M13_Admin_Portal.md) | OD-011 | 8h | PLANNED | ADM-22/23 |
| M13-FE-005 | Accounts/roles UI | [M13](milestones/M13_Admin_Portal.md) | BE-005 | 6h | PLANNED | UI §Admin Accounts |
| M13-TEST-001 | Admin acceptance | [M13](milestones/M13_Admin_Portal.md) | all | 8h | PLANNED | NFR-SEC/PRIV-* |
| M14-DOC-001 | Retention/legal matrix | [M14](milestones/M14_Security_Privacy_Deletion.md) | OD-005/015 | 8h | PLANNED | FR-PRIV/DELETE/LEGAL-* |
| M14-SEC-001 | Web/API hardening | [M14](milestones/M14_Security_Privacy_Deletion.md) | M13 | 8h | PLANNED | FR-SEC-*; NFR-SEC-* |
| M14-BE-001 | Deletion workflow | [M14](milestones/M14_Security_Privacy_Deletion.md) | DOC-001 | 8h | PLANNED | FR-DELETE-*; US-017 |
| M14-DB-001 | Deletion/retention metadata | [M14](milestones/M14_Security_Privacy_Deletion.md) | BE design | 6h | PLANNED | FR-DELETE/PRIV-* |
| M14-OPS-001 | Retention jobs | [M14](milestones/M14_Security_Privacy_Deletion.md) | DOC/DB | 8h | PLANNED | NFR-PRIV-* |
| M14-FE-001 | Privacy/legal/deletion UX | [M14](milestones/M14_Security_Privacy_Deletion.md) | BE-001 | 8h | PLANNED | FR-LEGAL/DELETE-* |
| M14-SEC-002 | Privacy/log audit | [M14](milestones/M14_Security_Privacy_Deletion.md) | all | 6h | PLANNED | NFR-PRIV/OBS-* |
| M14-TEST-001 | IDOR/security regression | [M14](milestones/M14_Security_Privacy_Deletion.md) | all | 8h | PLANNED | AC-SEC-* |
| M15-TEST-001 | Regression matrix | [M15](milestones/M15_Quality_Operational_Readiness.md) | M14 | 8h | PLANNED | all P0 AC |
| M15-TEST-002 | Load/concurrency | [M15](milestones/M15_Quality_Operational_Readiness.md) | OD-008 | 8h | PLANNED | NFR-PERF/REL-* |
| M15-TEST-003 | AI benchmark gate | [M15](milestones/M15_Quality_Operational_Readiness.md) | M07 | 8h | PLANNED | AC-AI-* |
| M15-OPS-001 | Observability/alerts | [M15](milestones/M15_Quality_Operational_Readiness.md) | M13 | 8h | PLANNED | FR-OBS-*; NFR-OBS-* |
| M15-OPS-002 | Backup/restore rehearsal | [M15](milestones/M15_Quality_Operational_Readiness.md) | OD-006 | 8h | PLANNED | NFR-REL/PRIV-*; Ops §Backup |
| M15-OPS-003 | Reconciliation/recovery | [M15](milestones/M15_Quality_Operational_Readiness.md) | M11/M14 | 8h | PLANNED | NFR-REL-* |
| M15-SEC-001 | Security review | [M15](milestones/M15_Quality_Operational_Readiness.md) | all | 8h | PLANNED | NFR-SEC-* |
| M15-DOC-001 | Runbook catalog | [M15](milestones/M15_Quality_Operational_Readiness.md) | OPS tasks | 6h | PLANNED | Ops §Runbook |
| M16-OPS-001 | Production images | [M16](milestones/M16_VPS_Staging_Deployment.md) | M15 | 8h | PLANNED | NFR-MAINT/SEC-* |
| M16-OPS-002 | Staging Compose/proxy | [M16](milestones/M16_VPS_Staging_Deployment.md) | OPS-001 | 8h | PLANNED | System §VPS; Ops §Compose |
| M16-OPS-003 | Environment/secrets | [M16](milestones/M16_VPS_Staging_Deployment.md) | OPS-002 | 6h | PLANNED | Ops §Configuration |
| M16-OPS-004 | CI/CD deploy | [M16](milestones/M16_VPS_Staging_Deployment.md) | OPS-001..003 | 8h | PLANNED | Roadmap §Git/CI |
| M16-DB-001 | Migration/rollback pipeline | [M16](milestones/M16_VPS_Staging_Deployment.md) | OPS-004 | 8h | PLANNED | Ops §Migration/Rollback |
| M16-TEST-001 | Staging smoke | [M16](milestones/M16_VPS_Staging_Deployment.md) | all | 8h | PLANNED | Ops Release Checklist |
| M16-DOC-001 | Deployment runbook | [M16](milestones/M16_VPS_Staging_Deployment.md) | all | 6h | PLANNED | Ops §Go-Live |
| M17-DOC-001 | Beta protocol | [M17](milestones/M17_Closed_Beta.md) | OD-013/014 | 6h | PLANNED | Release Gate 5/6 |
| M17-OPS-001 | Access/release | [M17](milestones/M17_Closed_Beta.md) | M16 | 8h | PLANNED | NFR-SEC/REL-* |
| M17-OPS-002 | Daily operations | [M17](milestones/M17_Closed_Beta.md) | OPS-001 | 8h | PLANNED | Ops dashboards/runbooks |
| M17-TEST-001 | Real-flow validation | [M17](milestones/M17_Closed_Beta.md) | cohort | 8h | PLANNED | all P0 AC |
| M17-DOC-002 | AI/product report | [M17](milestones/M17_Closed_Beta.md) | observation | 8h | PLANNED | Overview §Success metrics |
| M17-OPS-003 | Go/no-go review | [M17](milestones/M17_Closed_Beta.md) | all | 6h | PLANNED | Gate 6 |
| M18-DOC-001 | Scope/release freeze | [M18](milestones/M18_Public_MVP.md) | M17 | 6h | PLANNED | PRD §MVP criteria |
| M18-OPS-001 | Go-live preparation | [M18](milestones/M18_Public_MVP.md) | DOC-001 | 8h | PLANNED | Ops §Go-Live |
| M18-OPS-002 | Production release | [M18](milestones/M18_Public_MVP.md) | OPS-001 | 6h | PLANNED | Gate 6 |
| M18-OPS-003 | Launch monitoring | [M18](milestones/M18_Public_MVP.md) | OPS-002 | 8h | PLANNED | FR-OBS-* |
| M18-DOC-002 | Release/postmortem record | [M18](milestones/M18_Public_MVP.md) | OPS-003 | 4h | PLANNED | Ops §Release/Postmortem |
| M19-DOC-001 | Evidence-based scope | [M19](milestones/M19_Version_1_0.md) | M18 | 4h | PLANNED | P1 requirements |
| M19-TEST-001 | Accessibility audit | [M19](milestones/M19_Version_1_0.md) | scope | 8h | PLANNED | NFR-UX-*; UI §Accessibility |
| M19-DEV-001 | Selected P1 slices | [M19](milestones/M19_Version_1_0.md) | DOC-001 | TBD | PLANNED | exact IDs TBD |
| M19-TEST-002 | V1 regression/release | [M19](milestones/M19_Version_1_0.md) | slices | 8h | PLANNED | exact IDs |
| M20-DOC-001 | Mobile discovery | [M20](milestones/M20_Post_MVP.md) | M19 | 1d | PLANNED | P2; Roadmap §Mobile |
| M20-DOC-002 | Classroom/community discovery | [M20](milestones/M20_Post_MVP.md) | M19 | 1d | PLANNED | P2 future |
| M20-DOC-003 | Provider/analytics discovery | [M20](milestones/M20_Post_MVP.md) | M19 metrics | 1d | PLANNED | US-022/P2 |

## Integrity Rules

- ID là duy nhất giữa registry và 21 milestone files; đổi ID cần change record.
- Execution task phải 2–8 giờ. Placeholder TBD ở M19/M20 không được READY trước khi phân rã.
- Dependency không tự tham chiếu hoặc tạo vòng; milestone gate luôn bắt buộc.
- P0 không defer nếu chưa có owner-approved scope change và risk disposition.
- Wildcard traceability phải thành exact IDs trước READY.
