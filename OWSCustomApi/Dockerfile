#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OWSCustomApi/OWSCustomApi.csproj", "OWSCustomApi/"]
COPY ["OWSShared/OWSShared.csproj", "OWSShared/"]
RUN dotnet restore "OWSCustomApi/OWSCustomApi.csproj"
COPY . .
WORKDIR "/src/OWSCustomApi"
RUN dotnet build "OWSCustomApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OWSCustomApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OWSCustomApi.dll"]