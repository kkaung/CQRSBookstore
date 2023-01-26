FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5068

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["./CQRSBookstore.UI", "src/CQRSBookstore.UI/"] 
COPY ["./CQRSBookstore.App", "src/CQRSBookstore.App/"] 
COPY ["./CQRSBookstore.Api", "src/CQRSBookstore.Api/"] 

RUN dotnet restore "src/CQRSBookstore.UI/CQRSBookstore.UI.csproj"

COPY . .

WORKDIR "/src/CQRSBookstore.UI/"
RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
RUN ls -l
ENTRYPOINT [ "dotnet", "CQRSBookstore.UI.dll" ]




