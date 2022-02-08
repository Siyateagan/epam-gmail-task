FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env
WORKDIR /app

COPY . ./
RUN dotnet publish MyApp.csproj -c Release -o out --self-contained -r linux-x64 /p:PublishTrimmed=true

FROM selenium/standalone-chrome
WORKDIR /app

COPY --from=build-env /app/out .

ENTRYPOINT ["dotnet", "test"]