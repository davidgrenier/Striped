module Website.Striped

open IntelliFactory.WebSharper

type StripedClient() =
    inherit Web.Control()

    [<JS>]
    override this.Body = Client.page () :> _

open IntelliFactory.Html

let body() =
    Div [
        Id "wrapper"
    ] -< [new StripedClient()]