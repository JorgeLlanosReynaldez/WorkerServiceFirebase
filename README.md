# WorkerServiceFirebase

Este proyecto es un servicio de fondo (Worker Service) que se conecta a una base de datos en tiempo real de Firebase, extrae información de un conjunto de datos (dataset), y envía los datos procesados a Firebase.

## Descripción

El Worker Service se ejecuta en intervalos configurables, tomando datos de un archivo CSV y enviándolos a una base de datos en tiempo real de Firebase. El servicio funciona durante las horas configuradas en el archivo de configuración y procesa los datos de manera continua durante su ejecución.

### Flujo

1. El servicio lee un archivo CSV que contiene información sobre películas.
2. El servicio toma estos datos y los envía a la base de datos de Firebase Real-Time Database.
3. La configuración y el comportamiento del servicio están definidos en el archivo `appsettings.json`.
4. Firebase permite leer y escribir datos sin autenticación, ya que las reglas de acceso están configuradas para permitir acceso sin restricciones.

### Estructura del Proyecto

El proyecto está compuesto por los siguientes elementos principales:

- **Worker**: Un servicio en segundo plano que se encarga de leer los datos y enviarlos a Firebase.
- **Firebase Module**: Módulo encargado de manejar la comunicación con Firebase para insertar y obtener datos.
- **Read Module**: Módulo encargado de leer los datos desde el archivo CSV.
- **appsettings.json**: Archivo de configuración donde se definen las URL de Firebase, el directorio del dataset, y los horarios de ejecución.

## Configuración

La configuración del servicio se encuentra en el archivo `appsettings.json`. Aquí se definen las siguientes secciones:

### AppSettings
```json
"Logging": {
  "LogLevel": {
    "Default": "Information",
    "Microsoft.Hosting.Lifetime": "Information"
  }
}
```
```Firebase
"Firebase": {
  "url": "https ---- URL REAL TIME DATABASE FIREBASE ----"
}
```
```Directorio
"Dataset": {
  "dir": "D:// ---- DIR ----"
}
```
```Hour
"Hour": {
  "Init": 8,
  "End": 20,
  "Iter": 10
}
```
```rules
{
  "rules": {
    ".read": true,
    ".write": true
  }
}
```
### Librerías Utilizadas
```
<PackageReference Include="CsvHelper" Version="33.0.1" />
<PackageReference Include="Microsoft.Extensions.Hosting" Version="8.0.1" />
<PackageReference Include="Newtonsoft.Json" Version="13.0.3" />
```

### Se muestra un ejemplo de cómo los datos se insertan en Firebase. Este es un registro de una película, con diversos atributos como el género principal, el año de lanzamiento y las recomendaciones.
"-OKYUjFL16s2hSAkgTRq": {
  "MainGenre": "Drama",
  "MaturityRating": "1994",
  "N_id": "1",
  "OriginalAudio": "R",
  "Recommendations": "English",
  "ReleaseYear": "Prison",
  "SubGenres": "Crime",
  "Title": "The Shawshank Redemption"
}
