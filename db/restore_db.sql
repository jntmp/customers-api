RESTORE DATABASE Customers FROM DISK = '/var/opt/mssql/backup/customers.bak' WITH MOVE 'Customers' TO '/var/opt/mssql/data/Customers.mdf', MOVE 'Customers_log' TO '/var/opt/mssql/data/Customers_log.ldf'