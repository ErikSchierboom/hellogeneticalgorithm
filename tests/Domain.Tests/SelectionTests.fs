namespace StudioDonder.HelloGeneticAlgorithm.Domain.Tests

open StudioDonder.HelloGeneticAlgorithm.Domain.Selection
open System
open Xunit
open Xunit.Extensions

type SelectionTests() = 
        
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
        let selectedPopulation = tournament 2 ["hello", 0.8f; "there", 0.5f; "world", 0.2f]
        Assert.Equal(3, List.length selectedPopulation)

    [<Fact>]  
    member this.tournamentWithSizeIsZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament 0 ["hello", 0.8f] |> ignore)

    [<Fact>]  
    member this.tournamentWithSizeIsLessThanZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament -1 ["hello", 0.8f] |> ignore)

    [<Fact>]  
    member this.tournamentWithSizeIsGreaterThanSizeOfPopulationThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> tournament 2 ["hello", 0.8f] |> ignore)
