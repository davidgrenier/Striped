namespace Website

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets

type Page =
    | [<CompiledName "">] Home

type Site () =
    interface IWebsite<Page> with
        member __.Actions = []
        member __.Sitelet =
            Sitelet.Infer <| function
                | Home ->
                    PageContent <| fun ctx ->
                        {
                            Page.Default with
                                Title = Some "Striped"
                                Body = [ Div []]
                        }

[<assembly: Website(typeof<Site>)>]
do ()