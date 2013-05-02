namespace StudioDonder.HelloGeneticAlgorithm.Console

open StudioDonder.HelloGeneticAlgorithm.Domain.Crossover
open StudioDonder.HelloGeneticAlgorithm.Domain.Mutation
open StudioDonder.HelloGeneticAlgorithm.Domain.Selection
open StudioDonder.HelloGeneticAlgorithm.Domain.Population
open StudioDonder.HelloGeneticAlgorithm.Domain.Fitness
open StudioDonder.HelloGeneticAlgorithm.Domain.Simulation
open StudioDonder.HelloGeneticAlgorithm.Console.Input
open StudioDonder.HelloGeneticAlgorithm.Console.Output
open System

module Main = 

    let runSimulation (target:string) populationSize numberOfGenerations =    
        let generateMethod = generate target.Length populationSize
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness target       
        let selectionMethod = tournament 3
        simulate crossoverMethod mutationMethod fitnessMethod selectionMethod generateMethod numberOfGenerations

    [<EntryPoint>]
    let main argv = 
        let optionTarget = readTarget                
        let optionPopulationSize = readPopulationSize        
        let optionNumberOfGenerations = readNumberOfGenerations

        if optionTarget = None || optionPopulationSize = None || optionNumberOfGenerations = None then -1
        else
            let generations = runSimulation optionTarget.Value optionPopulationSize.Value optionNumberOfGenerations.Value
            printGenerations optionTarget.Value optionPopulationSize.Value optionNumberOfGenerations.Value generations
            0
