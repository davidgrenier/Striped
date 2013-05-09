[<JS>]
module Website.Config

open IntelliFactory.WebSharper
type Window = IntelliFactory.WebSharper.Html5.Window

type GridConfig = { collapse: bool }
type Alternate = { range: string }
type Desktop = { range: string; containers: int }

type Mobile =
    {
        range: string
        lockViewport: bool
        containers: string
        grid: GridConfig
    }

type BreakPoint =
    {
        mobile: Mobile
        desktop: Desktop
        wide: Alternate
        narrow: Desktop
        narrower: Alternate
    }

type Config =
    {
        prefix: string
        resetCSS: bool
        useOrientation: bool
        breakpoints: BreakPoint
    }

let config() =
    Window.Self?_skel_config <-
        {
            prefix = "css/style"
            resetCSS = true
            useOrientation = true
            breakpoints =
                {
                    mobile =
                        {
                            range = "-640"
                            lockViewport = true
                            containers = "fluid"
                            grid = { collapse = true }
                        }
                    desktop =
                        {
                            range = "641-"
                            containers = 1200
                        }
                    wide = { range = "1201-" }
                    narrow =
                        {
                            range = "641-1200"
                            containers =  960
                        }
                    narrower = { range = "641-1000" }
                }
        }

type Panel =
    {
        breakpoints: string
        position: string
        style: string
        size: string
        html: string
    }

type Bar =
    {
        breakpoints: string
        position: string
        style: string
        size: int
        html: string
    }

type Panels = { sidePanel: Panel; sidePanelNarrower: Panel }
type Bars = { titleBar: Bar; titleBarNarrower: Bar }
type UIConfig = { panels: Panels; bars: Bars }

let uiConfig() =
    Window.Self?_skel_ui_config <-
        {
            panels =
                {
                    sidePanel =
                        {
                            breakpoints = "mobile"
                            position = "left"
                            style = "reveal"
                            size = "250px"
                            html = """<div data-action="moveElement" data-target="sidebar"></div>"""
                        }
                    sidePanelNarrower =
                        {
                            breakpoints = "narrower"
                            position = "left"
                            style = "reveal"
                            size = "300px"
                            html = """<div data-action="moveElement" data-target="sidebar"></div>"""
                        }
                }
            bars =
                {
                    titleBar =
                        {
                            breakpoints = "mobile"
                            position = "top"
                            size = 44
                            style = "floating"
                            html = """<div class="toggle " data-action="panelToggle" data-target="sidePanel"></div>
<div class="title" data-action="copyHTML" data-target="logo"></div>"""
                        }
                    titleBarNarrower =
                        {
                            breakpoints = "narrower"
                            position = "top"
                            size = 60
                            style = "floating"
                            html = """<div class="toggle " data-action="panelToggle" data-target="sidePanelNarrower"></div>
<div class="title" data-action="copyHTML" data-target="logo"></div>"""
                        }
                }
        }