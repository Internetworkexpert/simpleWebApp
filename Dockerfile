FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["CloudFunBC.csproj", "./"]
RUN dotnet restore "CloudFunBC.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CloudFunBC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudFunBC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudFunBC.dll"]
