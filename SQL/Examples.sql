/*
You work at a book store. It's the end of the month, and you need to find out the 5 bestselling books at your store. 
Use a select statement to list names, authors, and number of copies sold of the 5 books which were sold most.

books table schema

name
author
copies_sold
NOTE: Your solution should use pure SQL. Ruby is used within the test cases just to validate your answer.
*/
SELECT name, author, copies_sold FROM books
ORDER BY copies_sold DESC
LIMIT 5;



/*
For this challenge you need to create a SELECT statement that will contain data about departments that had a sale with a price over 98.00 dollars. 
This SELECT statement will have to use an EXISTS to achieve the task.

departments table schema
id
name

sales table schema
id
department_id (department foreign key)
name
price
card_name
card_number
transaction_date

resultant table schema
id
name
*/

SELECT id, name 
FROM departments 
WHERE EXISTS( 
  SELECT id 
  FROM sales
  WHERE price > 98.00 and departments.id = sales.department_id );
  


/*
Instructions:

You are the owner of the Grocery Store. All your products are in the database, that you have created after CodeWars SQL excercises!:)

You care about local market, and want to check how many products come from United States of America or Canada.

Please use SELECT statement and IN to filter out other origins.

In the results show how many products are from United States of America and Canada respectively.

Order by number of products, descending.

products table schema
id
name
price
stock
producer
country
results table schema
products
country 
*/


CREATE TABLE results AS
  SELECT COUNT(id) as products, country from products
  WHERE country IN ('United States of America', 'Canada')
  GROUP BY country
  ORDER BY products DESC;
SELECT * FROM results;




/* 
Given a table of random numbers as follows:

** numbers table schema **

id
number1
number2
Your job is to return table with similar structure and headings, where if the sum of a column is odd, 
the column shows the minimum value for that column, and when the sum is even, it shows the max value. You must use a case statement.

** output table schema **

number1
number2
*/

SELECT
  CASE 
    WHEN SUM(number1) % 2 = 0 THEN MAX(number1)
    ELSE MIN(number1)
  END AS number1,
  CASE
    WHEN SUM(number2) % 2 = 0 THEN MAX(number2)
    ELSE MIN(number2)
  END AS number2
  FROM numbers;
