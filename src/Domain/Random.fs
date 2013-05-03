namespace StudioDonder.HelloGeneticAlgorithm.Domain

open System

module Random =

    let private random = new Random()

    let meetsProbability probability = 
        if probability < 0.0 || probability > 1.0  then raise (ArgumentOutOfRangeException("The probability must be in the range [0.0 .. 1.0]."))            
        random.NextDouble() <= probability

    let doesNotMeetProbability probability = 
        if probability < 0.0 || probability > 1.0  then raise (ArgumentOutOfRangeException("The probability must be in the range [0.0 .. 1.0]."))            
        random.NextDouble() > probability

    let generateProbability = random.Next()
    let generateInt maxValue = random.Next(maxValue)