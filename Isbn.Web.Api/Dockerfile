FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Isbn.Web.Api/Isbn.Web.Api.csproj", "Isbn.Web.Api/"]
RUN dotnet restore "Isbn.Web.Api/Isbn.Web.Api.csproj"
COPY . .
WORKDIR "/src/Isbn.Web.Api"
RUN dotnet build "Isbn.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Isbn.Web.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Isbn.Web.Api.dll"]
