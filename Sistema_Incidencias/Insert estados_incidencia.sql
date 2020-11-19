/****** Script for Insert into estados_incidencia command from SSMS  ******/
Use Sistema_Incidencias
Go

/**** id identity(1,1) *****/
INSERT INTO estados_incidencia(
	nombre
)

VALUES
 /***** Departamentos Académicos *****/
	('Abierta'),
	('Aprobada'), 
	('Rechazada'), 
	('En Curso'), 
	('Finalizada'), 
	('Liberada')