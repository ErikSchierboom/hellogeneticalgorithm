namespace StudioDonder.HelloGeneticAlgorithm.Domain

open Fitness
open Random
open System

module Selection =

    let tournamentRound size populationWithFitness =
        if size < 1 || size > (List.length populationWithFitness) then raise (ArgumentOutOfRangeException("size"))        
        populationWithFitness 
        |> List.takeRandom size
        |> List.sortBy snd
        |> List.rev
        |> List.head

    let tournament size populationWithFitness =
        if size < 1 || size > (List.length populationWithFitness) then raise (ArgumentOutOfRangeException("size"))         
        List.init (List.length populationWithFitness) (fun _ -> tournamentRound size populationWithFitness)