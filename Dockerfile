FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY src/NeuAI.Video.API/NeuAI.Video.API.csproj src/NeuAI.Video.API/
RUN dotnet restore src/NeuAI.Video.API/NeuAI.Video.API.csproj

COPY . .
RUN dotnet publish src/NeuAI.Video.API/NeuAI.Video.API.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

EXPOSE 5187

ENTRYPOINT ["dotnet", "NeuAI.Video.API.dll"]