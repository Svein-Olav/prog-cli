Remove-Item -Path '..\TestResults\*' -Recurse -Force
dotnet test ..\Programming.Datastructure.Stack.Test.csproj --collect:"XPlat Code Coverage"