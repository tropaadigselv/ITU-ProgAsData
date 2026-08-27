# Feedback

The assignment description says:

> Please provide Readme file explaining your solutions and modifications / additions to the source code handed out.

For most of these the description is largely the same as the exercise descriptions, as they were fairly simple to explain.

For feedback, can you please tell us whether this level of detail in the explanations is okay?

# 1.1

1. We added match cases for `MIN`, `MAX`, and `==`.
2. Then, we wrote some example expressions that use these new match cases and tested that they worked.
``` F#
let e4 = Prim("MAX", CstI 8, Prim("+", CstI 10, CstI 10))  
  
let e5 = Prim("MIN", CstI 8, Prim("+", CstI 10, CstI 10))  
  
let e6 = Prim("==", CstI 10, CstI 5)  
  
let e7 = Prim("==", Var "baf", Prim("*", Var "b", CstI 6))  
// returns 1  
  
let e8 = Prim("MIN", Var "c", Prim("-", Var "b", CstI 11))  
// returns 78
```
3. Then, we refactored `eval`, such that we could pattern match on the operator after having having computed the expressions.
4. Added support for `If` statements. To do this, a new constructor was added to `expr`.
5. And lastly, the `If` case was added to `eval`.

# 1.2

1. We implemented an alternative datatype to `expr` called `aexpr` and gave it the constructors as specified in the exercise.
2. See solution:
``` F#
let ae1 = Sub(Var "v", Add(Var "w", Var "z"))  
let ae2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))  
let ae3 = Add(Add(Var "x", Var "y"), Add(Var "z", Var "v"))
```
3. We implemented a "pretty printer" for the new datatype, which formatted expressions with surrounding parentheses and the relevant operator. I.e. `Sub(Var "x", CstI 34)` becomes `"(x - 34)"`.
4. For `simplify` we made a match case for each row in the given table, that would simplify all the expressions.
5. The same mostly goes for symbolic differentiation - see the function `diff`, where each rule got its own match case.

# 1.4

1. Inspired by the Java examples in the book, we created classes for each type of expression, using `Expr` and `Binop` as abstract classes and `Add`, `Mul` and `Sub` as concrete classes. Then, overwrote the `ToString()` method, to format the expression like in exercise 1.2.3.
2. See expressions:
``` C#
var a1 = new Add(new CstI(17), new Mul(new Var("x"), new CstI(20)));
var a2 = new Sub(new Var("x"), new Mul(new Var("y"), new CstI(20)));
var a3 = new Mul(new Var("x"), new CstI(20));

// (17 + (x * 20))
// (x - (y * 20))
// (x * 20)
```
3. Overwrote `Eval()` method in all concrete expression classes to evaluate the expression in question.
4. Implemented `Simplify()` to work like the one from exercise 1.2.4.

# 2.1

For all of the exercises in this part a lot of the code have been commented out to support the addition of multiple sequential let bindings. 

To extend the `expr` languge the suggestion from the exercises was followed. That is the language became:
``` F#
type expr = 
| CstI of int 
| Var of string 
| Let of (string * expr) list * expr 
| Prim of string * expr * expr
```
From this the eval method for the `expr` language need to be changed. Since all the expressions in the Let need to be calculated before the body could it was easy to see that an auxiliary function need to be made that could run through all the right hand sides and add them to the environment. When that is done it will then evaluate the body of the Let binding using the new environment.

# 2.2

Many of the same thoughts happened for revising the `freevars` function, where the variables used in the right hand side of the let binding needs to be found and save so the variables can be cleared when finding them for the body of the binding. This lead to the samme approach as before where an auxilory function is made that can calculate the free variables and save the variables it itself declares. This is then used when finding the free variables for the body.

# 2.3

When revising the `tcomp` function the same approach with an auxiliary function is used. Here it calculates the compile environment for the different right hand sides of the let binding and makes nested `Tlet`'s after for the bindings. 