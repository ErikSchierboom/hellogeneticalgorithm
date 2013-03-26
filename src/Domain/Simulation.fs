namespace Domain

open Domain.Population
open Domain.Fitness
open Domain.Selection

open Characters
open System

module Simulation =

   let simulationRound crossover mutation fitness selection generation =        
       let parents = selection generation
       let children = evolve crossover mutation (List.map fst parents)
       calculateFitnessForPopulation fitness children       

   let simulationRounds crossover mutation fitness selection numberOfGenerations generation =     
       if numberOfGenerations < 1 then raise (ArgumentOutOfRangeException("numberOfGenerations"))         
       let secondGeneration = simulationRound crossover mutation fitness selection generation
       List.fold (fun acc elem -> simulationRound crossover mutation fitness selection (List.head acc) :: acc) [secondGeneration] [2..numberOfGenerations]

   let simulate crossover mutation fitness selection generate numberOfGenerations = 
       generate 
       |> calculateFitnessForPopulation fitness
       |> simulationRounds crossover mutation fitness selection numberOfGenerations
       |> List.rev