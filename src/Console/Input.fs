namespace StudioDonder.HelloGeneticAlgorithm.Console

open System

module Input =

    let readString (message:string) = 
        Console.WriteLine(message) |> ignore
        let target = Console.ReadLine()
        if target = "" then 
            Console.WriteLine("Error: you did not enter a valid value.")
            None 
        else 
            Some(target)

    let readInt (message:string) = 
        match readString message with
        | None -> None
        | Some(x) -> Some(int x)

    let readTarget =
        readString "Please enter the string you want to generate (e.g. \"Hello World\")"

    let readPopulationSize =
        readInt "Please enter the size of the population (e.g. 20)"
 
    let readNumberOfGenerations =
        readInt "Please enter the maximum number of generations (e.g. 500)"