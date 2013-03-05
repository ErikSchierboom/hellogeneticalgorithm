﻿namespace Domain

open Domain.Characters
open System

module Selection =
    
    let fitness (target:string) (individual:string) =       
        if target = null then raise (ArgumentNullException("individual"))
        if individual = null then raise (ArgumentNullException("individual"))        
        let zipped = List.zip (numericCharacterValues individual) (numericCharacterValues target)
        1.0 - List.fold (fun acc (x:uint16,y:uint16) -> acc + (Math.Abs(float x - float y) / float Char.MaxValue)) 0.0 zipped

    let tournament size population =
        if size < 1 || size > (List.length population) then raise (ArgumentException("size"))        
        population
            