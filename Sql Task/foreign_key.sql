
create table boat(bid int primary key,bname varchar(10),bcolor varchar(10));
insert into boat(bid,bname,bcolor)values(111,'Island','Blue');
 insert into boat(bid,bname,bcolor)values(112,'Henry','Green');
 insert into boat(bid,bname,bcolor)values(113,'Speed','Blue');
 insert into boat(bid,bname,bcolor)values(114,'Wind','Green');
 insert into boat(bid,bname,bcolor)values(115,'Marine','Blue');

		select * from boat;
create table reserve(bid INT,day VARCHAR(20),foreign key(bid) references boat(bid));
insert into reserve(bid,day)values(114,'monday');
insert into reserve(bid,day)values(112,'tuesday');
insert into reserve(bid,day)values(114,'wednessday');
insert into reserve(bid,day)values(113,'thursday');
insert into reserve(bid,day)values(114,'friday');
insert into reserve(bid,day)values(113,'sunday');
 select * from reserve
 

 select reserve.day from reserve where bid in(select bid from boat where bcolor='Blue');
