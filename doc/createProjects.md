# Lage nye prosjekter med dotnet cli

## lage nye prosjekter med test
```
dotnet new console -n Programming.Datastructure.List
dotnet new xunit -n Programming.Datastructure.List.Test
cd Programming.Datastructure.List.Test
dotnet add reference ../Programming.Datastructure.List/Programming.Datastructure.List.csproj
```

## Legger til et Benchmark prosjekt
```
dotnet new console -n Programming.Datastructure.List.Benchmark
cd Programming.Datastructure.List.Benchmark
dotnet add package BenchmarkDotNet
dotnet add reference ../Programming.Datastructure.List/Programming.Datastructure.List.csproj
```