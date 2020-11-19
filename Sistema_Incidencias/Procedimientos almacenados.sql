Use Sistema_Incidencias
Go

create proc ElementosTIPorDepartamento
as
Select departamento.id as 'Departamento', departamento.nombre, count(elementoTI.id) as 'Cantidad de elementos'  From elementoTI
Inner Join elementoTI_departamento
On elementoTI_departamento.fk_elementoTI = elementoTI.id
Inner Join departamento
On departamento.id = elementoTI_departamento.fk_departamento
Group By departamento.id, departamento.nombre
Order by COUNT(departamento.id) DESC
go

create proc CantidadIncidencias
as
Select incidencia_detalle.departamento, departamento.nombre, count(incidencia.id) as 'Canditad'  From incidencia
JOIN incidencia_detalle
on incidencia_detalle.fk_incidencia = incidencia.id
Join departamento
On departamento.id = incidencia_detalle.departamento
Where incidencia.estado != 6
Group by incidencia_detalle.departamento, departamento.nombre
Go

create proc verElementosTIAsignadosADepartamento
as
Select elementoTI.id as 'Id elementoTI', tipos_elementoTI.nombre, elementoTI.marca, elementoTI.modelo, elementoTI.Descripcion, elementoTI.garantia, elementoTI.fechaCompra, departamento.nombre, persona.nombre, persona.apellidoPaterno
From elementoTI
Inner Join elementoTI_departamento On elementoTI_departamento.fk_elementoTI = elementoTI.id
Inner Join departamento On departamento.id = elementoTI_departamento.fk_departamento
Inner Join persona_elementoTI on persona_elementoTI.fk_elementoTI = elementoTI.id
Inner Join persona on persona.id = persona_elementoTI.fk_persona
Inner Join tipos_elementoTI on elementoTI.tipo = tipos_elementoTI.id Where tipos_elementoTI.id = elementoTI.tipo
go












