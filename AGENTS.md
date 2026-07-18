# BandUp repository guidance

## Mục tiêu

BandUp là Desktop Web AI Writing Coach cho IELTS Writing Task 2. Ưu tiên vòng lặp học tập: chọn đề → viết/autosave → submit → chấm → hiểu lỗi → theo dõi tiến bộ → luyện lại. Mobile App, Teacher Classroom và Community không thuộc MVP.

## Tài liệu nguồn bắt buộc

Trước khi thay đổi nghiệp vụ hoặc kiến trúc, đọc phần liên quan trong:

1. `Docs/01_BandUp_Overview.tex`
2. `Docs/02_Product_Requirements.tex`
3. `Docs/03_UI_UX_Design.tex`
4. `Docs/04_System_Design.tex`
5. `Docs/05_Development_Roadmap.tex`
6. `Docs/06_Operations.tex`
7. `Docs/07_Implementation_Plan.md`, `Docs/08_Milestone_Backlog.md`, `Docs/09_Open_Decisions.md`

File `.tex` là nguồn nội dung; PDF chỉ dùng đối chiếu bố cục. Không tự sửa baseline 01–06 khi task chỉ yêu cầu triển khai.

## Kiến trúc đã chốt

- Desktop Web trước; React + TypeScript + Vite; ASP.NET Core Web API; PostgreSQL + EF Core/Npgsql.
- Modular Monolith. API và Hangfire Worker là hai process/container production dùng chung application/module code.
- Google OIDC xác thực danh tính; BandUp phát secure application cookie. Authorization dùng role + permission + policy + ownership; user có nhiều role và role có nhiều user.
- Hangfire cho background jobs. AI dùng một OpenAI model chính, structured output và validation backend.
- Credit là immutable ledger với reservation: `AVAILABLE → RESERVED → CONSUMED|RELEASED`.
- payOS/VietQR; chỉ webhook đã xác minh chữ ký hoặc reconciliation backend được xác nhận payment.
- VPS + Docker Compose + Caddy/Nginx, same-origin ưu tiên; Development/Staging/Production tách biệt.
- Không đưa microservice, Kubernetes, Kafka hoặc Redis vào MVP nếu chưa có số liệu chứng minh.

## Ranh giới và dependency

- Host/UI → application contract/service → domain; infrastructure triển khai port/interface của module.
- Module chỉ thay đổi dữ liệu do mình sở hữu. Giao tiếp qua application service/contract hoặc domain event đã định nghĩa.
- Grading không sửa credit; Payment không sửa wallet; Admin không update trực tiếp bảng module khác; Progress không sửa Assessment; Analytics không điều khiển transaction.
- Không cho domain phụ thuộc EF Core, HTTP SDK, OpenAI, payOS, email hoặc storage provider.
- Không nhân đôi business logic giữa API, Worker và frontend. Frontend không hard-code giá, credit cost, permission, state transition hoặc grading rule.
- Shared Kernel chỉ chứa primitive/abstraction ổn định, không là thư mục gom code dùng chung tùy tiện.

## Quy ước triển khai

- Mỗi thay đổi phải truy vết tới FR/NFR/BR/AC và screen ID khi có; giữ task/PR trong một milestone.
- Backend là nguồn sự thật cho validation, authorization, ownership, idempotency và state transition.
- Migration chỉ thêm schema đang được milestone sử dụng; có owner, constraint/index, rollback/recovery note và test.
- Endpoint mutation có idempotency khi client/provider/job có thể retry. Transaction tài chính và state machine phải test concurrency.
- API lỗi dùng Problem Details; log có correlation/user/entity ID nhưng không chứa essay, raw AI payload nhạy cảm, token, cookie hoặc secret.
- Admin action nhạy cảm phải permission-check, confirmation, reason và audit.
- Không commit secret. Cấu hình nhạy cảm lấy từ environment/secret store; production key ring phải persistent và bảo vệ.
- Giữ commit nhỏ; không trộn refactor không liên quan; không tự đổi kiến trúc đã chốt.

## Build và test hiện tại

- TODO M01: repository chưa có application project hay lệnh build/test hợp lệ.
- Không tự bịa lệnh. Cập nhật mục này khi M01 tạo solution/package scripts/Compose và CI đầu tiên.

## Definition of Ready

- Goal, requirement/AC, phạm vi và dependency rõ; UI/behavior, permission, validation/error state và dữ liệu test đã xác định.
- Không còn open decision mức Blocker cho task; nếu có, dừng và dẫn `Docs/09_Open_Decisions.md`.
- Task đủ nhỏ để hoàn thành trong 2–8 giờ hoặc đã chia nhỏ.

## Definition of Done

- Build/lint/type-check pass; migration/seed cần thiết có test và recovery note.
- Ownership, authorization, validation, idempotency và audit phù hợp đã triển khai.
- Unit/integration/E2E/manual test theo backlog pass; loading/empty/error/success/disabled states hoàn chỉnh khi có UI.
- Không log dữ liệu cấm; contract, tài liệu, traceability và runbook được cập nhật.
- Chạy được ở môi trường mục tiêu của milestone và đạt Acceptance Gate; không còn bug P0/P1 chưa có quyết định.

## Khi không chắc chắn

Nêu rõ: nguồn và section đã đọc, điều chưa chắc, các lựa chọn, khuyến nghị, tác động và milestone bị block. Không âm thầm chọn phương án ảnh hưởng kiến trúc, schema tài chính, privacy/retention, security hoặc external contract. Quyết định mới phải được ghi vào `Docs/09_Open_Decisions.md` và ADR khi thích hợp.
