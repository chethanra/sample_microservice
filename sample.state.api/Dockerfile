FROM microsoft/dotnet:1.1.0-sdk-projectjson

COPY . /app

WORKDIR /app

RUN ["dotnet", "restore", "-s" ,"https://api.nuget.org/v3/index.json", "--disable-parallel", "--no-cache"] 

WORKDIR /app/src/sample.state.api

RUN ["dotnet", "build"]

EXPOSE 8000/tcp
ENV ASPNETCORE_URLS http://*:8000
 
ENTRYPOINT ["dotnet", "run"]