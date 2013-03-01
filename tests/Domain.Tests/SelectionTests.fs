namespace Domain.Tests

open Domain.Selection
open System
open Xunit
open Xunit.Extensions

type SelectionTests() = 

    [<Fact>]  
    member this.fitnessOnCorrectlyCalculatesFitness() =
        Assert.Equal(1.0, fitness "hello world" "hello world")

    [<Fact>]  
    member this.fitnessOfMoreCorrectIndividualIsHigherThanLessCorrectIndividual() =
        Assert.True(fitness "hello world" "halla world" > fitness "xalla porla" "hello world")

    [<Fact>]  
    member this.fitnessOnIndividualWithLengthLessThanTargetStringThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> fitness "hello world" "hello worl" |> ignore)

    [<Fact>]  
    member this.fitnessOnIndividualWithLengthGreaterThanTargetStringThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> fitness "hello world" "hello worlds" |> ignore)

    [<Fact>]  
    member this.fitnessWithNullIndividualThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> fitness "hello world" null |> ignore)

    [<Fact>]  
    member this.fitnessWithNullTargetThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> fitness null "hello world" |> ignore)
