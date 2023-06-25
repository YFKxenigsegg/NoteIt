FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebApi/NoteIt.WebApi.csproj", "WebApi/"]
COPY ["Application/NoteIt.Application.csproj", "Application/"]
COPY ["Domain/NoteIt.Domain.csproj", "Domain/"]
COPY ["Infrastructure/NoteIt.Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "WebApi/NoteIt.WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "NoteIt.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "NoteIt.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NoteIt.WebApi.dll"]