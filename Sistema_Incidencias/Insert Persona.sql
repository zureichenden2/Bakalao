  /****** Script for Insert Into Persona command from SSMS  ******/
Use Sistema_Incidencias
Go

/**** id identity(1,1) *****/
INSERT INTO persona(
	nombre,
    apellidoPaterno,
    apellidoMaterno,
    usuario,
    contraseña,
    numeroCelular,
    direccion
)

VALUES
 /***** Jefes de departamento *****/
	('Roberto', 'León', 'Piña', 'UserRL', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Yareli Ariana', 'López', 'Arce', 'UserYareliL', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Cristal Gabriela  ', 'Ramírez', 'Escobar', 'UserCristalRamírez', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Dinorah', 'Meza', 'García', 'UserDinorahMeza', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Juan Francisco', 'Núñez', 'López', 'UserJuanNúñez', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Verónica Eblyn', 'Escalante', 'Gamboa', 'UserVerónicaEscalante', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Claudia', 'Burgos', 'De los Ríos', 'UserClaudiaBurgos', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Nohemí', 'Hidalgo', 'Beltrán', 'UserNohemíBeltran', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Fernando', 'López', 'Salas', 'UserFernandoLópez', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Gregorio', 'Camberos', 'Aguirre', 'UserGregorioCamberos', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Jorge Guillermo', 'Moya', 'Palazuelos', 'UserJorgeMoya', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('María del Rosario', 'González', 'Álvarez', 'UserMaríaGonzález', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Bertha Lucía', 'Patrón', 'Arellano', 'UserBerthaPatrón', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Carlos Rafael', 'Lizárraga', 'Arreola', 'UserCarlosLizárraga', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Paola', 'Espinoza', 'Verdugo', 'UserPaolaEspinoza', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Dora Esthela', 'García', 'Velarde', 'UserDoraGarcía', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('José Ángel', 'Alcaraz', 'Vega', 'UserJoséAlcaraz', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Jaredt Guadalupe', 'Torres', 'Lopes', 'UserJaredtTorres', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Joel Arturo', 'Sánchez', 'Borboa', 'UserJoelSánchez', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Alfredo', 'Anaya', 'Hill', 'UserAlfredoAnaya', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('María Aracely', 'Martínez', 'Amaya', 'UserMaríaMartínez', 'contra', '6673236540', 'Av. Juan de Dios Bátiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Jesus', 'Barajas', 'Villegas', 'barajin', 'enojon', '6673236540', 'Tartarus'),
	('Melissa', 'Lion', 'Leona', 'meli', 'lion', '6612938271', 'La Fama'),
	('Marco', 'Rodríguez', 'Astorga', 'admin', 'pass', '6677125132', 'Juan de Dios Bátiz')


