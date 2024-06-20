--Homework 2 - Day 2

-- Query 1 - How many products can you find in the Production.Product table?

SELECT COUNT(*) AS TotalNumofProducts
FROM Production.Product


-- Query 2 -  Write a query that retrieves the number of products in the Production.Product table that are included in a subcategory. The rows that have NULL in column ProductSubcategoryID are considered to not be a part of any subcategory.

SELECT COUNT(ProductSubcategoryID) AS NumberOfProductsInSubcategory
FROM Production.Product


-- Query 3 - How many Products reside in each SubCategory? Write a query to display the results with the following titles.

--ProductSubcategoryID CountedProducts

  -------------------- ---------------

SELECT ProductSubcategoryID, COUNT(ProductID) AS CountedProducts  
FROM Production.Product
GROUP BY ProductSubcategoryID                                 --> Since, there is no null checks needed, it list the coutn of products where subcatID is NULL


-- Query 4 - How many products that do not have a product subcategory.

SELECT COUNT(ProductID) AS NumberOfProductsInSubcategory
FROM Production.Product
WHERE ProductSubcategoryID IS NULL 


-- Query 5 - Write a query to list the sum of products quantity in the Production.ProductInventory table.

SELECT SUM(Quantity) AS SumProdQuantity
FROM Production.ProductInventory


-- Query 6 - Write a query to list the sum of products in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100.

--ProductID		TheSum

  -----------   ----------

SELECT ProductID, SUM(Quantity) AS TheSum 
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY ProductID  
HAVING SUM(Quantity)<100 


-- Query 7 - Write a query to list the sum of products with the shelf information in the Production.ProductInventory table and LocationID set to 40 and limit the result to include just summarized quantities less than 100

--  Shelf        ProductID      TheSum

    ----------   -----------    -----------

SELECT Shelf, ProductID, SUM(Quantity) AS TheSum 
FROM Production.ProductInventory
WHERE LocationID = 40
GROUP BY Shelf, ProductID 
HAVING SUM(Quantity)<100 


-- Query 8 - Write the query to list the average quantity for products where column LocationID has the value of 10 from the table Production.ProductInventory table.

SELECT AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE LocationID = 10


-- Query 9 - Write query to see the average quantity of products by shelf  from the table Production.ProductInventory

--  ProductID   Shelf      TheAvg

    ----------- ---------- -----------

SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
GROUP BY ProductID, Shelf 


-- Query 10 - Write query  to see the average quantity  of  products by shelf excluding rows that has the value of N/A in the column Shelf from the table Production.ProductInventory

--  ProductID   Shelf      TheAvg

    ----------- ---------- -----------

SELECT ProductID, Shelf, AVG(Quantity) AS TheAvg
FROM Production.ProductInventory
WHERE Shelf <> 'N/A'
GROUP BY ProductID, Shelf 


-- Query 11 - List the members (rows) and average list price in the Production.Product table. This should be grouped independently over the Color and the Class column. Exclude the rows where Color or Class are null.

--  Color           Class     TheCount       AvgPrice

    --------------  -----     ----------    ---------------------

SELECT Color, Class, COUNT(ProductID) AS TheCount, AVG(ListPrice) AS AvgPrice
FROM Production.Product
WHERE Color IS NOT NULL AND Class IS NOT NULL
GROUP BY Color, Class                                            --> we can also Order by color, class for better readability



-- JOINS


-- Query 12 - Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables. Join them and produce a result set similar to the following.

--  Country         Province

    ---------       ----------------------

SELECT pc.[Name] Country, ps.[Name] Province																--> Using [Name] to avoid Name becoming keyword because of its type Name
FROM Person.CountryRegion pc JOIN Person.StateProvince ps ON pc.CountryRegionCode = ps.CountryRegionCode    --> if we want NULL values where match doesn't exist used FULL JOIN


-- Query 13 - Write a query that lists the country and province names from person.CountryRegion and person.StateProvince tables and list the countries filter them by Germany and Canada. Join them and produce a result set similar to the following.

--  Country         Province

    ---------       ----------------------

SELECT pc.[Name] Country, ps.[Name] Province
FROM Person.CountryRegion pc JOIN Person.StateProvince ps ON pc.CountryRegionCode = ps.CountryRegionCode
WHERE pc.[Name] IN ('Germany', 'Canada')



-- Now, we have to use Northwind Database: (Use aliases for all the Joins)


USE NorthWind
Go


-- Query 14 - List all Products that has been sold at least once in last 27 years.

SELECT DISTINCT p.ProductName
FROM Products p JOIN [Order Details] od ON p.ProductID=od.ProductID JOIN Orders o ON od.OrderID=o.OrderID
WHERE o.OrderDate >= '1997-06-19'                  --> took date from current date which is 27 years apart
ORDER BY p.ProductName						       --> better readability

-- Query 15 - List top 5 locations (Zip Code) where the products sold most.

SELECT TOP 5 c.PostalCode AS [Zip Code], COUNT(od.OrderID) AS ProductsSold
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID JOIN [Order Details] od ON o.OrderID=od.OrderID
WHERE c.PostalCode IS NOT NULL                                                 --> added null check to ensure the locations zipcode is not null
GROUP BY c.PostalCode
ORDER BY ProductsSold DESC

-- Query 16 - List top 5 locations (Zip Code) where the products sold most in last 27 years.

SELECT TOP 5 c.PostalCode AS [Zip Code], COUNT(od.OrderID) AS ProductsSold
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID JOIN [Order Details] od ON o.OrderID=od.OrderID
WHERE o.OrderDate >= '1997-06-19' AND c.PostalCode IS NOT NULL                                                 
GROUP BY c.PostalCode
ORDER BY ProductsSold DESC


-- Query 17 - List all city names and number of customers in that city.     

SELECT City, COUNT(CustomerID) AS NumOfCustomers
FROM Customers
GROUP BY City
ORDER BY NumOfCustomers DESC                           --> for better readability


-- Query 18 - List city names which have more than 2 customers, and number of customers in that city

SELECT City, COUNT(CustomerID) AS NumOfCustomers
FROM Customers
GROUP BY City 
HAVING COUNT(CustomerID) > 2
ORDER BY NumOfCustomers DESC


-- Query 19 - List the names of customers who placed orders after 1/1/98 with order date.

SELECT c.ContactName AS CustomerName, o.OrderDate
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID
WHERE o.OrderDate > '1998-01-01'      
ORDER BY o.OrderDate										--> for better readability


-- Query 20 - List the names of all customers with most recent order dates

--SELECT c.ContactName AS CustomerName, o.OrderDate    --> First thought of this way but it's not sure which will be recent if the dates are same so using MAX is much accurate
--FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID 
--ORDER BY o.OrderDate DESC	

SELECT c.ContactName AS CustomerName, MAX(o.OrderDate) AS MostRecentOrderDate
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID
GROUP BY c.ContactName
ORDER BY MostRecentOrderDate DESC	


-- Query 21 - Display the names of all customers along with the count of products they bought

SELECT c.ContactName AS CustomerName, COUNT(od.ProductID) AS ProductCount
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID JOIN [Order Details] od ON o.OrderID=od.OrderID
GROUP BY c.ContactName
ORDER BY ProductCount DESC													--> for better readability


-- Query 22 - Display the customer ids who bought more than 100 Products with count of products.

SELECT c.CustomerID, COUNT(od.ProductID) AS ProductCount
FROM Customers c JOIN Orders o ON c.CustomerID=o.CustomerID JOIN [Order Details] od ON o.OrderID=od.OrderID
GROUP BY c.CustomerID
HAVING COUNT(od.ProductID) > 100
ORDER BY ProductCount DESC	


-- Query 23 - List all of the possible ways that suppliers can ship their products. Display the results as below

--  Supplier Company Name                Shipping Company Name

    ---------------------------          ----------------------------------

SELECT s.CompanyName as [Supplier Company Name], sh.CompanyName as [Shipping Company Name]
FROM Suppliers s JOIN Products p ON s.SupplierID=p.SupplierID JOIN [Order Details] od ON p.ProductID=od.ProductID JOIN Orders o ON od.OrderID=o.OrderID JOIN Shippers sh ON o.ShipVia=sh.ShipperID
GROUP BY s.CompanyName, sh.CompanyName						 --> to remove duplicate records and get all of the different possible ways (its optional but I used it as many ways are the same getting 2155 rows instead of 87 distinct ways)
ORDER BY s.CompanyName, sh.CompanyName                       --> for better readability


-- Query 24 - Display the products order each day. Show Order date and Product Name.

SELECT o.OrderDate, p.ProductName
FROM Orders o JOIN [Order Details] od ON o.OrderID=od.OrderID JOIN Products p ON p.ProductID=od.ProductID
ORDER BY o.OrderDate, p.ProductName


-- Query 25 - Displays pairs of employees who have the same job title.

--need to use SELF JOIN here

SELECT e1.EmployeeID AS EmployeeID1, e1.FirstName + ' ' + e1.LastName AS EmployeeName1, e2.EmployeeID AS EmployeeID2, e2.FirstName + ' ' + e2.LastName AS EmployeeName2, e1.Title AS JobTitle
FROM Employees e1 JOIN Employees e2 ON e1.Title = e2.Title
WHERE e1.EmployeeID < e2.EmployeeID                                      --> to ensure we get valid different pairs
ORDER BY e1.Title, e1.EmployeeID, e2.EmployeeID;


-- Query 26 - Display all the Managers who have more than 2 employees reporting to them.

-- CEO : Andrew
-- Manager : Nancy, Janet, Margaret, Steven, Laura
-- Employees : Michael, Robert, Anne

--SELECT EmployeeID, FirstName, LastName, ReportsTo
--FROM Employees

SELECT e1.EmployeeID AS ManagerID, e1.FirstName + ' ' + e1.LastName AS ManagerName, COUNT(e2.ReportsTo) AS NoEmpReporting
FROM Employees e1 JOIN Employees e2 ON e1.EmployeeID=e2.ReportsTo
GROUP BY e1.EmployeeID, e1.FirstName + ' ' + e1.LastName
HAVING COUNT(e2.ReportsTo) > 2


-- Query 27 - Display the customers and suppliers by city. The results should have the following columns

--City
--Name
--Contact Name,
--Type (Customer or Supplier)

-- Here, we can use UNION ALL

SELECT City, CompanyName AS [Name], ContactName, 'Customer' AS [Type]
FROM Customers
UNION ALL
SELECT City, CompanyName AS [Name], ContactName, 'Supplier' AS [Type]
FROM Suppliers
ORDER BY City, [Name]

