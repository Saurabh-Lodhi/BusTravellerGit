# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything
COPY . .

# Publish the project explicitly
RUN dotnet publish BusTravellerGit-1.csproj -c Release -o /app

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published output
COPY --from=build /app .

# Bind to Render port
ENV ASPNETCORE_URLS=http://+:10000

# Run the correct DLL
ENTRYPOINT ["dotnet", "BusTravellerGit-1.dll"]
