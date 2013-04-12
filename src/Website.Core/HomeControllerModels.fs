namespace StudioDonder.HelloGeneticAlgorithm.Website

open StudioDonder.HelloGeneticAlgorithm.Domain.Fitness
open System.ComponentModel.DataAnnotations
open System

type IndividualViewModel(individual: (string * float32)) =
    member this.Value with get() = fst individual
    member this.Fitness with get() = snd individual

type GenerationViewModel(generation: (string * float32) list, generationNumber) =
    let individualModels = new System.Collections.Generic.List<IndividualViewModel>(List.map (fun x -> new IndividualViewModel(x)) generation |> List.toSeq)
    member this.Individuals with get() = individualModels
    member this.MostFitIndividual with get() = new IndividualViewModel(mostFitIndividual generation)
    member this.AverageFitness with get() = averageFitness generation
    member this.MaximumFitness with get() = maximumFitness generation
    member this.MinimumFitness with get() = minimumFitness generation
    member this.GenerationNumber with get() = generationNumber

type HomeIndexViewModel() = 
    [<Required>]
    member val Target = "" with get, set

    [<Required>]
    member val PopulationSize = 20 with get, set

    [<Required>]
    member val NumberOfGenerations = 500 with get, set

    [<Required>]
    member val CrossoverPoint = 3 with get, set

    [<Required>]
    member val MutationProbability = 0.05 with get, set

    [<Required>]
    member val TournamentSize = 5 with get, set

    member val TimeElapsed = new Nullable<DateTime>() with get, set
    member val Generations = new System.Collections.Generic.List<GenerationViewModel>() with get, set
    member this.ProcessGenerations(generations: (string * float32) list list) =
        this.Generations <- new System.Collections.Generic.List<GenerationViewModel>(List.mapi (fun i x -> new GenerationViewModel(x, i + 1)) generations |> List.ofSeq)