# BandUp — Open Decisions, Conflicts and Gaps

Baseline: 18/07/2026. Recommendations are PROVISIONAL, not approved decisions.

## Classification

BLOCKER prevents the required-by gate; IMPORTANT requires disposition before affected acceptance/release gate; DEFERRED is outside current MVP execution.

## BLOCKER

| ID | Decision | Affected / required by | Provisional recommendation | Owner/status |
|---|---|---|---|---|
| OD-001 | OpenAI model/version conflict. | M07 | Configure, benchmark, ADR; no domain hard-code. | Product/Tech — OPEN |
| OD-002 | Rubric, prompt, schema, quality threshold. | M07 | Version schema/rubric/golden set first. | Product/AI — OPEN |
| OD-003 | Official package/price/bonus/expiry/cost. | M11 | Effective-dated settings; no implicit subscription. | Product/Finance — OPEN |
| OD-005 | Legal retention periods. | M14 | Approved retention matrix and finance anonymization. | Product/Legal — OPEN |
| OD-009 | Session/re-auth/account linking. | M02 | Issuer+subject; re-auth sensitive actions. | Security/Product — OPEN |
| OD-010 | SPA CSRF strategy. | M02 | Antiforgery token/header; SameSite defense-in-depth. | Security/Tech — OPEN |
| OD-014 | Beta/Public success thresholds. | M17 | Define cohort/window and quality/reliability/cost/support thresholds. | Product — OPEN |
| OD-015 | Remaining credit on deletion. | M14 | Resolve policy/refund before anonymization. | Product/Legal/Finance — OPEN |
| OD-017 | Hangfire PostgreSQL provider readiness. | M06 | Enqueue/retry/lock/restart/multi-worker spike. | Tech — OPEN |

## IMPORTANT

| ID | Decision | Affected | Provisional recommendation | Owner/status |
|---|---|---|---|---|
| OD-004 | Refund/dispute policy. | M11–M13 | Auto-release only technical failure; others reasoned/audited. | Product/Finance — OPEN |
| OD-006 | RPO/RTO. | M15–M16 | Start 24h/4h, measure restore, approve. | Ops/Product — OPEN |
| OD-008 | Rate/concurrency/budget thresholds. | M07/M15/M17 | Configurable conservative baseline tuned by evidence. | Tech/Product — OPEN |
| OD-011 | Permission catalog/Super Admin bootstrap. | M02/M13 | Action permissions and one-time audited bootstrap. | Security/Product — OPEN |
| OD-012 | Public MVP Admin cut. | M13 | Basic content/user/support/payment/failure/settings/role/audit; advanced KPI M19. | Product — OPEN |
| OD-013 | Support ownership/SLA. | M17 | Best-effort externally; internal severity/owner/escalation. | Product/Ops — OPEN |
| OD-016 | Caddy or Nginx. | M16 | Caddy baseline; change by ADR only. | Tech/Ops — OPEN |

## DEFERRED

| ID | Decision | Affected | Disposition |
|---|---|---|---|
| OD-007 | S3-compatible provider/region. | M20/first attachment need | DEFERRED until object storage is required. |
| OD-018 | Mobile/Classroom/Community/Flashcards/Gamification/multi-provider/advanced analytics. | M20 | DEFERRED/Post-MVP; separate discovery/PRD. |

## Conflicts — Unresolved History

| ID | Conflict | Required handling |
|---|---|---|
| CF-001 | Requested overview path differs from actual Docs/01_BandUp_Overview.tex. | Use actual path; do not rename source in M00. |
| CF-002 | Overview Subscription vs newer credit/payOS baseline. | Recurring subscription deferred without new requirement. |
| CF-003 | Product-feature MVP vs production-safe P0. | Public gate retains security/payment/support/operations. |
| CF-004 | 23 admin screens vs solo MVP. | OD-012 cut; no silent expansion. |
| CF-005 | Concrete model AC vs configurable benchmark. | OD-001 controls; name not domain invariant. |
| CF-006 | Accessibility basics vs advanced audit P2. | Basics in DoD; advanced audit M19. |

## Missing Technical Design

Account linking; canonical word count; autosave conflict; assessment schema/re-grade compatibility; Progress/Redo formula; late/refund payment states; deletion proof/backup expiry; analytics consent/retention. Resolve in owning milestone and promote material choices here/ADR.

## Over-engineering Guard

No provider framework before need; no premature materialized aggregate/object storage; no SignalR, Redis, Kafka, Kubernetes, microservices, advanced admin KPI or multi-provider AI implicitly.

## Screens Without One-to-One FR

AUTH-02/03; USER-04/06/07/10/12/15/19/20/23/25; ADM-13/14/15/18/19/21/22/23 use requirement groups/UI checklist. New business behavior requires PRD/change record.

## Closing a Decision

Record owner, date, option, rationale, milestone/gate and ADR; update master, milestone, backlog, traceability and tests in one PR; retain history.
