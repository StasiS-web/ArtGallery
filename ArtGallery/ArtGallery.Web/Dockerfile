#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ArtGallery.Web/ArtGallery.Web.csproj", "ArtGallery.Web/"]
COPY ["ArtGallery.Services/ArtGallery.Services.csproj", "ArtGallery.Services/"]
COPY ["ArtGallery.Services.Messaging/ArtGallery.Services.Messaging.csproj", "ArtGallery.Services.Messaging/"]
COPY ["ArtGallery.Data.Models/ArtGallery.Data.Models.csproj", "ArtGallery.Data.Models/"]
COPY ["ArtGallery.Common/ArtGallery.Common.csproj", "ArtGallery.Common/"]
COPY ["ArtGallery.Data.Common/ArtGallery.Data.Common.csproj", "ArtGallery.Data.Common/"]
COPY ["ArtGallery.Web.ViewModels/ArtGallery.Web.ViewModels.csproj", "ArtGallery.Web.ViewModels/"]
COPY ["ArtGallery.Services.Mapping/ArtGallery.Services.Mapping.csproj", "ArtGallery.Services.Mapping/"]
COPY ["ArtGallery.Data/ArtGallery.Data.csproj", "ArtGallery.Data/"]
COPY ["ArtGallery.Services.Data/ArtGallery.Services.Data.csproj", "ArtGallery.Services.Data/"]
COPY ["ArtGallery.Web.Infrastructure/ArtGallery.Web.Infrastructure.csproj", "ArtGallery.Web.Infrastructure/"]
RUN dotnet restore "ArtGallery.Web/ArtGallery.Web.csproj"
COPY . .
WORKDIR "/src/ArtGallery.Web"
RUN dotnet build "ArtGallery.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ArtGallery.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ArtGallery.Web.dll"]