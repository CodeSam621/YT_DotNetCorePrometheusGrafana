FROM mcr.microsoft.com/dotnet/sdk:5.0 as dev
RUN mkdir /work/
WORKDIR /work
COPY ./src/CustomerApi/CustomerApi.csproj /work/CustomerApi.csproj
RUN dotnet restore

COPY ./src/CustomerApi/ /work
RUN mkdir /out/
RUN cd /work/
RUN dotnet publish  --output /out/ --configuration Release

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as prod
RUN mkdir /app/
WORKDIR /app/
COPY --from=dev /out/ /app/
RUN chmod +x /app/
ENTRYPOINT ["dotnet", "CustomerApi.dll" ]