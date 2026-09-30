# Exercise 6.4
## (i)
The type rule tree for ´´´ let f x = 1 in f f end ´´´ looks like this:

<img width="987" height="262" alt="billede" src="https://github.com/user-attachments/assets/c78374fa-0fac-4bcd-ac12-640abab400a3" />

The type of f is polymorphic since it returns the x that is given.

## (ii)
The type rule tree for ´´´ let f x = if x<10 then 42 else f(x+1) in f 20 end ´´´ looks like this:

<img width="1082" height="325" alt="billede" src="https://github.com/user-attachments/assets/db1b8d46-ad97-42c0-9956-a76ec405c00c" />

The type of f is not polymorphic since the if statement returns an integer.

# Exercise 6.5

Results from running the type inference:

```
> inferType (fromString "let f x = 1 in f f end");;
val it: string = "int"

> inferType (fromString "let f g = g g in f end");;
System.Exception: type error: circularity
   at FSI_0002.TypeInference.occurCheck[a](a tyvar, FSharpList`1 tyvars) in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\TypeInference.fs:line 93
   at FSI_0002.TypeInference.linkVarToType(FSharpRef`1 tyvar, typ t) in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\TypeInference.fs:line 109
   at FSI_0002.TypeInference.unify(typ t1, typ t2) in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\TypeInference.fs:line 161
   at FSI_0002.TypeInference.typ(Int32 lvl, FSharpList`1 env, expr e) in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\TypeInference.fs:line 271
   at FSI_0002.TypeInference.typ(Int32 lvl, FSharpList`1 env, expr e) in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\TypeInference.fs:line 261
   at FSI_0002.ParseAndType.inferType@7.Invoke(expr e)
   at <StartupCode$FSI_0005>.$FSI_0005.main@() in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\stdin:line 3
   at System.Reflection.MethodBaseInvoker.InterpretedInvoke_Method(Object obj, IntPtr* args)
   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
Stopped due to error

> inferType (fromString "let f x = let g y = y in g false end in f 42 end");;
val it: string = "bool"

> inferType (fromString "let f x = let g y = if true then y else x in g false end in f 42 end");;
System.Exception: type error: bool and int
   at FSI_0002.TypeInference.unify(typ t1, typ t2) in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\TypeInference.fs:line 164
   at FSI_0002.TypeInference.unify(typ t1, typ t2) in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\TypeInference.fs:line 154
   at FSI_0002.TypeInference.typ(Int32 lvl, FSharpList`1 env, expr e) in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\TypeInference.fs:line 271
   at FSI_0002.ParseAndType.inferType@7.Invoke(expr e)
   at <StartupCode$FSI_0007>.$FSI_0007.main@() in C:\Storage\ITU\5 Sem. Programmer som Data\ITU-ProgAsData\Assignment 5\Exercise 6.5\Fun\stdin:line 5
   at System.Reflection.MethodBaseInvoker.InterpretedInvoke_Method(Object obj, IntPtr* args)
   at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object[] parameters, CultureInfo culture)       
Stopped due to error

> inferType (fromString "let f x = let g y = if true then y else x in g false end in f true end");;
val it: string = "bool"

```

The program below is ill typed because the type of parameter `g` can never be polymorphic. Only functions and let-bound variables can.

```
let f g = g g
in f end
```

The program below is ill typed because the two branches of the if-expression must have the same type, which is not the case here. `x` has type `int` since `f` is called with `42` as its parameter, while `y` must be a `bool`, since `g` is called with `false`.

```
let f x =
    let g y = if true then y else x
    in g false end
in f 42 end
```

# Exercise 7.1

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

# Exercise 7.2
note: the for loops implemented in 7.3 is used in the answering of these exercises. The exercise description of 7.2 hints at this being a viable option, so I assume it's allowed.

## (i)
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

## (ii)
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

## (iii)
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

# Exercise 7.3
Modified lexer and parser to support for loops through while loops as suggested in the exercise description. I added a file at ``CEX/forloop.c`` to test it.

Running ``run (fromFile "CEX/forloop.c") [10];;`` outputs ``Interp.store = map [(0, 10); (1, 10); (2, 45)]``, as expected, containing the store, where:
```
address 0: n = 10, the argument
address 1: i = 10, which ended at 10 because the loop stops once i < n is false
address 2: sum = 45, the result
```


