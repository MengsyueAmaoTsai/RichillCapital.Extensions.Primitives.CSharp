# RichillCapital.Extensions.Primitives

## Pack

```powershell
dotnet pack -o ./dist -c Release
```

```powershell
```

## Test

```powershell
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../../coverage/lcov.info -- MSTest.Parallelize.Workers=5
```
