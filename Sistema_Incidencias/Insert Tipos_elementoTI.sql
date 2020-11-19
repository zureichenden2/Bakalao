/****** Script for Insert Into Tipos_elementoTI command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[nombre]
  FROM [Sistema_Incidencias].[dbo].[tipos_elementoTI]

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
('Access Point')