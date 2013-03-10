// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open Domain.Crossover
open Domain.Mutation
open Domain.Selection
open Domain.Population
open Domain.Simulation

[<EntryPoint>]
let main argv = 
    let numberOfRounds = 50
    let size = 50
    let fitnessMethod = fitness "hello world"
    let generateMethod = generate 11
    let selectionMethod = tournament 10
    let mutationMethod = mutate 0.05
    let crossoverMethod = onePoint 5
    //let result = simulate crossoverMethod mutationMethod fitnessMethod selectionMethod generateMethod size numberOfRounds
    //let result = simulationRounds crossoverMethod mutationMethod fitnessMethod selectionMethod [] numberOfRounds
    0 // return an integer exit code
