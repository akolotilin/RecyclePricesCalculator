# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
#COPY *.csproj ./
COPY ./Sources /sources
RUN dotnet restore /sources/VmsInformWeb.sln

# Copy everything else and build
#COPY ../engine/examples ./
RUN dotnet publish /sources/VmsInformWeb.sln --framework net5 -c Release -o out -r linux-x64 --no-self-contained

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
RUN apt-get update && apt-get install -y xvfb x11vnc x11-xkb-utils xfonts-100dpi xfonts-75dpi xfonts-scalable xfonts-cyrillic x11-apps libgdiplus libx11-dev wget \
	&& mkdir ~/.mysql && \
		wget "https://crls.yandex.net/allCAs.pem" -O ~/.mysql/root.crt && \
		chmod 0600 ~/.mysql/root.crt
#ENTRYPOINT ["dotnet", "VmsInformWeb.dll"]