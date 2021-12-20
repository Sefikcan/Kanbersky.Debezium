# Debezium Notes

# What is Kafka ?
- Apache Kafka is an open source, publisher-subscriber-based distributed messaging system focused on delivering big data flow with low latency.
- Below are the most important kafka terms to know:
- Producer: Its role is publisher. Its send messages to the subscribers who listen to it.
- Consumer: Consumers listens to messages from producers.
- Topic: It is the structure that Where the data store in Kafka.
- Broker: Broker is the servers that host the topics. Groups containing more than one broker are called Kafka Clusters. Among the brokers, one is determined to be the leader and the others to be the follower. Follower brokers keep a copy of the data on the leader. If leader broker is down or anything, other follower replaces it.

# What is Kafka Connect ?
- It is the structure that allows Apache Kafka to connect to databases, systems such as Consul or structures such as Elasticsearch.
- Kafka has two connector: Sink Connector and Source Connector.
- Source Connector:  It collect all database change  and send Kafka Topic. Also, if we want collect our application metric, Kafka Connect allows with very low latency collect application metrics.
 
- Sink Connector: It transfers data on Apache kafka, systems such as Elasticsearch, hadoop.


# What is Debezium ?
- It is a structure that reads the database's logs and transmits the changes in the database to Kafka through the structure called Kafka Connector.
- if realtime data change is important to you, you use debezium is good choice. For example, we develop e-commerce app and We want, when any product price is change in ERP platform, we want instantly to reflect in platform. In such cases, you can use Debezium.

# What is CDC ?
- CDC stands for Change Data Capture. 
- It's the process of monitoring the initial and final state of the changed data after operations such as Insert, Update or Delete in the   database by the database that provides CDC support and recording the changes. Of course, we use trigger in this state. But, CDC is better than trigger. The reason is it serves all these operations by reading the log file of the database.
- In addition to the ability to follow the entire table in the database, it also allows you to follow the changes made in certain columns in the table.




