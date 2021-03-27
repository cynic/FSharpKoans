namespace FSharpKoans
open NUnit.Framework

module _05_To_iterate_is_human_but_to_recurse_is_divine =
    (*
        The `rec` keyword exposes the function identifier for use inside the function.
        And that's literally all that it does - it has no other purpose whatsoever.
    *)

    [<Test>]
    let _01_'rec'_exposes_the_name_of_the_function_for_use_inside_the_function () =
        let rec converge d c n =
            match d = c with
            | false ->
                match d < c with
                | true ->
                    converge (d+10) c (n+1)
                | false ->
                    converge (d - 1) c (n+1)
            | true ->
                n
        converge 3 10 0 |> should equal __

    [<Test>]
    let _02_Tail_recursion_stops_a_stack_overflow_from_occurring () =
        // CHANGE the recursive function to be tail recursive.
        let myfun n =
            let sq =
                n*n
            let v =
                sq*sq*sq*sq
            let rec inner count =
                match count = v with
                | true ->
                    0
                | false ->
                    -1 + inner (count+1)
            inner sq

        myfun 12 |> should equal
