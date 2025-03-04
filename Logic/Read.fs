module Read

open System
open System.IO
open System.Globalization
open CsvHelper
open CsvHelper.Configuration
open Movie

let readCsv (filePath: string) : Movie list =
    use reader = new StreamReader(filePath)
    let config = CsvConfiguration(CultureInfo.InvariantCulture, MissingFieldFound = fun _ -> ())
    use csv = new CsvReader(reader, config)

    csv.Read() |> ignore
    csv.ReadHeader() |> ignore

    let movies =
        seq {
            while csv.Read() do
                try
                    let nId = csv.GetField<string>("N_id")
                    let title = csv.GetField<string>("Title")
                    let mainGenre = csv.GetField<string>("Main_Genre")
                    let subGenres = csv.GetField<string>("Sub_Genres")
                    let releaseYear = csv.GetField<string>("Release_Year")
                    let maturityRating = csv.GetField<string>("Maturity_Rating")
                    let originalAudio = csv.GetField<string>("Original_Audio")
                    let recommendations = csv.GetField<string>("Recommendations")
                    yield {
                        N_id = nId
                        Title = title
                        MainGenre = mainGenre
                        SubGenres = subGenres
                        ReleaseYear = releaseYear
                        MaturityRating = maturityRating
                        OriginalAudio = originalAudio
                        Recommendations = recommendations
                    }
                with
                | ex -> printfn "Error reading line: %s" ex.Message
        } |> Seq.toList

    movies
