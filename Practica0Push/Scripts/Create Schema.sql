CREATE DATABASE FerreteriaAmericana;

Use FerreteriaAmericana;

CREATE TABLE Encabezados(
	Id int primary key identity(1,1),
	Tipo_Registro char(1),
	RNC varchar(9),
	Periodo_Nomina varchar(10)
);

CREATE TABLE Detalles(
	Id int primary key identity(1,1),
	Tipo_Registro char(1),
	Cedula varchar(11),
	Sueldo_Bruto bigint,
	Numero_TSS int
);

CREATE TABLE EncabezadoDetalle(
	Id int primary key identity(1,1),
	EncabezadoId int,
	DetalleId int,
	CONSTRAINT FK_Encabezado FOREIGN KEY (EncabezadoId) REFERENCES Encabezados(Id),
	CONSTRAINT FK_Detalle FOREIGN KEY (DetalleId) REFERENCES Detalles(Id) 
);


