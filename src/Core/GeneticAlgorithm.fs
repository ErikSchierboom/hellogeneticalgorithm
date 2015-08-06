namespace GeneticAlgorithm

open FSharpx.Collections

type Gene = 
    | Zero = 0 
    | One = 1

type Chromosome = {
    Genes: NonEmptyList<Gene>
    Fitness: float
}

module Chromosomes =

    let map f x = { x with Genes = NonEmptyList.map f x.Genes }

module Mutation =

    let mutateGene gene = if gene = Gene.Zero then Gene.One else Gene.Zero

    let mutateChromosome shouldMutateGene mutateGene chromosome = Chromosomes.map (fun x -> if shouldMutateGene x then mutateGene x else x) chromosome  