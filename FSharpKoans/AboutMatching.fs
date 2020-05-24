namespace FSharpKoans
open NUnit.Framework

(*
What's a match expression?  It's a construct that uses the power of patterns
to conditionally execute code.  The first pattern (going from top to bottom) that
matches causes the associated code to be executed.  All non-matching patterns,
and any patterns after the first matching pattern, are ignored.  If no pattern
matches, then you get a MatchFailureException at runtime and you turn into a
Sad Panda.
*)

module ``04: Match expressions`` = 
    [<Test>]
    let ``01 Basic match expression`` () =
        match 8000 with
        | v -> "Insufficient power-level"
        ()

    [<Test>]
    let ``02 Match expressions are expressions, not statements`` () =
        let result =
            match 9001 with
            | y -> // <-- use an identifier pattern here!
                match y + 1000 with // <-- now use the identifier that you've bound
                | 10001 -> "Hah! It's a palindromic number!"
                | x -> "Some number."
            | x -> "I should have matched the other expression."
        result |> should equal "Hah! It's a palindromic number!"

    [<Test>]
    let ``03 Shadowing in match expressions`` () =
        let x = 213
        let y = 19
        match x with
        | 100 -> ()
        | 19 -> ()
        | y ->
            y |> should equal 213
            x |> should equal 213
        y |> should equal 19
        x |> should equal 213

    [<Test>]
    let ``04 Match order in match expressions`` () =
        let x = 213
        let y = 19
        let z =
            match x with
            | 100 -> "Kite"
            | 19 -> "Smite"
            | 213 -> "Bite"
            | y -> "Light"
        let a = 
            match x with
            | 100 -> "Kite"
            | 19 -> "Smite"
            | y -> "Trite"
            | 213 -> "Light"
        x |> should equal 213
        y |> should equal 19
        z |> should equal "Bite"
        a |> should equal "Trite"

    [<Test>]
    let ``05 Using a mapping function`` () =
        let mapper = function
            | 3 -> "Joey"
            | 8 -> "Bingo"      
            | 11 -> "Kelvin"
            | 15 -> "Kelvin"   // write the cases for this function!
        mapper 3 |> should equal "Joey"
        mapper 8 |> should equal "Bingo"
        mapper 11 |> should equal "Kelvin"
        mapper 15 |> should equal "Kelvin"

    (*
        "The OR pattern is used when input data can match multiple patterns,
        and you want to execute the same code as a result. The types of both
        sides of the OR pattern must be compatible."
    *)

    [<Test>]
    let ``06 Using an OR-pattern`` () =
        let f input =
            match input with
            | "wut" | "lol" -> "yolo"
            | "sunrise"
            | "sunset" -> "transition"
            | "Johnny Walker" | "Bell's" | "vodka"  -> "failure"
            | _ -> "lolwut"
        f "lol" |> should equal "yolo"
        f "wut" |> should equal "yolo"
        f "Johnny Walker" |> should equal "failure"
        f "Bell's" |> should equal "failure"
        f "vodka" |> should equal "failure"

    [<Test>]
    let ``07 Identifiers bound on all branches of an OR-pattern must be the same`` () =
        let f input =
            
            match input with
            | 0,0 -> "Both 0"
            | c,0| 0,c -> sprintf "One 0, one %d" c
            | 9,5 -> "No 0"
        f (3,0) |> should equal "One 0, one 3"
        f (0, 4) |> should equal "One 0, one 4"
        f (9, 5) |> should equal "No 0"
        f (0, 0) |> should equal "Both 0"

