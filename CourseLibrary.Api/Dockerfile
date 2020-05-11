FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["CourseLibrary.Api.csproj", "CourseLibrary.Api/"]
RUN dotnet restore "CourseLibrary.Api/CourseLibrary.Api.csproj"
WORKDIR "/src/CourseLibrary.Api"
COPY . .
RUN dotnet build "CourseLibrary.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CourseLibrary.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet CourseLibrary.Api.dll