[<JS>]
module Website.Client

open IntelliFactory.WebSharper
open IntelliFactory.WebSharper.Html

let divi id content = Div [Id id] -< content

let byLine text = span text |+ "byline"

let header h text = HTML5.Tags.Header [H2 [a "#" h]; byLine text]    

let article content = HTML5.Tags.Article content |+ "is-post is-post-excerpt"

let fullImage url = A [HRef "#"] -- Img [Src ("images/" + url); Alt ""] |+ "image image-full"

let infoBlock content = Div content |+ "info"

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
            |> List.map (fun (v, c) -> LI [a "#" (string v) |+ ("link-icon24 link-icon24-" + c)])
            |> UL     
            |+ "stats"
                      
        let article1 =
            let h5u () = a "http://html5up.net/" "HTML5 UP"

            let p1 =
                P [Strong [Text "Hello!"]]
                ++ " You're looking at "
                -- a "http://html5up.net/striped/" "Striped"
                ++ ", a fully responsive HTML5 site template designed by "
                -- a "http://n33.co/" "AJ"
                ++ " for " -- h5u()
                ++ " It features a clean, minimalistic design, styling for all basic page elements (including blockquotes, tables and lists), a
responsible sidebar (left or right), and HTML5/CSS3 code designed for quick and easy customization (see code comments for details)."

            let p2 =
                P [Text "Striped is released for free under the "]
                -- a "http://html5up.net/license/" "Creative Commons Attribution license"
                ++ " so feel free to use it for personal projects or even commercial ones &ndash; just be sure to credit " -- h5u()
                ++ " for the design. If you like what you see here, be sure to check out " -- h5u()
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
                    a "#" "1" |+ "active"
                    a "#" "2"
                    a "#" "3"
                    a "#" "4"
                    span "&hellip;"
                    a "#" "20"
                ] |+ "pages"
                a "#" "Next Page" |+ "button next"
            ] |+ "pager"
        ]

    divi "content" [inner]

let section content clazz = HTML5.Tags.Section content |+ clazz

let sidebar =
    divi "sidebar" [
        divi "logo" []
        HTML5.Tags.Nav [Id "nav"]
        section [] "is-search"
        section [] "is-search-style1"
        section [] "is-recent-post"
        section [] "is-recent-comment"
        section [] "is-calendar"
        divi "copyright" []
    ]

let page =
    divi "wrapper" [
        content
        sidebar
    ]
    |>! OnAfterRender (fun _ -> JQuery.JQuery.Of("body").AddClass "left-sidebar" |> ignore)