CREATE TABLE IF NOT EXISTS CONTACT
( 
  ID INTEGER IDENTITY(1,1) NOT NULL primary key, /* El primer 1 és d'on comença el camp i el segon 1 és quan incrementa a cada instància */
  NOM VARCHAR(30),
  EMAIL VARCHAR(60)
 );