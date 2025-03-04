module Config

open System
open Microsoft.Extensions.Configuration

let config =
    ConfigurationBuilder()
        .SetBasePath(AppContext.BaseDirectory)
        .AddJsonFile("appsettings.json", optional = false, reloadOnChange = true)
        .Build()

let getFirebaseUrl () = config.["Firebase:url"]
let getDatasetDir () = config.["Dataset:dir"]

let getInitHour () = config.["Hour:Init"] |> int
let getEndHour () = config.["Hour:End"] |> int
let getIterationInterval () = config.["Hour:Iter"] |> int
