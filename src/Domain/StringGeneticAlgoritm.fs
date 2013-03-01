namespace Domain

open System

module StringGeneticAlgorithm =

    let random = new Random()

    let numericCharacterValues (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        List.map (fun c -> Convert.ToUInt16(c:char)) (List.ofArray (str.ToCharArray()))

    let generateRandomIndividual length =
        List.fold (fun acc i -> acc + Convert.ToChar(random.Next(128)).ToString()) "" [1..length]

    let generatePopulation size length =
        List.init size (fun i -> generateRandomIndividual length)

    let mutateCharacter (c:char) =
        if c > char 127 then raise (ArgumentException("The character must be an ASCII character (range [0..127])"))
        match c with
        | '\000' -> '\001' 
        | '\127' -> '~' 
        | _      -> if random.Next(2) = 1 then char (Convert.ToUInt16(c) + uint16 1) else char (Convert.ToUInt16(c) - uint16 1)            

    let mutateCharacterAtIndex index (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        if str.Length = 0 then raise (ArgumentException("The string to mutate must not have length zero."))
        if index < 0 || index >= str.Length then raise (ArgumentException("The index must be greater than or equal to zero and be less than the length of the string."))
        let chars = str.ToCharArray()
        chars.[index] <- mutateCharacter chars.[index]
        new string(chars)

    let mutate (probability:float) (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        if str.Length = 0 then raise (ArgumentException("The string to mutate must not have length zero."))
        if float (random.Next(101)) > probability * 100.0 then str 
        else mutateCharacterAtIndex (random.Next(str.Length)) str            

    let fitness (target:string) (individual:string) =       
        if target = null then raise (ArgumentNullException("individual"))
        if individual = null then raise (ArgumentNullException("individual"))        
        let zipped = List.zip (numericCharacterValues individual) (numericCharacterValues target)
        1.0 - List.fold (fun acc (x:uint16,y:uint16) -> acc + (Math.Abs(float x - float y) / float Char.MaxValue)) 0.0 zipped 
            