FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Raptor.Wasm/Raptor.Wasm.csproj", "Raptor.Wasm/"]
RUN dotnet restore "Raptor.Wasm/Raptor.Wasm.csproj"
COPY . .
WORKDIR "/src/Raptor.Wasm"
RUN dotnet build "Raptor.Wasm.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Raptor.Wasm.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Raptor.Wasm.dll"]
