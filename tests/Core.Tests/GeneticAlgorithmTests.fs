namespace GeneticAlgorithm.Tests

open GeneticAlgorithm
open System
open FsCheck
open FsCheck.Xunit
open FSharpx.Collections

module TestHelpers = 
    let geneMutated (input, output) = 
        if input = Gene.Zero then output = Gene.One
        else output = Gene.Zero
    
    let listAsFunction xs = 
        let mutable remainder = xs
        
        let h = 
            fun _ -> 
                let hd = remainder |> List.head
                remainder <- remainder |> List.tail
                hd
        h

module TestData =

    type ChromosomeTestData = 
        { Chromosome : Chromosome
          ShouldMutateValues : bool list }
    
    type CustomGenerators = 
        
        static member ChromosomeTestData() = 
            { new Arbitrary<ChromosomeTestData>() with
                  member x.Generator = 
                      gen { 
                          let! chromosome = Arb.generate<Chromosome>
                          let! shouldMutateValues = Arb.generate<bool> |> Gen.listOfLength chromosome.Genes.Length
                          return { Chromosome = chromosome
                                   ShouldMutateValues = shouldMutateValues }
                      } }
        
        static member NonEmptyList() = 
            { new Arbitrary<NonEmptyList<'a>>() with
                  member x.Generator = gen { let! head = Arb.generate<'a>
                                             let! tail = Arb.generate<'a> |> Gen.listOf
                                             return NonEmptyList.create head tail }
                  member x.Shrinker(xs : NonEmptyList<'a>) = 
                      Arb.shrink xs.Tail |> Seq.map (fun ys -> NonEmptyList.create xs.Head ys) }
    
    type ChromosomePropertyAttribute() = 
        inherit PropertyAttribute(Arbitrary = [| typeof<CustomGenerators> |])

module MutationTests = 

    open TestData
    open TestHelpers
    open Mutation

    [<Property>]
    let ``mutateGene returns mutated gene`` (gene : Gene) = 
        let mutated = mutateGene gene

        geneMutated (gene, mutated)
    
    [<ChromosomePropertyAttribute>]
    let ``mutateChromosome returns chromosome with genes mutated when shouldMutateGene returns true`` (chromosomeTestData : ChromosomeTestData) = 
        let shouldMutate = chromosomeTestData.ShouldMutateValues |> listAsFunction

        let mutated = mutateChromosome shouldMutate mutateGene chromosomeTestData.Chromosome

        let flipped = 
            List.zip (chromosomeTestData.Chromosome.Genes |> NonEmptyList.toList) (mutated.Genes |> NonEmptyList.toList) 
            |> List.map (fun pair -> geneMutated pair)
        flipped = chromosomeTestData.ShouldMutateValues
