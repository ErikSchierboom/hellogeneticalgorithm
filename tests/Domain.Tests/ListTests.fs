namespace StudioDonder.HelloGeneticAlgorithm.Domain.Tests

open System
open Xunit
open Xunit.Extensions

type ListTests() =  

    [<Fact>]
    member this.takeRandomElementReturnsSpecifiedNumberOfRandomElements() =        
        let randomElements = List.takeRandom 4 [1..10]
        Assert.Equal(4, List.length randomElements)

    [<Fact>]  
    member this.takeRandomWithSizeIsZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> List.takeRandom 0 [2; 3; 4] |> ignore)

    [<Fact>]  
    member this.takeRandomWithSizeIsLessThanZeroThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> List.takeRandom -1 [2; 3; 4] |> ignore)

    [<Fact>]  
    member this.takeRandomWithSizeIsGreaterThanSizeOfPopulationThrowsArgumentOutOfRangeException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> List.takeRandom 4 [2; 3; 4] |> ignore)

    [<Fact>]  
    member this.partitionBySizeWithSizeIsEqualToListSizeReturnsOnepartitionBySize() =
        Assert.True([[2; 3; 4]] = List.partitionBySize 3 [2; 3; 4])

    [<Fact>]  
    member this.partitionBySizeReturnPartitionedList() =
        Assert.True([[2; 3]; [4; 5]; [6; 7]] = List.partitionBySize 2 [2; 3; 4; 5; 6; 7])

    [<Fact>]  
    member this.partitionBySizeWithSizeIsNotMultipleOfListSizeThrowsArgumentException() =
        Assert.Throws<ArgumentException>(fun() -> List.partitionBySize 2 [2; 3; 4] |> ignore)

    [<Fact>]  
    member this.partitionBySizeWithSizeIsZeroThrowsArgumentException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> List.partitionBySize 0 [2; 3; 4] |> ignore)

    [<Fact>]  
    member this.partitionBySizeWithSizeIsLessThanZeroThrowsArgumentException() =
        Assert.Throws<ArgumentOutOfRangeException>(fun() -> List.partitionBySize -1 [2; 3; 4] |> ignore)