FROM uselagoon/php-8.1-cli:latest

ENV LAGOON=dotnet

RUN apk add libgdiplus --repository https://dl-3.alpinelinux.org/alpine/edge/testing/
RUN apk add bash icu-libs krb5-libs libgcc libintl libssl1.1 libstdc++ zlib

COPY lagoon/dotnet-install.sh /tmp

RUN chmod +x /tmp/dotnet-install.sh && /tmp/dotnet-install.sh

WORKDIR /app
COPY RazorPagesMovie /app

EXPOSE 3000

CMD ["sleep", "500000"]