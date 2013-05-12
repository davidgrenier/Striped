namespace Website

open IntelliFactory.Html
open IntelliFactory.WebSharper.Sitelets

type Page =
    | [<CompiledName "">] Home

module Header =
    let freeMeta name = Tags.Meta [Name name; Attr.Content ""]
    let stylesheet href = Link [Rel "stylesheet"; HRef href]
    let css file = stylesheet (sprintf "css/%s.css" file)
    let js file = Script [Src (sprintf "js/%s.js" file)]
    let head =
        [
            Tags.Meta [CharSet "utf-8"]
            freeMeta "description"
            freeMeta "keywords"
            stylesheet "http://fonts.googleapis.com/css?family=Source+Sans+Pro:400,400italic,700|Open+Sans+Condensed:300,700"
            js "jquery-1.9.1.min"
            js "config"
            js "skel.min"
            js "skel-ui.min"
            NoScript [
                css "skel-noscript"
                css "style"
                css "style-desktop"
                css "style-wide"
            ]
        ]

type Site () =
    interface IWebsite<Page> with
        member x.Actions = []
        member x.Sitelet =
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