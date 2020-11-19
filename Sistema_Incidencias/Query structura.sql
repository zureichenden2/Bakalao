Create database Sistema_Incidencias
Go
Use Sistema_Incidencias
Go

CREATE TABLE departamento(
	id int NOT NULL identity(1,1),
	nombre VARCHAR(55) NOT NULL,
 	PRIMARY KEY (id)	
);

CREATE TABLE tipos_elementoTI(
    id int NOT NULL identity(1,1),
    nombre VARCHAR(50) not null,

    PRIMARY KEY (id)	
);

CREATE TABLE estados_incidencia(
 id int NOT NULL identity(1,1),
nombre VARCHAR(60),

PRIMARY KEY (id)	
);



CREATE TABLE tipos_incidencia(
id int NOT NULL identity(1,1),
nombre VARCHAR(30) not null,

PRIMARY KEY (id)
);



CREATE TABLE elementoTI(
	id int NOT NULL identity(1,1),
	tipo int NOT NULL,
	marca VARCHAR(30) NOT NULL,
	modelo VARCHAR(30) NOT NULL,
	Descripcion VARCHAR(200) NOT NULL,
	garantia int NOT NULL,
	fechaCompra date NOT NULL,
	PRIMARY KEY (id),

    FOREIGN KEY (tipo)
        REFERENCES tipos_elementoTI(id)
        ON DELETE CASCADE
);



CREATE TABLE persona(
	id int NOT NULL identity(1,1),
	nombre VARCHAR(50) NOT NULL,
	apellidoPaterno VARCHAR(30) NOT NULL,
	apellidoMaterno VARCHAR(30) NOT NULL,
	usuario VARCHAR(55) NOT NULL,
	contrase�a char(20) NOT NULL,
	numeroCelular char(10) NULL,
	direccion VARCHAR(80) NOT NULL,	
	PRIMARY KEY (id)	
);


CREATE TABLE cargo_persona(
	fk_persona int NOT NULL,
	cargo VARCHAR(80) NOT NULL,
	fk_departamento int NULL,

	FOREIGN KEY (fk_persona)
        REFERENCES persona(id)
        ON DELETE CASCADE,

	FOREIGN KEY (fk_departamento)
        REFERENCES departamento(id)
        ON DELETE CASCADE	
);

CREATE TABLE  elementoTI_departamento(
	fk_departamento int NOT NULL,
	fk_elementoTI int  NOT NULL,

	FOREIGN KEY (fk_departamento)
        REFERENCES departamento(id)
        ON DELETE CASCADE,

	FOREIGN KEY (fk_elementoTI)
        REFERENCES elementoTI(id)
        ON DELETE CASCADE      
);

CREATE TABLE persona_elementoTI(
	fk_persona int NOT NULL,
	fk_elementoTI int NOT NULL,
	ubicacion VARCHAR(30) NOT NULL,	
	hora_inicio int  NOT NULL,
	hora_fin int  NOT NULL,

	FOREIGN KEY (fk_persona)
        REFERENCES persona(id)
        ON DELETE CASCADE,

	FOREIGN KEY (fk_elementoTI)
        REFERENCES elementoTI(id)
        ON DELETE CASCADE
); 



CREATE TABLE servicios(
	id int NOT NULL identity(1,1),
	descripcion VARCHAR(400) NOT NULL,
	nombre VARCHAR(500) NOT NULL,
	tiempo_estimado VARCHAR(20) NULL,
	PRIMARY KEY (id)	
);


	
CREATE TABLE incidencia(
	id int NOT NULL identity(1,1),
	titulo VARCHAR(80) not null,
	descripcion VARCHAR(700) NOT NULL,
	tipo int not NULL,
	persona int NULL,
	prioridad VARCHAR(20) NOT NULL,
	fechaLevantamiento datetime NULL,	
	estado int NOT NULL,
	calificacion char(1) NULL,

	PRIMARY KEY (id),

    FOREIGN KEY (tipo)
    REFERENCES tipos_incidencia(id)
    ON DELETE CASCADE,

    FOREIGN KEY (estado)
    REFERENCES estados_incidencia(id)
    ON DELETE CASCADE


);

CREATE TABLE incidencia_detalle(
	fk_incidencia int not null,
	elementoTI int NULL,
    tipo_elementoTI int null,
	departamento int NOT NULL,
	tecnico int NULL,
	fechaInicio datetime NULL,
	fechaTerminacion datetime NULL,
	tiempoAtender VARCHAR(2) NULL,
	tiempo_estimado_Solucion VARCHAR(100) NULL,
	tiempoSolucionReal VARCHAR(20) NULL,

	FOREIGN KEY (fk_incidencia)
        REFERENCES incidencia(id)
        ON DELETE CASCADE, 

	FOREIGN KEY (elementoTI)
        REFERENCES elementoTI(id),
        
    FOREIGN KEY (tipo_elementoTI)
        REFERENCES tipos_elementoTI(id),
        

	FOREIGN KEY (departamento)
        REFERENCES departamento(id)
        ON DELETE CASCADE,    
);



CREATE TABLE incidencia_soluciones(
	fk_incidencia int not null,
    fk_elementoTI int not null,
    fk_servicio int not null,
	
	FOREIGN KEY (fk_incidencia)
        REFERENCES incidencia(id)
        ON DELETE CASCADE,

	FOREIGN KEY (fk_elementoTI)
        REFERENCES elementoTI(id)
        ON DELETE CASCADE, 

        FOREIGN KEY (fk_servicio)
        REFERENCES servicios(id)
        ON DELETE CASCADE
);


CREATE TABLE historial_incidencia(
	fk_incidencia_historial int NOT NULL,
	fk_elementoTI_historial int NOT NULL,
	fk_tecnico_historial int NOT NULL,

	FOREIGN KEY (fk_incidencia_historial)
        REFERENCES incidencia(id)
        ON DELETE CASCADE,       

	FOREIGN KEY (fk_elementoTI_historial)
        REFERENCES elementoTI(id)
        ON DELETE CASCADE,    

	FOREIGN KEY (fk_tecnico_historial)
        REFERENCES persona(id)
        ON DELETE CASCADE   
);


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'ElementosTIPorDepartamento') AND type in (N'P', N'PC'))
  DROP PROCEDURE [dbo].[ElementosTIPorDepartamento]
GO
create PROCEDURE [dbo].[ElementosTIPorDepartamento]
as
BEGIN
Select departamento.id as 'Departamento', departamento.nombre, count(elementoTI.id) as 'Cantidad de elementos'  From elementoTI
Inner Join elementoTI_departamento
On elementoTI_departamento.fk_elementoTI = elementoTI.id
Inner Join departamento
On departamento.id = elementoTI_departamento.fk_departamento
Group By departamento.id, departamento.nombre
Order by COUNT(departamento.id) DESC
END
GO	


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'CantidadIncidencias') AND type in (N'P', N'PC'))
  DROP PROCEDURE [dbo].[CantidadIncidencias]
GO
create proc [dbo].[CantidadIncidencias]
as
BEGIN
Select incidencia_detalle.departamento, departamento.nombre, count(incidencia.id) as 'Canditad'  From incidencia
JOIN incidencia_detalle
on incidencia_detalle.fk_incidencia = incidencia.id
Join departamento
On departamento.id = incidencia_detalle.departamento
Where incidencia.estado != 6
Group by incidencia_detalle.departamento, departamento.nombre
END
GO


IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'verElementosTIAsignadosADepartamento') AND type in (N'P', N'PC'))
  DROP PROCEDURE [dbo].[verElementosTIAsignadosADepartamento]
GO
create proc [dbo].[verElementosTIAsignadosADepartamento]
as
BEGIN
Select elementoTI.id as 'Id elementoTI', tipos_elementoTI.nombre, elementoTI.marca, elementoTI.modelo, elementoTI.Descripcion, elementoTI.garantia, elementoTI.fechaCompra, departamento.nombre, persona.nombre, persona.apellidoPaterno
From elementoTI
Inner Join elementoTI_departamento On elementoTI_departamento.fk_elementoTI = elementoTI.id
Inner Join departamento On departamento.id = elementoTI_departamento.fk_departamento
Inner Join persona_elementoTI on persona_elementoTI.fk_elementoTI = elementoTI.id
Inner Join persona on persona.id = persona_elementoTI.fk_persona
Inner Join tipos_elementoTI on elementoTI.tipo = tipos_elementoTI.id Where tipos_elementoTI.id = elementoTI.tipo
END
GO



Create Trigger tr_ForInserts_elementoTI_departamento
ON dbo.elementoTI_departamento --Tabla a asignar el Trigger
FOR INSERT --Evento que se desea lanzar Trigger
AS --C�digo a ejecutar cuando se realice un INSERT en la tabla

--Declarar variables
DECLARE @IdDepartamento INT
DECLARE @IdElementoTI INT

--Variables para el INSERT en persona_elementoTI
DECLARE @fk_persona INT
DECLARE @ubicacion VARCHAR(30) 
DECLARE @hora_inicio INT
DECLARE @hora_fin INT

--Asignar variables
SET @IdDepartamento = (SELECT fk_departamento FROM Inserted)
SET @IdElementoTI = (SELECT fk_elementoTI FROM Inserted)

Set @fk_persona = 
(
Select persona.id From persona
Inner Join cargo_persona
On cargo_persona.fk_persona = persona.id
Inner Join departamento
ON cargo_persona.fk_departamento = departamento.id
Inner Join inserted
On cargo_persona.fk_departamento = inserted.fk_departamento
where cargo_persona.fk_departamento IS NOT NULL
)

Set @ubicacion = 'Ubicaci�n X'
Set @hora_inicio = 9
Set @hora_fin = 10


BEGIN 
  SET NOCOUNT ON;
  INSERT INTO
   persona_elementoTI
        (
            fk_persona,
            fk_elementoTI,
            ubicacion,
            hora_inicio,
            hora_fin
        )
		
		VALUES (@fk_persona, @IdElementoTI, @ubicacion, @hora_inicio, @hora_fin)		
END


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
	('Centro de C�mputo');
	GO

	INSERT INTO persona(
	nombre,
    apellidoPaterno,
    apellidoMaterno,
    usuario,
    contrase�a,
    numeroCelular,
    direccion
)

VALUES
 /***** Jefes de departamento *****/
	('Roberto', 'Le�n', 'Pi�a', 'UserRL', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Yareli Ariana', 'L�pez', 'Arce', 'UserYareliL', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Cristal Gabriela  ', 'Ram�rez', 'Escobar', 'UserCristalRam�rez', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Dinorah', 'Meza', 'Garc�a', 'UserDinorahMeza', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Juan Francisco', 'N��ez', 'L�pez', 'UserJuanN��ez', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Ver�nica Eblyn', 'Escalante', 'Gamboa', 'UserVer�nicaEscalante', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Claudia', 'Burgos', 'De los R�os', 'UserClaudiaBurgos', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Nohem�', 'Hidalgo', 'Beltr�n', 'UserNohem�Beltran', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Fernando', 'L�pez', 'Salas', 'UserFernandoL�pez', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Gregorio', 'Camberos', 'Aguirre', 'UserGregorioCamberos', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Jorge Guillermo', 'Moya', 'Palazuelos', 'UserJorgeMoya', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Mar�a del Rosario', 'Gonz�lez', '�lvarez', 'UserMar�aGonz�lez', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Bertha Luc�a', 'Patr�n', 'Arellano', 'UserBerthaPatr�n', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Carlos Rafael', 'Liz�rraga', 'Arreola', 'UserCarlosLiz�rraga', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Paola', 'Espinoza', 'Verdugo', 'UserPaolaEspinoza', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Dora Esthela', 'Garc�a', 'Velarde', 'UserDoraGarc�a', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Jos� �ngel', 'Alcaraz', 'Vega', 'UserJos�Alcaraz', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Jaredt Guadalupe', 'Torres', 'Lopes', 'UserJaredtTorres', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Joel Arturo', 'S�nchez', 'Borboa', 'UserJoelS�nchez', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Alfredo', 'Anaya', 'Hill', 'UserAlfredoAnaya', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Mar�a Aracely', 'Mart�nez', 'Amaya', 'UserMar�aMart�nez', 'contra', '6673236540', 'Av. Juan de Dios B�tiz 310 Pte. Col. Guadalupe, C.P. 80220.'),
	('Jesus', 'Barajas', 'Villegas', 'barajin', 'enojon', '6673236540', 'Tartarus'),
	('Melissa', 'Lion', 'Leona', 'meli', 'lion', '6612938271', 'La Fama'),
	('Marco', 'Rodr�guez', 'Astorga', 'admin', 'pass', '6677125132', 'Juan de Dios B�tiz'),
	('Julissa', 'Villanueva', 'Romero', 'juli', 'pass', '6677125132', 'Juan de Dios B�tiz'),
	('Andrea', 'Valencia', 'Pfeifer', 'andrea', 'pass', '6677125132', 'Juan de Dios B�tiz'),
	('Mart�n', 'Nevarez', 'Nevarez', 'martin', 'nevarez', '6677125132', 'Juan de Dios B�tiz'),
	('Luis', 'Bola�os', 'Liz�rraga', 'bola�os', 'pass', '6677125132', 'Juan de Dios B�tiz');
	GO



INSERT INTO cargo_persona(
	fk_persona,
    cargo,
	fk_departamento
)

VALUES
 /***** Jefes de departamento *****/
(1, 'Jefe del depto. de Planeaci�n, Programaci�n y Presupuestaci�n', 15),
(2, 'Jefa del depto. de Gesti�n Tecnol�gica y Vinculaci�n', 14),
(3, 'Jefa del depto. de Comunicaci�n y Difusi�n', 13),
(4, 'Jefa del depto. de Servicios Escolares', 16),
(5, 'Jefe del depto. de Actividades Extraescolares', 11),
(6, 'Jefa del depto. de Centro de Informaci�n', 12),
(7, 'Jefa del depto. de Recursos Humanos', 20),
(8, 'Jefa del depto. de Recursos Financieros', 18),
(9, 'Jefe del depto. de Recursos Materiales y Servicios', 19),
(10, 'Jefe del depto. de Mantenimiento de Equipo', 17),
(11, 'Jefe del depto. de Centro de C�mputo', 21),
(12, 'Jefa del depto. de Sistemas y Computaci�n', 10),
(13, 'Jefa del depto. de Desarrollo Acad�mico', 3),
(14, 'Jefe del depto. de la Divisi�n de Estudios Profesionales', 4),
(15, 'Jefa del depto. de Ingenier�a Qu�mica y Bioqu�mica', 1),
(16, 'Jefa del depto. de Ingenier�a Industrial', 8),
(17, 'Jefe del depto. de Metal-Mec�nica', 9),
(18, 'Jefa del depto. de Ingenier�a El�ctrica-Electr�nica', 7),
(19, 'Jefe del depto. de Ciencias Econ�mico-Administrativas', 6),
(20, 'Jefe del depto. de Ciencias B�sicas', 2),
(21, 'Jefa del depto. de Divisi�n de Estudios de Posgrado e Investigaci�n', 5),
(22, 'Jefe de Taller de Hardware', null),
(23, 'T�cnico en Hardware', null),
(24, 'Administrador', null),
(25, 'T�cnico en Software', null),
(26, 'T�cnico en Redes', null),
(27, 'Jefe de Taller de Software', null),
(28, 'Jefe de Taller de Redes', null);

GO

INSERT INTO tipos_elementoTI(
	nombre
)
VALUES
 /***** Elementos de TI *****/
('Computadora'),
('Servidor'),
('Laptop'),
('Proyector'),
('Mouse'),
('Teclado'),
('Access Point');
GO

INSERT INTO elementoTI(
	tipo,
	marca,
	modelo,
	Descripcion,
	garantia,
	fechaCompra
)

VALUES
 /***** Elementos de TI *****/
(1, 'DELL', 'Optiplex 7040', 'PROCESADOR INTEL CORE I7 6700 DE 6TH 8 GB DE RAM 2 TB DE DISCO DURO', 1, GETDATE()),
(2, 'CISCO', 'SERVIDOR CISCO 2040', 'PROCESADOR INTEL CORE I9 6700 DE 6TH', 2, GETDATE()),
(3, 'ALIENWARE', 'LAPTOP ALIENWARE A40X', 'PROCESADOR INTEL CORE I20 14000 DE 6TH 92 GB DE RAM 200 TB DE DISCO DURO', 2, GETDATE()),
(4, 'CANON', 'PROYECTOR CANON WIDE', 'RGB', 3, GETDATE()),
(7, 'COPPEL', 'ACCESS POINT COPPEL READY', 'BANDA DE 2.4 GHZ RAM 2', 5, GETDATE());
GO

/****** Script for Insert Into Tipos_incidencia command from SSMS  ******/
  INSERT INTO tipos_incidencia(
	nombre
)

VALUES
 /***** Tipos de incidencia *****/
('Hardware'),
('Software'),
('Redes'),
('Otros');
GO


/**** id identity(1,1) *****/
INSERT INTO estados_incidencia(
	nombre
)

VALUES
 /***** Departamentos Acad�micos *****/
	('Abierta'),
	('Aprobada'), 
	('Rechazada'), 
	('En Curso'), 
	('Finalizada'), 
	('Liberada');
GO

	


Insert Into elementoTI_departamento
Values (21, 1);
GO

Insert Into elementoTI_departamento
Values (21, 2);
GO

Insert Into elementoTI_departamento
Values 	   (10, 3);
GO

Insert Into elementoTI_departamento
Values 	   (15, 4);
GO

Insert Into elementoTI_departamento
Values (15, 5);
GO



INSERT INTO incidencia(
	titulo,
	descripcion,
	tipo,
	persona,
	prioridad,
	fechaLevantamiento,
	estado,
	calificacion
)

VALUES
 /***** Departamentos Acad�micos *****/
	('Arreglar computadora de secretaria', 'Computadora no enciende', 1, 11, 'Media', GETDATE(), 1, null),
	('Programar software para control de kardex', 'Necesito un software de control', 2, 19, 'Alta', GETDATE(), 1, null),
	('Red WiFi lenta', 'Red lenta', 3, 20, 'Alta', GETDATE(), 1, null);
GO

Insert Into incidencia_detalle(
	fk_incidencia,
	elementoTI,
	tipo_elementoTI,
	departamento,
	tecnico,
	fechaInicio,
	fechaTerminacion,
	tiempoAtender,
	tiempo_estimado_Solucion,
	tiempoSolucionReal
)

Values(1, 1, 1, 21, null, null, null, null, null, null),
	  (2, null, null, 6, null, null, null, null, null, null),
      (3, null, null, 2, null, null, null, null, null, null);
GO