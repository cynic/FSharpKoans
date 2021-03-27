namespace FSharpKoans

open NUnit.Framework

(*
Lists are immutable, ordered, finite sequences of a single type.
*)

module _10_I_Have_Here_In_My_Hand_A_List = 
    [<Test>]
    let _01_Creating_a_list_Syntax 1 () = 
        let myList =
            [ __; __; __; __ ]
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
   
    [<Test>]
    let _02_Creating_a_list_Syntax_2 () =
        let myList =
            __::__::__::__::[]
        let myOtherList =
            __::__::__::[ __ ]
        let myNextList =
            __::__::__ // you may use [ and ] symbols on this line.
        let myLastList =
            __::__::__ // DO NOT use [ or ] symbols on this line!
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
        myOtherList |> should equal [ "orange"; "lemon"; "princess"; "queen" ]
        myNextList |> should equal ["lily"; "sunflower"; "daisy"; "carrot"]
        myLastList |> should equal [ "naartjie"; "raisin"; "apple"; "grape"; "pear"; "biscuit" ]

    [<Test>]
    let _03_Creating_a_list_via_concatenation () =
        let a =
            [902; 10]
        let b =
            [3; 13; 37]
        let result =
            __ @ __
        result |> should equal [902; 10; 3; 13; 37]

    [<Test>]
    let _04_The_operator_called_cons_does_not_modify_an_existing_list () = 
        let first =
            [ "grape"; "peach" ]
        let second =
            "pear" :: first
        let third =
            "apple" :: second
        third |> should equal __
        second |> should equal __
        first |> should equal __

    [<Test>]
    let _05_Pattern_matching_a_list_Part_1 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let a::_ =
            fruits
        a |> should equal __

    [<Test>]
    let _06_Pattern_matching_a_list_Part_2 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let b::c::_ =
            fruits
        b |> should equal __
        c |> should equal __

    [<Test>]
    let _07_Pattern_matching_a_list_Part_3 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::d::e =
            fruits
        d |> should equal __
        e |> should equal __

    [<Test>]
    let _08_Pattern_matching_a_list_Part_4 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let f::_::_::g::_ =
            fruits
        f |> should equal __
        g |> should equal __

    [<Test>]
    let _09_Pattern_matching_a_list_Part_5 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::_::_::h =
            fruits
        h |> should equal __

    [<Test>]
    let _10_Pattern_matching_a_list_Part_6 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [i;j;k;l;m;n] =
            fruits
        i |> should equal __
        j |> should equal __
        k |> should equal __
        l |> should equal __
        m |> should equal __
        n |> should equal __

    [<Test>]
    let _11_Pattern_matching_a_list_Part_7 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::o::_::[p;q;r] =
            fruits
        o |> should equal __
        p |> should equal __
        q |> should equal __
        r |> should equal __

    [<Test>]
    let _12_Pattern_matching_a_list_Part_8 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [_;s;_;_;t;_] =
            fruits
        s |> should equal __
        t |> should equal __

    [<Test>]
    let _13_Pattern_matching_a_list_Part_9 () =
        let fruits =
            ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let k =
            match fruits with
            | [a;b;c;d;e] ->
                "prune"
            | _::t::_::u::_
                -> t + u
            | _ ->
                "fig"
        k |> should equal __