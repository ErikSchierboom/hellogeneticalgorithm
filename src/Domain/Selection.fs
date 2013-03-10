namespace Domain

open Domain.Characters
open Random
open System

module Selection =
    
    let fitness (target:string) (individual:string) =       
        if target = null then raise (ArgumentNullException("individual"))
        if individual = null then raise (ArgumentNullException("individual"))        
        let zipped = List.zip (numericCharacterValues individual) (numericCharacterValues target)
        1.0f - List.fold (fun acc (x:uint16,y:uint16) -> acc + (Math.Abs(single x - single y) / single Char.MaxValue)) 0.0f zipped
        
    let calculateFitnessForPopulation fitness population =
        List.map (fun elem -> elem, fitness elem) population    

    let tournamentRound size populationWithFitness =
        if size < 1 || size > (List.length populationWithFitness) then raise (ArgumentOutOfRangeException("size"))        
        populationWithFitness 
        |> List.takeRandom size
        |> List.sortBy snd
        |> List.rev
        |> List.head

    let tournament size fitness population =
        if size < 1 || size > (List.length population) then raise (ArgumentOutOfRangeException("size")) 
        let populationWithFitness = calculateFitnessForPopulation fitness population
        List.init (List.length populationWithFitness) (fun _ -> tournamentRound size populationWithFitness)
        |> List.map fst