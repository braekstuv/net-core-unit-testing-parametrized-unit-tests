# 1. Commands to run:
```
dotnet new sln -n StudentApp
dotnet new classlib -n StudentApp.Domain
dotnet new xunit -n StudentApp.Domain.Test
dotnet sln StudentApp.sln add StudentApp.Domain StudentApp.Domain.Test
dotnet add StudentApp.Domain.Test/StudentApp.Domain.Test.csproj reference StudentApp.Domain/StudentApp.Domain.csproj
```