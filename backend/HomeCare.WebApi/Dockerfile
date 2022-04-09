#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["HomeCare.WebApi/HomeCare.WebApi.csproj", "HomeCare.WebApi/"]
COPY ["HomeCare.IoC/HomeCare.IoC.csproj", "HomeCare.IoC/"]
COPY ["HomeCare.Domain/HomeCare.Domain.csproj", "HomeCare.Domain/"]
COPY ["HomeCare.Common/HomeCare.Common.csproj", "HomeCare.Common/"]
COPY ["HomeCare.SendGrid/HomeCare.SendGrid.csproj", "HomeCare.SendGrid/"]
COPY ["HomeCare.PayPal/HomeCare.PayPal.csproj", "HomeCare.PayPal/"]
COPY ["HomeCare.RabbitMQ/HomeCare.RabbitMQ.csproj", "HomeCare.RabbitMQ/"]
COPY ["HomeCare.Data.InMemory/HomeCare.Data.InMemory.csproj", "HomeCare.Data.InMemory/"]
RUN dotnet restore "HomeCare.WebApi/HomeCare.WebApi.csproj"
COPY . .
WORKDIR "/src/HomeCare.WebApi"
RUN dotnet build "HomeCare.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HomeCare.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HomeCare.WebApi.dll"]