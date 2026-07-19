# BandUp — Project Status

- **Current Milestone:** M02 — Google Login and Authorization
- **Last Completed Milestone:** M01 — Repository and Foundation
- **Current Release Target:** Internal Alpha
- **Current Branch:** main
- **Application Code Status:** M01 foundation complete and verified; no business features implemented

## Current Blockers

Source: [Open Decisions — BLOCKER](09_Open_Decisions.md#blocker).

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

Product Owner quyết định OD-009 và OD-010 trước khi bắt đầu task M02 đầu tiên; không triển khai Identity hoặc Google Login khi hai blocker còn mở.

## Status Update Rule

Chỉ cập nhật Current/Last Completed sau Acceptance Gate. M01 đạt gate bằng local verification và hosted GitHub Actions [run 29682097093](https://github.com/Nhb170405/BandUp/actions/runs/29682097093).

