#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/OT.Assessment.Consumer/OT.Assessment.Consumer.csproj", "src/OT.Assessment.Consumer/"]
COPY ["src/OT.Assessment.App.Data.DataAccess/OT.Assessment.Data.DataAccess.csproj", "src/OT.Assessment.App.Data.DataAccess/"]
COPY ["src/OT.Assessment.Reposistories/OT.Assessment.Reposistories.csproj", "src/OT.Assessment.Reposistories/"]
RUN dotnet restore "./src/OT.Assessment.Consumer/OT.Assessment.Consumer.csproj"
COPY . .
WORKDIR "/src/src/OT.Assessment.Consumer"
RUN dotnet build "./OT.Assessment.Consumer.csproj" -c %BUILD_CONFIGURATION% -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./OT.Assessment.Consumer.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OT.Assessment.Consumer.dll"]