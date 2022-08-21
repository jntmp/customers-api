#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1-bionic AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1-bionic AS build
WORKDIR /src
COPY src/ .

FROM build AS publish
WORKDIR /src/customers.api
RUN dotnet publish "Customers.Api.csproj" -c Debug -o /app/publish -r ubuntu-x64

FROM base AS final
ENV ASPNETCORE_ENVIRONMENT=Development
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Customers.Api.dll"]