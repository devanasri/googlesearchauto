FROM selenium/standalone-chrome:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

# build and copy dotnet project
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SimpleGoogleSearch.csproj", "."]
RUN dotnet restore "./SimpleGoogleSearch.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "SimpleGoogleSearch.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleGoogleSearch.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# install dotnet
RUN sudo wget https://packages.microsoft.com/config/debian/10/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
RUN sudo dpkg -i packages-microsoft-prod.deb
RUN sudo apt-get update
RUN sudo apt-get install -y dotnet-runtime-6.0

# ENTRYPOINT ["dotnet", "Janus_Test_Framework.dll"]
ENTRYPOINT ["dotnet", "test", "SimpleGoogleSearch.dll"]