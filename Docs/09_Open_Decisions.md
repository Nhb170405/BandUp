# BandUp — Open Decisions, Conflicts and Gaps

Trạng thái: Planning baseline — 18/07/2026. Tài liệu này không thay đổi sáu baseline nguồn. `Provisional` cho phép lập backlog nhưng phải được owner xác nhận trước gate ghi trong bảng.

## Quy ước

- **Blocker:** không bắt đầu milestone bị block.
- **Gate:** có thể làm phần không phụ thuộc, nhưng không qua Acceptance Gate.
- **Provisional:** dùng khuyến nghị để thiết kế có khả năng thay đổi cấu hình; không đóng cứng dữ liệu/contract.
- Nguồn: [PRD](02_Product_Requirements.tex), [UI/UX](03_UI_UX_Design.tex), [System Design](04_System_Design.tex), [Roadmap](05_Development_Roadmap.tex), [Operations](06_Operations.tex).

## Quyết định cần owner chốt

| ID | Quyết định / thiếu rõ | Khuyến nghị provisional | Ảnh hưởng | Ưu tiên / block |
|---|---|---|---|---|
| OD-001 | Model OpenAI/version production. PRD AC-AI-001 gọi cụ thể GPT-5.6 Terra, trong khi System Design §AI yêu cầu một model cấu hình và benchmark. | Không đóng model vào domain/schema; benchmark model được phép dùng tại thời điểm M07 và chốt bằng ADR. | Cost, latency, schema compliance, benchmark. | Blocker M07 exit. |
| OD-002 | Rubric, prompt template, structured-output schema và ngưỡng quality chưa được version baseline. | Chốt JSON Schema, rubric version, golden set và review checklist trước real AI. | Assessment contract và khả năng so sánh lịch sử. | Blocker M07. |
| OD-003 | Giá/gói/bonus/expiry và credit cost chính thức. Overview §Mô hình kinh doanh chỉ ghi giá “dự kiến”. | Business settings có effective date; MVP dùng pay-per-credit, không triển khai subscription recurring nếu chưa có yêu cầu mới. | UI, seed, accounting, refund. | Blocker M11 checkout. |
| OD-004 | Chính sách refund tiền, refund credit và xử lý quality dispute. | Auto-release chỉ cho lỗi kỹ thuật chưa có assessment; các trường hợp khác cần permission, reason và audit. | Ledger/payment/support/legal. | Gate M12/M13. |
| OD-005 | Retention cụ thể cho draft, essay, assessment, logs, audit, payment, backup, attachment. | Lập retention matrix có căn cứ pháp lý Việt Nam; financial records được anonymize thay vì giữ liên kết profile. | Deletion jobs, backup, privacy notice. | Blocker M14 exit. |
| OD-006 | RPO/RTO production chính thức. Operations §Restore chỉ mô tả mục tiêu tham khảo. | Provisional RPO 24h/RTO 4h; đo restore rehearsal rồi owner phê duyệt. | Backup frequency, cost, runbook. | Gate M15/M16. |
| OD-007 | S3-compatible provider và region production. | Chọn provider có offsite durability và data-location phù hợp; adapter chỉ khi attachment/object storage thực sự dùng. | Cost, privacy, backup. | Gate trước attachment production. |
| OD-008 | Ngưỡng rate limit, queue concurrency, AI daily budget/circuit breaker. | Cấu hình theo environment; khởi đầu bảo thủ, load test và beta metrics để hiệu chỉnh. | Availability, abuse, cost. | Gate M15/M17. |
| OD-009 | Session lifetime, sliding expiration, re-auth window và account linking khi email thay đổi. | Link bằng Google subject+issuer; không link chỉ bằng email; re-auth cho deletion/admin-sensitive action. | Security/UX. | Blocker M02 exit. |
| OD-010 | CSRF strategy chính xác cho SPA same-origin. | Antiforgery token/header cho mutation; SameSite không được coi là lớp duy nhất. | API contract/frontend client. | Blocker M02 exit. |
| OD-011 | Role/permission catalog và bootstrap Super Admin. | Permission constants theo action; bootstrap one-time qua secret/config, buộc rotate/revoke sau tạo. | Admin access/audit. | Gate M02, blocker M13. |
| OD-012 | Admin Portal nào bắt buộc Public MVP. UI liệt kê 23 màn hình; Roadmap gọi “basic admin” P0. | Public MVP chỉ bắt buộc prompt, user support view, grading failures, payment/support, settings/kill switch, role/audit tối thiểu; KPI nâng cao sang M19. | Scope và lịch beta. | Gate M13 planning. |
| OD-013 | SLA/support ownership và incident on-call cho solo developer. | Công bố best-effort, phân severity nội bộ; không hứa SLA thương mại khi chưa đo. | Legal/ops/beta. | Gate M17. |
| OD-014 | Beta success metrics và Public release thresholds. | Chốt cohort, grading success, p95 latency, autosave loss, payment mismatch, P0 defects, support volume và AI cost/submission trước M17. | Go/no-go M18. | Blocker M17 entry. |
| OD-015 | Chính sách xử lý credit còn lại khi xóa tài khoản. | Không cash-out tự động; giải thích rõ, xử lý refund theo policy OD-004 trước anonymization. | UX/legal/ledger. | Blocker M14 deletion. |
| OD-016 | Caddy hay Nginx. | Caddy cho baseline solo developer và automatic HTTPS; đổi chỉ bằng ADR nếu có constraint. | Compose/runbook. | Provisional M16. |
| OD-017 | Hangfire PostgreSQL community provider production readiness. | Spike integration ở M06: enqueue, retry, lock, restart và multi-worker; giữ `IGradingJobQueue` boundary. | Reliability/refactor risk. | Blocker M06 exit. |

## Mâu thuẫn và lệch baseline

| ID | Vị trí | Mâu thuẫn / tác động | Phương án đề xuất |
|---|---|---|---|
| CF-001 | Yêu cầu gọi `docs/01_Product_Overview.tex`; repo có `Docs/01_BandUp_Overview.tex`. | Tooling/link có thể trỏ sai trên hệ thống phân biệt hoa thường. | Dùng path thực tế; không rename nguồn trong bước planning. |
| CF-002 | Overview v0.1 §Phạm vi ghi “Subscription”; PRD v1.0 §Credit/payOS và UI §Credit Wallet dùng package credit. | Recurring subscription làm tăng schema, billing và legal scope. | PRD/System Design mới hơn là baseline; đánh dấu subscription recurring Post-MVP cho đến khi có requirement. |
| CF-003 | Overview §Phiên bản đầu tiên gọi Model Essay/Mistake/Progress/Subscription; Roadmap phân P1 nhưng P0 payOS/support/admin/security/backup. | “MVP” có hai nghĩa: giá trị học tập và điều kiện phát hành an toàn. | Public MVP phải có P0 vận hành; Model/Mistake/Progress/Redo có thể beta/P1 nhưng kế hoạch vẫn đưa trước Public để bảo toàn khác biệt sản phẩm. |
| CF-004 | UI §Ưu tiên gọi Admin Dashboard/Prompt/User/AI Failure/App Settings là P0 và liệt kê portal đầy đủ; nguồn lực solo developer. | M13 có nguy cơ thành mega-milestone. | Chia M13 thành các task/slice độc lập; KPI/advanced analytics chuyển M19 nếu không phục vụ release gate. |
| CF-005 | PRD AC-AI-001 nêu model cụ thể; System Design §AI nói model chính được cấu hình và benchmark. | Hard-code model làm migration/contract nhanh lỗi thời. | Theo OD-001; AC được hiểu là baseline test hiện tại, không phải domain invariant. |
| CF-006 | UI hướng WCAG 2.1 AA màn hình chính nhưng advanced accessibility audit ghi P2. | Có thể trì hoãn accessibility thiết yếu. | Keyboard, label, contrast, focus và safe errors là DoD từ M01; audit độc lập nâng cao ở M19. |

## Requirement còn thiếu thiết kế kỹ thuật

- Quy tắc account merge/recovery và Google subject migration (FR-AUTH-*): giải quyết OD-009 ở M02.
- Canonical word-count algorithm và Unicode/punctuation behavior (FR-WRITE-*, AC-SUB-*): contract dùng chung phải chốt M04.
- Autosave conflict UX và server merge policy: baseline là optimistic concurrency, không tự merge essay; M04 chốt response/restore flow.
- Assessment JSON Schema, forward/backward compatibility và re-grade version semantics: OD-002/M07.
- Công thức Progress/Redo recommendation và minimum sample: M10 phải version rule, không tạo insight giả.
- Payment expiry/cancel/late-paid/refund transition và payOS reconciliation window: M11/OD-004.
- Deletion tombstone, anonymization keys, backup expiry và chứng cứ hoàn tất: M14/OD-005.
- Analytics consent/retention và event schema: M14; tuyệt đối không có essay text.

## Thiết kế không có requirement tương xứng hoặc có nguy cơ over-engineering

- Provider abstraction rộng cho storage/email/payment trước khi có hai implementation: chỉ tạo port tại boundary đang dùng; không framework hóa plugin.
- ProgressSnapshots/UserMistakeStats vật lý từ đầu: bắt đầu query/derived projection, chỉ materialize khi đo được nhu cầu.
- Advanced admin KPI, blocked-client UI, MFA UI “tương lai”, advanced analytics và multi-provider AI: M19/Post-MVP.
- Object storage cho essay thuần text: database là đủ; object storage chỉ cho attachment/export có requirement.
- SignalR, Redis/cache, Kafka, Kubernetes, microservices: không thuộc MVP.

## Screen chưa có functional mapping một-một

Các màn hình sau chủ yếu được mô tả bởi nhóm requirement, chưa có FR riêng cho toàn bộ UI state: `AUTH-02/03`, `USER-04/06/07/10/12/15/19/20/23/25`, `ADM-13/14/15/18/19/21/22/23`. Backlog ánh xạ chúng vào FR nhóm và UI Acceptance Checklist; không tạo requirement mới âm thầm. Nếu hành vi nghiệp vụ mới xuất hiện khi thiết kế Figma, bổ sung PRD/change record trước code.

## Nội dung bắt buộc nhưng không nhất thiết là feature MVP

- Privacy/Terms/AI disclaimer, support contact, retention notice và deletion explanation.
- Secret rotation, dependency patching, audit, backup offsite, restore test, rollback, maintenance mode, kill switch và incident runbook.
- Cost/budget telemetry, payment/credit reconciliation và owner cho support/payment/incident.
- Accessibility nền tảng và analytics không chứa essay.

## Quy tắc đóng quyết định

Owner ghi ngày, người quyết định, lựa chọn, lý do, milestone/gate và ADR liên quan. Sau khi đóng, cập nhật đồng thời plan/backlog/traceability; không xóa lịch sử quyết định.
