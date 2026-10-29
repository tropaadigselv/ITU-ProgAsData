# Exercise 11.1

See the file `Cont\len.fsx`.

## (i)

``` F#
> lenc [2; 5; 7] id;;
3

> lenc [2; 5; 7] (printf "The answer is ’% d’ \n");;
"The answer is 3"
```

## (ii)

``` F#
> let xs = [2;5;7];;
> lenc xs (fun v -> 2*v);;
6
```

The function returns the length of the list multiplied by 2.

## (iii)

What `leni` and `lenc` have in common is that they are both tail recursive.

# Exercise 11.2

See the file `Cont\rev.fsx`.

``` F#
> let xs = [2;5;7];;
```
## (i)

``` F#
> revc xs id;;
[7;5;2]
```

## (ii)

``` F#
> revc xs (fun v -> v @ v)
[7;5;2;7;5;2]
```

What happens here is that since the accumulator function concatenates `v` with itself, the list is reversed and then repeated again once.

## (iii)

See the `revi` function.

# Exercise 11.3

See the file `Cont\prods.fsx`.

# Exercise 11.4

See the `prodco` and `prodio` functions.

# Exercise 11.8

See the file `Cont\Icon.fs`

## (i)

``` F#
// every (write ( 1 + 2 * (1 to 4))) 
> Every(Write(Prim("+", CstI 1, Prim("*", CstI 2, FromTo(1,4)))));
3 5 7 9

every (write ((10 * (2 to 4)) + (1 to 2)))
> Every(Write(Prim "+", Prim ("*", CstI 10, FromTo(2, 4)), FromTo (1, 2)))
21 22 31 32 41 42
```

## (ii)

``` F#
// write (50 < 7 * (1 to 10))
> Write(Prim ("<", CstI 50, Prim("*", CstI 7, FromTo(1, 10))));;
56
```

## (iii)

See the extended `eval` function.

``` F#
> let ex13 = Write(Prim1("sqr", CstI 2));; 
val ex13: expr = Write (Prim1 ("sqr", CstI 2))

> run ex13;;
4 val it: value = Int 4

> let ex14 = Every(Write(Prim1("even", FromTo(1,10))));;
val ex14: expr = Every (Write (Prim1 ("even", FromTo (1, 10))))

> run ex14;;
2 4 6 8 10 val it: value = Int 0
```

## (iv)

See the extended `eval` function.

``` F#
> let ex16 = Write(Prim("<", CstI 50, Prim1("multiples", CstI 7)));;
val ex16: expr = Write (Prim ("<", CstI 50, Prim1 ("multiples", CstI 7)))

> run ex16;;
56 val it: value = Int 56
```

