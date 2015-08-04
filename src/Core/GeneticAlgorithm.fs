namespace GeneticAlgorithm

type Gene = 
    | Zero = 0 
    | One = 1

type Chromosome = {
    Genes: Gene list
    Fitness: float
}

module Genes =

    let mutate gene = if gene = Gene.Zero then Gene.One else Gene.Zero

module Chromosomes =

    let map f x = { x with Genes = List.map f x.Genes }

    let mutate shouldMutateGene mutateGene chromosome = map (fun x -> if shouldMutateGene x then mutateGene x else x) chromosome  