namespace Domain

open System
open Random

module Characters =

    let generateCharacter maxCharValue = Convert.ToChar(Random.random.Next(maxCharValue + 1))

    let numericCharacterValues (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        List.map (fun c -> Convert.ToUInt16(c:char)) (List.ofArray (str.ToCharArray()))