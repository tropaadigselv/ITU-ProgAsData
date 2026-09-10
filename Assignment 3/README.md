Assignment 3.5



For this assignment the program was run with the following inputs and generated these outputs:



fromString "2 + 3 \* 4";;

val it: Absyn.expr = Prim ("+", CstI 2, Prim ("\*", CstI 3, CstI 4))



fromString "x++";;

System.Exception: parse error near line 1, column 3



&#x20;  at Microsoft.FSharp.Core.PrintfModule.PrintFormatToStringThenFail@1448.Invoke(String message)

&#x20;  at FSI\_0002.Parse.fromString(String str) in C:\\Users\\frede\\OneDrive\\Skrivebord\\PSD\\ProgrammingLanguageConcepts\\plcFSharp\\Expr\\Parse.fs:line 20

&#x20;  at <StartupCode$FSI\_0005>.$FSI\_0005.main@() in C:\\Users\\frede\\OneDrive\\Skrivebord\\PSD\\ProgrammingLanguageConcepts\\plcFSharp\\Expr\\stdin:line 4

&#x20;  at System.Reflection.MethodBaseInvoker.InterpretedInvoke\_Method(Object obj, IntPtr\* args)

&#x20;  at System.Reflection.RuntimeMethodInfo.Invoke(Object obj, BindingFlags invokeAttr, Binder binder, Object\[] parameters, CultureInfo culture)

Stopped due to error



fromString "-1 + 2";;

val it: Absyn.expr = Prim ("+", CstI -1, CstI 2)



fromString "let x = 13 in z \* 4 - 6 end";;

val it: Absyn.expr = Let ("x", CstI 13, Prim ("-", Prim ("\*", Var "z", CstI 4), CstI 6))



fromString "5 + let x = -10 in let z = 5 \* x in z \* 2 end - x end";;

val it: Absyn.expr = Prim ("+", CstI 5, Let ("x", CstI -10, Prim ("-", Let ("z", Prim ("\*", CstI 5, Var "x"), Prim ("\*", Var "z", CstI 2)), Var "x")))



fromString "let y = 5 in y \* y end";;

val it: Absyn.expr = Let ("y", CstI 5, Prim ("\*", Var "y", Var "y"))

