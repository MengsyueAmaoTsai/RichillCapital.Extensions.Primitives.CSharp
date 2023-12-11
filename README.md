# RichillCapital.Extensions.Primitives

## Pack
```powershell
dotnet pack -o ./dist
```

## Test
```powershell
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=lcov /p:CoverletOutput=../../coverage/lcov.info -- MSTest.Parallelize.Workers=5
```