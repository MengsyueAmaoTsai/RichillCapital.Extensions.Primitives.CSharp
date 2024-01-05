# RichillCapital.Extensions.Primitives
[![Build & Tests](https://github.com/MengsyueAmaoTsai/RichillCapital.Extensions.Primitives.CSharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/MengsyueAmaoTsai/RichillCapital.Extensions.Primitives.CSharp/actions/workflows/dotnet.yml)
## Pack

```powershell
dotnet pack -o ./dist -c Release
```

## Push to NuGet

```powershell
dotnet nuget push .\dist\RichillCapital.Extensions.Primitives.1.0.0.nupkg -k <api-key> -s https://api.nuget.org/v3/index.json
```

## Testing

```powershell
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../../coverage/lcov.info -- MSTest.Parallelize.Workers=5
```
