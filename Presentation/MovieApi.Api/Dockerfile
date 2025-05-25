# SDK image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy solution and project files
COPY *.sln .
COPY Core/ Core/
COPY Infrastructure/ Infrastructure/
COPY Presentation/ Presentation/

# Restore dependencies
WORKDIR /src/Presentation/MovieApi.Api
RUN dotnet restore

# Build and publish
WORKDIR /src
RUN dotnet publish Presentation/MovieApi.Api/MovieApi.Api.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "MovieApi.Api.dll"]
