namespace Domain.Tests

open Domain.Population
open Domain.Crossover
open Domain.Selection
open Domain.Mutation
open Domain.Simulation
open System
open Xunit
open Xunit.Extensions

type SimulationTests() = 

    [<Fact>]  
    member this.simulationRoundReturnsGenerationOfEqualSize() =        
        let numberOfRounds = 50
        let size = 50
        let fitnessMethod = fitness "hello world"
        let generateMethod = generate 11
        let selectionMethod = tournament 10
        let mutationMethod = mutate 0.05
        let crossoverMethod = onePoint 5
        let nextGeneration = simulationRound crossoverMethod mutationMethod fitnessMethod selectionMethod ["hello"; "there"; "world"; "yeeha"]
        Assert.Equal<int>(10, List.length nextGeneration)

    [<Fact>]  
    member this.simulationRoundReturnsGenerationOfSpecifiedSize() =        
        let numberOfRounds = 50
        let size = 50
        let fitnessMethod = fitness "hello world"
        let generateMethod = generate 11
        let selectionMethod = tournament 10
        let mutationMethod = mutate 0.05
        let crossoverMethod = onePoint 5
        let generations = simulationRounds crossoverMethod mutationMethod fitnessMethod selectionMethod ["hello"; "there"; "world"; "yeeha"] numberOfRounds
        Assert.True(List.forall (fun elem -> List.length elem = size) generations)

    [<Fact>]  
    member this.simulate() =        
        []
        //Assert.Equal<int>(10, String.length (generateIndividual 10))