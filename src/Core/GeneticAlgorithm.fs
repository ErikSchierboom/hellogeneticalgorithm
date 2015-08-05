namespace GeneticAlgorithm

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