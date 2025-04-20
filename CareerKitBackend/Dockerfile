# Step 1: Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything into the container
COPY . ./

# Restore dependencies
RUN dotnet restore

# Build and publish the app to /publish folder
RUN dotnet publish -c Release -o /publish

# Step 2: Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy the published output from build stage
COPY --from=build /publish .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "CareerKitBackend.dll"]
