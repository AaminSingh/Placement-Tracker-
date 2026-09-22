# Use the official .NET 10 SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["PlacementTracker.csproj", "./"]
RUN dotnet restore "PlacementTracker.csproj"
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Use the official ASP.NET 10 runtime image to run the app
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "PlacementTracker.dll"]