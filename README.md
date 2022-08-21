
=== Getting Started ===

Only docker will be required to run this setup. We will setup the following:
1. A docker network
2. DB container
3. Api container

First create the docker network:
```docker network create customers-net```

=== DB ===
Under the `db` directory, build the docker iamge:
```docker build -t jonathan/db-customers:initial .```
Then run it:
```docker run -d -p 1433:1433 --name db-customers --network customers-net jonathan/db-customers:initial```
This will make the database `Customers` accessible on localhost / 127.0.0.1 on port 1433 (Change this in the command if you have conflicting ports already bound), for eg. `1433:1434`

This DB instance can be reached at localhost:1433 through a SQL client/browser

=== APP ===
Under the `api` directory, build the docker iamge:
```docker build -t jonathan/app-customers:initial .```
Then run it:
```docker run -d -p 8081:80 --name app-customers --network customers-net jonathan/app-customers:initial```

The API swagger can be reached at http://localhost:8081/swagger