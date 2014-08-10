namespace StudioDonder.HelloGeneticAlgorithm.Domain

open System
open Characters
open Random
open Types

module Mutation =

    type MutationIndex = int

    let mutateCharacter (c:char) =
        if c > char 127 then raise (ArgumentException("The character must be an ASCII character (range [0..127])"))
        match c with
        | '\000' -> '\001' 
        | '\127' -> '~' 
        | _      -> if meetsProbability 0.5 
                    then char (numericCharacterValue c - uint16 1) 
                    else char (numericCharacterValue c + uint16 1)

    let mutateCharacterAtIndex (mutationIndex:MutationIndex) (individual:Individual) =
        if individual = null then raise (ArgumentNullException("individual"))
        if individual.Length = 0 then raise (ArgumentException("The individual to mutate must not have length zero."))
        let chars = individual.ToCharArray()
        chars.[mutationIndex] <- mutateCharacter chars.[mutationIndex]
        new string(chars)

    let mutate (probability:Probability) (individual:Individual) =
        if individual = null then raise (ArgumentNullException("individual"))
        if individual.Length = 0 then raise (ArgumentException("The individual to mutate must not have length zero."))
        if doesNotMeetProbability probability then individual 
        else mutateCharacterAtIndex (Random.generateInt(individual.Length)) individual    
            