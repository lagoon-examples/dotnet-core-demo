FROM testlagoon/dotnet-8-sdk:pr-550

COPY RazorPagesMovie /app
WORKDIR /app/
RUN dotnet build
EXPOSE 3000

CMD ["dotnet", "run","--no-build"]
