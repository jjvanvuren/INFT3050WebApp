DROP TABLE postCode
DROP TABLE userAddress
DROP TABLE customerAddress
DROP TABLE orderItem
DROP TABLE orders
DROP Table postageOption
DROP TABLE payment
DROP TABLE customer
DROP TABLE webSiteUser
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
	longDescription VARCHAR(200),
	shortDescription VARCHAR(100),
	imagePath VARCHAR(100)
	Primary Key (itemId)
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

CREATE TABLE webSiteUser(
	userId VARCHAR(30) NOT NULL, 
	email VARCHAR(45) NOT NULL,
	password VARCHAR(45) NOT NULL,
	firstName CHAR(30) NOT NULL, 
	lastName CHAR(30),
	isAdmin Bit, 
	isActive Bit
	Primary Key (userId)
)

CREATE TABLE customer(
	userId VARCHAR(30) NOT NULL, 
	phoneNumber INTEGER
	Primary Key (userId)
	Foreign Key (userId) references webSiteUser(userId)ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE payment(
	paymentId VARCHAR(30) NOT NULL,
	datePayed Date,
	total DECIMAL(7,2) DEFAULT 0.0
	Primary key (paymentId)
)

CREATE TABLE postageOption(
	postageOptionId VARCHAR(30) NOT NULL,
	postageOptionName VARCHAR(30),
	amountOfDaysToDeliver DECIMAL(7,2) DEFAULT 0.0,
	shippingCost DECIMAL(7,2) DEFAULT 0.0
	Primary key (postageOptionId) 
)

CREATE TABLE orders(
	orderId VARCHAR(30) NOT NULL,
	userId VARCHAR(30) NOT NULL,
	paymentId VARCHAR(30) NOT NULL,
	postageOptionId VARCHAR(30),
	orderStatus VARCHAR(30) NOT NULL,
	GST INTEGER,
	subTotal DECIMAL(7,2) NOT NULL DEFAULT 0.0,
	dateOrderd Date,
	Primary key (orderId),
	Foreign key(userId) references customer(userId)ON DELETE NO ACTION ON UPDATE CASCADE,
	Foreign key(paymentId) references payment(paymentId)ON DELETE NO ACTION ON UPDATE CASCADE,
	Foreign key(postageOptionId) references postageOption(postageOptionId)ON DELETE NO ACTION ON UPDATE CASCADE

)



CREATE TABLE orderItem(
	orderId VARCHAR(30) NOT NULL,
	itemId VARCHAR(30) NOT NULL, 
	quantity INTEGER ,
	Primary key (orderId, itemId),
	Foreign key(orderId) references orders(orderId)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign key(itemId) references item(itemId)ON DELETE NO ACTION 
)



CREATE TABLE postCode(
	city VARCHAR(15) NOT NULL, 
	adressStates CHAR(3)NOT NULL,
	postCode INTEGER,
	Primary Key(city,adressStates)
)

CREATE TABLE userAddress(
	addressId VARCHAR(30) NOT NULL,
	streetNumber VARCHAR(6)NOT NULL, 
	streetName VARCHAR(15)NOT NULL, 
	city VARCHAR(15)NOT NULL, 
	adressStates CHAR(3) NOT NULL,
	Primary key (addressId),
	Foreign key(city,adressStates) references postCode(city,adressStates)ON DELETE NO ACTION ON UPDATE CASCADE
)

CREATE TABLE customerAddress(
	addressId VARCHAR(30) NOT NULL,
	userId VARCHAR(30) NOT NULL, 
	addressType VARCHAR(50),
	Primary key (addressId,userId),
	Foreign key(addressId) references userAddress(addressId)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign key(userId) references customer(userId)ON DELETE CASCADE ON UPDATE CASCADE
)
