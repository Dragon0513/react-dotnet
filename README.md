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
