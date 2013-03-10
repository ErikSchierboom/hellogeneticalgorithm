namespace Domain.Tests

open Domain.Selection
open System
open Xunit
open Xunit.Extensions

type SelectionTests() = 

    [<Fact>]  
    member this.fitnessOnCorrectlyCalculatesFitness() =
        Assert.Equal(1.0f, fitness "hello world" "hello world")

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

    [<Fact>]  
    member this.calculateFitnessForPopulationReturnsPopulationWithFitnessCalculatedForAllIndividuals() =
        let fitnessTest = fitness "hello world"
        let population = calculateFitnessForPopulation fitnessTest ["hallo world"; "hello world"; "hilli warld"]        
        Assert.True(["hallo world", 0.9999389639f; "hello world", 1.0f; "hilli warld", 0.9996337835f] = population)
        
    [<Fact>]  
    member this.tournamentRoundWillSelectMostFitIndividual() =
        let selectedIndividual = tournamentRound 3 ["hallo world", 0.9999389639f; "hello world", 1.0f; "hilli warld", 0.9996337835f]   
        Assert.True(("hello world", 1.0f) = selectedIndividual)

    [<Fact>]  
    member this.tournamentRoundWithSizeIsZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournamentRound 0 ["hello", 1.0f] |> ignore)

    [<Fact>]  
    member this.tournamentRoundWithSizeIsLessThanZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournamentRound -1 ["hello", 1.0f] |> ignore)

    [<Fact>]  
    member this.tournamentRoundWithSizeIsGreaterThanSizeOfPopulationThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournamentRound 2 ["hello", 1.0f] |> ignore)

    [<Fact>]  
    member this.tournamentWillReturnPopulationOfEqualSize() =
        let fitnessTest = fitness "hello"
        let selectedPopulation = tournament 2 fitnessTest ["hello"; "there"; "world"]
        Assert.Equal(3, List.length selectedPopulation)

    [<Fact>]  
    member this.tournamentWithSizeIsZeroThrowsArgumentOutOfRangeException() =
        let fitnessTest = fitness "hello"
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament 0 fitnessTest ["hello"] |> ignore)

    [<Fact>]  
    member this.tournamentWithSizeIsLessThanZeroThrowsArgumentOutOfRangeException() =
        let fitnessTest = fitness "hello"
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament -1 fitnessTest ["hello"] |> ignore)

    [<Fact>]  
    member this.tournamentWithSizeIsGreaterThanSizeOfPopulationThrowsArgumentOutOfRangeException() =
        let fitnessTest = fitness "hello"
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament 2 fitnessTest ["hello"] |> ignore)
