use DemoDB
CREATE TABLE EMPLOYEE1(Emp_No INT, Emp_Name VARCHAR(20),Salary INT,Department VARCHAR(20));
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(1,'Anu',20000,'Analyst');
SELECT * FROM EMPLOYEE1;
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(2,'Anoop',25000,'Analyst');
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(3,'Paul',20000,'Analyst');
SELECT * FROM EMPLOYEE1;
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(4,'Arjun',30000,'Manager');
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(5,'Anand',15000,'Marketing');
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(6,'Nikil',35000,'Manager');
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(7,'John',20000,'Sales');
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(8,'Manu',45000,'Manager');
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(9,'Sunny',15000,'Marketing');
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(10,'Noyal',20000,'Analyst');
INSERT INTO EMPLOYEE1(Emp_No,Emp_Name,Salary,Department)VALUES(11,'Ravi',30000,'Marketing');
SELECT * FROM EMPLOYEE1;

SELECT MIN(Salary) FROM EMPLOYEE1 WHERE Salary IN(SELECT DISTINCT TOP 2 Salary FROM EMPLOYEE1 ORDER BY Salary DESC);

SELECT * FROM EMPLOYEE1 WHERE SALARY=(SELECT MIN(Salary) FROM EMPLOYEE1 WHERE Salary IN(SELECT DISTINCT TOP 2 Salary FROM EMPLOYEE1 ORDER BY Salary DESC));

SELECT Department,COUNT(*) FROM EMPLOYEE1 GROUP BY Department;