/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [id]
      ,[titulo]
      ,[descripcion]
      ,[tipo]
      ,[persona]
      ,[prioridad]
      ,[fechaLevantamiento]
      ,[estado]
      ,[calificacion]
  FROM [Sistema_Incidencias].[dbo].[incidencia]

  /*11 es Moya*/
  
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
 /***** Departamentos Académicos *****/
	('Arreglar computadora de secretaria', 'Computadora no enciende', 1, 11, 'Media', GETDATE(), 1, null)