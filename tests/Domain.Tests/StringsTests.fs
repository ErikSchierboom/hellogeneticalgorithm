namespace Domain.Tests

open Domain.Strings
open System
open Xunit
open Xunit.Extensions

type StringsTests() = 

    [<Fact>]  
    member this.numericCharacterValuesReturnsCorrectCharacterValues() =
        Assert.True([uint16 104; uint16 101; uint16 108; uint16 108; uint16 111] = numericCharacterValues "hello")

    [<Fact>]  
    member this.numericCharacterValuesWithNullStringThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> numericCharacterValues null |> ignore)