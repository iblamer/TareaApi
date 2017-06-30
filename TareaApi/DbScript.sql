Create database CobrosDb

USE CobrosDb

CREATE TABLE Cobros(
IdCobro INT PRIMARY KEY IDENTITY (1,1),
Fecha DATETIME,
Referencia VARCHAR(50),
IdRemoto INT,
IdRuta INT,
Mora MONEY,
Monto MONEY,
Latitud DECIMAL,
Longitud DECIMAL,
EsNulo BIT
)

INSERT INTO Cobros(Fecha, Referencia, IdRemoto, IdRuta, Mora, Monto, Longitud, Latitud, EsNulo)
VALUES ('20110712', 'Tres', 1, 2, 500, 10020, 10020, 2000, 0)
INSERT INTO Cobros(Fecha, Referencia, IdRemoto, IdRuta, Mora, Monto, Longitud, Latitud, EsNulo)
VALUES ('20171212', 'Uno', 5, 12, 5100, 1012300, 1123, 2231, 0)
INSERT INTO Cobros(Fecha, Referencia, IdRemoto, IdRuta, Mora, Monto, Longitud, Latitud, EsNulo)
VALUES ('20171121', 'Uno', 10, 21, 5001, 10020, 10300, 20500, 1)

select * from Cobros

