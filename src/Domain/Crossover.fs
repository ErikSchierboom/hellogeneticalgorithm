namespace Domain

open System

module Crossover =

    let random = new Random()

    let onePoint point (parent1:string) (parent2:string) = 
        if parent1 = null then raise (ArgumentNullException("parent1"))
        if parent2 = null then raise (ArgumentNullException("parent2"))
        if not (parent1.Length = parent2.Length) then raise (ArgumentException("The parents must be of equal length."))
        if point < 1 || point > parent1.Length then raise (ArgumentException("The point must be in the range [1..parent1.Length]."))
        parent1.Substring(0, point) + parent2.Substring(point), parent2.Substring(0, point) + parent1.Substring(point)
            