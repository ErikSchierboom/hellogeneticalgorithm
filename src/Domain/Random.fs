namespace StudioDonder.HelloGeneticAlgorithm.Domain

open System

module Random =

    type Probability = double

    let private random = new Random()

    let meetsProbability (probability:Probability) = 
        if probability < 0.0 || probability > 1.0  then raise (ArgumentOutOfRangeException("The probability must be in the range [0.0 .. 1.0]."))            
        random.NextDouble() <= probability

    let doesNotMeetProbability (probability:Probability) = 
        if probability < 0.0 || probability > 1.0  then raise (ArgumentOutOfRangeException("The probability must be in the range [0.0 .. 1.0]."))            
        random.NextDouble() > probability

    let generateProbability = random.Next()
    let generateInt maxValue = random.Next(maxValue)