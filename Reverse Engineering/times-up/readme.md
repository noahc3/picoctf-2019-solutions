# Time's Up - 400 Points

This challenge requires you to solve a math expression in under a small amount of time. Our solution uses Python's eval function to evaluate the expression.

Note: Python's integers have no size limit, while the integers in C do. When the result of a math operation exceeds the maximum size of int64, the number will "underflow" or "overflow', effectively wrapping around from negative to positive or positive to negative like a cycle. Because of this, the solver script needs to get lucky and have a challenge that doesn't overflow/underflow in C. This can take up to 30 seconds.