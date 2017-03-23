FROM microsoft/dotnet:1.1.0-sdk-projectjson

COPY . /app

WORKDIR /app

RUN ["dotnet", "restore", "-s" ,"https://api.nuget.org/v3/index.json", "--disable-parallel", "--no-cache"] 

WORKDIR /app/src/Sample.City.Api

RUN ["dotnet", "build"]

EXPOSE 6001/tcp
ENV ASPNETCORE_URLS http://*:6001
 
ENTRYPOINT ["dotnet", "run"]