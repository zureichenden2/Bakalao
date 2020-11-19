/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [fk_incidencia]
      ,[elementoTI]
      ,[tipo_elementoTI]
      ,[departamento]
      ,[tecnico]
      ,[fechaInicio]
      ,[fechaTerminacion]
      ,[tiempoAtender]
      ,[tiempo_estimado_Solucion]
      ,[tiempoSolucionReal]
  FROM [Sistema_Incidencias].[dbo].[incidencia_detalle]

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

  Values(1, 1, 1, 21, null, null, null, null, null, null)