namespace Domain

open System

module Individuals =

    let random = new Random()   

    let generateRandomIndividual length =
        List.fold (fun acc elem -> acc + Convert.ToChar(random.Next(128)).ToString()) "" [1..length]

    let generatePopulation size length =
        List.init size (fun index -> generateRandomIndividual length)