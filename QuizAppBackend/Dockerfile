# Build-Stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app
RUN mkdir -p /app/data
RUN chmod 777 /app/data
# Alles ins Image kopieren, inkl. Data-Verzeichnis mit quiz.db
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish .
RUN ls -la /app/publish
# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
# Verzeichnis anlegen und Rechte setzen
RUN mkdir -p /app/data
RUN chmod 777 /app/data

COPY --from=build /app/publish ./

# Standardkommando beim Containerstart
ENTRYPOINT ["dotnet", "QuizAppBackend.dll"]
