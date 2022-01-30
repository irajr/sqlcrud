CREATE DATABASE MyDatabase
GO

CREATE TABLE gencustomers
(
	Cid INT NOT NULL,
	Cname VARCHAR(50) NOT NULL,
	Cemail VARCHAR(50) NOT NULL,
	Caddress VARCHAR(MAX) NOT NULL,
	Ccity VARCHAR(20) NOT NULL, 
	Cstate VARCHAR(30) NOT NULL,  
	Cgender VARCHAR(9) NOT NULL,
	Crecord DATE DEFAULT GETDATE(),
	CONSTRAINT cus_pk PRIMARY KEY(Cid),
	CONSTRAINT cus_chc_gen CHECK(Cgender in ('Male' , 'Female', 'unknown'))
)
GO




CREATE TABLE gencategory
(
	Catid INT NOT NULL,
	CatName VARCHAR(100) NOT NULL,
	CONSTRAINT cat_PK_id PRIMARY KEY(Catid),	
)
GO



CREATE TABLE genorders
(
	Oid int,
	OrderDate date NOT NULL,
	OrderNumber VARCHAR(10) NOT NULL UNIQUE,
	CusOrdid INT NOT NULL,
	CusCatOrdid INT NOT NULL,
	CONSTRAINT add_FK_cid FOREIGN KEY (CusOrdid) REFERENCES gencustomers(Cid),
	CONSTRAINT add_FK_catid FOREIGN KEY (CusCatOrdid) REFERENCES gencategory(Catid),
)
GO



--Customer
TRUNCATE TABLE gencustomers
INSERT INTO gencustomers(Cid,Cname,Cemail,Caddress,Ccity,Cstate,Cgender) values (1,'Raj','irajjsharma@gmail.com','AT AND POST PRANTIJ','PRANTIJ','GUJARAT','Male')
ALTER TABLE gencustomers ADD CONSTRAINT def_record DEFAULT GETDATE() FOR Crecord
drop table gencustomers

--category
DROP TABLE gencategory

--orders
drop table genorders
ALTER TABLE genorders ALTER Column Oid int NOT NUll
ALTER TABLE genorders ADD CONSTRAINT Oid_PK PRIMARY KEY(Oid)

