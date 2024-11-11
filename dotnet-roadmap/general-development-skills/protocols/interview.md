# Backend Developer Interview Questions and Answers

## Junior Developer

1. **What is the difference between `POST` and `PUT` in HTTP?**  
   - `POST` is used to create new resources on the server and can result in multiple new resources if the same request is made repeatedly. The response usually includes a `Location` header with the URI of the newly created resource.
   - `PUT` is idempotent, meaning it creates a resource if it doesn’t exist or updates it if it does. A `PUT` request to the same URL should yield the same result each time.

2. **Explain REST and its principles.**  
   REST (Representational State Transfer) is an architectural style for designing APIs. Its principles include:
   - **Statelessness**: Each request from a client contains all information the server needs to fulfill it.
   - **Client-Server Separation**: The client and server operate independently.
   - **Cacheability**: Responses can be cached to improve performance.
   - **Uniform Interface**: The structure of requests and responses should be consistent.

3. **What is JSON, and why is it commonly used in APIs?**  
   JSON (JavaScript Object Notation) is a lightweight data format for structuring data. It's commonly used in APIs due to its simplicity, readability, and compatibility with most programming languages.

4. **How does a web server handle client requests?**  
   A web server listens for requests on a specific port (often 80 for HTTP, 443 for HTTPS), parses the request, forwards it to the application logic, and then sends back an appropriate response.

5. **What are status codes, and why are they important?**  
   HTTP status codes inform clients about the result of their request. They help clients understand if a request was successful, if further action is required, or if an error occurred (e.g., `200 OK`, `404 Not Found`, `500 Internal Server Error`).

6. **What is a database transaction, and why are transactions important?**  
   A transaction is a sequence of operations performed as a single, atomic unit. Transactions ensure data integrity by following the ACID properties (Atomicity, Consistency, Isolation, Durability).

7. **Explain the difference between SQL and NoSQL databases.**  
   - **SQL** databases are relational, structured with tables and use SQL for querying.
   - **NoSQL** databases are non-relational, store unstructured or semi-structured data, and often provide more flexibility in data storage.

8. **What is an API, and why do we use it?**  
   An API (Application Programming Interface) allows applications to communicate and share data with each other. APIs enable modularity, separation of concerns, and easy integration with other systems.

9. **Explain the concept of “idempotency” in APIs.**  
   An idempotent operation produces the same result regardless of how many times it is executed. `GET`, `PUT`, and `DELETE` are typically idempotent, while `POST` is not.

10. **What are environment variables, and why are they used?**  
    Environment variables store configuration values outside the source code, allowing flexibility and security. They often store sensitive data like database credentials or API keys.

---

## Mid-Level Developer

1. **What is middleware in web development?**  
   Middleware is code that processes requests and responses between a server and an application. It can handle tasks like authentication, logging, and request parsing.

2. **Explain the purpose and use of caching in a backend system.**  
   Caching stores frequently accessed data temporarily to reduce response times and alleviate load on servers. Common caching tools include Redis and Memcached.

3. **What is the difference between SQL `JOIN` types?**  
   - **INNER JOIN**: Returns records with matching values in both tables.
   - **LEFT JOIN**: Returns all records from the left table and matched records from the right table; nulls if no match.
   - **RIGHT JOIN**: Returns all records from the right table and matched records from the left table.
   - **FULL JOIN**: Returns all records with matches in either table, with nulls where no match exists.

4. **Explain rate limiting and why it is used in APIs.**  
   Rate limiting controls the number of requests a client can make within a time period to prevent abuse and maintain server stability.

5. **How does database indexing work, and what are its pros and cons?**  
   Indexing improves query speed by creating a data structure that references table rows. Pros: Faster read operations; Cons: Slower write operations and increased storage space.

6. **What is data normalization, and why is it important?**  
   Data normalization organizes data to reduce redundancy and improve integrity. It minimizes data anomalies and optimizes the database structure.

7. **How would you design an endpoint to handle large file uploads?**  
   Consider chunking the upload, using multipart uploads, and setting appropriate file size limits. An endpoint should validate file types and use asynchronous processing if necessary.

8. **What are the differences between authentication and authorization?**  
   - **Authentication** verifies the user’s identity (e.g., login credentials).
   - **Authorization** grants or denies access to resources based on roles or permissions.

9. **Explain the purpose of database migrations in a project.**  
   Migrations manage schema changes in a database, enabling updates to database structure across different environments without data loss.

10. **What is horizontal vs. vertical scaling?**  
    - **Horizontal scaling** adds more servers to distribute load.
    - **Vertical scaling** increases resources (CPU, RAM) on a single server.

---

## Senior Developer

1. **What is the CAP theorem, and how does it relate to distributed systems?**  
   The CAP theorem states that in a distributed system, you can only achieve two of three properties: Consistency, Availability, and Partition Tolerance. Trade-offs depend on system requirements.

2. **Describe how you would approach designing a scalable REST API.**  
   Start by defining clear, consistent endpoints, use pagination, caching, and rate limiting, consider microservices architecture, and implement database optimizations.

3. **How do you ensure data consistency in a distributed system?**  
   Techniques like eventual consistency, distributed transactions, and using consensus algorithms (e.g., Raft, Paxos) help maintain data consistency.

4. **What are webhooks, and how do they differ from polling?**  
   - **Webhooks** are automated messages sent from one server to another based on an event, making them real-time and efficient.
   - **Polling** requires repeatedly checking for changes, increasing load and response time.

5. **Explain the use of a message broker in a microservices architecture.**  
   Message brokers (e.g., RabbitMQ, Kafka) enable asynchronous communication between microservices, helping to decouple services and improve scalability and fault tolerance.

6. **What are the pros and cons of using a monolithic vs. microservices architecture?**  
   - **Monolithic**: Easier to develop and deploy, but harder to scale and maintain.
   - **Microservices**: Scalable and modular, but complex to deploy, monitor, and manage.

7. **How do you handle distributed transactions across multiple microservices?**  
   Use techniques like the Saga pattern, which breaks transactions into smaller steps managed across services, or use two-phase commit protocols where consistency is a priority.

8. **What is a reverse proxy, and how is it useful in backend architecture?**  
   A reverse proxy (e.g., NGINX) sits between clients and servers, handling tasks like load balancing, SSL termination, and request routing for improved performance and security.

9. **How does OAuth 2.0 work, and when would you use it?**  
   OAuth 2.0 is an authorization protocol allowing third-party applications limited access to user resources without exposing credentials. Commonly used in web and mobile applications for secure user login.

10. **What are some common techniques for optimizing database queries in high-traffic applications?**  
    Use indexing, query optimization, caching, denormalization, partitioning, and connection pooling to improve database performance and handle high-traffic loads.