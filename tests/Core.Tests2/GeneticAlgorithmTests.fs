﻿namespace GeneticAlgorithm.Tests

open GeneticAlgorithm
open System
open FsCheck
open FsCheck.NUnit

module GenesTests = 

    [<Property>]
    let ``NUnit: Mutate returns flipped gene`` (gene: Gene) =
        let mutated = Genes.mutate gene

        if gene = Gene.Zero then mutated = Gene.One else mutated = Gene.Zero

module ChromosomesTests =

    [<Property>]
    let ``NUnit: Mutate with shouldMutateGene always true will flip all genes`` (chromosome: Chromosome) =       
        let mutated = Chromosomes.mutate (fun _ -> true) Genes.mutate chromosome
        
        List.zip chromosome.Genes mutated.Genes |> List.forall (fun (x, y) -> not (x = y))