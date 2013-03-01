namespace Domain

open System

module Strings =

    let numericCharacterValues (str:string) =
        if str = null then raise (ArgumentNullException("str"))
        List.map (fun c -> Convert.ToUInt16(c:char)) (List.ofArray (str.ToCharArray()))