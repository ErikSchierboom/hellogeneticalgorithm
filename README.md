# Hello Genetic Algorithm

## Introduction
This project contains an implementation of a [generic algorithm](http://en.wikipedia.org/wiki/Genetic_algorithm) that allows text to be evolved from random strings using a very simple genetic algorithm. The implementation is done in F#, which is a functional language that is very well suited for this type of problems.

To make this project slightly more interesting, we have made the functionality available from a console application (not so hard) and from an ASP.NET MVC application. We have tried to use F# wherever we can use in the ASP.NET MVC application.

## Implementation

## Console
The solution contains a small console project 

### Website
The website is a actually a hybrid website; part C# and part F#. The **Website** project contains the **Global.asax** file, the views, scripts and stylesheets. This project is a traditional ASP.NET MVC 4 website implemented in C#. However, the controllers and view models are written in F# and are located in the **Website.Core** project (they have to be separate projects as one will compile C# and the other will compile F#). Interestingly, the [**Global.asax**](src/Website/Global.asax) actually inherits from the [`Global`](src/Website.Core/Global) type defined in the F# project.

Writing the controllers in F# instead of C# is both a blessing and a curse. On the plus side, you get controllers that look a lot cleaner. Check out the definition of the Index action:

    [<HttpGet>]
    member this.Index () =        
        let model = new HomeIndexViewModel()
        this.View(model) :> ActionResult

Furthermore, it of course allows you to easily integrate with other F# code, in our case our domain logic that defines the genetic algorithm implementation. 

The downside is mainly that ASP.NET MVC works exclusively with classes. This problem became most apparent for us when we tried to render the output of our genetic algorithm in our website. We use Razor as our view engine, and Razor expects a class when you want to have a type-safe view. As our genetic algorithm outputs data structures that are specific to F#, Razor could not easily handle them. Therefore, we defined classes  for our view models (which Razor could handle happily) and converted our F# data structures to instances of these view model classes. An example of this is where we convert a tuple describing an individual and its fitness to a class:

    type IndividualViewModel(individual: (string * float32)) =
        member this.Value with get() = fst individual
        member this.Fitness with get() = snd individual

The end result is quite nice. You can define most of your website's logic in F# using only some simple conversions to translate objects from F# space to C# space.

If you are interested in using F# for your ASP.NET MVC applications, check out the [F# C# MVC 4 template](http://visualstudiogallery.msdn.microsoft.com/3d2bf938-fc9e-403c-90b3-8de27dc23095). It will add a template to Visual Studio that will generating the structure just described.

## License
[Apache License 2.0](LICENSE.md)
