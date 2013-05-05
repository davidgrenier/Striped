[<AutoOpen>]
module Website.Lib

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

type JS = Pervasives.JavaScriptAttribute

[<JS>]
[<AutoOpen>]
module Pervasives =
    let (|+) (elem: Element) clazz = elem -- Attr.Class clazz