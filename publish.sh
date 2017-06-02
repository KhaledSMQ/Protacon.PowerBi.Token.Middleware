#!/usr/bin/env bash
cd Protacon.PowerBi.Token.Middleware
echo $VERSION.$TRAVIS_BUILD_NUMBER
dotnet nuget pack Protacon.PowerBi.Token.Middleware.nuspec -Version $VERSION.$TRAVIS_BUILD_NUMBER -IncludeReferencedProjects -Prop Configuration=Release
dotnet nuget push *.nupkg $NUGET_API_KEY -verbosity detailed