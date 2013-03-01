namespace Domain.Tests

open Domain.StringGeneticAlgorithm
open System
open Xunit
open Xunit.Extensions

type StringGeneticAlgorithmTests() = 

    [<Fact>]  
    member this.numericCharacterValuesReturnsCorrectCharacterValues() =
        Assert.True([uint16 104; uint16 101; uint16 108; uint16 108; uint16 111] = numericCharacterValues "hello")

    [<Fact>]  
    member this.numericCharacterValuesWithNullStringThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> numericCharacterValues null |> ignore)

    [<Fact>]  
    member this.generateRandomIndividualGeneratesRandomIndividualOfSpecifiedLength() =
        let randomIndividual = generateRandomIndividual 10
        Assert.True(randomIndividual.Length = 10)

    [<Fact>]  
    member this.generateRandomIndividualGeneratesRandomIndividuals() =      
        Assert.False(generateRandomIndividual 10 = generateRandomIndividual 10)

    [<Fact>]  
    member this.generatePopulationGeneratesPopulationOfRandomIndividuals() =              
        Assert.Equal<int>(100, generatePopulation 100 5 |> Seq.distinct |> Seq.length)

    [<Fact>]  
    member this.generatePopulationGeneratesPopulationOfRandomIndividualsOfSpecifiedSize() =      
        Assert.Equal<int>(100, generatePopulation 100 5 |> List.length)

    [<Fact>]  
    member this.generatePopulationGeneratesPopulationOfRandomIndividualsWithSpecifiedLength() =              
        Assert.True(List.forall (fun (elem:string) -> elem.Length = 5) (generatePopulation 100 5))

    [<Fact>]  
    member this.mutateCharacterWillDecrementOrIncrementTheCharacterAtRandom() =
        let mutatedCharacters = List.init 50 (fun i -> mutateCharacter (char 89))
        Assert.True([char 88; char 90] = List.ofSeq (Seq.distinct mutatedCharacters))

    [<Fact>]  
    member this.mutateCharacterWithCharacterHasMinimumValueIncrementsTheCharacter() =
        Assert.Equal<char>(char 1, mutateCharacter (char 0))

    [<Fact>]  
    member this.mutateCharacterWithCharacterHasMaximumValueDecrementsTheCharacter() =
        Assert.Equal<char>(char 126, mutateCharacter (char 127))

    [<Fact>]  
    member this.mutateCharacterWithCharacterIsNoASCIICharacterThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> mutateCharacter (char 128) |> ignore)

    [<Fact>]  
    member this.mutateCharacterAtIndexWithCharacterHasMinimumValueIncrementsTheCharacter() =
        Assert.Equal<string>((char 1).ToString(), mutateCharacterAtIndex 0 ((char 0).ToString()))

    [<Fact>]  
    member this.mutateCharacterAtIndexWithCharacterHasMaximumValueDecrementsTheCharacter() =
        Assert.Equal<string>((char 126).ToString(), mutateCharacterAtIndex 0 ((char 127).ToString()))

    [<Fact>]  
    member this.mutateCharacterAtIndexWithNullStringThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> mutateCharacterAtIndex 0 null |> ignore)

    [<Fact>]  
    member this.mutateCharacterAtIndexWithStringOfLengthZeroThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> mutateCharacterAtIndex 0 "" |> ignore)

    [<Theory>]  
    [<InlineData(-1)>]
    [<InlineData(5)>]
    [<InlineData(6)>]
    member this.mutateCharacterAtIndexWithIndexIsInvalidThrowsArgumentException(index) =
        Assert.Throws<ArgumentException>(fun() -> mutateCharacterAtIndex index "hello" |> ignore)

    [<Fact>]  
    member this.mutateWithProbabilityIsOneMutatesIndividual() =
        Assert.NotEqual<string>("abcdefg", mutate 1.0 "abcdefg")

    [<Fact>]  
    member this.mutateWithProbabilityIsZeroDoesNotMutateIndividual() =
        Assert.Equal<string>("abcdefg", mutate 0.0 "abcdefg")

    [<Fact>]  
    member this.mutateWithNullStringThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> mutate 0.5 null |> ignore)

    [<Fact>]  
    member this.mutateWithStringOfLengthZeroThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> mutate 0.5 "" |> ignore)

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
