INSERT INTO Encabezados VALUES('E','123456789','02/12/2012'),('E','147852369','21/10/2017'),
								('E','258753951','22/02/2017'),('E','823971456','25/07/2018');

								SELECT * FROM Encabezados;

INSERT INTO Detalles VALUES('D','12345678900','45000','0123456789'),('D','01234567891','65520','147852369'),
('D','85296314778','21000','123456789'),('D','01234567890','95000','258963654'),
('D','741258963','120000','1598523578');

DELETE Detalles WHERE Id = 5;

ALTER TABLE Detalles
ALTER COLUMN Numero_TSS varchar(9);

SELECT * FROM Detalles;

INSERT INTO EncabezadoDetalle VALUES(1,1),(1,2),(1,3),(2,4);

SELECT * FROM EncabezadoDetalle;


--Encabezado
SELECT Tipo_Registro, RNC, Periodo_Nomina FROM Encabezados WHERE Periodo_Nomina = '02/12/2012';

--Detalles
SELECT d.Tipo_Registro, d.Cedula, d.Sueldo_Bruto, d.Numero_TSS
FROM Detalles AS d
INNER JOIN EncabezadoDetalle AS ed ON ed.DetalleId = d.Id
INNER JOIN Encabezados        AS e  ON e.Id = ed.EncabezadoId
WHERE e.Periodo_Nomina = '02/12/2012';

--Sumario
SELECT  COUNT(d.Id) AS Total_Empleados, SUM(d.Sueldo_Bruto) AS Total_Nomina
FROM Detalles AS d
INNER JOIN EncabezadoDetalle AS ed ON ed.DetalleId = d.Id
INNER JOIN Encabezados        AS e  ON e.Id = ed.EncabezadoId
WHERE e.Periodo_Nomina = '02/12/2012';


