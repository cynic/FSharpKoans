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

module ``03: Match expressions`` = 
    [<Test>]
    let ``01 Basic match expression`` () =
        match 8000 with
        | 8000 -> "Insufficient power-level"
        ()

    [<Test>]
    let ``02 Match expressions are expressions, not statements`` () =
        let result =
            match 9001 with
            | 9001 -> // <-- use a variable pattern here!
                match 9001 + 1000 with
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
