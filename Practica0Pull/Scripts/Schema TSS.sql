CREATE DATABASE TSS;
USE TSS;

CREATE TABLE Nomina(
	Id int primary key identity(1,1),
	Tipo_Registro char(1),
	RNC varchar(9),
	Periodo_Nomina varchar(10)
);

CREATE TABLE Detalle_Nomina(
	Id int primary key identity(1,1),
	Tipo_Registro char(1),
	Cedula_Empleado varchar(11),
	Sueldo bigint,
	Numero_TSS int
);

