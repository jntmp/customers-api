
### Getting Started
I chose to use `dotnet core 3.1` and `MSSQL 2019` for this.

Only docker will be required to run this setup, using
1. A docker network
2. DB container
3. Api container

First create the docker network:
```shell
docker network create customers-net
```

#### Database
In the root, under the `db` directory, build the docker iamge:
```shell
docker build -t jonathan/db-customers:initial .
```
Then run it:
```shell
docker run -d -p 1433:1433 --name db-customers --network customers-net jonathan/db-customers:initial
```
> This will make the database `Customers` accessible on localhost / 127.0.0.1 on port 1433 (Change this in the command if you have conflicting ports already bound), for eg. `1433:1434`

This DB instance can be reached at localhost:1433 through a SQL client/browser

#### Api
In the root, under the `api` directory, build the docker iamge:
```shell
docker build -t jonathan/app-customers:initial .
```
Then run it:
```shell
docker run -d -p 8081:80 --name app-customers --network customers-net jonathan/app-customers:initial
```

The API swagger can be reached at http://localhost:8081/swagger

### Requirements

#### Progress
Unfortunately I was only able to complete a few of the requested features, including chosen architectural approaches, due to time constraints:
- Customer database
- Ease of access, contained dependencies
- API structural design, multi-layered areas of concern
- Endpoints and swagger UI
- Customers query with supported filtering (all, or only by statusid)

##### Some devops/language factors took longer than expected
- Docker environment
- DB initialization in container
- Container network commnunications
- Status enum representative name serialization
- Dynamic query filtering, considering supported strongly typed field names and not exposing security risks

I don\'t work with these everyday, so it was great to refresh my memory!

### "Future backlog"
#### Missed requirements
If I had more time, I would continue with the following:
- Finalize REST endpoints, for eg.
  - Custommer details
  - Customer notes (CRUD)
- Customers query sorting
  - I would continue in a similar path as the strict supported filters
- Optimistic locking, there are multiple possible approaches, depending on the use case:
  - Validating ETag headers. Ideal for a busy front-end calling this API
  - Transactional database commits. Ideal for highly concurrent database (updates)
  - Or if stale data could be held for longer, perhaps a more manual approach to validate database computed checksums, before updating.

#### Professional enhancements
To a ensure we have a maintainable product, which is also easy to support and scale, I would highly recommend the following:
- Secure access. An HTTPS upgrade and authenticated access methods
  - Oauth2 credentials/JWT tokens
  - or even mutual 2way SSL (again depending on the target audience)
- Migrate to a cloud for
  - Continuous deploy pipeline
  - Kubernetes cluster for easy scale
  - An API gateway to isolate the concerns of spike arrests, circuit breakers, authentication and more
- Logging middleware for transparency and easier support, distributed to splunk/kibana/cloud
- Unit tests

#### Total time spent
- 1 hour -> analysis
- 1.5 hour -> db environment setup / design
- 2 hour -> api app design
- 4 hours -> features/patterns
- 2 hours -> finalizing preparations and readme doc
