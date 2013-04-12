namespace StudioDonder.HelloGeneticAlgorithm.Website

open StudioDonder.HelloGeneticAlgorithm.Domain.Crossover
open StudioDonder.HelloGeneticAlgorithm.Domain.Mutation
open StudioDonder.HelloGeneticAlgorithm.Domain.Selection
open StudioDonder.HelloGeneticAlgorithm.Domain.Population
open StudioDonder.HelloGeneticAlgorithm.Domain.Fitness
open StudioDonder.HelloGeneticAlgorithm.Domain.Simulation
open System
open System.Web
open System.Web.Mvc

[<HandleError>]
type HomeController() =
    inherit Controller()

    [<HttpGet>]
    member this.Index () =        
        let model = new HomeIndexViewModel()
        this.View(model) :> ActionResult

     [<HttpPost>]
     [<ValidateAntiForgeryToken>]
     member this.Index (model:HomeIndexViewModel) =
        if this.ModelState.IsValid then
            let generateMethod = generate model.Target.Length model.PopulationSize
            let crossoverMethod = onePoint model.CrossoverPoint
            let mutationMethod = mutate model.MutationProbability
            let fitnessMethod = fitness model.Target       
            let selectionMethod = tournament model.TournamentSize

            let startTime = DateTime.Now
            let generations = simulate crossoverMethod mutationMethod fitnessMethod selectionMethod generateMethod model.NumberOfGenerations
            let timeElapsed = DateTime.Now - startTime

            model.ProcessGenerations(generations)

            this.View(model) :> ActionResult
        else
            this.View(model) :> ActionResult