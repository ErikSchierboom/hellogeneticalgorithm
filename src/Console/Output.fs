namespace StudioDonder.HelloGeneticAlgorithm.Console

open System
open StudioDonder.HelloGeneticAlgorithm.Domain.Fitness

module Output =

    let printGeneration index generation =
        let (individual, fitness) = mostFitIndividual generation
        printfn "Generation %d: %s (%f)" (index + 1) individual fitness

    let printGenerations target populationSize numberOfGenerations generations =
        printfn "Target: %s" target
        printfn "Population size: %d" populationSize
        printfn "Number of generation: %d" numberOfGenerations
        printfn ""
        List.iteri printGeneration generations