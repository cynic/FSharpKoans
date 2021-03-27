namespace FSharpKoans
open NUnit.Framework

(*
    A record is an ordered group of named data.  Unlike tuples, a record type must
    be defined before it can be used.  You can decompose a record using a pattern,
    and you can access individual fields by name using dot-syntax.  In other
    functional programming languages, you can only access fields by pattern
    decomposition, so it's useful to get into the habit of using that instead of dot-syntax.

    Before you skip over to the tests, take a look at the record definitions under this comment.
*)

type Pokemon = 
   { Name : string
   ; Attack : int
   ; Defense : int
   }

type Book = 
   { Title : string
   ; Author : string
   ; Year : int
   }

// and now, the tests:
module _13_On_the_Record =
    [<Test>]
    let _01_Creating_records () =
        let myRecord =
            __
        myRecord.Title |> should equal "Steelheart"
        myRecord.Author |> should equal "Brandon Sanderson"
        myRecord.Year |> should equal 2013

    [<Test>]
    let _02_The_type_of_a_record_is_inferred () =
        let myRecord =
            { Name="Pikachu"
            ; Attack=55
            ; Defense=40
            }
        let myOtherRecord =
            { Title="Discipline and Punish"
            ; Author="Michel Foucault"
            ; Year=1975
            }
        myRecord |> should be ofType<FILL_ME_IN>
        myOtherRecord |> should be ofType<FILL_ME_IN>

    [<Test>]
    let _03_Decomposing_with_a_record_pattern () =
        let book =
            { Title="Dune"
            ; Author="Frank Herbert"
            ; Year=1965
            }
        let __ =
            book
        __ |> should equal "Dune" // DO NOT use a . symbol in your answer
        __ |> should equal 1965 // DO NOT use a . symbol in your answer

    [<Test>]
    let _04_Decomposing_in_a_match_expression () =
        let result =
            match { Name="Raichu"; Attack=90; Defense=55 } with
            | { Name="Pikachu"; Attack=a } ->
                a/2
            | { Name="Raichu"; Attack=a } ->
                a/3
            | { Attack=blah; Defense=lol } ->
                (blah + lol) / 2
        result |> should equal __

    [<Test>]
    let _05_Accessing_record_members_using_dot_syntax () =
        let book =
            { Title="Tigana"
            ; Author="Guy Gavriel Kay"
            ; Year=1990
            }
        let k =
            __
        let j =
            __
        k |> should equal "Tigana"
        j |> should equal 1990

    [<Test>]
    let _06_Creating_records_based_on_other_records () =
        let first =
            { Title="A Game of Thrones"
            ; Author="George R. R. Martin"
            ; Year=1996
            }
        let second =
            { first with
                Title = "A Clash of Kings"
                Year = first.Year+2 (* <-- Pssst - see what I did here? *)
            }
        let third =
            { second with
                Title="A Storm of Swords"
                Year=2000
            }
        let {Year=y0}, {Year=y1}, {Year=y2} =
            first, second, third
        y0 |> should equal __
        y1 |> should equal __
        y2 |> should equal __

    (*
        "The as-pattern is a pattern that has an as clause appended to it.
        The as clause binds the matched value to a name that can be used
        in the execution expression of a match expression, or, in the case
        where this pattern is used in a let binding, the name is added as
        a binding to the local scope."
    *)

    [<Test>]
    let _07_Binding_composed_and_decomposed_structures_using_'as' () =
        let f (___ as _____) =
            { __ with
                Year = __ + 3 }
        f
            { Title="A Wizard of Earthsea"
            ; Author="Ursula K. LeGuin"
            ; Year=1968
            }
        |> should equal
            { Title="A Wizard of Earthsea"
            ; Author = "Ursula K. LeGuin"
            ; Year = 1971
            }

    // this is how we might define a record type with two generic fields.
    type GenericRecordExample<'a,'b> =
        { Something : 'a
        ; Blah : int
        ; Otherwise : 'b
        ; What : 'a * string * 'b
        }
    // we might create this with:
    // { Something = 5
    // ; Blah = 8
    // ; Otherwise = 9.3
    // ; What = 77, "hi", 0.88
    // }

    type MyRecord = // <-- you'll need to change this line
        { Who : FILL_ME_IN // <-- should be generic
        ; What : FILL_ME_IN // <-- should be generic, and a different type to Who
        ; Where : string
        }

    [<Test>]
    let _08_Creating_a_generic_record () =
        // You need to edit the definition of MyRecord first!  It's just above this test.
        let a =
            __
        let b =
            __  
        a.Who |> should equal "The Doctor"
        b.Who |> should equal 'R'
        a.What |> should equal 4.53
        b.What |> should equal false
        a.Where |> should equal "TTFN"
        b.Where |> should equal "tiffin"
