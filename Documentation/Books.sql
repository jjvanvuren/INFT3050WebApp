DROP TABLE orderItem
DROP TABLE orders
DROP TABLE postageOption
DROP TABLE payment
DROP TABLE webSiteUser
DROP TABLE bookCategory
DROP TABLE bookAuthor
DROP TABLE category
DROP TABLE author
DROP TABLE book
DROP TABLE item
DROP TABLE shippingAddress
DROP TABLE postCode

/* Create Database Login */
CREATE LOGIN editAdmin WITH PASSWORD = 'INFT3050!';

/* Create Item Table */
CREATE TABLE item
(
	itemID INTEGER IDENTITY(1,1),
	price DECIMAL(7,2) NOT NULL DEFAULT 0.0,
	stockQuantity INTEGER DEFAULT 0,
	longDescription VARCHAR(MAX),
	shortDescription VARCHAR(250),
	imagePath VARCHAR(100),
	thumbnailPath VARCHAR(100),
	isActive BIT,
	PRIMARY KEY (itemID)
)

GO

/* Create Book Table */
CREATE TABLE book
(
	itemID INTEGER,
	ISBN VARCHAR(30) NOT NULL,
	title VARCHAR(MAX) NOT NULL,
	datePublished Date NOT NULL,
	secondaryTitle VARCHAR(MAX),
	isBestSeller BIT,
	publisher VARCHAR(MAX),
	PRIMARY KEY (itemID),
	FOREIGN KEY (itemID) REFERENCES item(itemID) ON DELETE CASCADE ON UPDATE CASCADE
)

GO

/* Create Author Table */
CREATE TABLE author
(
	authorID INTEGER IDENTITY(1,1),
	firstName VARCHAR(MAX) NOT NULL,
	lastName VARCHAR(MAX),
	description VARCHAR(MAX),
	PRIMARY KEY (authorID)
)

GO

/* Create Category Table */
CREATE TABLE category
(
	categoryID INTEGER IDENTITY(1,1),
	Name VARCHAR(MAX) NOT NULL,
	description VARCHAR(MAX),
	PRIMARY KEY (categoryID)
)

GO

/* Create BookAuthor Table */
CREATE TABLE bookAuthor
(
	itemID INTEGER,
	authorID INTEGER,
	PRIMARY KEY (itemID, authorID),
	FOREIGN KEY (itemID) REFERENCES book (itemID)ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (authorID) REFERENCES author (authorID)ON DELETE NO ACTION ON UPDATE NO ACTION
)

GO

/* Create BookCategory Table */
CREATE TABLE bookCategory
(
	itemID INTEGER,
	categoryID INTEGER,
	PRIMARY KEY (itemID, categoryID),
	FOREIGN KEY (itemID) REFERENCES book (itemID)ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY (categoryID) REFERENCES category (categoryID)ON DELETE NO ACTION ON UPDATE NO ACTION
)

GO

/* Create WebSiteUser Table*/
CREATE TABLE webSiteUser
(
	userID INTEGER IDENTITY(1,1),
	email VARCHAR(45) NOT NULL,
	password VARCHAR(250) NOT NULL,
	firstName VARCHAR(250) NOT NULL,
	lastName VARCHAR(250),
	isAdmin BIT,
	isActive BIT,
	validationKey VARCHAR(MAX),
	isVerified BIT,
	PRIMARY KEY (userID)
)

GO

/* Create Payment Table*/
CREATE TABLE payment
(
	paymentID INTEGER IDENTITY(1,1),
	datePayed Date,
	total DECIMAL(7,2) DEFAULT 0.0,
	PRIMARY KEY (paymentID)
)

GO

/* Create Postage Option Table*/
CREATE TABLE postageOption
(
	postageOptionID INTEGER IDENTITY(1,1),
	postageOptionName VARCHAR(30),
	amountOfDaysToDeliver DECIMAL(7,2) DEFAULT 0.0,
	shippingCost DECIMAL(7,2) DEFAULT 0.0,
	isActive BIT,
	PRIMARY KEY (postageOptionID)
)

GO

/* Create PostCode Table*/
CREATE TABLE postCode
(
	city VARCHAR(15) NOT NULL,
	addressState CHAR(3)NOT NULL,
	postCode INTEGER,
	PRIMARY KEY(city,addressState)
)

GO

/* Create User Address Table */
CREATE TABLE shippingAddress
(
	addressID INTEGER IDENTITY(1,1),
	streetNumber VARCHAR(6)NOT NULL,
	streetName VARCHAR(15)NOT NULL,
	city VARCHAR(15)NOT NULL,
	addressState CHAR(3) NOT NULL,
	PRIMARY KEY (addressID),
	FOREIGN KEY(city,addressState) REFERENCES postCode(city,addressState)ON DELETE NO ACTION ON UPDATE CASCADE
)

GO

/* Create Orders Table */
CREATE TABLE orders
(
	orderID INTEGER IDENTITY(1,1),
	userID INTEGER,
	paymentID INTEGER,
	postageOptionID INTEGER,
	orderStatus VARCHAR(30),
	GST INTEGER,
	subTotal DECIMAL(7,2) DEFAULT 0.0,
	dateOrdered Date,
	shippingAddressID INTEGER,
	PRIMARY KEY (orderID),
	FOREIGN KEY(userID) REFERENCES webSiteUser(userID)ON DELETE NO ACTION ON UPDATE CASCADE,
	FOREIGN KEY(paymentID) REFERENCES payment(paymentID)ON DELETE NO ACTION ON UPDATE CASCADE,
	FOREIGN KEY(postageOptionID) REFERENCES postageOption(postageOptionID)ON DELETE NO ACTION ON UPDATE CASCADE,
	FOREIGN KEY(shippingAddressID) REFERENCES shippingAddress(addressID)ON DELETE NO ACTION ON UPDATE CASCADE
)

GO

/* Create OrderItem Table */
CREATE TABLE orderItem
(
	orderID INTEGER,
	itemID INTEGER,
	quantity INTEGER ,
	PRIMARY KEY (orderID, itemID),
	FOREIGN KEY(orderID) REFERENCES orders(orderID)ON DELETE CASCADE ON UPDATE CASCADE,
	FOREIGN KEY(itemID) REFERENCES item(itemID)ON DELETE NO ACTION
)

GO

-- Create fulltext catalog to be used when creating a fulltext index
CREATE FULLTEXT CATALOG fulltextCatalog AS DEFAULT;

-- Create unique index
CREATE UNIQUE INDEX PK_book_itemID ON Book(itemID)

-- Create fulltext index on book.title
CREATE FULLTEXT INDEX ON book(title)
KEY INDEX PK_book_itemID
WITH STOPLIST = SYSTEM;

GO

--INSERT DATA INTO TABLES

--Insert Users
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('joe@example.com', '1e28284f59e926547bb6793ad8723722', 'Joe', '', 0, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('james@example.com', '1e28284f59e926547bb6793ad8723722', 'James', 'Smith', 0, 0, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('sara@example.com', '1e28284f59e926547bb6793ad8723722', 'Sara', 'Headges', 0, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('alex@usedbooksales.com.au', '1e28284f59e926547bb6793ad8723722', 'Alex', 'Budwill', 1, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('patrick@usedbooksales.com.au', '1e28284f59e926547bb6793ad8723722', 'Patrick', 'Foley', 1, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('derrick@example.com', '1e28284f59e926547bb6793ad8723722', 'Derrick', 'Hardy', 0, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('soli@example.com', '1e28284f59e926547bb6793ad8723722', 'Soli', 'Soliman', 0, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('chelsea@example.com', '1e28284f59e926547bb6793ad8723722', 'Chelsea', 'Gordon', 0, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('karl@usedbooksales.com.au', '1e28284f59e926547bb6793ad8723722', 'Karl', 'Foley', 1, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('jacques@usedbooksales.com.au', '1e28284f59e926547bb6793ad8723722', 'Jacques', 'Janse van Vuren', 1, 1, '', 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive, validationKey, isVerified)
VALUES ('francois@usedbooksales.com.au', '1e28284f59e926547bb6793ad8723722', 'Francois', 'Janse van Vuren', 1, 1, '', 1);

GO

--Insert Categories
INSERT INTO category (Name, description) VALUES ('History', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Thriller', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Sci-Fi', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Horror', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Crime', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Fantasy', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Art', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Technology', 'Category description goes here.');

GO

--Insert Authors
INSERT INTO author (firstName, lastName, description) VALUES ('J L', 'Pickering', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('K.L', 'Slater', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Mark', 'Lawrence', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Ruth', 'Hogan', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Harlan', 'Coben', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Metropolitan Museum of Art New York', '', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Ashlee', 'Vance', 'Author description goes here.');

GO

--Insert item and book tables
INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
VALUES (45.92, 20,
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9780813056173.jpg', '/UL/Images/9780813056173_thumb.jpg', 1);
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
VALUES (1, '9780813056173', 'Picturing Apollo 11', '20190430', '', 1, 'Univ Pr of Florida');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
VALUES (16.49, 20,
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9781786812445.jpg', '/UL/Images/9781786812445_thumb.jpg', 1);
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
VALUES (2, '9781786812445', 'The Mistake', '20171004', '', 1, 'Bookouture');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
VALUES (22.99, 20,
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9781503903265.jpg', '/UL/Images/9781503903265_thumb.jpg', 1);
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
VALUES (3, '9781503903265', 'One Word Kill', '20190501', '', 1, '47 North');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
VALUES (16.81, 20,
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9781473635487.jpg', '/UL/Images/9781473635487_thumb.jpg', 1);
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
VALUES (4, '9781473635487', 'The Keeper of Lost Things', '20170810', '', 1, 'Hodder & Stoughton General Division');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
VALUES (16.11, 20,
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9781784751173.jpg', '/UL/Images/9781784751173_thumb.jpg', 1);
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
VALUES (5, '9781784751173', 'Run Away', '20180806', '', 1, 'ARROW LTD');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
VALUES (19.99, 20,
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9780008152406.jpg', '/UL/Images/9780008152406_thumb.jpg', 1);
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
VALUES (6, '9780008152406', 'Holy Sister', '20190318', '', 1, 'Voyager - GB');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
VALUES (74.62, 20,
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9780847846597.jpg', '/UL/Images/9780847846597_thumb.jpg', 1);
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
VALUES (7, '9780847846597', 'Masterpiece Paintings', '20161001', '', 1, 'Rizzoli');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, isActive)
VALUES (23.36, 20,
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam,
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
		'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9780753555644.jpg', '/UL/Images/9780753555644_thumb.jpg', 1);
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher)
VALUES (8, '9780753555644', 'Elon Musk', '20160310', '', 1, 'Ebury Publishing');

GO

--Insert into bookAuthor
INSERT INTO bookAuthor (itemID, authorID) VALUES (1, 1);
INSERT INTO bookAuthor (itemID, authorID) VALUES (2, 2);
INSERT INTO bookAuthor (itemID, authorID) VALUES (3, 3);
INSERT INTO bookAuthor (itemID, authorID) VALUES (4, 4);
INSERT INTO bookAuthor (itemID, authorID) VALUES (5, 5);
INSERT INTO bookAuthor (itemID, authorID) VALUES (6, 3);
INSERT INTO bookAuthor (itemID, authorID) VALUES (7, 6);
INSERT INTO bookAuthor (itemID, authorID) VALUES (8, 7);

GO

--Insert into bookCategory
INSERT INTO bookCategory (itemID, categoryID) VALUES (1, 1);
INSERT INTO bookCategory (itemID, categoryID) VALUES (2, 2);
INSERT INTO bookCategory (itemID, categoryID) VALUES (3, 3);
INSERT INTO bookCategory (itemID, categoryID) VALUES (4, 4);
INSERT INTO bookCategory (itemID, categoryID) VALUES (5, 5);
INSERT INTO bookCategory (itemID, categoryID) VALUES (6, 6);
INSERT INTO bookCategory (itemID, categoryID) VALUES (7, 7);
INSERT INTO bookCategory (itemID, categoryID) VALUES (8, 8);

GO

--Insert postage options
INSERT INTO postageOption (postageOptionName, shippingCost, isActive) VALUES ('Pick Up', 0.00, 1);
INSERT INTO postageOption (postageOptionName, shippingCost, isActive) VALUES ('AusPost', 5.99, 1);
INSERT INTO postageOption (postageOptionName, shippingCost, isActive) VALUES ('AusPost Express', 9.99, 1);
INSERT INTO postageOption (postageOptionName, shippingCost, isActive) VALUES ('Startrack', 3.99, 1);
INSERT INTO postageOption (postageOptionName, shippingCost, isActive) VALUES ('Startrack Express', 7.99, 1);

GO