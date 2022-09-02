
ARG IMAGE_REPO
FROM ${IMAGE_REPO:-uselagoon}/commons as commons

ENV LAGOON=dotnet

FROM  mcr.microsoft.com/dotnet/sdk:6.0-alpine




COPY RazorPagesMovie /app
WORKDIR /app/
RUN dotnet build
EXPOSE 3000

CMD ["dotnet", "run","--no-build"]