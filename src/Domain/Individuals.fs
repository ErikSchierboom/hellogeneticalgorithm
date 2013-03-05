namespace Domain

open Characters

module Individuals =

    let generateRandomIndividual length =
        List.fold (fun acc elem -> acc + (generateCharacter 127).ToString()) "" [1..length]

    let generatePopulation size length =
        List.init size (fun index -> generateRandomIndividual length)