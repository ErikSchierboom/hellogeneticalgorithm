namespace StudioDonder.HelloGeneticAlgorithm.Domain

open Characters
open System

module Population =

    type Fitness = float
    type Individual = string

    type IndividualWithFitness = {
        Individual: Individual
        Fitness: Fitness
    }

    type Population = Individual list

    type PopulationWithFitness = {
        Individuals: IndividualWithFitness list
        MostFitIndividual: IndividualWithFitness
        AverageFitness: Fitness
        MaximumFitness: Fitness
        MinimumFitness: Fitness
    }
    
    let generateIndividual length : Individual = List.fold (fun acc elem -> acc + (generateCharacter 127).ToString()) "" [1..length]

    let generate length size : Population = List.init size (fun index -> generateIndividual length)

    let evolve crossover mutation parents = 
        if List.length parents % 2 = 1 then raise (ArgumentException("The parents list must be of even length."))
        parents
        |> List.partitionBySize 2
        |> List.fold (fun acc partition -> 
            let (child1, child2) = crossover partition.[0] partition.[1]            
            mutation child1 :: (mutation child2 :: acc)) []