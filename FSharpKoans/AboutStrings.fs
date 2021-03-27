namespace FSharpKoans
open NUnit.Framework

module _11_String_manipulation =
    [<Test>]
    let _01_Finding_the_length_of_a_string () =
        let a =
            "calamari"
        let b =
            "It's-a me, Maaario!"
        String.FILL_ME_IN a |> should equal 8
        String.FILL_ME_IN b |> should equal 19

    [<Test>]
    let _02_Getting_a_substring_Part_1 () =
        let a =
            "bright"
        a.[1..] |> should equal __

    [<Test>]
    let _03_Getting_a_substring_Part_2 () =
        let a =
            "bright"
        a.[..3] |> should equal __

    [<Test>]
    let _04_Getting_a_substring_Part_3 () =
        let a =
            "bright"
        a.[1..3] |> should equal __

    [<Test>]
    let _05_Concatenating_strings () =
        let a =
            ["hip"; "hip"; "hurray"]
        String.FILL__ME_IN " " a |> should equal "hip hip hurray"
        String.FILL__ME_IN __ __ |> should equal "hiphiphurray"
        String.FILL__ME_IN __ __ |> should equal "hip! hip! hurray"

    [<Test>]
    let _06_Getting_a_string_from_an_integer_or_float () =
        let a =
            23
        let b =
            17.8
        __ a |> should equal "23"
        __ b |> should equal "17.8"

    [<Test>]
    let _07_String_formatting () =
        let num =
            9
        let ch =
            'S'
        let result = $"{__} planets, {__}ir, endlessly circle, {__}ir"
        result |> should equal "9 planets, Sir, endlessly circle, Sir"

   // double-up a { or } to get that character in.
    [<Test>]
    let _08_String_formatting_Putting_a_left_brace_or_right_brace_in () =
        let who =
            "yourself"
        let result =
            $"Brace {__}: {__}" // <-- modify this line
        result |> should equal "Brace yourself: {yourself}"

    [<Test>]
    let _09_You_can_use_the_'usual'_CSharp_string_methods_from_FSharp () =
        let s =
            "  Dr Phil, PhD, MD, MC, Medicine Man  "
        let first_index_of_'P' =
            s.FILL_ME_IN
        let last_index_of_'P' =
            s.FILL_ME_IN
        let lowercase_version =
            s.FILL_ME_IN
        let without_surrounding_space =
            s.FILL_ME_IN
        first_index_of_'P' |> should equal 5
        last_index_of_'P' |> should equal 11
        lowercase_version |> should equal "  dr phil, phd, md, mc, medicine man  "
        without_surrounding_space |> should equal "Dr Phil, PhD, MD, MC, Medicine Man"
        // ......... and many others!
