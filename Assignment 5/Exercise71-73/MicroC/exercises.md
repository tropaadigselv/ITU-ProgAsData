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

### (i)
```c
void arrsum(int n, int arr[], int *sump) {
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
    a[0] = 7; a[1] = 13; a[2] = 9; a[3] = 8;
    sum = 0;
    arrsum(4, a, &sum);
    print sum;
}
```

### (ii)
```c
void arrsum(int n, int arr[], int *sump) {
    int i;
    i = 0;
    *sump = 0;
    while (i < n) {
        *sump = *sump + arr[i];
        i = i + 1;
    }
}

void squares(int n, int arr[]) {
    int i;
    for (i = 0; i < n; i = i + 1)
        arr[i] = i * i;
}

void main(int n) {
    if (n > 20)
        return;

    int sum;
    int a[20];
    sum = 0;
    squares(n, a);
    arrsum(n, a, &sum);
    print sum;
}
```

### (iii)
```c
void histogram(int n, int ns[], int max, int freq[]) {
    int i;
    i = 0;
    while (i <= max) {
        freq[i] = 0;
        i = i + 1;
    }

    for (i = 0; i < n; i = i + 1) {
        int idx;
        idx = ns[i];
        freq[idx] = freq[idx] + 1;
    }
}

void main() {
    int arr[7];
    int freq[4];     // max + 1 elements
    int i;

    arr[0] = 1; arr[1] = 2; arr[2] = 1; arr[3] = 1;
    arr[4] = 1; arr[5] = 2; arr[6] = 0;

    histogram(7, arr, 3, freq);

    for (i = 0; i < 4; i = i + 1)
        print freq[i];
    println;
}
```

**What happens if freq has fewer than max + 1 elements?**
Nothing detects it. An array is passed only as its base address, so `histogram`
cannot know the length of `freq`. `histogram` would then silently write past the end of `freq` into whatever lies next in
memory, corrupting other variables. For example, with `int freq[3];` the cell
right after the elements is the one holding `freq`'s own base address. Zeroing
`freq[3]` overwrites it, so `main` afterwards prints the wrong memory.

## Exercise 7.3
Modified lexer and parser to support for loops through while loops as suggested in the exercise description. I added a file at ``CEX/forloop.c`` to test it.

Running ``run (fromFile "CEX/forloop.c") [10];;`` outputs ``Interp.store = map [(0, 10); (1, 10); (2, 45)]``, as expected, containing the store, where:
```
address 0: n = 10, the argument
address 1: i = 10, which ended at 10 because the loop stops once i < n is false
address 2: sum = 45, the result
```


