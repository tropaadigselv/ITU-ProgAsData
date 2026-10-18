# 8.1
## (i)
The readme was read and the code was run succesfully

## (ii)
To see the structued bytecode for ex03 and ex05 look in file bytecode.md

To see the execution traces for ex03 and ex05 look in files ex3trace.txt and ex5trace.txt

# 8.3
The new type was added and can be tested by running the test.c file like any other micro-c program file. In it it can be seen what it should print

# 8.4
## (i)
prog1 runs faster then ex08 because it does not do that many look ups and the stack that it builds does not have that many operations applied to it.
This can both be seen in the way that _i_ is initialized and in how the subtraction is made in the body of the while loop.

When looking at a small sample of the stack trace this can more clearly be seen:
For the prog1 the stack trace looks like this:
````
[ ]{0: CSTI 20000000}
[ 20000000 ]{2: GOTO 7}
[ 20000000 ]{7: DUP}
[ 20000000 20000000 ]{8: IFNZRO 4}
[ 20000000 ]{4: CSTI 1}
[ 20000000 1 ]{6: SUB}
[ 19999999 ]{7: DUP}
[ 19999999 19999999 ]{8: IFNZRO 4}
[ 19999999 ]{4: CSTI 1}
[ 19999999 1 ]{6: SUB}
[ 19999998 ]{7: DUP}
[ 19999998 19999998 ]{8: IFNZRO 4}
````
While for ex08 it looks like this:
````
[ ]{0: LDARGS}
[ ]{2: CALL 0 6}
[ 5 -999 ]{6: INCSP 1}
[ 5 -999 0 ]{8: GETBP}
[ 5 -999 0 2 ]{9: CSTI 0}
[ 5 -999 0 2 0 ]{11: ADD}
[ 5 -999 0 2 ]{12: CSTI 20000000}
[ 5 -999 0 2 20000000 ]{14: STI}
[ 5 -999 20000000 20000000 ]{15: INCSP -1}
[ 5 -999 20000000 ]{17: GOTO 36}
[ 5 -999 20000000 ]{36: GETBP}
[ 5 -999 20000000 2 ]{37: CSTI 0}
[ 5 -999 20000000 2 0 ]{39: ADD}
[ 5 -999 20000000 2 ]{40: LDI}
[ 5 -999 20000000 20000000 ]{41: IFNZRO 19}
[ 5 -999 20000000 ]{19: GETBP}
[ 5 -999 20000000 2 ]{20: CSTI 0}
[ 5 -999 20000000 2 0 ]{22: ADD}
[ 5 -999 20000000 2 ]{23: GETBP}
[ 5 -999 20000000 2 2 ]{24: CSTI 0}
[ 5 -999 20000000 2 2 0 ]{26: ADD}
[ 5 -999 20000000 2 2 ]{27: LDI}
[ 5 -999 20000000 2 20000000 ]{28: CSTI 1}
[ 5 -999 20000000 2 20000000 1 ]{30: SUB}
[ 5 -999 20000000 2 19999999 ]{31: STI}
[ 5 -999 19999999 19999999 ]{32: INCSP -1}
[ 5 -999 19999999 ]{34: INCSP 0}
[ 5 -999 19999999 ]{36: GETBP}
[ 5 -999 19999999 2 ]{37: CSTI 0}
[ 5 -999 19999999 2 0 ]{39: ADD}
[ 5 -999 19999999 2 ]{40: LDI}
[ 5 -999 19999999 19999999 ]{41: IFNZRO 19}
````
It can clearly be seen that there are much fewer operations being made on prog1 then there is on ex08. Because of this prog1 will run quicker.

## (ii)

When looking at the bytecode it can be seen that the while loop uses backwards jumps. 
That means that the while condition jumps back to an earlier part of the bytecode.
The conditional statements of the if statement uses forward jumps. That means that it jumps to later parts of the bytecode which then skip parts of the code depending on the boolean values it checks
