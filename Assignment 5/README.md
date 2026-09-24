# Exercise 6.4


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


# Exercise 7.2


# Exercise 7.3

