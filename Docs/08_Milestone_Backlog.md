# BandUp — Milestone Backlog

Baseline: 18/07/2026. Estimate là focused engineering time; `0.5d = 4h`, `1d = 8h`. Mỗi task là một commit/PR unit hợp lý; nếu investigation làm estimate vượt 8h, dừng và tách task.

## Cách đọc task

Mỗi dòng có đủ: **ID/title**, **Objective & work**, **Dependency**, **Expected impact**, **Trace** (FR/NFR/BR/AC/US/screen), **Verification & acceptance**, **Definition of Done**, **Risk/note**, **Estimate**. `Module paths` là dự kiến, không cấp quyền scaffold ngoài milestone. Wildcard chỉ dùng ở planning; trước khi task đạt Ready phải thay bằng ID cụ thể liên quan.

DoD chung: đáp ứng `AGENTS.md`; build/test liên quan pass; authorization/ownership/validation/idempotency/audit phù hợp; không log essay/secret; contract/docs/traceability cập nhật. Các dòng chỉ nêu DoD bổ sung.

## M00 — Planning Baseline

**Entry:** sáu `.tex` khả dụng. **Exit:** analysis A–L, plan/backlog/decision/agent guidance nhất quán; P0 có milestone. **Deliverable:** tài liệu review độc lập. **Out:** code/schema/infra. **Recovery:** revert file riêng. **Effort:** 16–24h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M00-DOC-001 — Inventory nguồn | Đọc đủ nguồn, lập section/ID/screen inventory và repo status. | None; `Docs/01..06` | all IDs | So khớp unique ID/count/path; DoD: ghi tên overview thực tế. Risk: LaTeX escaped IDs. | 4h |
| M00-DOC-002 — Analysis A–L | Đối chiếu product/module/dependency/conflict/gap/risk/scope. | 001; `07`, `09` | all | Review từng mục A–L có dẫn section; không tự xử lý conflict. | 6h |
| M00-DOC-003 — Milestone/trace | Chuyển roadmap thành M00–M20, release/gate/migration/test/trace. | 001–002; `07` | all P0/P1/P2 | Query không còn P0 orphan; dependency không vòng. | 6h |
| M00-DOC-004 — Backlog/agent rules | Viết task 2–8h, DoR/DoD và repository rules. | 003; `08`, `AGENTS.md` | Roadmap §24–28 | Required fields/ID uniqueness/link check. | 4h |

## M01 — Repository and Foundation

**Entry:** M00; stack không còn blocker. **Exit/Gate 1:** local build/test, migration, health, Compose và CI chạy. **Out:** feature/auth thật. **Recovery:** xóa/recreate disposable dev artifacts; không có user data. **Effort:** 40–56h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M01-BE-001 — Minimal solution | Tạo API, Contracts, SharedKernel tối thiểu, Modules/Infrastructure boundary; config validation/Problem Details. | M00; `src/*` | NFR-MAINT-*, FR-COMPAT-* | Build + architecture dependency test. DoD: không project explosion. | 8h |
| M01-FE-001 — Web shell | React/TS/Vite shell, routing, API client boundary, error/loading primitives. | M00; `apps/web` | NFR-UX/COMPAT-*, UI §Component/Global states | Typecheck/lint/component smoke; keyboard baseline. | 8h |
| M01-DB-001 — PostgreSQL bootstrap | EF/Npgsql, dev DB, migration convention, readiness. | BE-001; Persistence | NFR-REL/MAINT-* | Empty DB migrate/up smoke; no business tables/seed. | 6h |
| M01-OPS-001 — Local Compose | Web/API/Postgres dev topology, env example, volumes and health. | BE/FE/DB; `deploy` | System §Topology; Ops §Environments | Fresh clone-style start and health smoke. No secret committed. | 8h |
| M01-TEST-001 — Test harness | Unit/integration/architecture/E2E skeleton with isolated DB. | BE/FE/DB | Roadmap Gate 1 | Deliberate failing sample proves runners, then remove sample. | 6h |
| M01-OPS-002 — CI baseline | Build/type/lint/test/migration validation; artifact conventions. | TEST-001 | NFR-MAINT-* | Clean pipeline pass; cache must not hide failures. | 6h |
| M01-DOC-001 — Commands/ADR | README/AGENTS real commands, ADR stack/repo boundary. | all M01 | System §Decisions | Commands copied from CI and rerun locally. | 4h |

## M02 — Identity and Authorization

**Entry:** Gate 1; OD-009/010 resolved. **Exit:** AC-AUTH-001..004, AC-DASH-001. **Out:** full admin portal. **Recovery:** disable auth route; additive schema only. **Effort:** 56–72h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M02-DB-001 — Identity schema | Users, ExternalLogins, Roles, Permissions, joins, Profiles; unique issuer+subject and join keys. | M01-DB; Identity/Profile | FR-AUTH-003/005/009..015 | Migration/invariant tests. Risk: email-based linking forbidden. | 8h |
| M02-BE-001 — OIDC login | Challenge/callback, verified email policy, unique local user/link. | DB-001, OD-009 | FR-AUTH-001..005/016; AC-AUTH-001/002; US-002; AUTH-01/02 | Fake OIDC integration; repeat callback no duplicate. | 8h |
| M02-SEC-001 — Cookie/session/CSRF | Secure/HttpOnly/SameSite, expiry/revoke, data-protection persistence plan, antiforgery. | BE-001, OD-010 | FR-AUTH-006..008; NFR-SEC-* | Header/cookie/CSRF integration; logout invalidates session. | 8h |
| M02-BE-002 — Policy/ownership | Role-permission claims/policies, USER/admin/owner checks, account status. | DB-001; Identity | FR-AUTH-009..013; AC-AUTH-003/004 | Permission matrix + cross-user IDOR tests. | 8h |
| M02-BE-003 — Profile/onboarding API | Read/update learning profile with optional/validated fields. | BE-001/002; Profile | FR-AUTH-014; AC-DASH-001; US-003 | Integration validation/ownership. | 6h |
| M02-FE-001 — Auth/onboarding UI | Login/callback/error/logout/onboarding/profile and permission-aware nav. | BE-001..003 | AUTH-01..03, USER-01/24 | E2E first/repeat/blocked login; onboarding skip; UI states. | 8h |
| M02-SEC-002 — Admin bootstrap | Versioned permission catalog and one-time Super Admin procedure with audit. | BE-002, OD-011 | UI §Roles/Permissions; FR-ADMIN-* | Bootstrap twice is safe; secret not persisted/logged. | 6h |
| M02-TEST-001 — Auth security suite | Consolidate OIDC/cookie/CSRF/session/role/ownership negative cases. | all M02 | AC-AUTH-*; NFR-SEC-* | Suite passes against PostgreSQL; direct admin URL/API denied. | 6h |

## M03 — Prompt and Learner Shell

**Entry:** M02. **Exit:** AC-PROMPT-001/002 and authenticated learner reaches active prompt. **Out:** model essay/full CMS. **Recovery:** archive used content. **Effort:** 40–56h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M03-DB-001 — Prompt schema | Prompts/tags/status/publish fields; unique PromptNumber and active indexes. | M02 | FR-PROMPT-*; WritingContent | Migration constraint/query plan tests. | 6h |
| M03-BE-001 — Prompt queries | Paginated filter/detail/random active-only; avoid near repeat when possible. | DB-001 | FR-PROMPT-001..011; AC-PROMPT-001/002; US-004/005 | Unit random policy + integration active/archived. | 8h |
| M03-BE-002 — Controlled content seed | Small reviewed prompt dataset and repeatable seed/update rule. | DB-001 | UI USER-03/04 | Seed twice stable; source/review recorded. | 4h |
| M03-FE-001 — Learner shell/dashboard | App nav and dashboard next-action/new-user states. | M02-FE | FR-DASH-*; USER-02 | Component/manual UX/accessibility states. | 6h |
| M03-FE-002 — Prompt library/detail | Filters, pagination, random, detail, empty/error/loading. | BE-001 | USER-03/04 | E2E select/random/archived unavailable. | 8h |
| M03-TEST-001 — Content acceptance | Permission, active-only, deterministic test fixtures, UI flow. | all M03 | AC-PROMPT-* | Gate evidence and trace updated. | 4h |
| M03-DOC-001 — Content workflow | Document PromptNumber/status/seed/archive/review. | all | US-018 future admin | Reviewer can publish seed without SQL. | 4h |

## M04 — Writing Room and Draft

**Entry:** selected prompt. **Exit:** AC-WRITE-001/002; no silent overwrite; ≤10s target. **Out:** submission/credit. **Recovery:** previous server/local copy. **Effort:** 56–72h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M04-DOC-001 — Draft contract | Chốt word algorithm, autosave/version/conflict/offline contract. | M03 | FR-WRITE-*; AC-WRITE-*; USER-05 | Examples incl. Unicode/punctuation; no unresolved merge choice. | 4h |
| M04-DB-001 — Draft schema | Draft owner/prompt/content/timing/status/version; indexes/active policy. | DOC-001 | FR-WRITE-* | Migration/concurrency token test. Essay never logged. | 6h |
| M04-BE-001 — Draft API | Create/read/autosave/pause/resume with ownership and optimistic concurrency. | DB-001 | FR-WRITE-001..018 | Integration stale-version/IDOR/pause tests. | 8h |
| M04-FE-001 — Editor/timer | Desktop Writing Room, canonical count, timer/pause, exit warning. | DOC/BE | USER-05; AC-WRITE-002 | Component clock tests + manual keyboard/refresh. | 8h |
| M04-FE-002 — Autosave/recovery | Debounce/idle save, visible states, retry, local recovery, conflict UI. | BE-001 | AC-WRITE-001; UI §Autosave/Mất kết nối | Fake-clock/network E2E; no silent overwrite. | 8h |
| M04-TEST-001 — Two-tab/offline | Automate two-tab edit, dropped responses, reload/crash recovery and loss measurement. | FE-002 | NFR-REL/UX-* | Evidence ≤10s under defined test; stale tab blocked. | 8h |
| M04-SEC-001 — Draft privacy | Log/analytics redaction, payload limits, owner checks. | BE-001 | NFR-PRIV/SEC-* | Log capture has no essay; cross-user suite passes. | 4h |

## M05 — Submission and Credit Reservation

**Entry:** saved draft. **Exit:** AC-SUB-001..004, AC-BILL-001 and balanced ledger. **Recovery:** explicit idempotent release. **Effort:** 56–72h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M05-DOC-001 — State/invariant spec | Finalize submission/reservation transitions, idempotency and lock order. | M04 | BR credit/submission; System §State/Reserve | Transition table covers retries/terminal states. | 4h |
| M05-DB-001 — Ledger/wallet schema | Wallet, append-only transactions, reservations; unique refs/check constraints. | DOC-001 | FR-BILL-*; AC-BILL-001 | Migration + invariant/reconciliation queries. | 8h |
| M05-DB-002 — Submission/idempotency schema | Submission snapshot/status/request key and one reservation relation. | DB-001 | FR-SUB-* | Unique request race test. | 6h |
| M05-BE-001 — Credit service | Grant/reserve/consume/release APIs with transaction and idempotency. | DB-001 | FR-BILL-*; AC-BILL-001..003 | Unit transitions + concurrent last-credit integration. | 8h |
| M05-BE-002 — Submit transaction | Validate owner/word/AI gate, reserve+submission atomically, return status. | BE-001/DB-002 | FR-SUB-*; AC-SUB-001..004; US-007/014 | <200/200–249/valid/double submit/rollback tests. | 8h |
| M05-FE-001 — Submit/status/wallet basic | Confirmation, warnings, insufficient credit, disable duplicate click, status shell. | BE-002 | USER-06/07/16 | E2E all AC-SUB cases; server remains authoritative. | 8h |
| M05-TEST-001 — Transaction/concurrency | Fault injection between reserve/submission and parallel retry. | all M05 | NFR-REL-* | No orphan/negative/duplicate; reconciliation clean. | 6h |
| M05-DOC-002 — Recovery runbook draft | Detect/release orphan reservation without ledger edits. | TEST-001 | Ops §Credit | Dry-run query and audited procedure documented. | 4h |

## M06 — Hangfire and Fake Grading

**Entry:** queued submission. **Exit:** fake async exactly-once logical result; OD-017 passed. **Recovery:** pause/requeue by ID. **Effort:** 48–64h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M06-OPS-001 — Worker/Hangfire storage spike | Add Worker host, PostgreSQL storage, queue/config/dashboard auth stub. | M05, OD-017 | System §Hangfire; NFR-REL-* | Enqueue/restart/multi-worker/lock integration; blocker if fails. | 8h |
| M06-DB-001 — Grading attempt/assessment | Attempts and assessment skeleton; unique attempt and successful assessment. | OPS-001 | FR-AI-* | Migration/unique race tests. | 6h |
| M06-BE-001 — Job contract/enqueue | Identifier-only job args and after-commit enqueue/recovery strategy. | DB-001 | FR-SUB/AI-* | API/Worker serialization contract and lost-enqueue recovery test. | 8h |
| M06-BE-002 — Fake grader pipeline | State checks, deterministic structured result, save then consume; terminal release. | BE-001, M05 Credit | AC-BILL-002/003 | Duplicate executions yield one result/transition. | 8h |
| M06-OPS-002 — Retry/recovery jobs | Bounded retry, stale reservation/submission scan, alert categories. | BE-002 | NFR-REL/OBS-* | Timeout/restart/dead job fault tests. | 6h |
| M06-FE-001 — Async polling states | QUEUED/PROCESSING/COMPLETED/FAILED copy and leave/return behavior. | BE-002 | USER-07; UI §Submission Status | E2E background completion/failure. | 6h |
| M06-TEST-001 — Replay suite | Concurrent duplicate, retry after save, worker crash boundaries. | all | AC-SUB-004; BR invariants | Assessment and credit exactly once. | 8h |

## M07 — OpenAI Grading

**Entry:** M06; OD-001/002 closed. **Exit:** AC-AI-001..005 and kill switch. **Recovery:** disable provider/queue; preserve or release by policy. **Effort:** 64–80h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M07-DOC-001 — Rubric/schema/golden set | Version rubric, prompt, JSON schema and benchmark fixtures. | OD-001/002 | FR-AI-*; AC-AI-* | Owner review; representative/injection cases. | 8h |
| M07-DB-001 — Version/usage schema | PromptVersions, schema/model/version, token/cost/latency metadata. | DOC-001 | FR-AI/OBS-* | Immutable version and correlation constraints. | 6h |
| M07-BE-001 — OpenAI adapter | Typed request/response, timeouts, secrets, model config; no domain SDK dependency. | DOC/DB | US-022; NFR-SCALE-* | Contract tests with stub; key/payload absent logs. | 8h |
| M07-BE-002 — Structured validator | Parse/schema/business-range validation and safe mapping. | BE-001 | AC-AI-001/003 | Invalid/missing/extra/range fixture suite. | 8h |
| M07-BE-003 — Retry/circuit/kill | Transient ≤3, one corrective retry, permanent fail, budget and kill switch. | BE-002 | AC-AI-002..004, AC-ADMIN-002 | Fake provider 429/5xx/4xx/timeout sequences. | 8h |
| M07-SEC-001 — Injection/data controls | Delimit essay as untrusted content, output sanitization boundary, redacted telemetry. | BE-001/002 | AC-AI-005; NFR-SEC/PRIV-* | Adversarial golden tests and log inspection. | 6h |
| M07-TEST-001 — Benchmark | Run golden set; record schema pass, latency, cost, reviewer quality baseline. | all | NFR-PERF/OBS-* | Meets owner threshold; model/version recorded. | 8h |
| M07-OPS-001 — Provider runbook | Incident, key rotate, budget alert, prompt rollback procedure. | BE-003/TEST | Ops §OpenAI | Tabletop drill; no raw essay in evidence. | 4h |

## M08 — Result Vertical Slice

**Entry:** real assessment. **Exit:** Gate 3 and login→result demo. **Recovery:** safe status/retry; no assessment overwrite. **Effort:** 40–56h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M08-BE-001 — Result query | Owner-only structured DTO, terminal state and version metadata. | M07 | FR-RESULT-*; AC-RESULT-001 | Integration owner/cross-user/incomplete. | 6h |
| M08-BE-002 — Atomic terminal transition | Persist result + capture or terminal fail + release exactly once. | M07, M05 | AC-BILL-002/003 | Crash-boundary/replay transaction tests. | 8h |
| M08-FE-001 — Result page | Overall/criteria/summary/strength/weakness/corrections/vocab/plan progressive UI. | BE-001 | USER-08; USER-08 screen | Component/E2E complete/partial optional fields. | 8h |
| M08-SEC-001 — Safe render | Escape/sanitize AI/user markup and safe links. | FE-001 | AC-RESULT-002 | XSS corpus executes no script. | 4h |
| M08-FE-002 — Poll/deep link | Poll with bounded cadence, terminal stop, refresh/leave/return. | M06-FE/M08-BE | USER-07/08 | E2E slow/success/fail/refresh. | 6h |
| M08-TEST-001 — Vertical slice gate | Full browser flow with fake OIDC and provider plus staging-like DB/worker. | all M01–08 | Gate 2/3 | Video/log evidence without essay; no P0 defect. | 8h |
| M08-DOC-001 — Alpha runbook/release notes | Document demo, known limits, kill/recovery. | TEST-001 | Internal Alpha | Independent reviewer reproduces flow. | 4h |

## M09 — Model Essay and History

**Entry:** M08. **Exit:** AC-MODEL-001; USER-09/10 usable. **Recovery:** archive/version. **Effort:** 40–56h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M09-DB-001 — Model essay/version | ModelEssays with prompt, approval, source/license/version. | M03 | FR-MODEL-* | One active-approved policy; archive test. | 6h |
| M09-BE-001 — Approved model query | Return approved-only reference content. | DB-001 | AC-MODEL-001; US-010 | Draft/inactive never leaks. | 4h |
| M09-FE-001 — Model essay UI | Result/detail reference section with source/license note. | BE-001 | USER-08/04 | Manual UX/accessibility and approved-only E2E. | 6h |
| M09-BE-002 — History queries | Owner pagination/filter/status/detail with prompt snapshot. | M08 | FR-HISTORY-* | Query/index and cross-user integration. | 6h |
| M09-FE-002 — History/detail UI | USER-09/10 loading/empty/error/filter/deep link. | BE-002 | US-007/008 | Browser pagination/filter/owner. | 8h |
| M09-TEST-001 — Content/history acceptance | Archive prompt/model, old submission visibility, safe rendering. | all | AC-MODEL-001 | Regression pass; no mutable history. | 4h |
| M09-DOC-001 — Review/license workflow | Define approval/source/license/archive process. | DB/BE | FR-MODEL-* | Reviewer checklist complete. | 4h |

## M10 — Mistake, Progress and Redo

**Entry:** M08/M09. **Exit:** AC-MISTAKE/PROGRESS/REDO. **Recovery:** recompute projections. **Effort:** 64–80h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M10-DB-001 — Taxonomy/occurrence | Version/archive taxonomy and immutable error occurrence snapshot. | M08 | FR-MISTAKE-* | Unique occurrence/replay and archive tests. | 8h |
| M10-BE-001 — Mistake projection | Idempotent assessment→occurrence and owner aggregate/detail. | DB-001 | AC-MISTAKE-001; US-011 | Replay same assessment no duplicate. | 8h |
| M10-FE-001 — Mistake UI | USER-11/12 filters, examples, actions and sparse states. | BE-001 | FR-MISTAKE-* | E2E owner/filter/detail. | 6h |
| M10-BE-002 — Progress rules | Aggregate overall/criteria/errors with sample-size caveat; version rule. | M08 | FR-PROGRESS-*; AC-PROGRESS-001 | One/many/no assessment unit+integration. | 8h |
| M10-FE-002 — Progress UI | USER-13 charts with text alternative/tooltip/empty/small-sample. | BE-002 | US-012; NFR-UX-* | Accessibility/manual chart test. | 6h |
| M10-DB-002 — Redo linkage | Source submission/recommendation/new attempt relationships. | M09 | FR-REDO-* | No overwrite; owner/unique tests. | 4h |
| M10-BE-003 — Redo service/comparison | Create new flow and compare same-version-safe scores. | DB-002 | AC-REDO-001/002; US-013 | Integration original/new/history. | 8h |
| M10-FE-003 — Redo UI | USER-14/15 recommendation/start/comparison states. | BE-003 | US-013 | E2E proactive redo and comparison. | 6h |
| M10-TEST-001 — Projection recovery | Rebuild mistakes/progress from assessments and compare checksum. | all | NFR-REL-* | Repeatable/no duplicates; runbook recorded. | 6h |

## M11 — payOS and Wallet

**Entry:** Credit module; OD-003/004. **Exit:** AC-PAY-001..003 and Gate 4 commerce. **Recovery:** disable checkout/reconcile/compensate. **Effort:** 64–80h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M11-DOC-001 — Payment state/contract | Chốt package snapshot, amount/order/event, late/expiry/refund/reconcile transitions. | OD-003/004 | FR-BILL-*; System §payOS | Transition table covers out-of-order events. | 6h |
| M11-DB-001 — Payment schema | Packages/orders/events/grants/refunds with provider uniques and snapshots. | DOC-001 | FR-BILL-* | Duplicate event/grant constraints and migration test. | 8h |
| M11-BE-001 — payOS adapter/checkout | Create order/QR, secret handling, configured URLs; no grant on return. | DB-001 | US-015; USER-17/18 | Sandbox/stub contract and amount snapshot tests. | 8h |
| M11-BE-002 — Signed webhook | Verify raw signature before parse trust, idempotent state/grant transaction, audit event. | BE-001, M05 Credit | AC-PAY-001/002 | valid/invalid/duplicate/concurrent webhook tests. | 8h |
| M11-BE-003 — Reconciliation | Query provider backend, resolve pending/mismatch safely, scheduled retry/alert. | BE-001/002 | Ops §Payment reconciliation | Stub outage/late paid/mismatch/replay tests. | 8h |
| M11-FE-001 — Wallet/packages/checkout | USER-16..20 balances/history/package/QR/pending/result; return is display-only. | BE-001..003 | US-014/015; AC-PAY-003 | E2E pending→paid/expired and spoofed return. | 8h |
| M11-TEST-001 — Payment race suite | Event ordering, duplicate provider ID, webhook+reconcile concurrency and ledger checksum. | all | AC-PAY-*; NFR-REL/SEC-* | Credit granted exactly once in every interleaving. | 8h |
| M11-OPS-001 — Commerce runbook | Disable checkout, investigate missing credit, reconcile and compensate with audit. | TEST-001 | Ops §payOS/Credit | Tabletop sandbox case completed. | 4h |

## M12 — Support and Notifications

**Entry:** grading/payment contexts; OD-004. **Exit:** AC-SUPPORT-001/002. **Recovery:** disable external delivery; retain in-app record. **Effort:** 48–64h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M12-DB-001 — Support schema | Tickets/messages/context links/resolution and notification/delivery tables. | M08/M11 | FR-SUPPORT/NOTIFY-* | Ownership/status/idempotency constraints. | 8h |
| M12-BE-001 — User ticket API | Create/list/detail/reply with allowed submission/payment links and categories. | DB-001 | AC-SUPPORT-001; US-016 | IDOR/link ownership/status tests. | 8h |
| M12-BE-002 — Resolution service | Re-grade/refund/reject routed to module services with permission/reason/audit. | BE-001, M05/M11 | AC-SUPPORT-002 | No auto-refund quality dispute; duplicate action safe. | 8h |
| M12-BE-003 — Notification pipeline | In-app events for grading/payment/ticket; idempotent delivery. | DB-001 | FR-NOTIFY-* | Replay and unread/read integration. | 6h |
| M12-FE-001 — Support UI | USER-22/23 create/list/conversation/status/resolution. | BE-001/002 | US-016 | E2E failed grading/payment/quality cases. | 8h |
| M12-FE-002 — Notification UI | USER-21 badge/list/deep link/error states. | BE-003 | FR-NOTIFY-* | Component/E2E replay does not duplicate. | 4h |
| M12-TEST-001 — Support permission audit | User/admin roles, essay privacy, refund/regrade trace. | all | NFR-PRIV/SEC-* | Least-privilege matrix and audit record verified. | 6h |

## M13 — Admin Portal

**Entry:** M02/03/07/11/12; OD-011/012. **Exit:** AC-ADMIN-001..003 and basic-admin P0. **Recovery:** per-surface feature flags. **Effort:** 72–96h; split PRs by task.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M13-BE-001 — Admin query boundary | Permission-filtered dashboard/user activity; essays closed by default. | M02 | FR-ADMIN-*; AC-ADMIN-001 | Query/API direct access matrix. | 8h |
| M13-FE-001 — Admin shell/dashboard | Permission-aware nav, action alerts and minimal KPIs. | BE-001 | ADM-01; US-021 | E2E multi-role menu plus direct-route denial. | 8h |
| M13-BE-002 — Content commands | Prompt/model/taxonomy draft-review-publish-archive via module services. | M03/M09/M10 | US-018; ADM-02..07 | Permission/status/version/audit integration. | 8h |
| M13-FE-002 — Content UI | Lists/editors with validation/status/confirmation. | BE-002 | ADM-02..07 | Manual/E2E publish/archive. | 8h |
| M13-BE-003 — User/finance/support actions | Scoped detail, credit adjustment, payment/refund and ticket orchestration. | M11/M12 | US-019/020; ADM-08..13/16/17 | Reason/permission/idempotency/audit tests. | 8h |
| M13-FE-003 — User/finance/support UI | Required lists/details/actions; sensitive fields gated. | BE-003 | ADM-08..13/16/17 | Role-specific E2E; essay not auto-open. | 8h |
| M13-BE-004 — AI/settings/security actions | Failure view, kill switch/settings version, session revoke/security event. | M07/M02 | AC-ADMIN-002/003; ADM-14/15/18..21 | Concurrent setting/version/audit and revoke tests. | 8h |
| M13-FE-004 — Ops/security UI | AI usage/failure, settings, security/audit screens in P0 cut. | BE-004 | ADM-14/15/18..21 | Permission/confirmation/manual incident flow. | 8h |
| M13-BE-005 — Role/permission management | Multi-role membership and preview; Super Admin-only administration. | OD-011 | ADM-22/23 | Union-of-permissions, last-admin safety and audit. | 8h |
| M13-FE-005 — Accounts/roles UI | Account list, role assignment, permission matrix preview. | BE-005 | UI §Admin Accounts | E2E multiple users/roles/direct API denial. | 6h |
| M13-TEST-001 — Admin acceptance | Full role/action/privacy matrix and AC-ADMIN suite. | all | NFR-SEC/PRIV-* | No unauthorized data/action; every sensitive success audited. | 8h |

## M14 — Security, Privacy and Deletion

**Entry:** all data modules; OD-005/015. **Exit:** security/privacy/deletion P0 and Gate 5 portion. **Recovery:** deletion forward-only/resumable. **Effort:** 64–80h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M14-DOC-001 — Retention/legal matrix | Chốt data class, purpose, duration, deletion/anonymization/backup expiry and owner. | OD-005/015 | FR-PRIV/DELETE/LEGAL-* | Legal/product sign-off; no unspecified financial linkage. | 8h |
| M14-SEC-001 — Web/API hardening | CSP/security headers, CSRF/CORS/XSS, payload/rate/abuse controls and secret review. | M13 | FR-SEC-*; NFR-SEC-* | OWASP-focused automated/manual suite. | 8h |
| M14-BE-001 — Deletion workflow | Re-auth request, pending/session revoke, resumable purge, finance anonymize, completion record. | DOC-001 | FR-DELETE-*; US-017 | Partial-failure/retry/idempotency integration. | 8h |
| M14-DB-001 — Deletion/retention metadata | Requests/steps/tombstone/anonymization identifiers and cleanup indexes. | BE design | FR-DELETE/PRIV-* | Unique active request; migration/recovery test. | 6h |
| M14-OPS-001 — Retention jobs | Cleanup drafts/logs/attachments/backups metadata per matrix; dry-run/report. | DOC/DB | NFR-PRIV-* | Clock-controlled boundary and rerun tests. | 8h |
| M14-FE-001 — Privacy/legal/deletion UX | PUB-03, USER-25/26 disclosure, typed confirmation, re-auth and status. | BE-001 | FR-LEGAL/DELETE-* | E2E cancel/confirm/fail/complete; accessible copy. | 8h |
| M14-SEC-002 — Privacy/log audit | Scan logs/analytics/audit/support for essay, secret, excess PII. | all | NFR-PRIV/OBS-* | Seed canaries absent from prohibited sinks. | 6h |
| M14-TEST-001 — IDOR/security regression | All owner resources/admin permissions, injection and session revoke. | all | AC-SEC-* | Negative matrix pass; findings triaged. | 8h |

## M15 — Quality and Operational Readiness

**Entry:** core/commerce/privacy complete; OD-006/008. **Exit:** Beta evidence, measured restore/performance/cost. **Recovery:** disposable/sanitized tests. **Effort:** 56–80h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M15-TEST-001 — Regression matrix | Consolidate unit/integration/E2E/auth/transaction/security/smoke CI tiers. | M14 | all P0 AC | Trace report has no P0 orphan; stable retry policy. | 8h |
| M15-TEST-002 — Load/concurrency | Autosave, submit, last-credit, worker concurrency, webhook and reads under target load. | OD-008 | NFR-PERF/REL-* | p95/error/DB/queue baseline recorded. | 8h |
| M15-TEST-003 — AI benchmark gate | Blind/reviewer golden run, schema/retry/cost/latency report. | M07 | AC-AI-* | Owner accepts threshold/model/version. | 8h |
| M15-OPS-001 — Observability/alerts | Structured metrics/dashboards/alerts for API/DB/jobs/AI/payment/product. | M13 | FR-OBS-*; NFR-OBS-* | Synthetic fault triggers actionable alert without sensitive data. | 8h |
| M15-OPS-002 — Backup/restore rehearsal | Offsite encrypted backup and isolated full restore with evidence. | OD-006 | NFR-REL/PRIV-*; Ops §Backup | Measured RPO/RTO, checksum and smoke. | 8h |
| M15-OPS-003 — Reconciliation/recovery | Credit/payment/orphan reservation/stale job/deletion health reports. | M11/M14 | NFR-REL-* | Inject mismatch then repair safely/audited. | 8h |
| M15-SEC-001 — Security review | Dependency scan, auth/config/admin/provider threat review and remediation. | all | NFR-SEC-* | No critical/high unaccepted finding. | 8h |
| M15-DOC-001 — Runbook catalog | Incident, AI outage, missing credit, rollback, restore, deletion and escalation. | OPS tasks | Ops §Runbook | Tabletop top scenarios; owner/contact assigned. | 6h |

## M16 — VPS and Staging Deployment

**Entry:** M15; OD-016. **Exit:** Operations Acceptance Criteria on staging. **Recovery:** versioned rollback/backup/forward-fix. **Effort:** 48–64h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M16-OPS-001 — Production images | Reproducible non-root Web/API/Worker images, pinned runtime, health. | M15 | NFR-MAINT/SEC-* | Image scan, immutable tag, local run. | 8h |
| M16-OPS-002 — Staging Compose/proxy | Separate services, Caddy HTTPS/same-origin, networks/volumes/key ring. | OPS-001 | System §VPS; Ops §Compose | Fresh VPS-like staging deploy and restart persistence. | 8h |
| M16-OPS-003 — Environment/secrets | Dev/Staging/Prod config contract, secret injection/rotation checklist. | OPS-002 | Ops §Configuration | Secret scan; missing config fails safely. | 6h |
| M16-OPS-004 — CI/CD deploy | Versioned artifact, staging deploy, approval production flow, release record. | OPS-001..003 | Roadmap §Git/CI | Repeat deploy same artifact; no rebuild drift. | 8h |
| M16-DB-001 — Migration/rollback pipeline | Backup, migrate-before-compatible-app, expand/contract and failure stop. | OPS-004 | Ops §Migration/Rollback | Staging upgrade/app rollback/forward-fix rehearsal. | 8h |
| M16-TEST-001 — Staging smoke | Login, prompt, autosave, submit, worker, result, payment sandbox, credit/support/admin. | all | Ops Release Checklist | Automated/manual signed evidence. | 8h |
| M16-DOC-001 — Deployment runbook | DNS/HTTPS/firewall/release/rollback/restore/access steps. | all | Ops §Go-Live | Independent dry run; no secret values. | 6h |

## M17 — Closed Beta

**Entry:** staging ops pass; OD-013/014 closed. **Exit:** beta thresholds accepted, no unresolved P0. **Recovery:** stop invites/payment/grading; maintenance/rollback. **Effort:** 40–64h engineering + 2–4 weeks observation.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M17-DOC-001 — Beta protocol | Cohort, consent/support, metrics/thresholds, observation and stop conditions. | OD-013/014 | Release Gate 5/6 | Owner signs before invite. | 6h |
| M17-OPS-001 — Access/release | Controlled account/invite, production-like release and rollback rehearsal. | M16 | NFR-SEC/REL-* | Only cohort access; smoke pass. | 8h |
| M17-OPS-002 — Daily operations | Review queue/AI/payment/credit/support/security/cost and incident log. | OPS-001 | Ops dashboards/runbooks | Daily checklist/evidence; alerts owned. | 8h |
| M17-TEST-001 — Real-flow validation | Observe login/autosave/submission/result/payment/deletion; reproduce defects sanitized. | cohort | all P0 AC | No sensitive content copied to tickets/logs. | 8h |
| M17-DOC-002 — AI/product report | Aggregate quality, retention, repeat error, cost and interviews. | observation | Overview §Success metrics | Threshold result and limitations explicit. | 8h |
| M17-OPS-003 — Go/no-go review | Classify defects/risks, close actions, decide Public gate. | all | Gate 6 | Written decision; rollback/deferral if threshold fails. | 6h |

## M18 — Public MVP

**Entry:** M17 go. **Exit:** Gate 6/public monitoring stable. **Recovery:** maintenance/kill switch/rollback/communications. **Effort:** 24–40h.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M18-DOC-001 — Scope/release freeze | Confirm every P0 Verified/Accepted, known issues, version/notes/owners. | M17 | PRD §MVP criteria | No orphan P0 or blocker decision. | 6h |
| M18-OPS-001 — Go-live preparation | Backup, capacity/budget, DNS/HTTPS, secrets, support/incident schedule. | DOC-001 | Ops §Go-Live | Checklist signed; restore evidence current. | 8h |
| M18-OPS-002 — Production release | Apply runbook, migration, deploy same artifact, health/smoke. | OPS-001 | Gate 6 | All core/commerce/admin smoke pass. | 6h |
| M18-OPS-003 — Launch monitoring | Watch 30m+ and defined heightened window; capture metrics/incidents. | OPS-002 | FR-OBS-* | Threshold alerts and rollback decision recorded. | 8h |
| M18-DOC-002 — Release/postmortem record | Record result, deviations, issues, next actions without sensitive data. | OPS-003 | Ops §Release/Postmortem | Owner acknowledges close or incident process begins. | 4h |

## M19 — Version 1.0

**Entry:** Public MVP observation and frozen metric-driven scope. **Exit:** selected P1/regression gate. **Recovery:** feature flags/revert. Estimate only after selection.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M19-DOC-001 — Evidence-based scope | Rank accessibility/performance/admin KPI/email/UX work from metrics; explicitly reject unmeasured scope. | M18 | P1 requirements | Owner-approved bounded list and estimates. | 4h |
| M19-TEST-001 — Accessibility audit | WCAG 2.1 AA audit of primary flows and remediation backlog. | scope | NFR-UX-*; UI §Accessibility | Keyboard/screen-reader/contrast report. | 8h |
| M19-DEV-001 — Selected P1 slices | Implement only approved slices as separate 2–8h tasks generated from DOC-001. | DOC-001 | exact IDs TBD | Each slice receives full task record before Ready. | TBD |
| M19-TEST-002 — V1 regression/release | Full P0 + selected P1 regression, performance and release gate. | slices | exact IDs | No regression and release evidence. | 8h |

## M20 — Post-MVP

**Entry:** Web stable and separate business case. **Exit:** discovery decision, not automatic implementation. **Recovery:** no production mutation during discovery.

| Task | Objective & work | Dependency / impact | Trace | Verification / acceptance / DoD / risk | Est. |
|---|---|---|---|---|---|
| M20-DOC-001 — Mobile discovery | Validate mobile jobs, shared API/auth/security and Web stability prerequisites. | M19 | P2; Roadmap §Mobile | Research decision; no app scaffold. | 1d |
| M20-DOC-002 — Classroom/community discovery | Validate personas, moderation/privacy/business model and module impact. | M19 | P2 future | Separate PRD/architecture proposal. | 1d |
| M20-DOC-003 — Provider/analytics discovery | Use incident/cost evidence before multi-provider/advanced analytics. | M19 metrics | US-022/P2 | ADR only if measured benefit exceeds complexity. | 1d |

## Cross-milestone release gates

| Gate | Required milestones/evidence |
|---|---|
| Gate 1 — Foundation Ready | M01 build, Compose, CI, migration, health. |
| Gate 2 — Core Writing Ready | M02–M06 login/prompt/draft/fake async result. |
| Gate 3 — AI Ready | M07–M08 structured AI, retry, credit, real result. |
| Gate 4 — Commerce Ready | M11–M12 verified payment, reconciliation, support. |
| Gate 5 — Beta Ready | M09–M16 learning differentiation, admin, security, backup/restore, monitoring/legal. |
| Gate 6 — Public Ready | M17 evidence, no P0 defect, accepted cost/support/capacity. |

## Mandatory scenario ownership

| Scenario | Owning task |
|---|---|
| Google Login/cookie/role/permission | M02-TEST-001 |
| Autosave/two tabs | M04-TEST-001 |
| Double-click Submit/credit race | M05-TEST-001 |
| Hangfire job replay/restart | M06-TEST-001 |
| OpenAI retry/invalid structured output | M07-BE-002/003, M07-TEST-001 |
| Payment duplicate webhook/reconciliation | M11-TEST-001 |
| Account deletion/anonymization | M14-BE-001, M14-TEST-001 |
| Backup/restore | M15-OPS-002 |

## Backlog maintenance rules

1. Trước khi kéo task vào Ready: thay wildcard trace bằng exact IDs; link design/ADR; resolve blocker; confirm test data.
2. Nếu task vượt 8h hoặc chạm hơn hai module độc lập, tách theo contract/schema/backend/UI/test hoặc vertical behavior.
3. Không đóng task chỉ vì code chạy local; DoD và milestone Acceptance Gate là bắt buộc.
4. Requirement thay status phải cập nhật `07` traceability và `09` decision/conflict trong cùng PR.
5. P0 không được defer nếu chưa có owner-approved release-scope change và risk disposition.
