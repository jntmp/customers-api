@ECHO OFF
echo pulling sql docker image...
docker pull mcr.microsoft.com/mssql/server:2019-latest

echo run sql docker image...
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=SecretPHAssessPwd1!" -p 1433:1433 --name db-customers --hostname db-customers -d mcr.microsoft.com/mssql/server:2019-latest

echo attaching database...
docker exec -it db-customers mkdir /var/opt/mssql/backup
docker cp customers.bak db-customers:/var/opt/mssql/backup
docker exec -it db-customers /opt/mssql-tools/bin/sqlcmd -S localhost -U SA -P "SecretPHAssessPwd1!" -Q "RESTORE DATABASE Customers FROM DISK = '/var/opt/mssql/backup/customers.bak' WITH MOVE 'Customers' TO '/var/opt/mssql/data/Customers.mdf', MOVE 'Customers_log' TO '/var/opt/mssql/data/Customers_log.ldf'"