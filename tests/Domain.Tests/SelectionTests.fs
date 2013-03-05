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

    [<Fact>]  
    member this.populationWithFitnessReturnsPopulationWithFitnessCalculatedForAllIndividuals() =
        let fitnessTest = fitness "hello world"
        let populationWithFitness = populationWithFitness fitnessTest ["hallo world"; "hello world"; "hilli warld"]        
        Assert.True(["hallo world", 0.999938963912413; "hello world", 1.0; "hilli warld", 0.999633783474479] = populationWithFitness)
        
        
//    [<Fact>]  
//    member this.tournamentRoundWillSelectMostFitIndividual() =
//        let selectedIndividuals = tournamentRound 2 ["hello"; "there"; "world"]        
//        Assert.Equal(2, selectedIndividuals |> Seq.distinct |> Seq.length)

    [<Fact>]  
    member this.tournamentRoundWithSizeIsZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournamentRound 0 ["hello"] |> ignore)

    [<Fact>]  
    member this.tournamentRoundWithSizeIsLessThanZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournamentRound -1 ["hello"] |> ignore)

    [<Fact>]  
    member this.tournamentRoundWithSizeIsGreaterThanSizeOfPopulationThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournamentRound 2 ["hello"] |> ignore)

    [<Fact>]  
    member this.tournamentWillReturnPopulationOfEqualSize() =
        let selectedPopulation = tournament 2 ["hello"; "there"; "world"]
        Assert.Equal(3, List.length selectedPopulation)

    [<Fact>]  
    member this.tournamentWithSizeIsZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament 0 ["hello"] |> ignore)

    [<Fact>]  
    member this.tournamentWithSizeIsLessThanZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament -1 ["hello"] |> ignore)

    [<Fact>]  
    member this.tournamentWithSizeIsGreaterThanSizeOfPopulationThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament 2 ["hello"] |> ignore)
