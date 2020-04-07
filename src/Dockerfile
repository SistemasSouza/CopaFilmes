FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env

WORKDIR .
EXPOSE 80

COPY . ./publish

FROM mcr.microsoft.com/dotnet/core/runtime:3.1 AS runtime
WORKDIR .
COPY — from=build-env

CMD ASPNETCORE_URLS=http://*:$PORT dotnet copafilmes.api.dll

