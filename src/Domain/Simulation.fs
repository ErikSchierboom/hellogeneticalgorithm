namespace StudioDonder.HelloGeneticAlgorithm.Domain

open Population
open Fitness
open Selection
open Characters
open System

module Simulation =

   let simulationRound crossover mutation fitness selection generation =        
       let parents = selection generation
       let children = evolve crossover mutation (List.map fst parents)
       calculateFitnessForPopulation fitness children       

   let simulationRounds crossover mutation fitness selection numberOfGenerations generation =     
       if numberOfGenerations < 1 then raise (ArgumentOutOfRangeException("numberOfGenerations"))
       let rec simulationRoundAccumulator numberOfGenerations generations =
           if numberOfGenerations <= 1 || maximumFitness (List.head generations) >= 1.0f then generations
           else 
               let newGeneration = simulationRound crossover mutation fitness selection (List.head generations)
               simulationRoundAccumulator (numberOfGenerations - 1) (newGeneration :: generations)
            
       simulationRoundAccumulator numberOfGenerations [generation]

   let simulate crossover mutation fitness selection generate numberOfGenerations = 
       generate 
       |> calculateFitnessForPopulation fitness
       |> simulationRounds crossover mutation fitness selection numberOfGenerations
       |> List.rev