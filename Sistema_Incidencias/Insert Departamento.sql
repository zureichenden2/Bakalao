/****** Script for Insert Into Departamento command from SSMS  ******/
Use Sistema_Incidencias
Go

/**** id identity(1,1) *****/
INSERT INTO departamento(
	nombre
)

VALUES
 /***** Departamentos Académicos *****/
	('Ingeniería Química-Bioquímica'),
	('Ciencias Básicas'),
	('Desarrollo Académico'),
	('División de Estudios Profesionales'),
	('División de Estudios de Posgrado e Investigación'),
	('Ciencias Económico-Administrativas'),
	('Eléctrica-Electrónica'),
	('Industrial'),
	('Metal-Mecánica'),
	('Sistemas y Computación'),

 /***** Departamentos de Planeación y Vinculación *****/
	('Promoción Cultural y Deportiva'),
	('Centro de Información'),
	('Comunicación y Difusión'),
	('Gestión Tecnológica y Vinculación'),
	('Planeación, Programación y Presupuestación'),
	('Servicios Escolares'),

 /***** Departamentos de Servicios Administrativos *****/
	('Mantenimiento y Equipo'),
	('Recursos Financieros'),
	('Recursos Materiales y Servicios'),
	('Recursos Humanos'),
	('Centro de Cómputo')