#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["lab.OCRSample/lab.OCRSample.csproj", "lab.OCRSample/"]
RUN dotnet restore "lab.OCRSample/lab.OCRSample.csproj"
COPY . .
WORKDIR "/src/lab.OCRSample"
RUN dotnet build "lab.OCRSample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lab.OCRSample.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lab.OCRSample.dll"]