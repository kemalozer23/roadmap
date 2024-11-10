
# Database Design and SQL Syntax Cheat Sheet

---

## 1. Database Design Fundamentals

### 1.1 Key Concepts
- **Database**: Structured set of data, managed by a Database Management System (DBMS).
- **Table**: Collection of related data organized in rows and columns.
- **Row/Record**: Single entry in a table.
- **Column/Field**: Attribute of the data, like `Name` or `Date`.
- **Schema**: Blueprint of the database structure.

### 1.2 Normalization
Normalization reduces redundancy and improves data integrity.

1. **1NF (First Normal Form)**: Each column contains atomic values; no repeating groups.
2. **2NF (Second Normal Form)**: Satisfies 1NF and every non-key attribute is fully functionally dependent on the primary key.
3. **3NF (Third Normal Form)**: Satisfies 2NF and no transitive dependency on the primary key.

### 1.3 Keys in Database Design
- **Primary Key**: Uniquely identifies a record in a table.
- **Foreign Key**: References a primary key in another table, establishing relationships.
- **Unique Key**: Ensures all values in a column are unique.
- **Composite Key**: Primary key made up of more than one field.

### 1.4 Relationships
- **One-to-One**: Each record in Table A has one corresponding record in Table B.
- **One-to-Many**: Each record in Table A can have multiple related records in Table B.
- **Many-to-Many**: Records in Table A and Table B can relate to multiple records in each other.

---

## 2. SQL Syntax Basics

### 2.1 Common Data Types
- **Integer Types**: `INT`, `BIGINT`, `SMALLINT`, `TINYINT`
- **Decimal Types**: `FLOAT`, `DOUBLE`, `DECIMAL`
- **Text Types**: `VARCHAR`, `CHAR`, `TEXT`
- **Date/Time Types**: `DATE`, `TIME`, `DATETIME`, `TIMESTAMP`

### 2.2 Creating and Modifying Tables

- **Create Table**
  ```sql
  CREATE TABLE Customers (
      CustomerID INT PRIMARY KEY,
      Name VARCHAR(50) NOT NULL,
      Email VARCHAR(100) UNIQUE
  );
  ```

- **Modify Table**
  ```sql
  ALTER TABLE Customers
  ADD PhoneNumber VARCHAR(15);
  ```

- **Delete Table**
  ```sql
  DROP TABLE Customers;
  ```

---

## 3. Basic SQL Operations

### 3.1 Inserting Data

- **Insert Single Row**
  ```sql
  INSERT INTO Customers (CustomerID, Name, Email)
  VALUES (1, 'John Doe', 'john@example.com');
  ```

- **Insert Multiple Rows**
  ```sql
  INSERT INTO Customers (CustomerID, Name, Email)
  VALUES 
      (2, 'Jane Doe', 'jane@example.com'),
      (3, 'Jim Brown', 'jim@example.com');
  ```

### 3.2 Selecting Data

- **Select All Columns**
  ```sql
  SELECT * FROM Customers;
  ```

- **Select Specific Columns**
  ```sql
  SELECT Name, Email FROM Customers;
  ```

- **Using WHERE Clause**
  ```sql
  SELECT * FROM Customers WHERE CustomerID = 1;
  ```

### 3.3 Updating Data
- **Update Statement**
  ```sql
  UPDATE Customers
  SET Email = 'newemail@example.com'
  WHERE CustomerID = 1;
  ```

### 3.4 Deleting Data
- **Delete Statement**
  ```sql
  DELETE FROM Customers WHERE CustomerID = 1;
  ```

---

## 4. Advanced SQL Concepts

### 4.1 Joins
- **Inner Join**: Returns records with matching values in both tables.
  ```sql
  SELECT Orders.OrderID, Customers.Name
  FROM Orders
  INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;
  ```

- **Left Join**: Returns all records from the left table, and matched records from the right table.
  ```sql
  SELECT Customers.Name, Orders.OrderID
  FROM Customers
  LEFT JOIN Orders ON Customers.CustomerID = Orders.CustomerID;
  ```

- **Right Join**: Returns all records from the right table, and matched records from the left table.
  ```sql
  SELECT Customers.Name, Orders.OrderID
  FROM Customers
  RIGHT JOIN Orders ON Customers.CustomerID = Orders.CustomerID;
  ```

- **Full Join**: Returns records when there is a match in either left or right table.
  ```sql
  SELECT Customers.Name, Orders.OrderID
  FROM Customers
  FULL OUTER JOIN Orders ON Customers.CustomerID = Orders.CustomerID;
  ```

### 4.2 Grouping and Aggregations
- **GROUP BY**: Groups rows that have the same values.
  ```sql
  SELECT COUNT(*), Country
  FROM Customers
  GROUP BY Country;
  ```

- **HAVING**: Filters groups by condition, similar to WHERE but after aggregation.
  ```sql
  SELECT Country, COUNT(*)
  FROM Customers
  GROUP BY Country
  HAVING COUNT(*) > 5;
  ```

### 4.3 Indexes
Indexes improve the speed of data retrieval but can slow down write operations.

- **Create Index**
  ```sql
  CREATE INDEX idx_customer_name ON Customers (Name);
  ```

- **Drop Index**
  ```sql
  DROP INDEX idx_customer_name;
  ```

---

## 5. Transactions
Transactions ensure a series of operations are completed successfully or rolled back.

```sql
BEGIN TRANSACTION;

UPDATE Accounts SET Balance = Balance - 100 WHERE AccountID = 1;
UPDATE Accounts SET Balance = Balance + 100 WHERE AccountID = 2;

COMMIT; -- Or ROLLBACK if something fails
```

---

## 6. SQL Constraints

- **NOT NULL**: Ensures column cannot have a NULL value.
- **UNIQUE**: Ensures all values in a column are unique.
- **PRIMARY KEY**: Uniquely identifies each row.
- **FOREIGN KEY**: Enforces a link between columns in two tables.
- **CHECK**: Ensures all values in a column satisfy a condition.
- **DEFAULT**: Sets a default value for a column if no value is specified.

---

## 7. Best Practices in Database Design
1. **Use Meaningful Names**: Use descriptive names for tables and columns.
2. **Normalize Tables**: To reduce redundancy, use normalization but don’t over-normalize.
3. **Indexing**: Apply indexes on columns used frequently in WHERE or JOIN clauses.
4. **Use Foreign Keys**: Enforce relationships and data integrity.
5. **Avoid NULLs**: Use default values and avoid allowing NULL unless necessary.

---

## Additional Resources

- **SQL Documentation**: [SQL Tutorial](https://www.w3schools.com/sql/)
- **Database Normalization**: [Normalization Forms](https://en.wikipedia.org/wiki/Database_normalization)
- **Advanced SQL Guide**: [Advanced SQL Tutorial](https://www.sqltutorial.org/sql-advanced/)
