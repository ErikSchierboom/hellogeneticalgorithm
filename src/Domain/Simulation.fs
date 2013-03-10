namespace Domain

open Domain.Population

open Characters
open System

module Simulation =

   let simulationRound crossover mutation fitness selection generation =        
       let parents = selection fitness generation
       evolve crossover mutation parents

   let simulationRounds crossover mutation fitness selection generation numberOfRounds =        
       List.fold (fun acc elem -> 
            match acc with
            | []   -> simulationRound crossover mutation fitness selection generation
            | x::xs -> simulationRound crossover mutation fitness selection x) [] [1..numberOfRounds]

   let simulate crossover mutation fitness selection generate size numberOfRounds = 
       let population = generate size
       simulationRounds crossover mutation fitness selection population numberOfRounds