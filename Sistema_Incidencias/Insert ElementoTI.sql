/****** Script for Insert Into ElementoTI command from SSMS   ******/
SELECT TOP (1000) [id]
      ,[tipo]
      ,[marca]
      ,[modelo]
      ,[Descripcion]
      ,[garantia]
      ,[fechaCompra]
  FROM [Sistema_Incidencias].[dbo].[elementoTI]

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
(7, 'COPPEL', 'ACCESS POINT COPPEL READY', 'BANDA DE 2.4 GHZ RAM 2', 5, GETDATE())