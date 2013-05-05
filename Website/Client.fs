[<JS>]
module Website.Client

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

let divi id = Div [Id id]

let article content =
    HTML5.Tags.Article content
    |+ "is-post" |+ "is-post-excerpt"

let span text = Span [Text text]

let a url text = A [HRef url; Text text]

let content =
    let inner =
        let robot =
            A [HRef "#"]
            -- Img [Src "images/n33-robot-invader.jpg"; Alt ""]
            |+ "image"
            |+ "image-full"
        
        let dateAndIcons =
            let icoLi v class2 = LI [a "#" (string v) |+ "link-icon24" |+ class2]
            Div [
                Span [
                    span "Jan" -- span "nuary" |+ "month"
                    span "14" |+ "day"
                    span ", 2013" |+ "year"
                ] |+ "date"
                UL [
                    icoLi 16 "link-icon24-1"
                    icoLi 32 "link-icon24-2"
                    icoLi 64 "link-icon24-3"
                    icoLi 128 "link-icon24-4"
                ] |+ "stats"
            ] |+ "info"

        let p1 =
            P [Strong [Text "Hello!"]]
            -- Text " You're looking at "
            -- a "http://html5up.net/striped/" "Striped"
            -- Text ", a fully responsive HTML5 site template designed by "
            -- a "http://n33.co/" "AJ"
            -- Text " for"
            -- a "http://html5up.net/" "HTML5 UP"
            -- Text " It features a clean, minimalistic design, styling for all basic page elements (including blockquotes, tables and lists), a
responsible sidebar (left or right), and HTML5/CSS3 code designed for quick and easy customization (see code comments for details)."

        let p2 =
            P [Text "Striped is released for free under the "]
            -- a "http://html5up.net/license/" "Creative Commons Attribution license"
            -- Text " so feel free to use it for personal projects or even commercial ones &ndash; just be sure to credit "
            -- a "http://html5up.net/" "HTML5 UP"
            -- Text " for the design. If you like what you see here, be sure to check out "
            -- a "http://html5up.net/" "HTML5 UP"
            -- Text " for more cool designs or follow me on "
            -- a "http://twitter.com/n33co" "Twitter"
            -- Text " for new releases and updates."

        divi "content-inner"
        -< [
            article [
                HTML5.Tags.Header [
                    H2 [A [HRef "#"; Text "Welcome to Striped"]]
                    span "A free, fully responsive HTML5 site template by AJ for HTML5 UP" |+ "byline"
                ]
                dateAndIcons
                robot
                p1
                p2
            ]
            article []
            Div [] |+ "pager"
        ]
    divi "content" -- inner

let sidebar =
    divi "sidebar"
    -< [
        divi "logo"
        HTML5.Tags.Nav [Id "nav"]
        HTML5.Tags.Section [] |+ "is-search"
        HTML5.Tags.Section [] |+ "is-search-style1"
        HTML5.Tags.Section [] |+ "is-recent-post"
        HTML5.Tags.Section [] |+ "is-recent-comment"
        HTML5.Tags.Section [] |+ "is-calendar"
        divi "copyright"
    ]

let page =
    divi "wrapper"
    -< [
        content
        sidebar
    ]
    |>! OnAfterRender (fun _ -> JQuery.JQuery.Of("body").AddClass "left-sidebar" |> ignore)