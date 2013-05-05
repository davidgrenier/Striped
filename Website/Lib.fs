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

    let span text = Span [] ++ text

    let a url text = A [HRef url] ++ text