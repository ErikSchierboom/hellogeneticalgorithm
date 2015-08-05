#r @"..\..\packages\FsCheck.2.0.5\lib\net45\FsCheck.dll"
#r @"..\..\packages\FSharpx.Collections.1.12.1\lib\net40\FSharpx.Collections.dll"

open System
open FsCheck

open FSharpx.Collections

type Gene = 
    | Zero = 0 
    | One = 1

type Chromosome = {
    Genes: NonEmptyList<Gene>
    Fitness: float
}

module Genes =

    let mutate gene = if gene = Gene.Zero then Gene.One else Gene.Zero

module Chromosomes =

    let map f x = { x with Genes = NonEmptyList.map f x.Genes }

    let mutate shouldMutateGene mutateGene chromosome = map (fun x -> if shouldMutateGene x then mutateGene x else x) chromosome  

type CustomGenerators =
      static member NonEmptyList() = { new Arbitrary<NonEmptyList<'a>>() with
        override x.Generator = gen {
            let! head = Arb.generate<'a>
            let! tail = Arb.generate<'a> |> Gen.listOf
            return NonEmptyList.create head tail
        } 
        override x.Shrinker (xs: NonEmptyList<'a>) = 
            Arb.shrink xs.Tail |> Seq.map (fun ys -> NonEmptyList.create xs.Head ys)
     }

module Helpers =

    let geneFlipped (input, output) = if input = Gene.Zero then output = Gene.One else output = Gene.Zero

    let listAsFunction xs = 
        let mutable remainder = xs

        let h = fun _ -> 
            let hd = remainder |> List.head 
            remainder <- remainder |> List.tail 
            hd
        h
 
Arb.register<CustomGenerators>() |> ignore

let testEnum (e:Chromosome) = e.Genes.Length > 0
Check.Quick testEnum

   
let test2 (chromosome: Chromosome) (shouldMutateValues: bool list) =
    chromosome.Genes.Length = shouldMutateValues.Length ==> lazy

    let shouldMutate = shouldMutateValues |> Helpers.listAsFunction

    let mutated = Chromosomes.mutate shouldMutate Genes.mutate chromosome

    //mutated.Genes.Length = (chromosome.Genes.Length)
    let flipped = List.zip (chromosome.Genes |> NonEmptyList.toList) (mutated.Genes  |> NonEmptyList.toList) |> List.map (fun pair -> Helpers.geneFlipped pair)
    flipped = shouldMutateValues

Check.Quick test2
        
    