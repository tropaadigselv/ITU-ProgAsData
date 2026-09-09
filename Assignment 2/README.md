# Exercises 2.4, 2.5

See the bottom of Intcomp1.fs.

# Exercise 3.2

_Write a regular expression that recognizes all sequences consisting of a and b where two a’s are always separated by at least one b._

`b*(ab+)*a?` or alternatively: `^(b|ab)*a?$`

_Construct the corresponding NFA._

![3.2-nfa.png](3.2-nfa.png)

Or alternatively:
![exercise32.png](exercise32(ask).png)

_Try to find a DFA corresponding to the NFA._

| DFA state | move(a) | move(b) | NFA states       |
|-----------|---------|---------|------------------|
| s0        | s2      | s1      | {1, <u>2</u>}    |
| s1        | s2      | s1      | {<u>2</u>, 3}    |
| s2        | {}      | s1      | {<u>2</u>, 4}    |

![3.2-dfa.png](3.2-dfa.png)

# Exercise 3.3

*Write out the rightmost derivation of `let z = (17) in z + 2 * 3 end EOF`*

```
Main
A  Expr EOF
F  LET NAME EQ Expr IN Expr END EOF
H  LET NAME EQ Expr IN Expr PLUS Expr END EOF
G  LET NAME EQ Expr IN Expr PLUS Expr TIMES Expr END EOF //resolve right Expr first 
C  LET NAME EQ Expr IN Expr PLUS Expr TIMES CSTINT END EOF //then the second from right    
C  LET NAME EQ Expr IN Expr PLUS CSTINT TIMES CSTINT END EOF
B  LET NAME EQ Expr IN NAME PLUS CSTINT TIMES CSTINT END EOF
E  LET NAME EQ LPAR Expr RPAR IN NAME PLUS CSTINT TIMES CSTINT END EOF
C  LET NAME EQ LPAR CSTINT RPAR IN NAME PLUS CSTINT TIMES CSTINT END EO
```

# Exercise 3.4

*Draw the above derivation as a tree.*

![exercise34.png](exercise34.png)

