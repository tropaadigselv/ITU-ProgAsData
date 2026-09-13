#r "bin/Debug/net10.0/FsLexYacc.Runtime.dll"
#load "Absyn.fs"
#load "FunPar.fs"
#load "FunLex.fs"
#load "Parse.fs"
#load "Fun.fs"
#load "ParseAndRun.fs"

open ParseAndRun

//exercises 4.1
printfn "%d" (run (fromString "5+7"))
printfn "%d" (run (fromString "let y = 7 in y + 2 end"))
printfn "%d" (run (fromString "let f x = x + 7 in f 2 end"))


//exercise 4.2
printfn "%d" (run (fromString "let sum n = if n = 0 then 0 else n + sum (n - 1) in sum 1000 end"))
printfn "%d" (run (fromString "let exp1 n = if n = 0 then 1 else 3 * exp1 (n - 1) in exp1 8 end"))

printfn
    "%d"
    (run (
        fromString
            "let exp1 n = if n = 0 then 1 else 3 * exp1 (n - 1)
            in let exp2 n = if n = 0 then 1 else exp1 n + exp2 (n - 1)
            in exp2 11 end
            end"
    ))

printfn
    "%d"
    (run (
        fromString
            "let p8 i = i * i * i * i * i * i * i * i 
            in let sum n = if n = 0 then 0 else p8 n + sum (n - 1)
            in sum 10 end
            end"

    )) //needs 2 param functions for this to not be awkward

//exercise 4.4

printfn "%d" (run (fromString "let pow x n = if n=0 then 1 else x * pow x (n-1) in pow 3 8 end"))


printfn
    "%d"
    (run (
        fromString
            "let max2 a b = if a<b then b else a
                 in let max3 a b c = max2 a (max2 b c)
                    in max3 25 6 62 end
                 end"
    ))
