if(Test-Path .\artifacts) {
    Remove-Item .\artifacts -Force -Recurse
}

dotnet restore
dotnet build

dotnet pack .\Protacon.PowerBi.Token.Middleware\ -c Release -o .\artifacts --version-suffix=$env:APPVEYOR_BUILD_NUMBER