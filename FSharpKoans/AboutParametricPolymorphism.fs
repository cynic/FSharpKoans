namespace FSharpKoans
open NUnit.Framework

(*
    In functional programming, we often care about the "shape" of data, rather
    than the data itself.  For example, if we are trying to find the length of a list,
    it doesn't matter whether we have a list-of-strings or a list-of-floats or a
    list-of-something-elses.  All that matters is that the data occurs in the shape
    of a list.  Similarly, if we are given a tuple of two items and we only look at
    the second item, then the type of the first item doesn't matter to us - it
    could be anything, and the meaning of the program wouldn't change at all!
    
    But what if we are given a tuple of 4 items, and our function outputs the
    third item?  Now we have an interesting situation.  We hope to be able to
    take in a tuple of ANY four types, but output a value that has the type of
    the third item.  We can achieve this if we specify the type of the tuple
    generically, as
    
        'a * 'b * 'c * 'd

    This gives each component of the tuple a "fake" type (indicated by the ' symbol
    before the type-name).  The function returns the third element, so we can
    say that the type of the function is

        'a * 'b * 'c * 'd -> 'c

    ...and now we have a perfectly generic function, which can be use with any
    4-tuple, and which is also completely safe to use.  And as a side-effect,
    by looking at the function type, we can tell what the function does without
    even looking at the code of the function!  The function cannot know what
    'a, 'b, 'c, or 'd types are, and it cannot know how to construct them.  The
    only way that it can get hold of a 'c value is by having it passed in.  Since
    we know this to be true, it must be the case that the function is returning
    the third item in the tuple [0]!

    The ability to look at the *shape* of data, and ignore unnecessarily-specific
    types, is called "parametric polymorphism".  The non-specific (or "generic")
    types are given as 'a, 'b, 'c, and so on.  We sometimes say that types which are
    parametrically polymorphic are "generic types".

    We may sometimes want to make our more structured types, like records
    or discriminated unions, generic.
*)

module _08_Parametric_polymorphism =
    (*
        The next test demonstrates *type inference*.
        
        Not all functional languages are typed.  The first (and, arguably, the most powerful)
        functional language was Lisp, and Lisp isn't strongly typed.  Typing is something that tends
        to work very well with functional programming, but isn't something that is essential to
        functional programming.  In the case of F#, typing often stops you from making "silly" errors.

        F# uses type inference extensively.  Type inference means that it tries to work out
        (or "infer") what type a particular name is by looking at code around it.  A readable, if
        simplified, explanation of how this works can be found at:
        http://fsharpforfunandprofit.com/posts/type-inference/
    *)
   
    [<Test>]
    let _01_The_type_of_symbols_in_variable_patterns_is_inferred () = 
        let x =
            50
        let y =
            "a string"
        let z =
            -4.23
        let a =
            false
        let b =
            't'
        x |> should be ofType<int>
        y |> should be ofType<FILL_ME_IN>
        z |> should be ofType<FILL_ME_IN>
        a |> should be ofType<FILL_ME_IN>
        b |> should be ofType<FILL_ME_IN>

    [<Test>]
    let _02_id_the_simplest_built_in_generic_function () =
        // `id` is the identify function: it takes an input ... and gives it back immediately.
        id 8 |> should equal __
        id 7.6 |> should equal __
        id "wut!" |> should equal __
        // id can be surprisingly useful.  Remember it :).

    [<Test>]
    let _03_Defining_a_generic_function () =
        let f x y =
            __
        f 4 5 |> should equal (4, 5, 5)
        f "k" 'p' |> should equal ("k", 'p', 'p')
     
    type GenericDiscriminatedUnionExample<'a,'b> =
    | Frist
    | Secnod of 'a * 'b
    | Thrid of ('a -> ('b * 'a * int)) // <-- this shouldn't look odd.  Functions are first-class!

    [<Test>]
    let _04_Creating_a_generic_discriminated_union_Part_1 () =
        let a =
            Secnod (6.55, 7)
        let b =
            Thrid (fun k -> true, k, 8)
        // how do you write a generic type?
        a |> should be ofType<FILL_ME_IN>
        b |> should be ofType<FILL_ME_IN>

    type MyDiscriminatedUnion = // <-- you will need to change this line, too
    | Furoth of FILL_ME_IN
    | Fevi
    | Sxi of FILL_ME_IN

    [<Test>]
    let _05_Creating_a_generic_discriminated_union_Part_2 () =
        // You need to edit the definition of MyDiscriminatedUnion first!  It's just above this test.
        let a =
            __
        let b =
            __
        let c =
            __
        let d =
            __
        match a with
        | Furoth n ->
            n |> should equal 7
        | _ ->
            Assert.Fail ()
        match b with
        | Sxi x ->
            x |> should equal "bleh"
        | _ ->
            Assert.Fail ()
        match c with
        | Furoth p ->
            p |> should equal 't'
        | _ ->
            Assert.Fail ()
        match d with
        | Sxi y ->
            y |> should equal true
        | _ ->
            Assert.Fail ()
