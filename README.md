# Test for .NET Backend Web Development

## Platforms
The project was developed in Visual Studio 2017 Community Edition

## Technologies
- ASP.NET MVC 5
- AngularJS
- SQL Server Express

## Project Structure
```bash

PointOfSale/
├── Application/
|   └── PointOfSale.Application
|
├── Domain/
|   └── PointOfSale.Domain
|
├── Infra/
|   ├── PointOfSale.Infrastructure.IoC
|   └── PointOfSale.Infrastructure.Repository
|
├── Presentation/
    └── PointOfSale.Mvc

```

## Used Libraries
- [EntityFramework](https://github.com/aspnet/EntityFramework6)
- [AutoMapper](https://github.com/AutoMapper/AutoMapper)
- [Bulma](http://bulma.io/)
- [Toastr](https://github.com/CodeSeven/toastr)
- [JQuery](https://github.com/jquery/jquery)
- [SimpleInjector](https://github.com/simpleinjector)

# Build and Execution instructions

## Database
> All database structure and mappings can be found in "PointOfSale.Infrastructure.Repository" project.

mssqllocaldb was used as the application default database. The context name used was PointOfSaleContext

You have to use the **Package Manager Console** and run the command `Update-Database` with default project set to "PointOfSale.Infrastructure.Repository" in order to apply the migrations and create the database.
