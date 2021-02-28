namespace FSharpKoans
open NUnit.Framework

module ``11: String manipulation`` =
    [<Test>]
    let ``01 Finding the length of a string`` () =
        let a = "calamari"
        let b = "It's-a me, Maaario!"
        String.FILL_ME_IN a |> should equal 8
        String.FILL_ME_IN b |> should equal 19

    [<Test>]
    let ``02 Getting a substring (Part 1).`` () =
        let a = "bright"
        a.[1..] |> should equal __

    [<Test>]
    let ``03 Getting a substring (Part 2).`` () =
        let a = "bright"
        a.[..3] |> should equal __

    [<Test>]
    let ``04 Getting a substring (Part 3).`` () =
        let a = "bright"
        a.[1..3] |> should equal __

    [<Test>]
    let ``05 Concatenating strings`` () =
        let a = ["hip"; "hip"; "hurray"]
        String.FILL__ME_IN " " a |> should equal "hip hip hurray"
        String.FILL__ME_IN __ __ |> should equal "hiphiphurray"
        String.FILL__ME_IN __ __ |> should equal "hip! hip! hurray"

    [<Test>]
    let ``06 Getting a string from an integer or float`` () =
        let a = 23
        let b = 17.8
        __ a |> should equal "23"
        __ b |> should equal "17.8"

    [<Test>]
    let ``07 String formatting: %s format specifier`` () =
        let num = 9
        let ch = 'S'
        let result = $"{__} planets, {__}ir, endlessly circle, {__}ir"
        result |> should equal "9 planets, Sir, endlessly circle, Sir"

   // double-up a { or } to get that character in.
    [<Test>]
    let ``08 String formatting: Putting a '{' or '}' in`` () =
        let who = "yourself"
        let result = $"Brace {who}: {who}" // <-- modify this line
        result |> should equal "Brace yourself: {yourself}"

    [<Test>]
    let ``09 You can use the "usual" C# string methods from F#`` () =
        let s = "  Dr Phil, PhD, MD, MC, Medicine Man  "
        let ``first index of 'P'`` = s.FILL_ME_IN
        let ``last index of 'P'`` = s.FILL_ME_IN
        let ``lowercase version`` = s.FILL_ME_IN
        let ``without surrounding space`` = s.FILL_ME_IN
        ``first index of 'P'`` |> should equal 5
        ``last index of 'P'`` |> should equal 11
        ``lowercase version`` |> should equal "  dr phil, phd, md, mc, medicine man  "
        ``without surrounding space`` |> should equal "Dr Phil, PhD, MD, MC, Medicine Man"
        // ......... and many others!
