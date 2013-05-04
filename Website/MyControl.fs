namespace Website

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

type MyControl() =
    inherit Web.Control()

    [<JavaScript>]
    override this.Body = Div [] :> _
