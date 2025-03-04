module Firebase

open System
open System.Net.Http
open System.Text
open System.Threading.Tasks
open Newtonsoft.Json

let insertarDatos (url: string) (json: string) : Task =
    Task.Run(fun () ->
        try
            use client = new HttpClient()
            let contenido = new StringContent(json, Encoding.UTF8, "application/json")
            let response = client.PostAsync(url, contenido).Result
            response.EnsureSuccessStatusCode() |> ignore

            let respuesta = response.Content.ReadAsStringAsync().Result
            printfn "✅ Insertado con éxito: %s" respuesta
        with
        | ex -> printfn $"❌ Error al insertar datos: {ex.Message}"
    )
