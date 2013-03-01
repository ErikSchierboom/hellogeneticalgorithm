namespace Domain.Tests

open Domain.StringGeneticAlgorithm
open System
open Xunit

type StringGeneticAlgorithmTests() = 

    [<Fact>]  
    member this.generateRandomIndividualGeneratesRandomIndividualOfSpecifiedLength() =
        let randomIndividual = generateRandomIndividual 10
        Assert.True(randomIndividual.Length = 10)

    [<Fact>]  
    member this.generateRandomIndividualGeneratesRandomIndividuals() =      
        Assert.False(generateRandomIndividual 10 = generateRandomIndividual 10)

    [<Fact>]  
    member this.numericCharacterValuesReturnsCorrectCharacterValues() =
        Assert.True([uint16 104; uint16 101; uint16 108; uint16 108; uint16 111] = numericCharacterValues "hello")

    [<Fact>]  
    member this.fitnessOnCorrectlyCalculatesFitness() =
        Assert.Equal(1.0, fitness "hello world" "hello world")

    [<Fact>]  
    member this.fitnessOfMoreCorrectIndividualIsHigherThanLessCorrectIndividual() =
        Assert.True(fitness "halla world" "hello world" > fitness "xalla porla" "hello world")

    [<Fact>]  
    member this.fitnessOnIndividualWithLengthLessThanTargetStringThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> fitness "hello worl" "hello world" |> ignore)

    [<Fact>]  
    member this.fitnessOnIndividualWithLengthGreaterThanTargetStringThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> fitness "hello worlds" "hello world" |> ignore)
