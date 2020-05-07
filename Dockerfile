FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
EXPOSE 80

COPY publish/ ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CopaFilmes.Api.dll