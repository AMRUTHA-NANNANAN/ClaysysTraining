
 GO 
 CREATE PROCEDURE SELECT_REG
 AS BEGIN
 SELECT * FROM REGISTRATION;
 END;

 GO 
 CREATE PROCEDURE 
 INSERT_REG(@fname VARCHAR(20),@lname VARCHAR(20),@date_of_birth DATE,@age INT,@gender VARCHAR(20),@phone VARCHAR(35),@email VARCHAR(20),@u_address VARCHAR(20),@username VARCHAR(20),@pwd VARCHAR(20))
 AS BEGIN
 INSERT INTO REGISTRATION(fname,lname,date_of_birth,age,gender,phone,email,u_address,username,pwd)values(@fname,@lname,@date_of_birth,@age,@gender,@phone,@email,@u_address,@username,@pwd);

 END;

 GO 
 CREATE PROCEDURE UPDATE_REG(@fname VARCHAR(20),@lname VARCHAR(20),@date_of_birth DATE,@age INT)
 AS BEGIN
 UPDATE REGISTRATION SET fname=@fName,lname=@lname,date_of_birth=@date_of_birth,age=@age;
 END;

 GO 
 CREATE PROCEDURE DELETE_REG(@lname VARCHAR(20))
 AS BEGIN
 DELETE FROM REGISTRATION WHERE lname=@lname;
 END;

 EXEC SELECT_REG
 EXEC INSERT_REG 'jithu','s','1993-03-22',30,'male',9535636546,'niravth,perumbavoor,kerla','jithu@gmail.com','jithus','jithu#123'
 EXEC UPDATE_REG 'jithu','soman','1993-03-22',30
 EXEC DELETE_REG 'soman'

---single stored procedure
CREATE TABLE REG(ID INT PRIMARY KEY,Name VARCHAR(20),Age INT,Phone INT);

ALTER TABLE REG ADD Type VARCHAR(20);
SELECT * FROM REG;



GO
 ALTER PROCEDURE CRUD_REG(@ID INT,@Name VARCHAR(20),@Age INT,@Phone INT,@Type VARCHAR(20))
 AS
 BEGIN

 IF @Type='SELECT'
 BEGIN
 SELECT * FROM REG;
 END;

 IF @Type='INSERT'
 BEGIN
INSERT INTO REG(ID,Name,age,phone)values(@ID,@Name,@Age,@Phone);

 END;

 IF @Type='UPDATE'
 BEGIN
 UPDATE REG SET Name=@Name,Age=@Age,Phone=@Phone WHERE ID=@ID;
 END;

 IF @Type='DELETE'
 BEGIN
 delete from REG WHERE @ID=ID;
 END;
 END;

EXEC CRUD_REG 0,'',0,0,'SELECT';
EXEC CRUD_REG 1,'Anu',20,93045456,'INSERT'
EXEC CRUD_REG 1,'Anu',24,93045456,'UPDATE'
EXEC CRUD_REG 1,'',0,0,'DELETE'
