open StudioDonder.HelloGeneticAlgorithm.Domain.Crossover
open StudioDonder.HelloGeneticAlgorithm.Domain.Mutation
open StudioDonder.HelloGeneticAlgorithm.Domain.Selection
open StudioDonder.HelloGeneticAlgorithm.Domain.Population
open StudioDonder.HelloGeneticAlgorithm.Domain.Fitness
open StudioDonder.HelloGeneticAlgorithm.Domain.Simulation
open System

let printGeneration index generation =
    let (individual, fitness) = mostFitIndivdual generation
    printfn "Generation %d: %s (%f)" (index + 1) individual fitness

let printGenerations target size numberOfGenerations generations =
    printfn "Target: %s" target
    printfn "Population size: %d" size
    printfn "Number of generation: %d" numberOfGenerations
    printfn ""
    List.iteri printGeneration generations

[<EntryPoint>]
let main argv = 
    let target = "erik"
    let size = 20
    let numberOfGenerations = 500
    let generateMethod = generate target.Length size
    let crossoverMethod = onePoint 3
    let mutationMethod = mutate 0.05
    let fitnessMethod = fitness target       
    let selectionMethod = tournament 3
    let generations = simulate crossoverMethod mutationMethod fitnessMethod selectionMethod generateMethod numberOfGenerations
    printGenerations target size numberOfGenerations generations
    0 // return an integer exit code
