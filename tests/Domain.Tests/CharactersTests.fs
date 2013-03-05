namespace Domain.Tests

open Domain.Characters
open System
open Xunit
open Xunit.Extensions

type CharactersTests() = 

    [<Fact>]  
    member this.generateCharacterReturnsCharacterWithSpecifiedRange() =
        let characters = List.init 50 (fun i -> generateCharacter 30)
        Assert.True(List.forall (fun c -> int c >= 0 && int c <= 30) characters)

    [<Fact>]  
    member this.generateCharacterReturnsRandomCharacters() =
        let characters = List.init 50 (fun i -> generateCharacter 127)
        Assert.True(characters |> Seq.distinct |> Seq.length > 1)

    [<Fact>]  
    member this.numericCharacterValuesReturnsCorrectCharacterValues() =
        Assert.True([uint16 104; uint16 101; uint16 108; uint16 108; uint16 111] = numericCharacterValues "hello")

    [<Fact>]  
    member this.numericCharacterValuesWithNullStringThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> numericCharacterValues null |> ignore)