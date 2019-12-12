FROM microsoft/dotnet:2.1-sdk AS build

ENV DB_CONNECTION_STRING=host=127.0.0.1;port=5432;database=interaction_db;username=phets_interaction;password=phets_interaction
ENV DEFAULT_ADDRESS=http://127.0.0.1:4005/
ENV POSTGRES_USER=phets_interaction
ENV POSTGRES_PASSWORD=phets_interaction
ENV POSTGRES_DB=interaction_db

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