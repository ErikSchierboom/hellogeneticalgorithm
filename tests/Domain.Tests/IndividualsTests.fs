namespace Domain.Tests

open Domain.Individuals
open System
open Xunit
open Xunit.Extensions

type IndividualsTests() = 

    [<Fact>]  
    member this.generateRandomIndividualGeneratesRandomIndividualOfSpecifiedLength() =        
        Assert.Equal<int>(10, String.length (generateRandomIndividual 10))

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