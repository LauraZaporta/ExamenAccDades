CREATE TABLE IF NOT EXISTS CONTACT
( 
  ID INTEGER IDENTITY(1,1) NOT NULL primary key, /* El primer 1 �s d'on comen�a el camp i el segon 1 �s quan incrementa a cada inst�ncia */
  NOM VARCHAR(30),
  EMAIL VARCHAR(60)
 );