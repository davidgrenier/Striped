[<JS>]
module Website.Client

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

let divi id content = Div [Id id] -< content

let byLine text = span text |+ "byline"

let dead = a "#"

let header h text = HTML5.Tags.Header [H2 [dead h]; byLine text]    

let article content = HTML5.Tags.Article content |+ "is-post is-post-excerpt"

let fullImage url = A [HRef "#"] -- Img [Src ("images/" + url); Alt ""] |+ "image image-full"

let infoBlock content = Div content |+ "info"

let h5u text = a "http://html5up.net/" text
let aj() = a "http://n33.co/" "AJ"

let content =
    let inner =
        let date (day: int) =
            Span [
                span "Jan" -- span "uary" |+ "month"
                span (" " + string day) |+ "day"
                span ", 2013" |+ "year"
            ] |+ "date"
            
        let icoLis v1 v2 v3 v4 =
            [for x in 1..4 -> string x]
            |> List.zip [v1; v2; v3; v4]
            |> List.map (fun (v, c) -> LI [dead (string v) |+ ("link-icon24 link-icon24-" + c)])
            |> UL     
            |+ "stats"
                      
        let article1 =
            let p1 =
                P [Strong [Text "Hello!"]]
                ++ " You're looking at "
                -- a "http://html5up.net/striped/" "Striped"
                ++ ", a fully responsive HTML5 site template designed by "
                -- aj()
                ++ " for " -- h5u "HTML5 UP"
                ++ " It features a clean, minimalistic design, styling for all basic page elements (including blockquotes, tables and lists), a
repositionable sidebar (left or right), and HTML5/CSS3 code designed for quick and easy customization (see code comments for details)."

            let p2 =
                P [Text "Striped is released for free under the "]
                -- a "http://html5up.net/license/" "Creative Commons Attribution license"
                ++ " so feel free to use it for personal projects or even commercial ones – just be sure to credit " -- h5u "HTML5 UP"
                ++ " for the design. If you like what you see here, be sure to check out " -- h5u "HTML5 UP"
                ++ " for more cool designs or follow me on "
                -- a "http://twitter.com/n33co" "Twitter"
                ++ " for new releases and updates."

            article [
                header "Welcome to Striped" "A free, fully responsive HTML5 site template by AJ for HTML5 UP"
                infoBlock [
                    date 14
                    icoLis 16 32 64 128
                ]
                fullImage "n33-robot-invader.jpg"
                p1
                p2
            ]

        let article2 =
            article [
                header "Lorem ipsum dolor sit amet" "Feugiat interdum sed commodo ipsum consequat dolor nullam metus"
                infoBlock [
                    date 8
                    icoLis 12 24 48 96
                ]
                fullImage "fotogrph-dark-stairwell.jpg"
                P [
                    Text "Quisque vel sapien sit amet tellus elementum ultricies. Nunc vel orci turpis. Donec id malesuada metus.
Nunc nulla velit, fermentum quis interdum quis, tate etiam commodo lorem ipsum dolor sit amet dolore.
Quisque vel sapien sit amet tellus elementum ultricies. Nunc vel orci turpis. Donec id malesuada metus.
Nunc nulla velit, fermentum quis interdum quis, convallis eu sapien. Integer sed ipsum ante."
                ]
            ]

        divi "content-inner" [
            article1
            article2
            Div [
                Div [
                    dead "1" |+ "active"
                    dead "2"
                    dead "3"
                    dead "4"
                    span "…"
                    dead "20"
                ] |+ "pages"
                dead "Next Page" |+ "button next"
            ] |+ "pager"
        ]

    divi "content" [inner]

let section content clazz = HTML5.Tags.Section content |+ clazz

let sidebar =
    let deadLi text = LI [dead text]
    let search = HTML5.Attr.PlaceHolder "search"
    let deadLis = List.map deadLi >> UL

    let nav =
        HTML5.Tags.Nav [Id "nav"]
        -- (deadLis ["Archives"; "About Me"; "Contact Me"] +< [deadLi "Latest Post" |+ "current_page_item"])

    let search =
        section [
            Form [Input [Attr.Type "text"; Name "search"; search] |+ "text"]
            -< [Method "post"; Action "#"]
        ] "is-search"

    let speech =
        section [
            Div [
                P [Strong [Text "Striped:"]]
                ++ " A free and fully responsive HTML5 site template designed by "
                -- aj()
                ++ " for "
                -- h5u "HTML5 up!"
            ] |+ "inner"
        ] "is-text-style1"

    let informal hText content clazz =
        section [
            HTML5.Tags.Header [H2 [Text hText]]
            content
        ] clazz

    let recentPosts =
        informal "Recent Posts" (
            deadLis [
                "Nothing happened"
                "My Dearest Cthulhu"
                "The Meme Meme"
                "Now Full Cyborg"
                "Temporal Flux"
            ]
        ) "is-recent-posts"

    let recentComments =
        informal "Recent Comments" (
            [
                "case on ", "Now Full Cyborg"
                "molly on ", "Untitled Post"
                "case on ", "Temporal Flux"
            ] |> List.map (fun (c, p) -> LI [] ++ c -- dead p) |> UL
        ) "is-recent-comments"

    let calendar =
        let calendarData hasEvents =
            List.map (fun x ->
                    match Seq.exists ((=) x) hasEvents with
                    | true -> [dead (string x)]
                    | _ -> [Span [] ++ string x]
                )
            >> List.map TD

        let calendarRow hasEvents days = calendarData hasEvents days |> TR

        let spacing width = TD [ColSpan (string width)] -- Span [Text "\u00A0"] |+ "pad"
            
        section [
            Div [
                Table [
                    Caption [Text "February 2013"]
                    THead [
                        [
                            "Monday"; "Tuesday"
                            "Wednesday"; "Thursday"
                            "Friday"; "Saturday"; "Sunday"
                        ] |> List.map (fun d -> TH [Attr.Scope "col"; Attr.Title d] ++ d.Substring(0, 1))
                        |> TR
                    ]
                    TBody [
                        calendarRow [] [1..3] +< [spacing 4]
                        calendarRow [6; 10] [4..10]
                        calendarRow [] [11..13] -- (TD [dead "14"] |+ "today") -< calendarData [] [15..17]
                        calendarRow [23] [18..24]
                        calendarRow [25] [25..28] -- spacing 3
                    ]
                ]
            ] |+ "inner"
        ] "is-calendar"

    divi "sidebar" [
        divi "logo" [H1 [Text "STRIPED"]]
        nav
        search
        speech
        recentPosts
        recentComments
        calendar
        divi "copyright" []
    ]

let page =
    divi "wrapper" [
        content
        sidebar
    ]
    |>! OnAfterRender (fun _ -> JQuery.JQuery.Of("body").AddClass "left-sidebar" |> ignore)