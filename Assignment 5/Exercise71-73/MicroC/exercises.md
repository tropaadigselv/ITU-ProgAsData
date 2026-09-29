## Exercise 7.1

```val it: Absyn.program =
  Prog
    [Fundec
       (None, "main", [(TypI, "n")],
        Block
          [Stmt
             (While
                (Prim2 (">", Access (AccVar "n"), CstI 0),
                 Block
                   [Stmt (Expr (Prim1 ("printi", Access (AccVar "n"))));
                    Stmt
                      (Expr
                         (Assign
                            (AccVar "n",
                             Prim2 ("-", Access (AccVar "n"), CstI 1))))]));
           Stmt (Expr (Prim1 ("println", CstI 10)))])] 
```

Declarations
- Fundec (None, "main", [(TypI, "n")], ...)                  the function main
- (TypI, "n")                                                  the parameter n

Types
- None                                                      return type void
- TypI                                                       int

Statements
- Block [...]                                                function body and loop body
- While (...)                                               the loop
- Expr (...)                                               expression used as a statement

Expressions
- Prim2 (">", Access (AccVar "n"), CstI 0)                           n > 0
- Prim1 ("printi", Access (AccVar "n"))                              print n
- Assign (AccVar "n", Prim2 ("-", Access (AccVar "n"), CstI 1))      n = n - 1
- Prim1 ("println", CstI 10)                                         println

Note: Stmt (...) just wraps each item inside a Block (a block item is either a statement or a local declaration).

## Exercise 7.2

### a
```void arrsum(int n, int arr[], int *sump) {
  int i;
  i = 0;
  *sump = 0;
  while (i < n) {
    *sump = *sump + arr[i];
    i = i + 1;
  }
}
 
void main() {
  int a[4];
  int sum;
  a[0] = 7;
  a[1] = 13;
  a[2] = 9;
  a[3] = 8;
  sum = 0;
  arrsum(4, a, &sum);
  print sum;
}
```

### Exercise 7.3
Modified lexer and parser to support for loops through while loops as suggested in the exercise description. I added a file at ``CEX/forloop.c`` to test it.

Running ``run (fromFile "CEX/forloop.c") [10];;`` outputs ``Interp.store = map [(0, 10); (1, 10); (2, 45)]``, as expected, containing the store, where:
```
address 0: n = 10, the argument
address 1: i = 10, which ended at 10 because the loop stops once i < n is false
address 2: sum = 45, the result
```


