# eshop-case-study
REST API service for providing all available products of an eshop.

# How to build & prepare

## Prerequisites
 - Visual Studio (tested on VS2022 - Version 17.2.3)
 - MSSQL Server (tested on 15.0.*)
 - dotnet cli tools
 - [Optional] SqlPackage cli utility

## tl;dr
Run there powershell scripts:
 - clone source codes from repo
 - clean up folder structure
 - build whole solution via dotnet cli
 - deploy dacpac file to database (sqlpackage is necessary)
   - it expect that SQL server run locally on TargetServerName:"."
 - run database seeds

~~~
.\clean-bin-obj.ps1
.\build-core.ps1
.\deploy-db.ps1
.\seed-database.ps1
~~~

# Manual alternative
Easiest way to build this application is just open Visual Studio and rebuild whole solution.

> Already tested on VS2022 - Version 17.2.3

1) Open solution "eshop-case-study.sln" 
2) Rebuild solution

## How to deploy database
For database deployment is used SQL Server Data Tools (SSDT). And it can publish database directly throw "Publish process".

1) In Visual Studio select "EshopDb.Database", right-click and choose "Publish..."
2) Click od "Edit" and choose database 
 - default value: (Server Same: ".", Auth: Windows auth, Database Name: "EshopDevDb")
 - if you change default values, don't forget setup appsettings.json - ConnectionString
3) And confirm via "Publish" button

Now, you have prepared whole database.

## Database Seeder
In solution structure, you can find "tools/DataSeeder.App" project. 

1) Just run application

It's seeds database with fake data from Bogus nuget.

# Sources
 - [Visual Studio](https://visualstudio.microsoft.com/cs/vs/)
 - [MsSql server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
 - [.NET 6.0](https://dotnet.microsoft.com/en-us/download)
 - [SSDT extension](https://docs.microsoft.com/en-us/sql/ssdt/download-sql-server-data-tools-ssdt?view=sql-server-ver16)
 - Optional: [SqlPackage](https://docs.microsoft.com/en-us/sql/tools/sqlpackage/sqlpackage-download?view=sql-server-ver16)