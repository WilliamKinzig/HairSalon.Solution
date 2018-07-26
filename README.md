# Hair Salon
##### July 19th, 2018

## William Kinzig
##### Email: wippawill2@gmail.com
##### Github: github.com/WilliamKinzig
____
#### Setup instructions:
* /Applications/MAMP/Library/bin/mysql --host=localhost -uroot -proot
* 
* mysql> SHOW DATABASES;
* mysql> CREATE DATABASE `william_kinzig`;
* mysql> USE `william_kinzig`;
* mysql> CREATE TABLE `clients` ( `Id` serial PRIMARY KEY, `Name` VARCHAR(255), `Stylist_Id` INT);
* mysql> CREATE TABLE `stylists` ( `Id` serial PRIMARY KEY, `Name` VARCHAR(255));
*
* phpMyAdmin
* select database william_kinzig, Operations tab, 'Copy database to' check 'Structure only', name it: william_kinzig_test, click 'go';
*
* dotnet add package MySqlConnector
* dotnet restore
*
* Exporting

* change the Export Method from Quick to Custom

* Make sure all of your tables are selected by choosing Select All

* Under Format leave SQL selected

* In the Output section, choose to output the database to a file, and under Compression, choose None or zipped. (Do NOT use gzipped as it has common import errors!)

* In Format-specific options leave the default selections intact

* Under 'Object creation options' tick the box for Add CREATE DATABASE/USE

* Under 'Data creation options' leave the defaults alone, make sure the radio button under Syntax to use when inserting data: is set to both of the above

* click Go

----
### Database Tables:
* | | stylist
* |---------
* | id
* | name
* | client_id


* | | client  
* |-----------
* | id
* | name
* | employee_id
------
### Specs and BDD:

* view list of stylists
* select a stylist and see their clients
* add new stylist
* add new clients
* each client only belongs to one stylist
* no adding clients if there are no stylists


|Behavior|Input|Output|
|--------|-----|------|
|GetList of Stylists|.|return stylist list|
|GetList of Clients|.|return clients list|
|Add new stylist|new name|name of stylist|
|Add new client|new name|name of client|
|delete stylist|delete stylist button|poof gone|
|delete client| delete client button|poof gone|
---
### Naming

* Production Database:
* first_last


* export file:
* first_last.sql


* Test Database:
* first_last_test


* export files:
* first_last_test.sql


* Main Project Folder:
* HairSalon


* Test Project Folder:
* HairSalon.Tests

---
### Models - Methodes

* GetId()
* GetName()
* GetStylistId()
* GetHashCode()
* Equals(System.Object otherClient)
* Save()
* Find(int id)
* GetAll()
* -
* public int GetId()
* public string GetName()
* public int GetStylistId()
* public override int GetHashCode()
* public override bool Equals(System.Object otherClient)
* public void Save()
* public static Client Find(int id)
* public static List<Client> GetAll()
