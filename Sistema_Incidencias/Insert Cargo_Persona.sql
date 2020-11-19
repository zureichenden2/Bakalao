    /****** Script for Insert Into Cargo_Persona command from SSMS  ******/
Use Sistema_Incidencias
Go


INSERT INTO cargo_persona(
	fk_persona,
    cargo,
	fk_departamento
)

VALUES
 /***** Jefes de departamento *****/
(1, 'Jefe del depto. de Planeación, Programación y Presupuestación', 15),
(2, 'Jefa del depto. de Gestión Tecnológica y Vinculación', 14),
(3, 'Jefa del depto. de Comunicación y Difusión', 13),
(4, 'Jefa del depto. de Servicios Escolares', 16),
(5, 'Jefe del depto. de Actividades Extraescolares', 11),
(6, 'Jefa del depto. de Centro de Información', 12),
(7, 'Jefa del depto. de Recursos Humanos', 20),
(8, 'Jefa del depto. de Recursos Financieros', 18),
(9, 'Jefe del depto. de Recursos Materiales y Servicios', 19),
(10, 'Jefe del depto. de Mantenimiento de Equipo', 17),
(11, 'Jefe del depto. de Centro de Cómputo', 21),
(12, 'Jefa del depto. de Sistemas y Computación', 10),
(13, 'Jefa del depto. de Desarrollo Académico', 3),
(14, 'Jefe del depto. de la División de Estudios Profesionales', 4),
(15, 'Jefa del depto. de Ingeniería Química y Bioquímica', 1),
(16, 'Jefa del depto. de Ingeniería Industrial', 8),
(17, 'Jefe del depto. de Metal-Mecánica', 9),
(18, 'Jefa del depto. de Ingeniería Eléctrica-Electrónica', 7),
(19, 'Jefe del depto. de Ciencias Económico-Administrativas', 6),
(20, 'Jefe del depto. de Ciencias Básicas', 2),
(21, 'Jefa del depto. de División de Estudios de Posgrado e Investigación', 5),
(22, 'Jefe de Taller de Hardware', 1),
(23, 'Técnico', 1),
(24, 'Administrador', 1)