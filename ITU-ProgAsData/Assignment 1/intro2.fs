module Assignment_1.intro2

(* Programming language concepts for software developers, 2010-08-28 *)

(* Evaluating simple expressions with variables *)

(* Association lists map object language variables to their values *)

let env = [("a", 3); ("c", 78); ("baf", 666); ("b", 111)];;

let emptyenv = []; (* the empty environment *)

let rec lookup env x =
    match env with 
    | []        -> failwith (x + " not found")
    | (y, v)::r -> if x=y then v else lookup r x;;

let cvalue = lookup env "c";;


(* Object language expressions with variables *)

type expr = 
  | CstI of int
  | Var of string
  | Prim of string * expr * expr
  | If of expr * expr * expr

let e1 = CstI 17;;

let e2 = Prim("+", CstI 3, Var "a");;

let e3 = Prim("+", Prim("*", Var "b", CstI 9), Var "a");;

let e4 = Prim("MAX", CstI 8, Prim("+", CstI 10, CstI 10))

let e5 = Prim("MIN", CstI 8, Prim("+", CstI 10, CstI 10))

let e6 = Prim("==", CstI 10, CstI 5)

let e7 = Prim("==", Var "baf", Prim("*", Var "b", CstI 6))
// returns 1

let e8 = Prim("MIN", Var "c", Prim("-", Var "b", CstI 11))
// returns 78

let e9 = If(Prim("==", Var "baf", Prim("*", Var "b", CstI 6)), CstI 1, CstI 2)

(* Evaluation within an environment *)

let rec eval e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | If (e1, e2, e3) ->
        let bool = eval e1 env
        if bool = 1 then eval e2 env else eval e3 env
    | Prim("+", e1, e2) -> eval e1 env + eval e2 env
    | Prim("*", e1, e2) -> eval e1 env * eval e2 env
    | Prim("-", e1, e2) -> eval e1 env - eval e2 env
    | Prim("MAX", e1, e2) ->
        let e1' = eval e1 env
        let e2' = eval e2 env
        if e1' > e2' then e1' else e2'
    | Prim("MIN", e1, e2) ->
        let e1' = eval e1 env
        let e2' = eval e2 env
        if e1' < e2' then e1' else e2'
    | Prim ("==", e1, e2) ->
        let e1' = eval e1 env
        let e2' = eval e2 env
        if e1' = e2' then 1 else 0
    | Prim _            -> failwith "unknown primitive";;

let rec eval2 e (env : (string * int) list) : int =
    match e with
    | CstI i            -> i
    | Var x             -> lookup env x
    | If (e1, e2, e3) ->
        let bool = eval2 e1 env
        if bool = 1 then eval2 e2 env else eval2 e3 env
    | Prim(ope, e1, e2) ->
        let i1 = eval2 e1 env
        let i2 = eval2 e2 env
        match ope with
        | "+" -> i1 + i2
        | "-" -> i1 - i2
        | "*" -> i1 * i2
        | "MAX" -> if i1 > i2 then i1 else i2
        | "MIN" -> if i1 < i2 then i1 else i2
        | "==" -> if i1 = i2 then 1 else 0
        | _ -> failwith "unknown primitive"

let e1v  = eval e1 env;;
let e2v1 = eval e2 env;;
let e2v2 = eval e2 [("a", 314)];;
let e3v  = eval e3 env;;

let e4v = eval e4 emptyenv
let e5v = eval e5 env
let e6v = eval e6 env
let e7v = eval e7 env
let e8v = eval e8 env

//1.2

type aexpr =
    | CstI of int
    | Var of string
    | Add of aexpr * aexpr
    | Sub of aexpr * aexpr
    | Mul of aexpr * aexpr
    
    
let ae1 = Sub(Var "v", Add(Var "w", Var "z"))
let ae2 = Mul(CstI 2, Sub(Var "v", Add(Var "w", Var "z")))
let ae3 = Add(Add(Var "x", Var "y"), Add(Var "z", Var "v"))

let rec fmt a =
    match a with
    | CstI i -> string i
    | Var x -> x
    | Add(a1, a2) -> "(" + fmt a1 + " + " + fmt a2 + ")"
    | Sub(a1, a2) -> "(" + fmt a1 + " - " + fmt a2 + ")"
    | Mul(a1, a2) -> "(" + fmt a1 + " * " + fmt a2 + ")"

let simplify (a:aexpr) : aexpr =
    match a with
    | Add(CstI 0, e) -> e
    | Add(e, CstI 0) -> e
    | Sub(e, CstI 0) -> e
    | Mul(CstI 1, e) -> e
    | Mul(e, CstI 1) -> e
    | Mul(CstI 0, _) -> CstI 0
    | Mul(_, CstI 0) -> CstI 0
    | Sub(e1, e2) -> if e1 = e2 then CstI 0 else Sub(e1, e2)
    | a -> a

let diff a =
    let rec aux a =
        match a with
        | CstI _ -> CstI 0
        | Var _ -> CstI 1
        | Add(e1, e2) -> Add(aux e1, aux e2)
        | Sub(e1, e2) -> Sub(aux e1, aux e2)
        | Mul(e1, e2) -> Add(Mul(aux e1, e2), Mul(e1, aux e2))
    simplify (aux a)