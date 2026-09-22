#r "bin/Debug/net10.0/FsLexYacc.Runtime.dll"
#load "Absyn.fs"
#load "FunPar.fs"
#load "FunLex.fs"
#load "Parse.fs"
#load "HigherFun.fs"
#load "ParseAndRunHigher.fs"

open ParseAndRunHigher

printfn "%A" (run (fromString "let add x = fun y -> x + y in add 2 5 end"));;
printfn "%A" (run (fromString "let add = fun x -> fun y -> x+y in add 2 5 end"));;