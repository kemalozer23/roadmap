# HTTP/HTTPS Protocol and TLS/SSL Cheat Sheet

## 1. HTTP and HTTPS Overview

- **What is HTTP?**  
  HTTP (Hypertext Transfer Protocol) is a protocol for transferring hypertext (HTML) files and resources between a web client and a server over the internet. HTTP operates on a request-response model and is stateless.

- **What is HTTPS?**  
  HTTPS (Hypertext Transfer Protocol Secure) is an extension of HTTP that adds a security layer using SSL/TLS to encrypt data during transmission. This prevents interception and tampering by third parties.

- **HTTP vs. HTTPS**  
  - HTTP is unencrypted, making it vulnerable to eavesdropping and man-in-the-middle attacks.
  - HTTPS encrypts data using TLS/SSL, ensuring confidentiality, integrity, and authenticity.

## 2. HTTP Methods

- **GET**  
  Retrieves data from a server. It should be idempotent and safe, meaning it does not alter server data.

- **POST**  
  Sends data to the server to create a resource. POST requests may modify server data.

- **PUT**  
  Updates an existing resource with new data or creates it if it doesn’t exist.

- **DELETE**  
  Deletes the specified resource from the server.

- **PATCH**  
  Partially updates a resource by sending only the modified data.

- **HEAD**  
  Similar to GET but only retrieves headers without the body, useful for checking resource metadata.

## 3. HTTP Status Codes

- **1xx (Informational)**  
  Request received, continuing process. Example: `100 Continue`.

- **2xx (Successful)**  
  The request was successfully received and processed. Examples:
  - `200 OK`: Standard response for a successful request.
  - `201 Created`: Resource created successfully.

- **3xx (Redirection)**  
  Further action is needed to complete the request. Examples:
  - `301 Moved Permanently`: Resource has a new URL.
  - `304 Not Modified`: Resource has not changed since last request.

- **4xx (Client Errors)**  
  Indicates a bad request from the client. Examples:
  - `400 Bad Request`: Invalid request syntax.
  - `401 Unauthorized`: Authentication is required.
  - `404 Not Found`: Resource not found.

- **5xx (Server Errors)**  
  Indicates a server-side error. Examples:
  - `500 Internal Server Error`: Server encountered an error.
  - `503 Service Unavailable`: Server is temporarily unavailable.

## 4. HTTP Headers

- **Request Headers**  
  - `Accept`: Specifies media types the client can process.
  - `Authorization`: Contains credentials for authentication.
  - `Content-Type`: Media type of the resource body.
  - `User-Agent`: Identifies the client software.

- **Response Headers**  
  - `Content-Type`: Media type of the response body.
  - `Set-Cookie`: Sets a cookie in the client.
  - `Cache-Control`: Directives for caching mechanisms.

## 5. Caching in HTTP

- **Cache-Control**  
  Directs caching behavior with options like `no-cache`, `no-store`, `public`, and `private`.

- **ETag**  
  A unique identifier for a resource version. Helps determine if a cached version is valid.

- **Expires**  
  Sets an expiration date for cached resources.

## 6. HTTPS and SSL/TLS

- **What is SSL/TLS?**  
  SSL (Secure Sockets Layer) and TLS (Transport Layer Security) are cryptographic protocols that secure communications over a network. TLS is the successor to SSL, providing stronger encryption and security features.

- **SSL vs. TLS**  
  - SSL is the older protocol and is now deprecated.
  - TLS is an improved, secure version with better encryption standards and is used by modern HTTPS connections.

## 7. How HTTPS Works (Handshake Process)

1. **Client Hello**: The client initiates a connection and sends supported cryptographic protocols and cipher suites.
2. **Server Hello**: The server selects a protocol, cipher suite, and sends its digital certificate.
3. **Certificate Verification**: The client verifies the server’s certificate using a trusted CA (Certificate Authority).
4. **Key Exchange**: A session key is generated, which is used to encrypt data for the session.
5. **Secure Connection Established**: Both client and server can now securely exchange encrypted data.

## 8. TLS/SSL Certificates

- **What is an SSL Certificate?**  
  An SSL certificate authenticates the identity of a website and enables encrypted communication.

- **Types of SSL Certificates**  
  - **DV (Domain Validation)**: Confirms ownership of the domain.
  - **OV (Organization Validation)**: Confirms organization identity and domain ownership.
  - **EV (Extended Validation)**: Requires a detailed vetting process, showing a green bar or organization name in the browser.

- **Self-Signed Certificates vs. CA-Signed Certificates**  
  - **Self-Signed**: Created by an individual, not trusted by browsers.
  - **CA-Signed**: Issued by a Certificate Authority, trusted by browsers.

## 9. HTTP/2 and HTTP/3

- **HTTP/2**  
  - Multiplexing: Allows multiple requests over a single TCP connection.
  - Header Compression: Reduces size of headers.
  - Server Push: Sends resources proactively.

- **HTTP/3**  
  Uses QUIC (a transport layer protocol) for faster, more reliable connections by reducing latency.