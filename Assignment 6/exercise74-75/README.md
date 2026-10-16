## 7.4
Added `PreDec` and `PreInc` to `Inter.fs``. The patttern is the same: we get the location and the store, then pull the value out and increment/decrement it. Lastly we save the updated value in the store again.

## 7.5
Not much to say here. Added the operators as nonassociative tokens, as they should be with only one operand. Wrote a small test in test.c to check it all functions as intended