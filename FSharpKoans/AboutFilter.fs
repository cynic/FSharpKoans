﻿namespace FSharpKoans
open NUnit.Framework

(*
A filter only lets particular elements through.
*)

module ``16: Filtering a list`` =
    [<Test>]
    let ``01 Fixed-function filtering, the hard way`` () =
        let filter (xs : int list) : int list =
            let rec doTheList =
                fun (l: int list) (outl: int list) ->
                    match l with
                    | [] -> outl
                    | head::tail ->
                        match head%2 with
                        | 1 ->
                            doTheList tail (outl@[head])
                        | _ -> doTheList tail outl
            doTheList xs []
                
            // write a function to filter for odd elements only.
        filter [1; 2; 3; 4] |> should equal [1; 3]
        filter [10; 9; 8; 7] |> should equal [9; 7]
        filter [15; 2; 7] |> should equal [15; 7]
        filter [215] |> should equal [215]
        filter [216] |> should equal []
        filter [2;4;6;8;10] |> should equal []
        filter [1;3;5;7;9] |> should equal [1;3;5;7;9]
        filter [] |> should equal []

   // once again, this would be a heck of a lot more flexible if we
   // were able to filter using different criteria!
   //
   // ... you can make a function to do that, right? ^_^.

    [<Test>]
    let ``02 Specified-function filtering, the hard way`` () =
        let filter (f : 'a -> bool) (xs : 'a list) : 'a list =
            let rec innerFilter xs filtered = // write a function which filters based on the specified criteria
                match xs with
                | [] -> filtered
                | x::xs ->
                    match f x with
                    | false -> innerFilter xs filtered
                    | true ->
                        let filtered = List.concat [ filtered; [x] ]
                        innerFilter xs filtered
            innerFilter xs []
            // write a function which filters based on the specified criteria
        filter (fun x -> x > 19) [9; 5; 23; 66; 4] |> should equal [23; 66]
        filter (fun x -> String.length x = 4) ["moo"; "woof"; "yip"; "nyan"; "meow"]
        |> should equal ["woof"; "nyan"; "meow"]
        filter (fun (a,b) -> a*b >= 14) [9,3; 4,2; 4,5] |> should equal [9,3; 4,5]

    // Hint: https://msdn.microsoft.com/en-us/library/ee370294.aspx
    [<Test>]
    let ``03 Specified-function mapping, the easy way`` () =
        List.filter (fun x -> x > 19) [9; 5; 23; 66; 4] |> should equal [23; 66]
        List.filter (fun x -> String.length x = 4) ["moo"; "woof"; "yip"; "nyan"; "meow"]
        |> should equal ["woof"; "nyan"; "meow"]
        List.filter (fun (a,b) -> a*b >= 14) [9,3; 4,2; 4,5] |> should equal [9,3; 4,5]
