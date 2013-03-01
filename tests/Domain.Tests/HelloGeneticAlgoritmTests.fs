namespace Domain.Tests

open Domain.HelloGeneticAlgorithm
open System
open Xunit

type HelloGeneticAlgorithmTests() = 

    [<Fact>]  
    member this.numericCharacterValuesReturnsCorrectCharacterValues() =
        Assert.True([uint16 104; uint16 101; uint16 108; uint16 108; uint16 111] = numericCharacterValues "hello")

    [<Fact>]  
    member this.fitnessOnCorrectlyCalculatesFitness() =
        Assert.Equal(1.0, fitness "hello world")

    [<Fact>]  
    member this.fitnessOfMoreCorrectIndividualIsHigherThanLessCorrectIndividual() =
        Assert.True(fitness "halla world" > fitness "xalla porla")

    [<Fact>]  
    member this.fitnessOnIndividualWithLengthLessThanTargetStringThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> fitness "hello worl" |> ignore)

    [<Fact>]  
    member this.fitnessOnIndividualWithLengthGreaterThanTargetStringThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> fitness "hello worlds" |> ignore)
