
# Stored Procedures Cheat Sheet

---

## 1. What is a Stored Procedure?
A stored procedure is a precompiled collection of SQL statements and optional control-of-flow statements, stored in a database, and executed as a single unit. They allow for reusable, efficient, and secure data manipulation.

### Benefits of Stored Procedures
- **Performance**: Reduced network traffic and optimized execution plans.
- **Reusability**: Reusable across applications.
- **Security**: Limit access to underlying data while enforcing business rules.

---

## 2. Basic Syntax for Creating a Stored Procedure

```sql
CREATE PROCEDURE ProcedureName
AS
BEGIN
    -- SQL statements
END;
```

- **Example**: Creating a procedure to retrieve all customers
  ```sql
  CREATE PROCEDURE GetAllCustomers
  AS
  BEGIN
      SELECT * FROM Customers;
  END;
  ```

---

## 3. Input Parameters

Parameters allow data to be passed into stored procedures.

### Syntax
```sql
CREATE PROCEDURE ProcedureName
    @ParameterName DataType
AS
BEGIN
    -- SQL statements using @ParameterName
END;
```

### Example
Creating a stored procedure with an input parameter:
```sql
CREATE PROCEDURE GetCustomerByID
    @CustomerID INT
AS
BEGIN
    SELECT * FROM Customers WHERE CustomerID = @CustomerID;
END;
```

---

## 4. Output Parameters

Stored procedures can also return data using output parameters.

### Syntax
```sql
CREATE PROCEDURE ProcedureName
    @OutputParameterName DataType OUTPUT
AS
BEGIN
    -- Set value for output parameter
    SET @OutputParameterName = SomeValue;
END;
```

### Example
Returning a customer’s name as an output parameter:
```sql
CREATE PROCEDURE GetCustomerName
    @CustomerID INT,
    @CustomerName NVARCHAR(50) OUTPUT
AS
BEGIN
    SELECT @CustomerName = Name FROM Customers WHERE CustomerID = @CustomerID;
END;
```

---

## 5. Executing a Stored Procedure

### Without Parameters
```sql
EXEC ProcedureName;
```

### With Parameters
```sql
EXEC ProcedureName @ParameterName = Value;
```

### With Output Parameters
```sql
DECLARE @OutputValue DataType;
EXEC ProcedureName @Parameter = Value, @OutputParameter = @OutputValue OUTPUT;
```

---

## 6. Controlling Flow with Logic Statements

Stored procedures can include control-of-flow statements such as `IF`, `WHILE`, `BEGIN...END`, etc.

### Example
Using `IF` logic in a stored procedure:
```sql
CREATE PROCEDURE UpdateCustomerStatus
    @CustomerID INT,
    @Status NVARCHAR(10)
AS
BEGIN
    IF @Status = 'Active'
        UPDATE Customers SET Status = 'Active' WHERE CustomerID = @CustomerID;
    ELSE
        UPDATE Customers SET Status = 'Inactive' WHERE CustomerID = @CustomerID;
END;
```

---

## 7. Error Handling in Stored Procedures

SQL Server provides `TRY...CATCH` blocks for handling errors.

### Example
Handling errors in a stored procedure:
```sql
CREATE PROCEDURE TransferFunds
    @FromAccountID INT,
    @ToAccountID INT,
    @Amount DECIMAL(10, 2)
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;
        UPDATE Accounts SET Balance = Balance - @Amount WHERE AccountID = @FromAccountID;
        UPDATE Accounts SET Balance = Balance + @Amount WHERE AccountID = @ToAccountID;
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        PRINT ERROR_MESSAGE();
    END CATCH
END;
```

---

## 8. Returning Results from Stored Procedures

### Using `RETURN`
Stored procedures can return an integer value using the `RETURN` statement.

```sql
CREATE PROCEDURE CheckStock
    @ProductID INT
AS
BEGIN
    DECLARE @StockCount INT;
    SELECT @StockCount = Stock FROM Products WHERE ProductID = @ProductID;
    RETURN @StockCount;
END;
```

### Using Result Sets
Procedures can also return entire result sets directly.

```sql
CREATE PROCEDURE GetOrdersByCustomer
    @CustomerID INT
AS
BEGIN
    SELECT * FROM Orders WHERE CustomerID = @CustomerID;
END;
```

---

## 9. Best Practices for Stored Procedures

1. **Use Naming Conventions**: Follow consistent naming conventions like `sp_` for stored procedures.
2. **Avoid Dynamic SQL**: Use parameters instead to avoid SQL injection risks.
3. **Optimize for Performance**: Use indexes and avoid unnecessary joins.
4. **Limit Result Sets**: Return only necessary columns and rows.
5. **Document Procedures**: Comment code for maintainability.

---

## Additional Resources

- **Microsoft Documentation**: [Stored Procedures (MS SQL Server)](https://docs.microsoft.com/en-us/sql/relational-databases/stored-procedures/stored-procedures-database-engine?view=sql-server-ver15)
- **Advanced Guide**: [Stored Procedures Tutorial](https://www.sqlshack.com/introduction-to-sql-server-stored-procedures/)
