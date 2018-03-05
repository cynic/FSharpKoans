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
     Attack : int
     Defense : int }

type Book = 
   { Title : string
     Author : string
     Year : int }

// and now, the tests:
module ``06: On the Record`` =
    [<Test>]
    let ``01 Creating records`` () =
        // Q: do we actually specify type of Book/Pokemon ever? I assume it finds type itself. glanced down when typing this comment
        let myRecord = { Title="Steelheart"; Author="Brandon Sanderson"; Year=2013 }
        myRecord.Title |> should equal "Steelheart"
        myRecord.Author |> should equal "Brandon Sanderson"
        myRecord.Year |> should equal 2013

    [<Test>]
    let ``02 The type of a record is inferred`` () =
        let myRecord = { Name="Pikachu"; Attack=55; Defense=40 }
        let myOtherRecord =
            {
                Title="Discipline and Punish"
                Author="Michel Foucault"
                Year=1975
            }
        myRecord |> should be ofType<Pokemon>
        myOtherRecord |> should be ofType<Book>

    [<Test>]
    let ``03 Decomposing with a record pattern`` () =
        let book = { Title="Dune"; Author="Frank Herbert"; Year=1965 }
        let { Title=myTitle; Author=_; Year=myYear } = book
        myTitle |> should equal "Dune" // DO NOT use a . symbol in your answer
        myYear |> should equal 1965 // DO NOT use a . symbol in your answer

    [<Test>]
    let ``04 Decomposing in a match expression`` () =
        let result =
            match { Name="Raichu"; Attack=90; Defense=55 } with
            | { Name="Pikachu"; Attack=a } -> a/2
            | { Name="Raichu"; Attack=a } -> a/3
            | { Attack=blah; Defense=lol } -> (blah + lol) / 2
        result |> should equal 30

    [<Test>]
    let ``05 Accessing record members using dot syntax`` () =
        let book = { Title="Tigana"; Author="Guy Gavriel Kay"; Year=1990 }
        let k = book.Title
        let j = book.Year
        k |> should equal "Tigana"
        j |> should equal 1990

    [<Test>]
    let ``06 Creating records based on other records`` () =
        let first = { Title="A Game of Thrones"; Author="George R. R. Martin"; Year=1996 }
        let second = { first with Title="A Clash of Kings"; Year=first.Year+2 } // <-- Pssst - see what I did here?
        let third = { second with Title="A Storm of Swords"; Year=2000 }
        // We can see we can use singular properties, not like the _ I used in 03 above for Author
        let {Year=y0}, {Year=y1}, {Year=y2} = first, second, third
        y0 |> should equal 1996
        y1 |> should equal 1998
        y2 |> should equal 2000
