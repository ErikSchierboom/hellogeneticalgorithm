namespace GeneticAlgorithm.Tests

open GeneticAlgorithm
open System
open FsCheck
open FsCheck.Xunit
open FSharpx.Collections

module Helpers =

    let geneFlipped (input, output) = if input = Gene.Zero then output = Gene.One else output = Gene.Zero

    let listAsFunction xs = 
        let mutable remainder = xs

        let h = fun _ -> 
            let hd = remainder |> List.head 
            remainder <- remainder |> List.tail 
            hd
        h
        
module GenesTests = 

    [<Property>]
    let ``Xunit: Mutate returns flipped gene`` (gene: Gene) =
        let mutated = Genes.mutate gene

        Helpers.geneFlipped (gene, mutated)

module ChromosomesTests =

    type ChromosomeTestData = {
        Chromosome: Chromosome
        ShouldMutateValues: bool list
     }

    type CustomGenerators =
      static member ChromosomeTestData() = { new Arbitrary<ChromosomeTestData>() with
        override x.Generator = gen {
            let! chromosome = Arb.generate<Chromosome>
            let! shouldMutateValues = Arb.generate<bool> |> Gen.listOfLength chromosome.Genes.Length
            return {
                Chromosome = chromosome
                ShouldMutateValues = shouldMutateValues
            }
        } 
      }

      static member NonEmptyList() = { new Arbitrary<NonEmptyList<'a>>() with
        override x.Generator = gen {
            let! head = Arb.generate<'a>
            let! tail = Arb.generate<'a> |> Gen.listOf
            return NonEmptyList.create head tail
        } 
        override x.Shrinker (xs: NonEmptyList<'a>) = 
            Arb.shrink xs.Tail |> Seq.map (fun ys -> NonEmptyList.create xs.Head ys)
    }

     type ChromosomePropertyAttribute () =
        inherit PropertyAttribute(Arbitrary = [| typeof<CustomGenerators> |])

    [<ChromosomePropertyAttribute>]
    let ``Xunit: Mutate only flips gene when shouldMutateGene returns true`` (chromosomeTestData: ChromosomeTestData) =
        let shouldMutate = chromosomeTestData.ShouldMutateValues |> Helpers.listAsFunction

        let mutated = Chromosomes.mutate shouldMutate Genes.mutate chromosomeTestData.Chromosome

        let flipped = List.zip (chromosomeTestData.Chromosome.Genes |> NonEmptyList.toList) (mutated.Genes  |> NonEmptyList.toList) |> List.map (fun pair -> Helpers.geneFlipped pair)
        flipped = chromosomeTestData.ShouldMutateValues