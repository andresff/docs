# See https://aka.ms/containerfastmode to understand how Visual Studio uses this
# Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["background-service/App.BackgroundService.csproj", "background-service/"]
RUN dotnet restore "background-service/App.BackgroundService.csproj"
COPY . .
WORKDIR "/src/background-service"
RUN dotnet build "App.BackgroundService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "App.BackgroundService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "App.BackgroundService.dll"]
