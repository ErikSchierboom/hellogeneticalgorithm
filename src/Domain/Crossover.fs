namespace StudioDonder.HelloGeneticAlgorithm.Domain

open System
open Random

module Crossover =

    let onePoint point (parent1:string) (parent2:string) = 
        if parent1 = null then raise (ArgumentNullException("parent1"))
        if parent2 = null then raise (ArgumentNullException("parent2"))
        if not (parent1.Length = parent2.Length) then raise (ArgumentException("The parents must be of equal length."))
        parent1.Substring(0, point) + parent2.Substring(point), parent2.Substring(0, point) + parent1.Substring(point)

    let twoPoint point1 point2 (parent1:string) (parent2:string) = 
        if parent1 = null then raise (ArgumentNullException("parent1"))
        if parent2 = null then raise (ArgumentNullException("parent2"))
        if not (parent1.Length = parent2.Length) then raise (ArgumentException("The parents must be of equal length."))
        parent1.Substring(0, point1) + parent2.Substring(point1, point2 - point1) + parent1.Substring(point2), 
        parent2.Substring(0, point1) + parent1.Substring(point1, point2 - point1) + parent2.Substring(point2)

    let uniform probability (parent1:string) (parent2:string) = 
        if parent1 = null then raise (ArgumentNullException("parent1"))
        if parent2 = null then raise (ArgumentNullException("parent2"))
        if not (parent1.Length = parent2.Length) then raise (ArgumentException("The parents must be of equal length."))
        let doCrossover = List.init parent1.Length (fun _ -> meetsProbability probability)
        let useFirstParentState list (crossover:bool) =
            match list with                
                | x::xs -> if crossover then not x else x
                | _     -> not crossover
        let useFirstParentStates = List.rev (List.fold (fun acc elem -> (useFirstParentState acc elem) :: acc) [] doCrossover)        
        let characters = List.mapi (fun i useFirstParent -> if useFirstParent then (parent1.Chars i, parent2.Chars i) else (parent2.Chars i, parent1.Chars i)) useFirstParentStates
        List.fold (fun (child1, child2) (child1Char, child2Char) -> (child1 + child1Char.ToString(), child2 + child2Char.ToString())) ("", "") characters