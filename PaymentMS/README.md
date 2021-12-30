# NOTES ON DEBEZIUM'S MSSQL FEATURE

- The following code is in MSSSQL enable the CDC feature.
```
 USE Database_Name
 EXEC sys.sp_cdc_enable_db
```
- After
```
USE Database_Name
GO
EXEC sys.sp_cdc_enable_table 
@source_schema = N'schema_name', 
@source_name = N'table_name', 
@role_name = NULL, 
@filegroup_name = N'', 
@supports_net_changes = 0 
GO
```

## It's Important!!!  
- If you are going to use the CDC feature of MSSQL, your Sql Server version must be Enterprise, Developer, Enterprise Evaluation, or Standard.

- Debezium use Kafka Connector which connects to any database.
- Debezium has own rest api.
- For MsSQL, we create a json file like this below.
```
  {
   "name": "payment-connector",
   "config": {
    "connector.class" : "io.debezium.connector.sqlserver.SqlServerConnector",
    "tasks.max" : "1",
    "database.server.name" : "127.0.0.1",
    "database.hostname" : "sqlserver",
    "database.port" : "1433",
    "database.user" : "sa",
    "database.password" : "ttt12345678",
    "database.dbname" : "PaymentDb",
    "database.history.kafka.bootstrap.servers" : "kafka:9092",
    "database.history.kafka.topic": "dbo.Payments"
   }
  }
```
- Now, let's make a request to Debezium's API using the JSON file we created above.
<code>
curl -X POST -H “Content-Type: application/json” -d @sqlserver-register.json http://localhost:xxxx/connectors
</code>
