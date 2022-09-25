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

Add-Migration IdentityAdded -p Persistence -s API
Remove-Migration -p Persistence -s API

jwt.io => DECODE TOKEN JWT


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
npm install mobx mobx-react-lite
npm install react-router-dom@5.2.0
npm install history@4.3.4
npm install react-calendar@3.2.1
npm install @types/react-calendar@3.1.2
npm install react-toastify@5.3.2
npm install formik@2.2.6
npm install yup@0.32.8
npm install @types/yup@0.29.11 --save-dev
npm install react-datepicker@3.3.0
npm install @types/react-datepicker@3.1.2
npm install react-datepicker --legacy-peer-deps


npm ls date-fns
npm install date-fns@2.16.1

npm install --save react-dropzone
npm install --save react-cropper --legacy-peer-deeps

npm install @microsoft/signalr


https://vertabelo.com
dotnet ef migrations script -o test.sql -p Persistence -s API

npm install react-infinite-scroller --legacy-peer-deps


# FOR PRODUCTION
npm run build

docker run --name dev -e POSTGRES_USER=admin -e POSTGRES_PASSWORD=secret -p 5432:5432 -d postgres:latest

https://hub.docker.com/_/postgres

Add-Migration PGInitial -p Persistence -s API



git add .
git commit -m "Heroku PROD"
git push heroku main


https://reactivitiesudemy.herokuapp.com/
