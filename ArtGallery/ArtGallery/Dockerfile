#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ArtGallery/ArtGallery.csproj", "ArtGallery/"]
COPY ["ArtGallery.Core/ArtGallery.Core.csproj", "ArtGallery.Core/"]
COPY ["ArtGallery.Infrastructure/ArtGallery.Infrastructure.csproj", "ArtGallery.Infrastructure/"]
COPY ["ArtGallery.Common/ArtGallery.Common.csproj", "ArtGallery.Common/"]
RUN dotnet restore "ArtGallery/ArtGallery.csproj"
COPY . .
WORKDIR "/src/ArtGallery"
RUN dotnet build "ArtGallery.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArtGallery.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtGallery.dll"]