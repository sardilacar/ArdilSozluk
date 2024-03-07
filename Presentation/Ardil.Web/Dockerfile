#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Presentation/Ardil.Web/Ardil.Web.csproj", "Presentation/Ardil.Web/"]
COPY ["Core/Ardil.Application/Ardil.Application.csproj", "Core/Ardil.Application/"]
COPY ["Core/Ardil.Domain/Ardil.Domain.csproj", "Core/Ardil.Domain/"]
COPY ["Infrastructure/Ardil.Persistence/Ardil.Persistence.csproj", "Infrastructure/Ardil.Persistence/"]
RUN dotnet restore "Presentation/Ardil.Web/Ardil.Web.csproj"
COPY . .
WORKDIR "/src/Presentation/Ardil.Web"
RUN dotnet build "Ardil.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ardil.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ardil.Web.dll"]