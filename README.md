# BandUp

BandUp là Desktop Web AI Writing Coach cho IELTS Writing Task 2. Repository hiện hoàn thành M01 Foundation; chưa có authentication hoặc chức năng nghiệp vụ.

## Prerequisites

- .NET SDK 8.0.300+ trong feature band 8.0
- Node.js 22 và npm
- Docker Desktop với Docker Compose v2

PowerShell trên một số máy chặn `npm.ps1`; dùng `npm.cmd` như các lệnh dưới đây.

## First-time setup

```powershell
Copy-Item .env.example .env
dotnet tool restore
dotnet restore BandUp.sln
Push-Location apps/web
npm.cmd ci
Pop-Location
```

Chỉ thay giá trị local trong `.env`; file này bị Git ignore. Không dùng credential production trong Development.

## Build and test

```powershell
dotnet build BandUp.sln -c Release --no-restore
dotnet test BandUp.sln -c Release --no-build
Push-Location apps/web
npm.cmd run lint
npm.cmd test
npm.cmd run build
npm.cmd audit --audit-level=high
Pop-Location
```

## Database migration

```powershell
docker compose --env-file .env -f deploy/compose.yml up -d database
$env:ConnectionStrings__Database = 'Host=localhost;Port=5432;Database=bandup;Username=bandup;Password=<local-password-from-.env>'
dotnet ef database update --project src/BandUp.Infrastructure --startup-project src/BandUp.Api --configuration Release
Remove-Item Env:ConnectionStrings__Database
```

Phải xóa biến connection string dành cho host trước khi chạy Compose trong cùng terminal; nếu không, biến process sẽ ghi đè giá trị `Host=database` trong `.env`.

Migration mới chỉ được tạo trong milestone sử dụng schema đó:

```powershell
dotnet ef migrations add <MigrationName> --project src/BandUp.Infrastructure --startup-project src/BandUp.Api --output-dir Persistence/Migrations --configuration Release
```

## Run local stack

```powershell
docker compose --env-file .env -f deploy/compose.yml up -d --build
docker compose --env-file .env -f deploy/compose.yml ps
```

- Web: `http://localhost:5174` (override bằng `WEB_PORT`)
- API liveness: `http://localhost:8080/health/live`
- API readiness: `http://localhost:8080/health/ready`

Stop containers nhưng giữ database volume:

```powershell
docker compose --env-file .env -f deploy/compose.yml down
```

## Repository layout

- `apps/web`: React/Vite shell; không chứa business rules.
- `src/BandUp.Api`: HTTP host/composition và health checks.
- `src/BandUp.Contracts`: external/job/event contracts khi được thêm.
- `src/BandUp.Modules`: business modules được thêm just-in-time.
- `src/BandUp.SharedKernel`: primitive ổn định tối thiểu.
- `src/BandUp.Infrastructure`: EF Core/PostgreSQL và provider adapters.
- `tests`: architecture và API integration tests.
- `deploy`: Development Compose definition.

Worker được tạo ở M06. Google Login bắt đầu ở M02.
