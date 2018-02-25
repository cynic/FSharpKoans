﻿namespace FSharpKoans
open NUnit.Framework

(*
Transforming a sequence is called "mapping".
*)

module ``15: Applying a map to a list`` =
    [<Test>]
    let ``01 Fixed-function mapping, the hard way (part 1).`` () =
        let map (xs : int list) : int list =
            let rec inc_list (l : int list) (i : int) (z : int list): int list = // l is list, i is amount, z is the return list
                match l with
                | [] -> z
                | happy::chappy -> (inc_list chappy (i) (List.append z [(happy+i)])) // Had to use List.append to do a "manual map" (aka. join 2 lists)
            inc_list xs 1 []
            //let banana = xs |> List.map (fun value -> value + 1)
            //banana
            // write a function which adds 1 to each element
        map [1; 2; 3; 4] |> should equal [2; 3; 4; 5]
        map [9; 8; 7; 6] |> should equal [10; 9; 8; 7]
        map [15; 2; 7] |> should equal [16; 3; 8]
        map [215] |> should equal [216]
        map [] |> should equal []

    [<Test>]
    let ``02 Fixed-function mapping, the hard way (part 2).`` () =
        let map (xs : int list) : int list =
            let rec bob_list (l : int list) (i : int) (z : int list): int list = // l is list, i is amount, z is the return list
                match l with
                | [] -> z
                | sad::chappy -> (bob_list chappy (i) (List.append z [(sad*i)])) // Had to use List.append to do a "manual map" (aka. join 2 lists)
            bob_list xs 2 []
            // let banana = xs |> List.map (fun value -> value * 2)
            // banana
            // write a function which doubles each element
        map [1; 2; 3; 4] |> should equal [2; 4; 6; 8]
        map [9; 8; 7; 6] |> should equal [18; 16; 14; 12]
        map [15; 2; 7] |> should equal [30; 4; 14]
        map [215] |> should equal [430]
        map [] |> should equal []

   (*
      Well, that was repetitive!  The only thing that really changed
      between the functions was a single line.  How boring.

      Perhaps we could reduce the boilerplace if we just specified
      the transforming function, and left the rest of the structure
      intact?
   *)

    [<Test>]
    let ``03 Specified-function mapping, the hard way`` () =
        let map (f : 'a -> 'b) (xs : 'a list) : 'b list = 
            let ans = List.map f xs
            ans // write a map which applies f to each element
        map (fun x -> x+1) [9;8;7] |> should equal [10;9;8]
        map ((*) 2) [9;8;7] |> should equal [18;16;14]
        map (fun x -> sprintf "%.2f wut?" x)  [9.3; 1.22] |> should equal ["9.30 wut?"; "1.22 wut?"]

    // Hint: https://msdn.microsoft.com/en-us/library/ee370378.aspx
    [<Test>]
    let ``04 Specified-function mapping, the easy way`` () =
        List.map (fun x -> x+1) [9;8;7] |> should equal [10;9;8]
        List.map ((*) 2) [9;8;7] |> should equal [18;16;14]
        List.map (fun x -> sprintf "%.2f wut?" x)  [9.3; 1.22] |> should equal ["9.30 wut?"; "1.22 wut?"]

    // Notes: these list's sets and maps are aweome, will be fun to use when needed (and confusing)