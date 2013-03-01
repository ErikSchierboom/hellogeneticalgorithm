namespace Domain

open System

module StringGeneticAlgorithm =

    let random = new Random()

    let generateRandomIndividual length =
        List.fold (fun acc i -> acc + Convert.ToChar(random.Next(128)).ToString()) "" [1..length]

    let numericCharacterValues (str:string) =
        List.map (fun c -> Convert.ToUInt16(c:char)) (List.ofArray (str.ToCharArray()))

    let fitness (individual:string) (target:string) =        
        let zipped = List.zip (numericCharacterValues individual) (numericCharacterValues target)
        1.0 - List.fold (fun acc (x:uint16,y:uint16) -> acc + (Math.Abs(float x - float y) / float Char.MaxValue)) 0.0 zipped 
            