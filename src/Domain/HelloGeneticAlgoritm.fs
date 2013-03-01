namespace Domain

open System

module HelloGeneticAlgorithm =

    let random = new Random()

    let numericCharacterValues (str:string) =
        List.map (fun c -> Convert.ToUInt16(c:char)) (List.ofArray (str.ToCharArray()))

    let fitness (individual:string) =        
        let zipped = List.zip (numericCharacterValues individual) (numericCharacterValues "hello world")
        1.0 - List.fold (fun acc (x:uint16,y:uint16) -> acc + (Math.Abs(float x - float y) / float Char.MaxValue)) 0.0 zipped 
            