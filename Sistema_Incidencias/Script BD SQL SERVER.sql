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
	contraseña char(20) NOT NULL,
	numeroCelular char(10) NULL,
	direccion VARCHAR(80) NOT NULL,	
	PRIMARY KEY (id)	
);


CREATE TABLE cargo_persona(
	fk_persona int NOT NULL,
	cargo VARCHAR(80) NOT NULL,
	fk_departamento int NOT NULL,

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
	titulo VARCHAR(40) not null,
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



