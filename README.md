# Proyecto PRT

## Requisitos previos
- **SDK .NET 8**: Aseg�rate de tener instalado el SDK de .NET 8. Puedes descargarlo desde [aqu�](https://dotnet.microsoft.com/download).
- **Base de datos**: SQL Server.

## Configuraci�n inicial
1. Clona el repositorio: git clone https://github.com/YefersonDuarteg/PrTec2025COI_YDG.git

2. Restaura las dependencias:
Des de la terminal nos ubicamos en el proyecto PRt.CrwAPI y ejecutamos el siguiente comando (cd PRt.CrwAPI): dotnet restore

3. Configura la cadena de conexi�n en el archivo `appsettings.json`: {"DataBaseConnection": "Server=TU_SERVIDOR;Database=COIPrtBd;Trusted_Connection=True;TrustServerCertificate=True; }

4. Aplica las migraciones para crear la base de datos: cd PRT.CrwAPI dotnet ef database update

**Nota**: Aseg�rate de que `dotnet-ef` est� instalado globalmente. Si no lo tienes, inst�lalo con: 

5. Ejecuta el script de base de datos adicional (si aplica) desde el archivo `DocDatabase/BD_Script_PruebaTecnica`.

## Ejecuci�n del proyecto
Ejecuta la soluci�n (Esta confugurada para que corra el proeyecto frontend y bakend al mismo tiempo)

Tambien se puede ejecutar los proyectos por separado, esto desde la raiz de la soluci�n:
- **Backend**: Navega a la carpeta del backend y ejecuta `cd PRT.CrwAPI dotnet run`.
- **Frontend**: Navega a la carpeta del frontend y ejecuta `cd PRT.UIBlz dotnet run`.

3. Accede a la aplicaci�n en tu navegador en `https://localhost:7290/`.

## Estructura del proyecto
- **PRT.CrwAPI**: Contiene la API REST para gestionar productos e im�genes.
- **PRT.UIBlz**: Contiene la interfaz de usuario desarrollada con Blazor.
- **Database**: Contiene los scripts necesarios para la base de datos.

## Funcionalidades principales
- Gesti�n de productos.
- Carga y previsualizaci�n de im�genes.
- Edici�n y eliminaci�n de im�genes.
- Persistencia de datos en base de datos.