/*Jefes de Departamentos */
Select persona.id, persona.nombre + ' ' + persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre', departamento.nombre as 'Departamento', departamento.id as 'Clave de Departamento', cargo_persona.cargo From persona
Inner Join cargo_persona
On cargo_persona.fk_persona = persona.id
Inner Join departamento
ON cargo_persona.fk_departamento = departamento.id
Where cargo LIKE '%Jefe del depto.%' or cargo LIKE '%Jefa del depto.%'


/*Jefes de talleres */
Select persona.id, persona.nombre + ' ' + persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre', departamento.nombre as 'Departamento', departamento.id as 'Clave de Departamento', cargo_persona.cargo From persona
Inner Join cargo_persona
On cargo_persona.fk_persona = persona.id
Inner Join departamento
ON cargo_persona.fk_departamento = departamento.id
Where cargo LIKE '%Jefe de Taller%' or cargo LIKE '%Jefa de Taller%'

/*T�cnicos */
Select persona.id, persona.nombre + ' ' + persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre', departamento.nombre as 'Departamento', departamento.id as 'Clave de Departamento', cargo_persona.cargo From persona
Inner Join cargo_persona
On cargo_persona.fk_persona = persona.id
Inner Join departamento
ON cargo_persona.fk_departamento = departamento.id
Where cargo LIKE '%T�cnico%' or cargo LIKE '%T�cnica%'

/*Ver Todas las personas con cargo asignado */
Select persona.id, persona.nombre + ' ' + persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre', departamento.nombre as 'Departamento', departamento.id as 'Clave de Departamento', cargo_persona.cargo From persona
Inner Join cargo_persona
On cargo_persona.fk_persona = persona.id
Inner Join departamento
ON cargo_persona.fk_departamento = departamento.id

--Script Login
Select persona.id, persona.nombre, persona.apellidoPaterno, persona.apellidoMaterno, persona.usuario, persona.contrase�a, persona.numeroCelular, persona.direccion, cargo_persona.cargo From persona
Inner Join cargo_persona
On cargo_persona.fk_persona = persona.id
Inner Join departamento
ON cargo_persona.fk_departamento = departamento.id
