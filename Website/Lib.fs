[<AutoOpen>]
module Website.Lib

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

type JS = Pervasives.JavaScriptAttribute

[<JS>]
[<AutoOpen>]
module Pervasives =
    let (|+) (elem: Element) classes = elem -- Attr.Class classes
    let (++) (elem: Element) text = elem -- Text text
    let (+<) (elem: Element) (elems: seq<Element>) =
        match elem.Dom.FirstChild with
        | null -> elem -< elems
        | child ->
            for x in elems do
                elem.Dom.InsertBefore(x.Dom, child) |> ignore
            elem

    let span text = Span [] ++ text

    let a url text = A [HRef url] ++ text