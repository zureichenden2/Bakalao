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
(22, 'Jefe de Taller de Hardware', 1),
(23, 'T�cnico', 1),
(24, 'Administrador', 1)