//let rec lenr xs =
//    match xs with
//    | [] -> 0
//    | _ :: xr -> 1 + lenr xr


let rec lenc xs k =
    match xs with
    | [] -> k 0
    | _ :: xr -> lenc xr (fun v -> k (1 + v))
    
lenc [2;5;7] id

lenc [2;5;7] (printf "the answer is '% d' \n")

let rec leni xs a =
    match xs with
    | [] -> a
    | _ :: xr -> leni xr (1+a)