reportgenerator -reports:"..\TestResults\**\coverage.cobertura.xml" -targetdir:"..\TestResults\coveragereport" -reporttypes:Html
Start-Process -FilePath "..\TestResults\coveragereport\index.htm"
