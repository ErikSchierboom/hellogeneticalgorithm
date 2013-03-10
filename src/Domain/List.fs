module List

open System

let takeRandom size list =    
    if size < 1 || size > (List.length list) then raise (ArgumentOutOfRangeException("size")) 
    match list with
    | [] -> failwith "Cannot call List.takeRandom on empty list."
    | x -> List.map (fun elem -> elem, Domain.Random.random.Next()) list
           |> List.sortBy snd
           |> Seq.take size           
           |> List.ofSeq
           |> List.map fst

let rec partitionBySize size list =
    match list with
    | [] -> []
    | _  ->
        if size < 1 || size > (List.length list) then raise (ArgumentOutOfRangeException("size")) 
        if not (List.length list % size = 0) then raise (ArgumentException("The list must have a length that is a multiple of size."))            
        (Seq.take size list |> List.ofSeq) :: partitionBySize size (Seq.skip size list |> List.ofSeq)