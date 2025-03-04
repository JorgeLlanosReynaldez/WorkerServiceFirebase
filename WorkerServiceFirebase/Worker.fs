namespace WorkerServiceFirebase

open System
open System.Threading
open System.Threading.Tasks
open Microsoft.Extensions.Hosting
open Microsoft.Extensions.Logging
open Config
open Read
open Firebase
open Newtonsoft.Json

type Worker(logger: ILogger<Worker>) =
    inherit BackgroundService()

    override _.ExecuteAsync(ct: CancellationToken) =
        task {
            let firebaseUrl = getFirebaseUrl()
            let datasetDir = getDatasetDir()
            let initHour = getInitHour()
            let endHour = getEndHour()
            let iterInterval = getIterationInterval() * 60 * 1000

            while not ct.IsCancellationRequested do
                let now = DateTime.Now
                let currentHour = now.Hour

                if currentHour >= initHour && currentHour < endHour then
                    logger.LogInformation("Worker running at: {time}", now)
                    let movies = readCsv datasetDir
                    logger.LogInformation($"[Length] {movies.Length}")

                    for movie in movies do
                        let json = JsonConvert.SerializeObject(movie)
                        do! insertarDatos firebaseUrl json
                        logger.LogInformation($"Movie send id: { movie.N_id}")

                else
                    logger.LogInformation("Offline")

                do! Task.Delay(iterInterval, ct)
        }
