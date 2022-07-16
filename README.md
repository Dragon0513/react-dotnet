# ReactDotNet
ASP.NET Web API with React JS Framework

# ASP WEB API commands used
-dotnet new sln
-dotnet new webapi -n API
-dotnet new classlib -n Application
-dotnet new classlib -n Domain
-dotnet new classlib -n Persistence

# ADD Proj dependencies
-dotnet sln
-dotnet sln list

-dotnet sln add API/API.csproj
-dotnet sln add Application
-dotnet sln add Persistence
-dotnet sln add Domain

-cd API -> dotnet add reference ../Application
-cd ../ cd Application -> dotnet add reference ../Persistence && dotnet add reference ../Domain
-cd ../ cd Persistence -> dotnet add reference ../Domain


# GUIDES
https://docs.microsoft.com/en-us/aspnet/core/migration/50-to-60-samples?view=aspnetcore-5.0

EF CORE COMMAND FOR VS 2022
/*
    Add-Migration
    Bundle-Migration
    Drop-Database
    Get-DbContext
    Get-Migration
    Optimize-DbContext
    Remove-Migration
    Scaffold-DbContext
    Script-DbContext
    Script-Migration
    Update-Database */
	
-Add-Migration InitialMigrate -OutputDir Data/Migrations
-Update-Database

#Revert Migration After applied in Db
-Update-Database -Migration 0
Update-Database -Migration 0 -p Infrastructure -s API

Add-Migration InitialCreate -p Infrastructure -s API -o Data/Migrations
Update-Database -p Infrastructure -s API 


# REACT
npx create-react-app client-app --use-npm --template typescript
npx create-react-app client-app
npm start

# DOWNGRADE
npm install -–save react@17.0.2 react-dom@17.0.2
https://exerror.com/how-to-downgrade-react-version-18-to-17/

# REACT PKG
npm install axios
npm install semantic-ui-react semantic-ui-css