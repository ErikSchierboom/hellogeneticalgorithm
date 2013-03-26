namespace Domain

open System
open Random

module Characters =

    let generateCharacter maxCharValue = Convert.ToChar(Random.random.Next(maxCharValue + 1))

    let charactersList (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        List.ofArray (str.ToCharArray())

    let numericCharacterValue c =
        Convert.ToUInt16(c:char)

    let numericCharacterValues (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        charactersList str |> List.map numericCharacterValue