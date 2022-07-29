FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SeenLive.Api/SeenLive.Api.csproj", "SeenLive.Api/"]
COPY ["SeenLive/SeenLive.csproj", "SeenLive/"]
RUN dotnet restore "SeenLive.Api/SeenLive.Api.csproj"
COPY . .
WORKDIR "/src/SeenLive.Api"
RUN dotnet build "SeenLive.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SeenLive.Api.csproj" -c Release -o /app/publish
RUN dotnet ef database update
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "SeenLive.Api.dll", "--launch-profile SeenLive"]