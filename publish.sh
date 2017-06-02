#!/usr/bin/env bash
cd Protacon.PowerBi.Token.Middleware
echo $VERSION.$TRAVIS_BUILD_NUMBER
dotnet pack --version $VERSION.$TRAVIS_BUILD_NUMBER --IncludeReferencedProjects --Prop Configuration=Release
dotnet nuget push *.nupkg $NUGET_API_KEY -verbosity detailed