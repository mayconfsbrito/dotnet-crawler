FROM microsoft/dotnet:2.2-sdk
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
ENTRYPOINT ["dotnet", "bin/Release/netcoreapp2.2/dotnet-crawler.dll"]