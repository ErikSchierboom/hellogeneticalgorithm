namespace StudioDonder.HelloGeneticAlgorithm.Domain

open System

module Types =
    
    type Individual = string
    type Fitness = float    
    type Children = Individual * Individual
    type Parent = Individual   
    
