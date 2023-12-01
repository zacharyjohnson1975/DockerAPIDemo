#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DockerAPIDemo/DockerAPIDemo.csproj", "DockerAPIDemo/"]
RUN dotnet restore "DockerAPIDemo/DockerAPIDemo.csproj"
COPY . .
WORKDIR "/src/DockerAPIDemo"
RUN dotnet build "DockerAPIDemo.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DockerAPIDemo.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DockerAPIDemo.dll"]