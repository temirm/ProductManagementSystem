## About The Project

System that allows to create products by uploading an Excel file.
It also periodically groups the products.

### Built With

* .NET 8
* ASP.NET Core
* SQLite
* [ClosedXML][closedxml-url]
* [Quartz.NET][quartznet-url]



## Getting Started

To apply migrations:

```sh
cd src/ProductManagementSystem.Infrastructure/
dotnet ef database update
```


To run the project:

```sh
dotnet run --project ./src/ProductManagementSystem.TaskManager/ProductManagementSystem.TaskManager.csproj
dotnet run --project ./src/ProductManagementSystem.WebAPI/ProductManagementSystem.WebAPI.csproj
```



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[closedxml-url]: https://github.com/ClosedXML/ClosedXML
[quartznet-url]: https://www.quartz-scheduler.net/