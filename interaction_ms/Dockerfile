FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore interaction_ms.csproj
COPY . ./
RUN dotnet publish interaction_ms.csproj -c Release -o out
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/out .
EXPOSE 4005
ENTRYPOINT ["dotnet", "interaction_ms.dll"]