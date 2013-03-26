namespace Domain.Tests

open Domain.Population
open Domain.Crossover
open Domain.Selection
open Domain.Mutation
open Domain.Fitness
open Domain.Simulation
open System
open Xunit
open Xunit.Extensions

type SimulationTests() = 

    [<Fact>]  
    member this.simulationRoundReturnsGenerationOfEqualSize() =        
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "hello"        
        let selectionMethod = tournament 3
        let generation = ["hello", 1.0f; "there", 0.5f; "world", 0.2f; "yeeha", 0.1f]
        let nextGeneration = simulationRound crossoverMethod mutationMethod fitnessMethod selectionMethod generation
        Assert.Equal<int>(List.length generation, List.length nextGeneration)

    [<Fact>]  
    member this.simulationRoundsReturnsGenerationsOfSpecifiedSize() =     
        let numberOfGenerations = 50
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "hello"        
        let selectionMethod = tournament 3
        let generation = ["hello", 1.0f; "there", 0.5f; "world", 0.2f; "yeeha", 0.1f]
        let generations = simulationRounds crossoverMethod mutationMethod fitnessMethod selectionMethod numberOfGenerations generation
        Assert.True(List.forall (fun elem -> List.length elem = List.length generation) generations)

    [<Fact>]  
    member this.simulationRoundsReturnsWhenSolutionHasBeenFound() =        
        let numberOfGenerations = 50
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "hello"        
        let selectionMethod = tournament 3
        let generation = ["hello", 1.0f; "there", 0.5f; "world", 0.2f; "yeeha", 0.1f]
        let generations = simulationRounds crossoverMethod mutationMethod fitnessMethod selectionMethod numberOfGenerations generation
        Assert.Equal<int>(1, List.length generations)

    [<Fact>]  
    member this.simulationRoundsDoesNotReturnMoreThanSpecifiedNumberOfGenerations() =        
        let numberOfGenerations = 3
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "zzzzz"        
        let selectionMethod = tournament 3
        let generation = ["aaaaa", 0.1f; "bbbbb", 0.2f; "ccccc", 0.3f; "ddddd", 0.4f]
        let generations = simulationRounds crossoverMethod mutationMethod fitnessMethod selectionMethod numberOfGenerations generation
        Assert.True(List.length generations <= numberOfGenerations)

    [<Theory>]
    [<InlineData(0)>]
    [<InlineData(-1)>]
    member this.simulationRoundsWithNumberOfGenerationsIsZeroThrowsArgumentOutOfRangeException(numberOfGenerations) =            
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "hello"        
        let selectionMethod = tournament 3
        let generation = ["hello", 1.0f; "there", 0.5f; "world", 0.2f; "yeeha", 0.1f]
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> simulationRounds crossoverMethod mutationMethod fitnessMethod selectionMethod numberOfGenerations generation |> ignore)
                
    [<Fact>]  
    member this.simulateReturnsGenerationsOfSpecifiedSize() =
        let size = 20
        let length = 5
        let numberOfGenerations = 50
        let generateMethod = generate length size
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "hello"        
        let selectionMethod = tournament 3
        let generations = simulate crossoverMethod mutationMethod fitnessMethod selectionMethod generateMethod numberOfGenerations
        Assert.True(List.forall (fun elem -> List.length elem = size) generations)

    [<Fact>]  
    member this.simulateReturnsSpecifiedNumberOfGenerations() =
        let size = 20
        let length = 5
        let numberOfGenerations = 50
        let generateMethod = generate length size
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "hello"        
        let selectionMethod = tournament 3
        let generations = simulate crossoverMethod mutationMethod fitnessMethod selectionMethod generateMethod numberOfGenerations
        Assert.Equal<int>(numberOfGenerations, List.length generations)

    [<Fact>]  
    member this.simulateWithNumberOfGenerationsIsOneDoesNotThrowException() =        
        let size = 20
        let length = 5
        let numberOfGenerations = 50
        let generateMethod = generate length size
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "hello"        
        let selectionMethod = tournament 3        
        Assert.DoesNotThrow(fun() -> simulate crossoverMethod mutationMethod fitnessMethod selectionMethod generateMethod numberOfGenerations |> ignore)

    [<Theory>]
    [<InlineData(0)>]
    [<InlineData(-1)>]
    member this.simulateWithNumberOfGenerationsIsZeroThrowsArgumentOutOfRangeException(numberOfGenerations) =            
        let size = 20
        let length = 5
        let generateMethod = generate length size
        let crossoverMethod = onePoint 3
        let mutationMethod = mutate 0.05
        let fitnessMethod = fitness "hello"        
        let selectionMethod = tournament 3        
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> simulate crossoverMethod mutationMethod fitnessMethod selectionMethod generateMethod numberOfGenerations |> ignore)