namespace FSharpKoans
open NUnit.Framework

(*
Reversing a list.
*)

module ``14: Reversing a list`` =

    [<Test>]
    let ``01 Reversing a list, the hard way`` () =
        let rev (xs : 'a list) : 'a list =
            let rec revList (l_n : int list) (l_o : int list) : int list =
                match l_n with
                | [] -> l_o
                | frnt::bck -> (revList bck (frnt::l_o))
            revList xs []
            
            // write a function to reverse a list here.
        rev [9;8;7] |> should equal [7;8;9]
        rev [] |> should equal []
        rev [0] |> should equal [0]
        rev [9;3;4;1;6;5;4] |> should equal [4;5;6;1;4;3;9]

    // Hint: https://msdn.microsoft.com/en-us/library/ee340277.aspx
    [<Test>]
    let ``02 Reversing a list, the easy way`` () =
        List.rev [9;8;7] |> should equal [7;8;9]
        List.rev [] |> should equal []
        List.rev [0] |> should equal [0]
        List.rev [9;8;5;8;45] |> should equal [45;8;5;8;9]

        // Note: take care of typing
        //        - in 01 "xs" is a list so we can use the function "List.rev"
        //        - in 02 its obviously use List.rev aswell
