namespace FSharpKoans

open NUnit.Framework

(*
Lists are immutable, ordered, finite sequences of a single type.
*)

module ``05: I Have Here In My Hand A List`` = 
    [<Test>]
    let ``01 Creating a list (Syntax 1).`` () = 
        let myList = [ "apple"; "grape"; "pear"; "biscuit" ]
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
   
    [<Test>]
    let ``02 Creating a list (Syntax 2).`` () =
        let myList = "apple"::"grape"::"pear"::"biscuit"::[]
        let myOtherList = "orange"::"lemon"::"princess"::[ "queen" ]
        // These next 2 comments literally talk about the symbols
        //  - letting myself know for when I re-read this in the future
        let myNextList = "lily"::"sunflower"::[ "daisy"; "carrot" ] // you may use [ and ] symbols on this line.
        let myLastList =  "naartjie"::"raisin"::myList // DO NOT use [ or ] symbols on this line!
        myList |> should equal [ "apple"; "grape"; "pear"; "biscuit" ]
        myOtherList |> should equal [ "orange"; "lemon"; "princess"; "queen" ]
        myNextList |> should equal ["lily"; "sunflower"; "daisy"; "carrot"]
        myLastList |> should equal [ "naartjie"; "raisin"; "apple"; "grape"; "pear"; "biscuit" ]

    [<Test>]
    let ``03 Creating a list (via concatenation).`` () =
        let a = [902; 10]
        let b = [3; 13; 37]
        let result = a @ b
        result |> should equal [902; 10; 3; 13; 37]

    [<Test>]
    let ``04 The : : symbol (called "cons") does not modify an existing list`` () = 
        let first = [ "grape"; "peach" ]
        let second = "pear" :: first
        let third = "apple" :: second
        // Ernest: remember to read the reuired step to "should equal"
        third |> should equal [ "apple"; "pear"; "grape"; "peach" ]
        second |> should equal [ "pear"; "grape"; "peach" ]
        first |> should equal [ "grape"; "peach" ]

    [<Test>]
    let ``05 Pattern-matching a list (Part 1).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        // This asks for the heads element, underscore covers the "tail" potentially (might be element or rest of list)
        let a::_ = fruits
        a |> should equal "apple"

    [<Test>]
    let ``06 Pattern-matching a list (Part 2).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let b::c::_ = fruits
        b |> should equal "apple"
        c |> should equal "peach"

    [<Test>]
    let ``07 Pattern-matching a list (Part 3).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::d::e = fruits
        d |> should equal "peach"
        e |> should equal ["orange"; "watermelon"; "pineapple"; "tomato"]
        // It uses the _ at the start as a single item, always note for using this from the start:
        //  - the answer is a list

    [<Test>]
    let ``08 Pattern-matching a list (Part 4).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let f::_::_::g::_ = fruits
        f |> should equal "apple"
        g |> should equal "watermelon"

    [<Test>]
    let ``09 Pattern-matching a list (Part 5).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::_::_::h = fruits
        h |> should equal [ "watermelon"; "pineapple"; "tomato" ]

    [<Test>]
    let ``10 Pattern-matching a list (Part 6).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [i;j;k;l;m;n] = fruits
        i |> should equal "apple"
        j |> should equal "peach"
        k |> should equal "orange"
        l |> should equal "watermelon"
        m |> should equal "pineapple"
        n |> should equal "tomato"

    [<Test>]
    let ``11 Pattern-matching a list (Part 7).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let _::o::_::[p;q;r] = fruits
        o |> should equal "peach"
        p |> should equal "watermelon"
        q |> should equal "pineapple"
        r |> should equal "tomato"

    [<Test>]
    let ``12 Pattern-matching a list (Part 8).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"]
        let [_;s;_;_;t;_] = fruits
        s |> should equal "peach"
        t |> should equal "pineapple"

    [<Test>]
    let ``13 Pattern-matching a list (Part 9).`` () =
        let fruits = ["apple"; "peach"; "orange"; "watermelon"; "pineapple"; "tomato"] //[f]
        let k =
            match fruits with
            | [a;b;c;d;e] -> "prune" //doesnt fit here
            | _::t::_::u::_ -> t + u // fits here even with "less"
            | _ -> "fig"
        k |> should equal "peachwatermelon"

    [<Test>]
    let ``14 Creating a list containing a sequence of numbers, and indexing`` () =
        let k = [6..50]
        let l = [3..3..20]
        k.[3] |> should equal 9
        l.[3] |> should equal 12
        // assumed it starts with first item 0 and was correct