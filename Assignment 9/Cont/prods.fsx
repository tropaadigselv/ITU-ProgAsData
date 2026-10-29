let rec prod xs =
    match xs with
    | [] -> 1
    | x :: xr -> x * prod xr
    
let rec prodc xs k =
    match xs with
    | [] -> k 1
    | x :: xr -> prodc xr (fun v -> k (v * x))
    
let rec prodco xs k =
    match xs with
    | [] -> k 1
    | 0 :: _ -> 0
    | x :: xr -> prodco xr (fun v -> k (v * x))
    
let rec prodio xs a =
    match xs with
    | [] -> a
    | 0 :: _ -> 0
    | x :: xr -> prodio xr (a*x)