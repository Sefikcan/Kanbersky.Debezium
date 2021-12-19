#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Payment.Api/Payment.Api.csproj", "src/Payment.Api/"]
COPY ["src/Payment.Application/Payment.Application.csproj", "src/Payment.Application/"]
COPY ["src/Payment.Infrastructure/Payment.Infrastructure.csproj", "src/Payment.Infrastructure/"]
COPY ["src/Payment.Common/Payment.Common.csproj", "src/Payment.Common/"]
RUN dotnet restore "src/Payment.Api/Payment.Api.csproj"
COPY . .
WORKDIR "/src/src/Payment.Api"
RUN dotnet build "Payment.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Payment.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Payment.Api.dll"]