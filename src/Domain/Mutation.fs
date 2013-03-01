namespace Domain

open System

module Mutation =

    let random = new Random()

    let mutateCharacter (c:char) =
        if c > char 127 then raise (ArgumentException("The character must be an ASCII character (range [0..127])"))
        match c with
        | '\000' -> '\001' 
        | '\127' -> '~' 
        | _      -> if random.Next(2) = 0 then char (Convert.ToUInt16(c) - uint16 1) else char (Convert.ToUInt16(c) + uint16 1)

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
            