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