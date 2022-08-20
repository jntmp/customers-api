FROM mcr.microsoft.com/mssql/server:2019-latest

ENV ACCEPT_EULA=Y
ENV SA_PASSWORD=SecretPHAssessPwd1!
ENV MSSQL_PID=Developer
ENV MSSQL_TCP_PORT=1433

WORKDIR /db

COPY customers.bak /var/opt/mssql/backup/customers.bak
COPY restore_db.sql .

RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" \
    && /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 \
    -U SA -P "SecretPHAssessPwd1!" \
    -i restore_db.sql

# RUN /opt/mssql-tools/bin/sqlcmd -S 127.0.0.1 \
#     -U SA -P "SecretPHAssessPwd1!" \
#     -i restore_db.sql
