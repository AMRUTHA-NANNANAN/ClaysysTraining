create table book(bid int primary key,bname varchar(20),author varchar(20));
insert into book(bid,bname,author)values(101,'Maths','peter');
insert into book(bid,bname,author)values(102,'Business','john');
insert into book(bid,bname,author)values(103,'java','james');
insert into book(bid,bname,author)values(104,'htmml','davis');
select * from book;

create table issue(bid int references book(bid),issued_id int,issuedate date);
insert into issue(bid,issued_id,issuedate)values(103,1,'2023-09-22');
insert into issue(bid,issued_id,issuedate)values(101,2,'2023-10-04');
insert into issue(bid,issued_id,issuedate)values(102,3,'2023-11-09');
insert into issue(bid,issued_id,issuedate)values(104,4,'2023-12-29');

select * from issue;

select book.bname,issue.issuedate from issue INNER JOIN book on issue.bid =102;

select book.author,issue.issued_id from issue LEFT JOIN book on issue.bid=book.bid order by book.author;

select book.bname,issue.issued_id from issue RIGHT JOIN book on issue.bid=book.bid order by book.bname;

select book.bname,issue.issued_id from issue FULL OUTER JOIN book on issue.bid=book.bid where issued_id=4;

select book.author,issue.issued_id from book INNER JOIN issue on issue.bid=101

 