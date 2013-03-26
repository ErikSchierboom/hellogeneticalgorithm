namespace StudioDonder.HelloGeneticAlgorithm.Domain

open StudioDonder.HelloGeneticAlgorithm.Domain.Characters
open System
open Random

module Mutation =

    let mutateCharacter (c:char) =
        if c > char 127 then raise (ArgumentException("The character must be an ASCII character (range [0..127])"))
        match c with
        | '\000' -> '\001' 
        | '\127' -> '~' 
        | _      -> if meetsProbability 0.5 
                    then char (numericCharacterValue c - uint16 1) 
                    else char (numericCharacterValue c + uint16 1)

    let mutateCharacterAtIndex index (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        if str.Length = 0 then raise (ArgumentException("The string to mutate must not have length zero."))
        let chars = str.ToCharArray()
        chars.[index] <- mutateCharacter chars.[index]
        new string(chars)

    let mutate (probability:float) (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        if str.Length = 0 then raise (ArgumentException("The string to mutate must not have length zero."))
        if doesNotMeetProbability probability then str 
        else mutateCharacterAtIndex (random.Next(str.Length)) str    
            