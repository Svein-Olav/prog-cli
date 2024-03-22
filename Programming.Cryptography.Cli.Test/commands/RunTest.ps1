Remove-Item -Path '..\TestResults\*' -Recurse -Force
dotnet test ..\Programming.Cryptography.Cli.Test.csproj --collect:"XPlat Code Coverage"