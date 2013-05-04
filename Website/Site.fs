namespace Website

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets

type Page =
    | [<CompiledName "">] Home


module Header =
    let freeMeta name = Tags.Meta [Name name; Attr.Content ""]
    let stylesheet href = Link [Rel "stylesheet"; HRef href]
    let head =
        [
            Tags.Meta [HttpEquiv "content-type"; Attr.Content "text/html; charset=utf-8"]
            freeMeta "description"
            freeMeta "keywords"
            stylesheet "http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,400italic,700|Open+Sans+Condensed:300,700"
            Script [Src "js/jquery-1.9.1.min.js"]
            Script [Src "js/config.js"]
            Script [Src "js/skel.min.js"]
            Script [Src "js/skel-ui.min.js"]
            NoScript [
                stylesheet "css/skel-noscript.css"
                stylesheet "css/style.css"
                stylesheet "css/style-desktop.css"
                stylesheet "css/style-wide.css"
            ]
        ]

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
                                Head = Header.head
                                Body = [Striped.body()]
                        }

[<assembly: Website(typeof<Site>)>]
do ()