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
	itemID VARCHAR(30) NOT NULL, 
	price DECIMAL(7,2) NOT NULL DEFAULT 0.0,
	stockQuantity INTEGER DEFAULT 0,
	longDescription VARCHAR(200),
	shortDescription VARCHAR(100),
	imagePath VARCHAR(100),
	thumbnailPath VARCHAR(100)
	Primary Key (itemID)
)

CREATE TABLE book(
	itemID VARCHAR(30) NOT NULL, 
	ISBN VARCHAR(30) NOT NULL, 
	title CHAR(45) NOT NULL,
	datePublished Date NOT NULL,
	secondaryTitle CHAR(45), 
	isBestSeller Boolean,
	publisher VARCHAR(100)
	Primary Key (itemID)
	Foreign Key (itemID) references item(itemID)ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE author(
	authorID VARCHAR(30) NOT NULL, 
	firstName CHAR(30) NOT NULL, 
	lastName CHAR(30), 
	description VARCHAR(100)
	Primary Key (authorID)
)

CREATE TABLE category(
	categoryID VARCHAR(30) NOT NULL, 
	Name CHAR(30) NOT NULL, 
	description VARCHAR(100)
	Primary Key (categoryID)
)

CREATE TABLE bookAuthor(
	itemID VARCHAR(30) NOT NULL,
	authorID VARCHAR(30) NOT NULL
	Primary Key (itemID, authorID)
	Foreign Key (itemID) references book (itemID)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign Key (authorID) references author (authorID)ON DELETE NO ACTION ON UPDATE NO ACTION
)

CREATE TABLE bookCategory(
	itemID VARCHAR(30) NOT NULL,
	categoryID VARCHAR(30) NOT NULL
	Primary Key (itemID, categoryID)
	Foreign Key (itemID) references book (itemID)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign Key (categoryID) references category (categoryID)ON DELETE NO ACTION ON UPDATE NO ACTION
)

CREATE TABLE webSiteUser(
	userID VARCHAR(30) NOT NULL, 
	email VARCHAR(45) NOT NULL,
	password VARCHAR(45) NOT NULL,
	firstName CHAR(30) NOT NULL, 
	lastName CHAR(30),
	isAdmin Bit, 
	isActive Bit
	Primary Key (userID)
)

CREATE TABLE customer(
	userID VARCHAR(30) NOT NULL, 
	phoneNumber VARCHAR(15)
	Primary Key (userID)
	Foreign Key (userID) references webSiteUser(userID)ON DELETE CASCADE ON UPDATE CASCADE
)

CREATE TABLE payment(
	paymentID VARCHAR(30) NOT NULL,
	datePayed Date,
	total DECIMAL(7,2) DEFAULT 0.0
	Primary key (paymentID)
)

CREATE TABLE postageOption(
	postageOptionID VARCHAR(30) NOT NULL,
	postageOptionName VARCHAR(30),
	amountOfDaysToDeliver DECIMAL(7,2) DEFAULT 0.0,
	shippingCost DECIMAL(7,2) DEFAULT 0.0
	Primary key (postageOptionID) 
)

CREATE TABLE orders(
	orderID VARCHAR(30) NOT NULL,
	userID VARCHAR(30) NOT NULL,
	paymentID VARCHAR(30) NOT NULL,
	postageOptionID VARCHAR(30),
	orderStatus VARCHAR(30) NOT NULL,
	GST INTEGER,
	subTotal DECIMAL(7,2) NOT NULL DEFAULT 0.0,
	dateOrderd Date,
	Primary key (orderID),
	Foreign key(userID) references customer(userID)ON DELETE NO ACTION ON UPDATE CASCADE,
	Foreign key(paymentID) references payment(paymentID)ON DELETE NO ACTION ON UPDATE CASCADE,
	Foreign key(postageOptionID) references postageOption(postageOptionID)ON DELETE NO ACTION ON UPDATE CASCADE

)



CREATE TABLE orderItem(
	orderID VARCHAR(30) NOT NULL,
	itemID VARCHAR(30) NOT NULL, 
	quantity INTEGER ,
	Primary key (orderID, itemID),
	Foreign key(orderID) references orders(orderID)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign key(itemID) references item(itemID)ON DELETE NO ACTION 
)



CREATE TABLE postCode(
	city VARCHAR(15) NOT NULL, 
	adressStates CHAR(3)NOT NULL,
	postCode INTEGER,
	Primary Key(city,adressStates)
)

CREATE TABLE userAddress(
	addressID VARCHAR(30) NOT NULL,
	streetNumber VARCHAR(6)NOT NULL, 
	streetName VARCHAR(15)NOT NULL, 
	city VARCHAR(15)NOT NULL, 
	adressStates CHAR(3) NOT NULL,
	Primary key (addressID),
	Foreign key(city,adressStates) references postCode(city,adressStates)ON DELETE NO ACTION ON UPDATE CASCADE
)

CREATE TABLE customerAddress(
	addressID VARCHAR(30) NOT NULL,
	userID VARCHAR(30) NOT NULL, 
	addressType VARCHAR(50),
	Primary key (addressID,userID),
	Foreign key(addressID) references userAddress(addressID)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign key(userID) references customer(userID)ON DELETE CASCADE ON UPDATE CASCADE
)
