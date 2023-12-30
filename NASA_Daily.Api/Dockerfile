FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NASA_Daily.Api/NASA_Daily.Api.csproj", "NASA_Daily.Api/"]
RUN dotnet restore "NASA_Daily.Api/NASA_Daily.Api.csproj"
COPY . .
WORKDIR "/src/NASA_Daily.Api"
RUN dotnet build "NASA_Daily.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NASA_Daily.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NASA_Daily.Api.dll"]
