namespace FSharpKoans
open NUnit.Framework

(*
    A tuple is an ordered group of data.  A tuple is formed using the comma operator,
    NOT brackets.  In F#, brackets are used for precedence and ordering, not to form tuples.

    The number of elements in a tuple is called its *arity*.  We can call a tuple with 2
    items a 2-tuple, a tuple with 5 elements is a 5-tuple, and so on.
*)

module ``04: Tuples`` = 
    [<Test>]
    let ``01 Creating tuples`` () = 
        let items = "apple", "dog"
        items |> should equal ("apple", "dog")

    [<Test>]
    let ``02 Elements of a tuple can be different types`` () =
        let stuff = "Rivet", false, 22.5
        stuff |> should equal ( "Rivet", false, 22.5 )

    [<Test>]
    let ``03 Decompose a tuple using tuple pattern`` () =
        let aida = 2020, "cranberry", false, "wait, what?"
        let a, b, c, d = aida
        a |> should equal 2020
        b |> should equal "cranberry"
        c |> should equal false
        d |> should equal "wait, what?"

    [<Test>]
    let ``04 Using a tuple in a match expression`` () =
        let result =
            match "Teresa", "pasta" with
            | name, "veggies" -> name + " likes vegetables"
            | name, "fish" -> name + " likes seafood"
            | name, "chicken" -> name + " crows about their food"
            | name, fruityflop -> name + " loves to eat " + fruityflop
        result |> should equal "Teresa loves to eat pasta"   
   
    [<Test>]
    let ``05 The type of a tuple is the contained types separated by '*' symbols`` () =
        let a = 3, 5, "hi", 'x', 7.22
        a |> should be ofType<int * int * string * char * double>

    [<Test>]
    let ``06 Using the wildcard pattern`` () = 
        // A single _ is a wildcard pattern, NOT a space to fill things in.
        // A wildcard pattern successfully matches ANYTHING.
        let name, _, _, weapon_name = "Shinji", 9103, true, "Unit 01"
        name |> should equal "Shinji"
        weapon_name |> should equal "Unit 01"