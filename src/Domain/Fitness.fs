namespace StudioDonder.HelloGeneticAlgorithm.Domain

open StudioDonder.HelloGeneticAlgorithm.Domain.Characters
open Random
open System

module Fitness =
    
    let fitness (target:string) (individual:string) =       
        if target = null then raise (ArgumentNullException("individual"))
        if individual = null then raise (ArgumentNullException("individual"))        
        let zipped = List.zip (numericCharacterValues individual) (numericCharacterValues target)
        1.0f - List.fold (fun acc (x:uint16,y:uint16) -> acc + (Math.Abs(single x - single y) / single Char.MaxValue)) 0.0f zipped
        
    let calculateFitnessForPopulation fitness population =
        List.map (fun elem -> elem, fitness elem) population

    let mostFitIndividual (populationWithFitness: ('a * float32) list) =
        List.maxBy snd populationWithFitness

    let averageFitness (populationWithFitness: ('a * float32) list) =
        List.average (List.map snd populationWithFitness)

    let maximumFitness (populationWithFitness: ('a * float32) list) =
        List.max (List.map snd populationWithFitness)

    let minimumFitness (populationWithFitness: ('a * float32) list) =
        List.min (List.map snd populationWithFitness)