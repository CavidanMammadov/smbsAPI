FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5021
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
WORKDIR "/src/Smbs.Api"
RUN dotnet restore "Smbs.Api.csproj"
RUN dotnet build "Smbs.Api.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Smbs.Api.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Smbs.Api.dll"]
