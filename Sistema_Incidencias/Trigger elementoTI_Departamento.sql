Use Sistema_Incidencias
GO

Create Trigger tr_ForInserts_elementoTI_departamento
ON dbo.elementoTI_departamento --Tabla a asignar el Trigger
FOR INSERT --Evento que se desea lanzar Trigger
AS --Código a ejecutar cuando se realice un INSERT en la tabla

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
)

Set @ubicacion = 'Ubicación X'
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