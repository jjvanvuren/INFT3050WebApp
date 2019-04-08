DROP TABLE payment
DROP TABLE orderItem
DROP TABLE order
DROP TABLE customerAddress
DROP TABLE address
DROP TABLE postCode
DROP TABLE customer
DROP TABLE user
DROP TABLE bookCategory
DROP TABLE bookAuthor
DROP TABLE category
DROP TABLE author
DROP TABLE book
DROP TABLE item


CREATE TABLE item(
	itemId VARCHAR(30) NOT NULL, 
	price DECIMAL(7,2) NOT NULL DEFAULT 0.0,
	stockQuantity INTEGER DEFAULT 0,
	shortDescription VARCHAR(200),
	shortDescription VARCHAR(100),
	Primary Key (categoryId)
)

CREATE TABLE book(
	itemId VARCHAR(30) NOT NULL, 
	ISBN VARCHAR(30) NOT NULL, 
	title CHAR(45) NOT NULL,
	datePublished Date NOT NULL,
	secondaryTitle CHAR(45), 
	description VARCHAR(100)
	Primary Key (itemId)
	Foreign Key (itemId) references item(itemId)ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE author(
	authorId VARCHAR(30) NOT NULL, 
	firstName CHAR(30) NOT NULL, 
	lastName CHAR(30), 
	description VARCHAR(100)
	Primary Key (authorId)
)

CREATE TABLE category(
	categoryId VARCHAR(30) NOT NULL, 
	Name CHAR(30) NOT NULL, 
	description VARCHAR(100)
	Primary Key (categoryId)
)

CREATE TABLE bookAuthor(
	itemId VARCHAR(30) NOT NULL,
	authorId VARCHAR(30) NOT NULL
	Primary Key (itemId, authorId)
	Foreign Key (itemId) references book (itemId)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign Key (authorId) references author (authorId)ON DELETE NO ACTION ON UPDATE NO ACTION
)

CREATE TABLE bookCategory(
	itemId VARCHAR(30) NOT NULL,
	categoryId VARCHAR(30) NOT NULL
	Primary Key (itemId, categoryId)
	Foreign Key (itemId) references book (itemId)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign Key (categoryId) references category (categoryId)ON DELETE NO ACTION ON UPDATE NO ACTION
)

CREATE TABLE user(
	userId VARCHAR(30) NOT NULL, 
	email VARCHAR(45) NOT NULL,
	password VARCHAR(45) NOT NULL,
	firstName CHAR(30) NOT NULL, 
	lastName CHAR(30),
	isAdim boolean, 
	isActive boolean
	Primary Key (userId)
)

CREATE TABLE customer(
	userId VARCHAR(30) NOT NULL, 
	phoneNumber INTEGER
	Primary Key (userId)
	Foreign Key (userId) references user(userId)ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE postCode(
	suburd VARCHAR(15) NOT NULL, 
	state CHAR(3)NOT NULL,
	postCodeDigit INTEGER
	Primary Key(suburd,states)
)

CREATE TABLE address(
	addressId VARCHAR(30) NOT NULL,
	streetNumber VARCHAR(6)NOT NULL, 
	streetName VARCHAR(15)NOT NULL, 
	suburd VARCHAR(15)NOT NULL, 
	states CHAR(3) NOT NULL,
	postCodeDigit INTEGER NOT NULL
	Primary key (addressId)
	Foreign key(suburd,state) references postCode(suburd)ON DELETE NO ACTION ON UPDATE CASCADE
)

CREATE TABLE customerAddress(
	addressId VARCHAR(30) NOT NULL,
	userId VARCHAR(30) NOT NULL, 
	addressType VARCHAR(50) 
	Primary key (addressId,userId)
	Foreign key(addressId) references address(addressId)ON DELETE CASCADE ON UPDATE CASCADE
	Foreign key(userId) references user(userId)ON DELETE CASCADE ON UPDATE CASCADE
)


CREATE TABLE order(
	orderId VARCHAR(30) NOT NULL,
	userId VARCHAR(30) NOT NULL,
	orderStatus VARCHAR(30) NOT NULL,
	GST INTEGER(2),
	shippingCost DECIMAL(7,2) DEFAULT 0.0,
	subTotal DECIMAL(7,2) NOT NULL DEFAULT 0.0,
	dateOrderd Date
	Primary key (orderId)
	Foreign key(userId) references customer(userId)ON DELETE NO ACTION ON UPDATE CASCADE
)

CREATE TABLE orderItem(
	orderId VARCHAR(30) NOT NULL,
	itemId VARCHAR(30) NOT NULL, 
	quantaty INTEGER(10) 
	Primary key (orderId, itemId)
	Foreign key(orderId) references order(orderId)ON DELETE CASCADE ON UPDATE CASCADE
	Foreign key(itemId) references item(itemId)ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE payment(
	paymentId VARCHAR(30) NOT NULL,
	orderId VARCHAR(30) NOT NULL,
	datePayed Date,
	total DECIMAL(7,2) DEFAULT 0.0
	Primary key (orderId)
	Foreign key(orderId) references order(orderId)ON DELETE CASCADE ON UPDATE CASCADE
)

