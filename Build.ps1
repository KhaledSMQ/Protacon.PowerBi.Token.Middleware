if(Test-Path .\artifacts) {
    Remove-Item .\artifacts -Force -Recurse
}

dotnet restore
dotnet build



$version = if($env:APPVEYOR_REPO_TAG_NAME) {
    $env:APPVEYOR_REPO_TAG_NAME
} else {
    "0.0.1-beta$env:APPVEYOR_BUILD_NUMBER"
}

dotnet pack .\Protacon.PowerBi.Token.Middleware\ -c Release -o .\artifacts /p:Version=$version