--Homework 3 - Day 3

-- Query 1 - List all cities that have both Employees and Customers.

-- practiced using sub-query

SELECT DISTINCT City              --> used distinct to get all different cities
FROM Employees
WHERE CITY IN (
	SELECT City
	FROM Customers
)

-- using join

SELECT DISTINCT e.City
FROM Employees e JOIN Customers c ON e.City = c.City
ORDER BY e.City


-- Query 2 -  List all cities that have Customers but no Employee.

-- Using sub-query

SELECT DISTINCT City             
FROM Customers
WHERE CITY NOT IN (
	SELECT City
	FROM Employees
)
ORDER BY City

-- Not using sub-query

SELECT DISTINCT c.City
FROM Customers c LEFT JOIN Employees e ON c.city=e.city
WHERE e.City IS NULL
ORDER BY c.City


-- Query 3 - List all products and their total order quantities throughout all orders.

SELECT p.ProductName, SUM(od.Quantity) AS TotalOrderQuantity
FROM Products p JOIN [Order Details] od ON p.ProductID=od.ProductID
GROUP BY p.ProductName


-- Query 4 - List all Customer Cities and total products ordered by that city.

SELECT c.City, SUM(od.Quantity) AS TotalProducts
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID JOIN [Order Details] od ON o.OrderID=od.OrderID
GROUP BY c.City


-- Query 5 - List all Customer Cities that have at least two customers.

-- Using sub-query

SELECT DISTINCT City
FROM Customers
WHERE City IN (
	SELECT City
	FROM Customers
	GROUP BY City
	HAVING COUNT(CustomerID)>=2
)

-- Not using sub-query

SELECT c.City
FROM Customers c
GROUP BY c.City
HAVING COUNT(CustomerID)>=2
ORDER BY c.City


-- Query 6 - List all Customer Cities that have ordered at least two different kinds of products.

SELECT c.City
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID JOIN [Order Details] od ON o.OrderID=od.OrderID
GROUP BY c.City
HAVING COUNT(DISTINCT od.ProductID) >= 2                     --> Distinct keyword is not necessary as Product ID is a primary key of Order Details table
ORDER BY c.City


-- Query 7 - List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT DISTINCT c.CustomerID, c.CompanyName, c.City AS CustomerCity, o.ShipCity
FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
WHERE c.City <> o.ShipCity
ORDER BY c.CustomerID


-- Query 8 - List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

SELECT TOP 5 p.ProductName, c.City, SUM(od.Quantity) as TotalQuantityOrdered, AVG(p.UnitPrice) AS [Average Price]
FROM Products p JOIN [Order Details] od ON p.ProductID=od.ProductID JOIN Orders o ON od.OrderID=o.OrderID JOIN Customers c ON o.CustomerID=c.CustomerID
GROUP BY p.ProductName, c.City
ORDER BY SUM(od.Quantity) DESC


-- Query 9 - List all cities that have never ordered something but we have employees there.

-- Using sub-query

SELECT e.City
FROM Employees e
WHERE e.City NOT IN (
    SELECT c.City
    FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID
)
ORDER BY e.City


-- Not using sub-query

SELECT e.City
FROM Employees e LEFT JOIN Customers c ON e.City=c.City LEFT JOIN Orders o ON c.CustomerID=o.CustomerID
WHERE o.OrderID IS NULL
ORDER BY e.City


-- Query 10 - List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)

-- we can use derived table for simplicity

SELECT TOP 1 dt.City
FROM(
	 SELECT e.City, COUNT(o.OrderID) AS TotalOrders
     FROM Employees e JOIN Orders o ON e.EmployeeID = o.EmployeeID
     GROUP BY e.City) AS dt
JOIN(
	 SELECT c.City, SUM(od.Quantity) AS TotalQuantityOrdered
     FROM Customers c JOIN Orders o ON c.CustomerID = o.CustomerID JOIN [Order Details] od ON o.OrderID = od.OrderID
     GROUP BY c.City) AS ccity ON dt.City=ccity.City
ORDER BY dt.TotalOrders DESC, ccity.TotalQuantityOrdered DESC          --> to ensure it selects city from where the employee sold most orders & city of most total quantity of products ordered from


-- Query 11 - How do you remove the duplicates record of a table?

-- 1] We can make use of primary key or unique constraint to prevent duplicates from being inserted.
-- 2] Now, if the duplicate record already exist in the table then we can make use of ROW_NUMBER rank function to assign a unique row number to each row within partitions of duplicate records, then delete rows where the row number is greater than one.
-- 3] We can also just use temporary table, where we will select distinct records and into temp table then truncate the original table, and then reinsert the distinct records from the temporary table 

-- example query with 2nd way

-- We will assign row numbers to duplicates
WITH CTE AS (
    SELECT ProductID, ProductName, CategoryID, ROW_NUMBER() OVER (PARTITION BY ProductName, CategoryID ORDER BY ProductID) AS RowNum  -->Always include all the columns(inside ROW_NUMBER to partition by) which can differ and make the record unique
    FROM Products
)

-- This will delete duplicates from Product table
DELETE FROM Products
WHERE ProductID IN (SELECT ProductID
					FROM CTE
					WHERE RowNum > 1)

-- This doesn't delete any record in this case as all the rows are unique in Products table 