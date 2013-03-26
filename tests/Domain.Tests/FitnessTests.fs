namespace Domain.Tests

open Domain.Fitness
open System
open Xunit
open Xunit.Extensions

type FitnessTests() = 

    [<Fact>]  
    member this.fitnessCorrectlyCalculatesFitness() =
        Assert.Equal(1.0f, fitness "hello world" "hello world")

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

    [<Fact>]  
    member this.calculateFitnessForPopulationReturnsPopulationWithFitnessCalculatedForAllIndividuals() =
        let fitnessTest = fitness "hello world"
        let population = calculateFitnessForPopulation fitnessTest ["hallo world"; "hello world"; "hilli warld"]        
        Assert.True(["hallo world", 0.9999389639f; "hello world", 1.0f; "hilli warld", 0.9996337835f] = population)

    [<Fact>]  
    member this.mostFitIndivdualReturnsIndividualWithHighestFitness() =                
        Assert.True(("hello", 0.8f) = mostFitIndivdual ["hello", 0.8f; "world", 0.2f; "holla", 0.4f])

    [<Fact>]  
    member this.averageFitnessReturnsAverageFitnessOfPopulation() =                
        Assert.Equal<float32>(0.466666669f, averageFitness ["hello", 0.8f; "world", 0.2f; "holla", 0.4f])

    [<Fact>]  
    member this.maximumFitnessReturnsAverageFitnessOfPopulation() =                
        Assert.Equal<float32>(0.8f, maximumFitness ["hello", 0.8f; "world", 0.2f; "holla", 0.4f])

    [<Fact>]  
    member this.minimumFitnessReturnsAverageFitnessOfPopulation() =                
        Assert.Equal<float32>(0.2f, minimumFitness ["hello", 0.8f; "world", 0.2f; "holla", 0.4f])
