#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DistributionCenter.API/DistributionCenter.API.csproj", "DistributionCenter.API/"]
COPY ["DistributionCenter.DAL.MSSQL/DistributionCenter.DAL.MSSQL.csproj", "DistributionCenter.DAL.MSSQL/"]
COPY ["DistributionCenter.Core/DistributionCenter.Core.csproj", "DistributionCenter.Core/"]
COPY ["DistributionCenter.BLL/DistributionCenter.BLL.csproj", "DistributionCenter.BLL/"]
COPY ["DistributionCenter.DAL/DistributionCenter.DAL.csproj", "DistributionCenter.DAL/"]
RUN dotnet restore "DistributionCenter.API/DistributionCenter.API.csproj"
COPY . .
WORKDIR "/src/DistributionCenter.API"
RUN dotnet build "DistributionCenter.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DistributionCenter.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DistributionCenter.API.dll"]
