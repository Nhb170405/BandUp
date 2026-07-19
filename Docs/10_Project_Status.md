# BandUp — Project Status

- **Current Milestone:** M01 — Repository and Foundation (hosted CI gate pending)
- **Last Completed Milestone:** M00 — Planning Baseline
- **Current Release Target:** Internal Alpha
- **Current Branch:** feature/m01-foundation
- **Application Code Status:** M01 foundation implemented and locally verified; hosted CI gate pending; no business features implemented

## Current Blockers

Source: [Open Decisions — BLOCKER](09_Open_Decisions.md#blocker).

M01 gate blocker: `.github/workflows/ci.yml` chưa có hosted run vì thay đổi chưa được commit/push/PR.

OD-001 (M07), OD-002 (M07), OD-003 (M11), OD-005 (M14), OD-009 (M02), OD-010 (M02), OD-014 (M17), OD-015 (M14), OD-017 (M06).

## Important Invariants

- Một submission chỉ có một assessment thành công.
- Một payment chỉ cộng credit một lần.
- Một credit reservation chỉ được consume hoặc release một lần.
- Không sửa trực tiếp credit balance.
- User chỉ được truy cập dữ liệu thuộc tài khoản của mình.
- Admin action nhạy cảm phải có audit log.
- AI lỗi không được làm user mất credit.
- Không log essay hoặc secret.

## Next Recommended Action

Commit/push và chạy GitHub Actions để đóng M01 Acceptance Gate. Sau đó Product Owner quyết định OD-009 và OD-010 trước khi bắt đầu M02; không triển khai Identity hoặc Google Login khi hai blocker còn mở.

## Status Update Rule

Chỉ cập nhật Current/Last Completed sau Acceptance Gate. Local verification của M01 đã pass; M01 vẫn current cho đến khi hosted CI pass.

