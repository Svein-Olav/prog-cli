# template-console
Dette prosjektet er en templeate med dev container, xunit og benchmark

Se link : https://github.com/mayuki/Cocona/blob/master/README.md#installing

# Testing
Hvis file slutter med txt få inneholder filen base64 representasjon av key og iv
```
 dotnet run encrypt --key-file .\testfiles\key.txt --iv-file .\testfiles.\iv.txt sveinolav
```
```
dotnet run decrypt --key-file .\testfiles\key.txt --iv-file .\testfiles\iv.txt --tekst 
YAU8va3yN4wL8CnneXVj4g==
```
For å kunne lese beskrive kan man utføre:
```
dotnet run -- encrypt -help
```
eller
```
dotnet run -- -help
```