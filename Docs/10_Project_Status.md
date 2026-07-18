# BandUp — Project Status

- **Current Milestone:** M00 — Planning Baseline
- **Last Completed Milestone:** None
- **Current Release Target:** Internal Alpha
- **Current Branch:** docs/detailed-milestones
- **Application Code Status:** Not started

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

Review và approve toàn bộ milestone trước khi bắt đầu M01.

## Status Update Rule

Chỉ cập nhật Current/Last Completed sau khi Acceptance Gate được Product Owner/reviewer chấp nhận. M00 chưa completed; không task application nào được bắt đầu.

