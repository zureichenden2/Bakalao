/****** Script for Insert Into Departamento command from SSMS  ******/
Use Sistema_Incidencias
Go

/**** id identity(1,1) *****/
INSERT INTO departamento(
	nombre
)

VALUES
 /***** Departamentos Acad�micos *****/
	('Ingenier�a Qu�mica-Bioqu�mica'),
	('Ciencias B�sicas'),
	('Desarrollo Acad�mico'),
	('Divisi�n de Estudios Profesionales'),
	('Divisi�n de Estudios de Posgrado e Investigaci�n'),
	('Ciencias Econ�mico-Administrativas'),
	('El�ctrica-Electr�nica'),
	('Industrial'),
	('Metal-Mec�nica'),
	('Sistemas y Computaci�n'),

 /***** Departamentos de Planeaci�n y Vinculaci�n *****/
	('Promoci�n Cultural y Deportiva'),
	('Centro de Informaci�n'),
	('Comunicaci�n y Difusi�n'),
	('Gesti�n Tecnol�gica y Vinculaci�n'),
	('Planeaci�n, Programaci�n y Presupuestaci�n'),
	('Servicios Escolares'),

 /***** Departamentos de Servicios Administrativos *****/
	('Mantenimiento y Equipo'),
	('Recursos Financieros'),
	('Recursos Materiales y Servicios'),
	('Recursos Humanos'),
	('Centro de C�mputo')