namespace Domain.Tests

open Domain.Population
open Domain.Crossover
open Domain.Mutation
open System
open Xunit
open Xunit.Extensions

type PopulationTests() = 

    [<Fact>]  
    member this.generateIndividualGeneratesRandomIndividualOfSpecifiedLength() =        
        Assert.Equal<int>(10, String.length (generateIndividual 10))

    [<Fact>]  
    member this.generateIndividualGeneratesRandomIndividuals() =      
        Assert.False(generateIndividual 10 = generateIndividual 10)

    [<Fact>]  
    member this.generateGeneratesPopulationOfRandomIndividuals() =              
        Assert.Equal<int>(100, generate 5 100 |> Seq.distinct |> Seq.length)

    [<Fact>]  
    member this.generateGeneratesPopulationOfRandomIndividualsOfSpecifiedSize() =      
        Assert.Equal<int>(100, generate 5 100 |> List.length)

    [<Fact>]
    member this.generateGeneratesPopulationOfRandomIndividualsWithSpecifiedLength() =              
        Assert.True(List.forall (fun (elem:string) -> elem.Length = 5) (generate 5 100))
        
    [<Fact>]
    member this.evolveReturnsPopulationOfSameSize() =
        let onePointCrossover = onePoint 3
        let mutation = mutate 0.25
        let evolvedPopulation = evolve onePointCrossover mutation ["hello"; "there"; "world"; "yeeha"]
        Assert.Equal(4, List.length evolvedPopulation)

    [<Fact>]
    member this.evolveOnPopulationOfOddSizeThrowsArgumentException() =
        let onePointCrossover = onePoint 3
        let mutation = mutate 0.25
        Assert.Throws<ArgumentException>(fun() -> evolve onePointCrossover mutation ["hello"; "there"; "world"] |> ignore)