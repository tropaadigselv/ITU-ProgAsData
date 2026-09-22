## 6.1

For program 3, the inner 'let' call shadows the variable x and assigns it to 77, however as addTwo 5 is resolved giving ``Int 5``, we move out a level and the env stored within in closure is discarded

For program 4, we provide x with the value 2, waiting for y. Like in 3, add is curried, and add 2 becomes the partial application we know from F#, which is why a ``Closure(...)`` is returned

## 6.2

Not much to say here. Added match cases and types in ``HigherFun`` as instructed, and made sure to add ``Clos(x, body, env)`` to the ``Call()`` in ``eval`` to ensure it has a valid way to interpret lambdas

## 6.3

We added concrete syntax ``fun x -> e``, parsed into the existing Fun(x, e) node. Unlike ``let ... end`` it has no closing token, so it lives in Expr (needing parentheses when applied or passed as an argument) and relies on ARROW precedence so its body extends as far right as possible.
Tested the listed functions in the exercise for correctness, and they parsed.