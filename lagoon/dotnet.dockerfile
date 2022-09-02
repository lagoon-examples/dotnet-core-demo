
ARG IMAGE_REPO
FROM ${IMAGE_REPO:-uselagoon}/commons as commons

ENV LAGOON=dotnet

FROM  mcr.microsoft.com/dotnet/sdk:6.0-alpine




COPY RazorPagesMovie /app
WORKDIR /app/
RUN dotnet build
EXPOSE 3000

ENV MARIADB_DATABASE=lagoon \
    MARIADB_USER=lagoon \
    MARIADB_PASSWORD=lagoon

RUN addgroup rootless -g 10001 && adduser rootless -G rootless -u 10000 -D


CMD ["dotnet", "run","--no-build"]