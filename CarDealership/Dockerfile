FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Src/CarDealership.Web/CarDealership.Web.csproj", "Src/CarDealership.Web/"]
COPY ["Src/CarDealership.Application/CarDealership.Application.csproj", "Src/CarDealership.Application/"]
COPY ["Src/CarDealership.Domain/CarDealership.Domain.csproj", "Src/CarDealership.Domain/"]
COPY ["Src/CarDealership.Infrastructure/CarDealership.Infrastructure.csproj", "Src/CarDealership.Infrastructure/"]
RUN dotnet restore "./Src/CarDealership.Web/CarDealership.Web.csproj"
COPY . .
WORKDIR "/src/Src/CarDealership.Web"
RUN dotnet build "./CarDealership.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./CarDealership.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://+:80
ENTRYPOINT ["dotnet", "CarDealership.Web.dll"]

COPY Src/CarDealership.Web/appsettings.json /app/
COPY Src/CarDealership.Web/appsettings.Development.json /app/