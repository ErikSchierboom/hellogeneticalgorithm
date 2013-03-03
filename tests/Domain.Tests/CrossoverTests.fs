namespace Domain.Tests

open Domain.Crossover
open System
open Xunit
open Xunit.Extensions

type CrossoverTests() = 

    [<Fact>]  
    member this.onePointUsesSpecifiedPointToCrossoverIndividuals() =
        let parent1 = "hellothere"
        let parent2 = "voilasuper"
        let child1, child2 = onePoint 5 parent1 parent2
        Assert.Equal<string>("hellosuper", child1)
        Assert.Equal<string>("voilathere", child2)

    [<Fact>]  
    member this.onePointWithCrossoverPointIsZeroThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> onePoint 0 "hello" "there" |> ignore)

    [<Fact>]  
    member this.onePointWithCrossoverPointIsLessThanZeroThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> onePoint -1 "hello" "there" |> ignore)

    [<Fact>]  
    member this.onePointWithCrossoverPointIsGreaterThanLengthOfParentThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> onePoint 6 "hello" "there" |> ignore)

    [<Fact>]  
    member this.onePointWithParentsOfDifferentLengthThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> onePoint 2 "hello" "hola" |> ignore)

    [<Fact>]  
    member this.onePointWithNullParentOneThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> onePoint 5 null "hello" |> ignore)

    [<Fact>]  
    member this.onePointWithNullParentTwoThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> onePoint 5 "hello" null |> ignore)
