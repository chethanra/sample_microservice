FROM microsoft/dotnet:1.1.0-sdk-projectjson

COPY . /app

WORKDIR /app

RUN ["dotnet", "restore", "-s" ,"https://api.nuget.org/v3/index.json", "--disable-parallel", "--no-cache"] 

WORKDIR /app/src/Sample.Web.Api

RUN ["dotnet", "build"]

EXPOSE 7000/tcp
ENV ASPNETCORE_URLS http://*:7000
 
ENTRYPOINT ["dotnet", "run"]