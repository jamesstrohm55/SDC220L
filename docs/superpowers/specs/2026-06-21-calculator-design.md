# SDC220L Calculator — User Interaction Design Document

**Date:** 2026-06-21
**Course:** SDC220L
**Language:** C#
**Type:** Console Application

---

## Overview

This document defines how the user interacts with the SDC220L Calculator at every stage of execution. It covers the startup experience, input method, operation types, output formatting, error handling, memory functions, and navigation/exit. The architecture uses static helper classes (`Display`, `InputHelper`, `Memory`) to maximize reusability in the final course project.

---

## 1. Startup Screen

When the application launches, the user sees a two-part opening sequence rendered by the `Display` class.

**Header** — satisfies the assignment requirement (week indicator, title, student name):

```
========================================
  Project Week 1 | SDC220L Calculator
  [Your Name]
========================================
```

**Welcome block** — orients the user and includes a witty quote:

```
Welcome to the SDC220L Calculator!
----------------------------------------
This calculator will guide you through
a series of operations. Follow the
prompts to enter values, and use the
menu after each result to continue or
exit.

"Why do programmers prefer dark mode?
 Because light attracts bugs."
----------------------------------------
Press any key to begin...
```

The user presses any key to begin, giving them control of the pace.

---

## 2. Input Method

Values are entered **one at a time**. Each prompt clearly labels what is being asked for and the expected data type:

```
Enter the first integer value: _
```

`InputHelper` exposes two static methods used throughout the application:

| Method | Returns | Validates |
|---|---|---|
| `ReadInt(string prompt)` | `int` | Whole numbers only |
| `ReadDouble(string prompt)` | `double` | Any numeric value |

Both methods loop internally until valid input is received — the caller never needs to handle re-prompting.

**Formula-style input** (e.g., typing `6 + 5` as a single line) is **not** used. Values are entered separately so validation and re-prompting can be applied to each independently.

---

## 3. Operation Types

### Standard Operations (2 values, 1 operator)
The primary mode for week 1 and most of the final project. The user enters two values sequentially; the result is computed and displayed immediately.

Covers: addition, subtraction, multiplication, division.

### Multi-Value Operations (many values, 1 operator)
Planned for future expansion (e.g., summing a list, finding an average). The user enters values one at a time and types `done` to finish. The same `InputHelper.ReadDouble()` loop handles each entry; a sentinel input breaks the loop.

**Week 1 implements standard operations only:** add two integers, subtract two doubles.

---

## 4. Output Formatting

All results are rendered by `Display.ShowResult(string formula)`. The formula string is built in `Program.cs` and passed in — `Display` only handles rendering.

**Integer result:**
```
----------------------------------------
  6 + 5 = 11
----------------------------------------
```

**Floating-point result (always 2 decimal places via `F2` format specifier):**
```
----------------------------------------
  3.14 - 1.00 = 2.14
----------------------------------------
```

- Integer results show no decimal places.
- Floating-point results always show exactly 2 decimal places.
- Separator lines provide visual breathing room as the console fills.

---

## 5. Error Handling

All error messages are routed through `Display.ShowError(string message)` for consistent formatting. Three conditions are handled:

### Non-Numeric Input
Caught inside `InputHelper.ReadInt()` / `ReadDouble()`. The loop re-prompts automatically:
```
Enter the first integer value: abc
  Error: Please enter a whole number. Try again.
Enter the first integer value: _
```

### Division by Zero
Checked in `Program.cs` before dividing. The result line is replaced with an error; the menu then appears as normal:
```
----------------------------------------
  Error: Cannot divide by zero.
----------------------------------------
```

### Overflow / Out-of-Range
If a value exceeds `int` or `double` bounds, `InputHelper` catches the parse failure and re-prompts with the same message as non-numeric input.

No unhandled exceptions reach the user. All three paths use `Display.ShowError()` so error formatting is consistent everywhere.

---

## 6. Memory Functions

A single `Memory` class stores one `double` value. It tracks whether a value has been stored with a `bool _hasValue` flag, distinguishing "stored zero" from "nothing stored."

| User Action | Method | Behavior |
|---|---|---|
| `MS` — Memory Store | `Memory.Store(double value)` | Saves the current result |
| `MR` — Memory Recall | `Memory.Recall()` | Returns the stored value for use as input |
| `MC` — Memory Clear | `Memory.Clear()` | Resets memory to empty |

Attempting `MR` or `MC` when memory is empty:
```
  Error: Memory is empty. Use MS after a result to store a value.
```

Memory functions appear in the post-result menu (see Section 7). They are designed now but **not implemented in week 1**.

---

## 7. Navigation Menu & Exit

After every result is displayed, the post-result menu appears:

```
----------------------------------------
What would you like to do next?
  1. Continue to next operation
  2. Store result in memory (MS)
  3. Recall memory value (MR)
  4. Clear memory (MC)
  5. Exit
Enter your choice: _
```

Invalid menu input re-displays the menu with an error — same re-prompt pattern as input validation.

**Choosing 5 (Exit)** prints the closing message and terminates the application:
```
========================================
  Thank you for using SDC220L Calculator!
  Goodbye!
========================================
```

**Week 1 note:** After the subtraction result (the final operation in week 1), only Exit is relevant. The full menu is the target for the final project.

---

## 8. Class Architecture Summary

| Class | Responsibility |
|---|---|
| `Display` | All console output: headers, welcome, results, errors, menus |
| `InputHelper` | All console input: prompting, validation, re-prompting |
| `Memory` | Single-slot value storage: store, recall, clear |
| `Program` | Orchestration only — calls the above classes in sequence |

Each class has one clear purpose, communicates through a well-defined interface, and can be understood and tested independently. All three helper classes are designed for direct reuse in the final project.
