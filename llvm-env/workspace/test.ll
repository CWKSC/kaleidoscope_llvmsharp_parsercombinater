; ModuleID = 'file'
source_filename = "file"

declare i32 @putchar(i32)

define i32 @mul2(i32 %0) {
entry:
  %mul_temp = mul i32 2, %0
  ret i32 %mul_temp
}

define i32 @main() {
entry:
  %i = alloca i32, align 4
  store i32 20, ptr %i, align 4
  br label %while_condition_check

while_condition_check:                            ; preds = %after_while, %entry
  %i4 = load i32, ptr %i, align 4
  %int_signed_greater_than_temp = icmp sgt i32 %i4, 0
  br i1 %int_signed_greater_than_temp, label %while_body, label %after_while3

while_body:                                       ; preds = %while_condition_check
  %j = alloca i32, align 4
  %i5 = load i32, ptr %i, align 4
  %call_temp = call i32 @mul2(i32 %i5)
  store i32 %call_temp, ptr %j, align 4
  br label %while_condition_check1

while_condition_check1:                           ; preds = %while_body2, %while_body
  %j6 = load i32, ptr %j, align 4
  %int_signed_greater_than_temp7 = icmp sgt i32 %j6, 0
  br i1 %int_signed_greater_than_temp7, label %while_body2, label %after_while

while_body2:                                      ; preds = %while_condition_check1
  %call_temp8 = call i32 @putchar(i32 42)
  %j9 = load i32, ptr %j, align 4
  %sub_temp = sub i32 %j9, 1
  store i32 %sub_temp, ptr %j, align 4
  br label %while_condition_check1

after_while:                                      ; preds = %while_condition_check1
  %call_temp10 = call i32 @putchar(i32 10)
  %i11 = load i32, ptr %i, align 4
  %sub_temp12 = sub i32 %i11, 1
  store i32 %sub_temp12, ptr %i, align 4
  br label %while_condition_check

after_while3:                                     ; preds = %while_condition_check
  ret i32 0
}