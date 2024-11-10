**Constraints in SQL: A Cheatsheet**

**What are Constraints?**

Constraints are rules enforced on data columns to ensure data integrity. They prevent invalid data from being inserted, updated, or deleted in a database.

**Types of Constraints:**

1. **NOT NULL:**
   - Ensures a column cannot have a NULL value.
   - Syntax: `column_name NOT NULL`

2. **UNIQUE:**
   - Ensures unique values in a column or a combination of columns.
   - Syntax: `UNIQUE (column_name)` or `UNIQUE (column1_name, column2_name, ...)`

3. **PRIMARY KEY:**
   - A special type of UNIQUE constraint that uniquely identifies each row in a table.
   - A PRIMARY KEY column cannot have NULL values.
   - Syntax: `PRIMARY KEY (column_name)`

4. **FOREIGN KEY:**
   - References the PRIMARY KEY of another table.
   - Ensures referential integrity.
   - Syntax: `FOREIGN KEY (column_name) REFERENCES other_table(column_name)`

5. **CHECK:**
   - Enforces a specific condition on a column or a combination of columns.
   - Syntax: 
     ```sql
     CREATE TABLE table_name (
         column_name data_type CHECK (condition)
     );
     ```
   - Example:
     ```sql
     CREATE TABLE products (
         product_id INT PRIMARY KEY,
         product_name VARCHAR(50),
         price DECIMAL(10,2) CHECK (price >= 0)
     );
     ```

**Additional Notes:**

- Constraints can be defined during table creation or after table creation using `ALTER TABLE` statement.
- Constraints can be dropped using `ALTER TABLE DROP CONSTRAINT` statement.
- Proper use of constraints enhances data quality, consistency, and security.
- Carefully consider which constraints are appropriate for your specific database design.

**Example:**

```sql
CREATE TABLE customers (
    customer_id INT PRIMARY KEY,
    customer_name VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE,
    phone_number VARCHAR(20),
    city VARCHAR(50),
    country VARCHAR(50),
    FOREIGN KEY (country) REFERENCES countries(country_code)
);