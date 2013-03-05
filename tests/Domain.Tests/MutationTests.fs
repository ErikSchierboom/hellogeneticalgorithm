namespace Domain.Tests

open Domain.Mutation
open System
open System.Threading
open Xunit
open Xunit.Extensions

type MutationTests() = 
  
    [<Fact>]  
    member this.mutateCharacterWillDecrementOrIncrementTheCharacterAtRandom() =
        let mutatedCharacters = List.init 100 (fun i -> mutateCharacter (char 89))
        Assert.Equal<int>(2, Seq.length (Seq.distinct mutatedCharacters))

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
    member this.mutateCharacterAtIndexWithIndexIsInvalidThrowsIndexOutOfRangeException(index) =
        Assert.Throws<IndexOutOfRangeException>(fun() -> mutateCharacterAtIndex index "hello" |> ignore)

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
