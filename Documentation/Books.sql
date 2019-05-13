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
DROP TABLE userAddress
DROP TABLE postCode

/* Create Database Login */
CREATE LOGIN Admin WITH PASSWORD = 'Password#1';

/* Create Item Table */
CREATE TABLE item(
	itemID INTEGER IDENTITY(1,1), 
	price DECIMAL(7,2) NOT NULL DEFAULT 0.0,
	stockQuantity INTEGER DEFAULT 0,
	longDescription VARCHAR(MAX),
	shortDescription VARCHAR(250),
	imagePath VARCHAR(100),
	thumbnailPath VARCHAR(100)
	Primary Key (itemID)
)

/* Create Book Table */
CREATE TABLE book(
	itemID INTEGER, 
	ISBN VARCHAR(30) NOT NULL, 
	title VARCHAR(MAX) NOT NULL,
	datePublished Date NOT NULL,
	secondaryTitle VARCHAR(MAX), 
	isBestSeller BIT,
	publisher VARCHAR(MAX)
	Primary Key (itemID)
	Foreign Key (itemID) references item(itemID)ON DELETE CASCADE ON UPDATE CASCADE
)

/* Create Author Table */
CREATE TABLE author(
	authorID INTEGER IDENTITY(1,1), 
	firstName VARCHAR(MAX) NOT NULL, 
	lastName VARCHAR(MAX), 
	description VARCHAR(MAX)
	Primary Key (authorID)
)

/* Create Category Table */
CREATE TABLE category(
	categoryID INTEGER IDENTITY(1,1), 
	Name VARCHAR(MAX) NOT NULL, 
	description VARCHAR(MAX)
	Primary Key (categoryID)
)

/* Create BookAuthor Table */
CREATE TABLE bookAuthor(
	itemID INTEGER,
	authorID INTEGER,
	Primary Key (itemID, authorID),
	Foreign Key (itemID) references book (itemID)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign Key (authorID) references author (authorID)ON DELETE NO ACTION ON UPDATE NO ACTION
)

/* Create BookCategory Table */
CREATE TABLE bookCategory(
	itemID INTEGER,
	categoryID INTEGER,
	Primary Key (itemID, categoryID),
	Foreign Key (itemID) references book (itemID)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign Key (categoryID) references category (categoryID)ON DELETE NO ACTION ON UPDATE NO ACTION
)

/* Create WebSiteUser Table*/
CREATE TABLE webSiteUser(
	userID INTEGER IDENTITY(1,1), 
	email VARCHAR(45) NOT NULL,
	password VARCHAR(250) NOT NULL,
	firstName VARCHAR(250) NOT NULL, 
	lastName VARCHAR(250),
	isAdmin BIT, 
	isActive BIT,
	Primary Key (userID)
)

/* Create Customer Table */
CREATE TABLE customer(
	userID INTEGER, 
	phoneNumber VARCHAR(15)
	Primary Key (userID)
	Foreign Key (userID) references webSiteUser(userID)ON DELETE CASCADE ON UPDATE CASCADE
)

/* Create Payment Table*/
CREATE TABLE payment(
	paymentID INTEGER IDENTITY(1,1),
	datePayed Date,
	total DECIMAL(7,2) DEFAULT 0.0
	Primary key (paymentID)
)

/* Create Postage Option Table*/
CREATE TABLE postageOption(
	postageOptionID INTEGER IDENTITY(1,1),
	postageOptionName VARCHAR(30),
	amountOfDaysToDeliver DECIMAL(7,2) DEFAULT 0.0,
	shippingCost DECIMAL(7,2) DEFAULT 0.0
	Primary key (postageOptionID) 
)

/* Create Orders Table */
CREATE TABLE orders(
	orderID INTEGER IDENTITY(1,1),
	userID INTEGER,
	paymentID INTEGER,
	postageOptionID INTEGER,
	orderStatus VARCHAR(30) NOT NULL,
	GST INTEGER,
	subTotal DECIMAL(7,2) NOT NULL DEFAULT 0.0,
	dateOrderd Date,
	Primary key (orderID),
	Foreign key(userID) references customer(userID)ON DELETE NO ACTION ON UPDATE CASCADE,
	Foreign key(paymentID) references payment(paymentID)ON DELETE NO ACTION ON UPDATE CASCADE,
	Foreign key(postageOptionID) references postageOption(postageOptionID)ON DELETE NO ACTION ON UPDATE CASCADE

)

/* Create OrderItem Table */
CREATE TABLE orderItem(
	orderID INTEGER,
	itemID INTEGER,
	quantity INTEGER ,
	Primary key (orderID, itemID),
	Foreign key(orderID) references orders(orderID)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign key(itemID) references item(itemID)ON DELETE NO ACTION 
)


/* Create PostCode Table*/
CREATE TABLE postCode(
	city VARCHAR(15) NOT NULL, 
	adressStates CHAR(3)NOT NULL,
	postCode INTEGER,
	Primary Key(city,adressStates)
)
/* Create User Address Table */
CREATE TABLE userAddress(
	addressID INTEGER IDENTITY(1,1),
	streetNumber VARCHAR(6)NOT NULL, 
	streetName VARCHAR(15)NOT NULL, 
	city VARCHAR(15)NOT NULL, 
	adressStates CHAR(3) NOT NULL,
	Primary key (addressID),
	Foreign key(city,adressStates) references postCode(city,adressStates)ON DELETE NO ACTION ON UPDATE CASCADE
)

/* Create Customer Address Table*/
CREATE TABLE customerAddress(
	addressID INTEGER,
	userID INTEGER,
	addressType VARCHAR(50),
	Primary key (addressID,userID),
	Foreign key(addressID) references userAddress(addressID)ON DELETE CASCADE ON UPDATE CASCADE,
	Foreign key(userID) references customer(userID)ON DELETE CASCADE ON UPDATE CASCADE
)

--INSERT DATA INTO TABLES

--Insert Users
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('joe@example.com', 'Password#1', 'Joe', '', 0, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('james@example.com', 'Password#1', 'James', 'Smith', 0, 0);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('sara@example.com', 'Password#1', 'Sara', 'Headges', 0, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('alex@usedbooksales.com.au', 'Password#1', 'Alex', 'Budwill', 1, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('patrick@usedbooksales.com.au', 'Password#1', 'Patrick', 'Foley', 1, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('derrick@example.com', 'Password#1', 'Derrick', 'Hardy', 0, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('soli@example.com', 'Password#1', 'Soli', 'Soliman', 0, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('chelsea@example.com', 'Password#1', 'Chelsea', 'Gordon', 0, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('karl@usedbooksales.com.au', 'Password#1', 'Karl', 'Foley', 1, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('jacques@usedbooksales.com.au', 'Password#1', 'Jacques', 'Janse van Vuren', 1, 1);
INSERT INTO webSiteUser (email, password, firstName, lastName, isAdmin, isActive) VALUES ('francois@usedbooksales.com.au', 'Password#1', 'Francois', 'Janse van Vuren', 1, 1);

--Insert Categories
INSERT INTO category (Name, description) VALUES ('History', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Thriller', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Sci-Fi', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Horror', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Crime', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Fantasy', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Art', 'Category description goes here.');
INSERT INTO category (Name, description) VALUES ('Technology', 'Category description goes here.');

--Insert Authors
INSERT INTO author (firstName, lastName, description) VALUES ('J L', 'Pickering', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('K.L', 'Slater', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Mark', 'Lawrence', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Ruth', 'Hogan', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Harlan', 'Coben', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Metropolitan Museum of Art New York', '', 'Author description goes here.');
INSERT INTO author (firstName, lastName, description) VALUES ('Ashlee', 'Vance', 'Author description goes here.');

--Insert item and book tables
INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath) VALUES (45.92, 20, 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9780813056173.jpg', '/UL/Images/9780813056173_thumb.jpg');
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher) VALUES (1, '9780813056173', 'Picturing Apollo 11', '20190430', '', 1, 'Univ Pr of Florida');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath) VALUES (16.49, 20, 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9781786812445.jpg', '/UL/Images/9781786812445_thumb.jpg');
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher) VALUES (2, '9781786812445', 'The Mistake', '20171004', '', 1, 'Bookouture');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath) VALUES (22.99, 20, 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9781503903265.jpg', '/UL/Images/9781503903265_thumb.jpg');
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher) VALUES (3, '9781503903265', 'One Word Kill', '20190501', '', 1, '47 North');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath) VALUES (16.81, 20, 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9781473635487.jpg', '/UL/Images/9781473635487_thumb.jpg');
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher) VALUES (4, '9781473635487', 'The Keeper of Lost Things', '20170810', '', 1, 'Hodder & Stoughton General Division');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath) VALUES (16.11, 20, 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9781784751173.jpg', '/UL/Images/9781784751173_thumb.jpg');
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher) VALUES (5, '9781784751173', 'Run Away', '20180806', '', 1, 'ARROW LTD');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath) VALUES (19.99, 20, 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9780008152406.jpg', '/UL/Images/9780008152406_thumb.jpg');
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher) VALUES (6, '9780008152406', 'Holy Sister', '20190318', '', 1, 'Voyager - GB');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath) VALUES (74.62, 20, 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9780847846597.jpg', '/UL/Images/9780847846597_thumb.jpg');
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher) VALUES (7, '9780847846597', 'Masterpiece Paintings', '20161001', '', 1, 'Rizzoli');

INSERT INTO item (price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath) VALUES (23.36, 20, 
'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.Ut enim ad minim veniam, 
quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.',
'Lorem ipsum dolor sit amet, consectetur adipiscing elit', '/UL/Images/9780753555644.jpg', '/UL/Images/9780753555644_thumb.jpg');
INSERT INTO book (itemID, ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher) VALUES (8, '9780753555644', 'Elon Musk', '20160310', '', 1, 'Ebury Publishing');

--Insert into bookAuthor
INSERT INTO bookAuthor (itemID, authorID) VALUES (1, 1);
INSERT INTO bookAuthor (itemID, authorID) VALUES (2, 2);
INSERT INTO bookAuthor (itemID, authorID) VALUES (3, 3);
INSERT INTO bookAuthor (itemID, authorID) VALUES (4, 4);
INSERT INTO bookAuthor (itemID, authorID) VALUES (5, 5);
INSERT INTO bookAuthor (itemID, authorID) VALUES (6, 3);
INSERT INTO bookAuthor (itemID, authorID) VALUES (7, 6);
INSERT INTO bookAuthor (itemID, authorID) VALUES (8, 7);

--Insert into bookCategory
INSERT INTO bookCategory (itemID, categoryID) VALUES (1, 1);
INSERT INTO bookCategory (itemID, categoryID) VALUES (2, 2);
INSERT INTO bookCategory (itemID, categoryID) VALUES (3, 3);
INSERT INTO bookCategory (itemID, categoryID) VALUES (4, 4);
INSERT INTO bookCategory (itemID, categoryID) VALUES (5, 5);
INSERT INTO bookCategory (itemID, categoryID) VALUES (6, 6);
INSERT INTO bookCategory (itemID, categoryID) VALUES (7, 7);
INSERT INTO bookCategory (itemID, categoryID) VALUES (8, 8);

--Select all book information
SELECT item.itemID, price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, 
ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher, firstName, lastName, author.description, 
Name, category.description 
FROM item 
INNER JOIN book ON item.itemID = book.itemID
INNER JOIN bookAuthor ON book.itemID = bookAuthor.itemID
INNER JOIN author ON bookAuthor.authorID = author.authorID
INNER JOIN bookCategory ON book.itemID = bookCategory.itemID
INNER JOIN category ON bookCategory.categoryID = category.categoryID;

--Select all book information for a single category
SELECT item.itemID, price, stockQuantity, longDescription, shortDescription, imagePath, thumbnailPath, 
ISBN, title, datePublished, secondaryTitle, isBestSeller, publisher, firstName, lastName, author.description, 
Name, category.description
FROM item 
INNER JOIN book ON item.itemID = book.itemID
INNER JOIN bookAuthor ON book.itemID = bookAuthor.itemID
INNER JOIN author ON bookAuthor.authorID = author.authorID
INNER JOIN bookCategory ON book.itemID = bookCategory.itemID
INNER JOIN category ON bookCategory.categoryID = category.categoryID
WHERE category.Name = 'category';