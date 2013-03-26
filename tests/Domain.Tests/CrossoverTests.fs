namespace StudioDonder.HelloGeneticAlgorithm.Domain.Tests

open StudioDonder.HelloGeneticAlgorithm.Domain.Crossover
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
    member this.onePointWithCrossoverPointIsZeroReturnsParentsAsChildren() =
        let parent1 = "hellothere"
        let parent2 = "voilasuper"
        let child1, child2 = onePoint 0 parent1 parent2
        Assert.Equal<string>("voilasuper", child1)
        Assert.Equal<string>("hellothere", child2)

    [<Fact>]  
    member this.onePointWithCrossoverPointIsLessThanZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> onePoint -1 "hello" "there" |> ignore)

    [<Fact>]  
    member this.onePointWithCrossoverPointIsGreaterThanLengthOfParentThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> onePoint 6 "hello" "there" |> ignore)

    [<Fact>]  
    member this.onePointWithParentsOfDifferentLengthThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> onePoint 2 "hello" "hola" |> ignore)

    [<Fact>]  
    member this.onePointWithNullParentOneThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> onePoint 5 null "hello" |> ignore)

    [<Fact>]  
    member this.onePointWithNullParentTwoThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> onePoint 5 "hello" null |> ignore)

    [<Fact>]  
    member this.twoPointUsesSpecifiedPointToCrossoverIndividuals() =
        let parent1 = "hellothere"
        let parent2 = "voilasuper"
        let child1, child2 = twoPoint 5 7 parent1 parent2
        Assert.Equal<string>("hellosuere", child1)
        Assert.Equal<string>("voilathper", child2)
        
    [<Fact>]  
    member this.twoPointWithCrossoverPointOneIsLessThanZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> twoPoint -1 2 "hello" "there" |> ignore)

    [<Fact>]  
    member this.twoPointWithCrossoverPointTwoIsLessThanPointOneArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> twoPoint 4 2  "hello" "there" |> ignore)

    [<Fact>]  
    member this.twoPointWithCrossoverPointTwoIsGreaterThanLengthOfParentThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> twoPoint 2 6  "hello" "there" |> ignore)

    [<Fact>]  
    member this.twoPointWithParentsOfDifferentLengthThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> twoPoint 2 4 "hello" "hola" |> ignore)

    [<Fact>]  
    member this.twoPointWithNullParentOneThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> twoPoint 2 4 null "hello" |> ignore)

    [<Fact>]  
    member this.twoPointWithNullParentTwoThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> twoPoint 2 4 "hello" null |> ignore)

    [<Fact>]  
    member this.uniformWithProbabilityIsZeroReturnsParents() =
        let parent1 = "hellothere"
        let parent2 = "voilasuper"
        let child1, child2 = uniform 0.0 parent1 parent2
        Assert.Equal<string>("hellothere", child1)
        Assert.Equal<string>("voilasuper", child2)

    [<Fact>]  
    member this.uniformWithProbabilityIsOneReturnsOneGeneFromEachParentAlternating() =
        let parent1 = "hellothere"
        let parent2 = "voilasuper"
        let child1, child2 = uniform 1.0 parent1 parent2
        Assert.Equal<string>("veilatueee", child1)
        Assert.Equal<string>("holloshprr", child2)

    [<Fact>]  
    member this.uniformWillSelectCharactersFromEachParent() =
        let parent1 = "hellothere"
        let parent2 = "voilasuper"
        let child1, child2 = uniform 0.5 parent1 parent2
        let charList (str:string) = List.ofArray (str.ToCharArray())
        let parentCharacters = List.zip (charList parent1) (charList parent2) |> List.map (fun (x,y) -> Set.ofList [x;y])        
        let childContainsCharactersFromOneOfParents child = List.zip (charList child) parentCharacters |> List.forall (fun (c, parents:Set<char>) -> parents.Contains c)
        Assert.True(childContainsCharactersFromOneOfParents child1)
        Assert.True(childContainsCharactersFromOneOfParents child2)

    [<Fact>]  
    member this.uniformWithProbabilityIsLessThanZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> uniform -0.1 "hello" "there" |> ignore)

    [<Fact>]  
    member this.uniformWithProbabilityIsGreaterThanOneThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> uniform 1.1 "hello" "there" |> ignore)

    [<Fact>]  
    member this.uniformWithParentsOfDifferentLengthThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> uniform 0.5 "hello" "hola" |> ignore)

    [<Fact>]  
    member this.uniformWithNullParentOneThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> uniform 0.5 null "hello" |> ignore)

    [<Fact>]  
    member this.uniformWithNullParentTwoThrowsArgumentNullException() =
        Assert.Throws<ArgumentNullException>(fun() -> uniform 0.5 "hello" null |> ignore)
