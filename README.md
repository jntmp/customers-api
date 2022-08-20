
=== DB ===
Under the `db` directory, run
```docker build -t jonathan/db-customers:initial .```
t0 build the docker iamge. Then
```docker run -d -p 1433:1433 --name db-customers jonathan/db-customers:initial```
to start it. This will make the database `Customers` accessible on localhost / 127.0.0.1 on port 1433 (Change this in the command if you have conflicting ports already bound)