# SQL Triggers Cheat Sheet

## What is a Trigger?
- **Trigger**: A set of SQL statements automatically executed or fired when certain events occur on a table in a database.

## Basic Syntax
```sql
CREATE TRIGGER trigger_name
{ BEFORE | AFTER | INSTEAD OF } 
{ INSERT | UPDATE | DELETE }
ON table_name
FOR EACH ROW
BEGIN
    -- SQL statements
END;