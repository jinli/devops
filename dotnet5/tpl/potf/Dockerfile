#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["potf/potf.csproj", "potf/"]
RUN dotnet restore "potf/potf.csproj"
COPY . .
WORKDIR "/src/potf"
RUN dotnet build "potf.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "potf.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "potf.dll"]