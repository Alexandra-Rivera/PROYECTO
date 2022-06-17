CREATE DATABASE PROYECTO_FINAL_v3;
GO
USE PROYECTO_FINAL_v3;
GO

CREATE TABLE TIPO_COLECCION(
id_tipo_coleccion INT PRIMARY KEY not null,
n_tipo_coleccion VARCHAR(50) not null
);

CREATE TABLE COLECCION(
id_coleccion INT PRIMARY KEY not null,
n_coleccion VARCHAR(50) not null,
id_tipo_coleccion INT not null
);

CREATE TABLE GENERO_COLECCION(
id_genero_coleccion INT PRIMARY KEY not null,
g_genero_coleccion VARCHAR(50) not null,
id_coleccion INT not null
);

CREATE TABLE EDITORIAL_EJEMPLAR(
id_editorial_ejemplar INT PRIMARY KEY not null,
n_editorial_ejemplar VARCHAR(50) not null
);

CREATE TABLE EJEMPLAR(
codigo_ejemplar INT PRIMARY KEY not null,
f_p_ejemplar DATETIME not null,
idioma_ejemplar VARCHAR(50) not null,
n_ejemplar VARCHAR(50) not null,
id_editorial_ejemplar INT not null,
id_coleccion INT not null,
carnet_usuario INT not null
);

CREATE TABLE FORMATO_EJEMPLAR(
id_formato_ejemplar INT PRIMARY KEY not null,
digital_formato_ejemplar VARCHAR(50) not null,
fisico_formato_ejemplar VARCHAR(50) not null,
codigo_ejemplar INT not null
);

CREATE TABLE GENERO_EJEMPLAR(
id_genero_ejemplar INT PRIMARY KEY not null,
g_genero_ejemplar VARCHAR(50) not null,
codigo_ejemplar INT not null
);

CREATE TABLE AUTOR_EJEMPLAR(
id_autor_ejemplar INT PRIMARY KEY not null,
a_autor_ejemplar VARCHAR(50) not null,
codigo_ejemplar INT not null
);

CREATE TABLE IDENTIFICADOR_EJEMPLAR(
id_identificador_ejemplar INT PRIMARY KEY not null,
iden_identificador_ejemplar INT not null,
codigo_ejemplar INT not null
);

CREATE TABLE OCUPACION_USUARIO(
id_ocupacion_usuario INT PRIMARY KEY not null,
n_ocupacion_usuario VARCHAR(50) not null
);

CREATE TABLE INSTITUTO_USUARIO(
id_instituto_usuario INT PRIMARY KEY not null,
n_instituto_usuario VARCHAR(50) not null
);

CREATE TABLE SESION(
id_sesion INT PRIMARY KEY not null,
f_h_inicio_sesion DATETIME not null,
f_h_cierre_sesion DATETIME not null
);

CREATE TABLE USUARIO(
carnet_usuario INT PRIMARY KEY not null,
email_usario VARCHAR(50) not null,
direccion_usuario VARCHAR(50) not null,
rol_usuario VARCHAR(50) not null,
n_usuario VARCHAR(50) not null,
id_ocupacion_usuario INT not null,
id_instituto_usuario INT not null,
id_evento INT not null,
codigo_ejemplar INT not null,
id_sesion INT not null
);

--EN LA TABLA DE USUARIO FALTA ANEXAR LA RELACION ESTIPULADA CON LA ENTIDAD AREA, EN LA CUAL SE VERA QUIEN PASA A QUIEN COMO FK

CREATE TABLE FOTOGRAFIA_USUARIO(
id_fotografia_usuario INT PRIMARY KEY not null,
carnet_usuario INT not null
);

CREATE TABLE TELEFONO_USUARIO(
id_telefono_usuario INT PRIMARY KEY not null,
tel_telefono_usuario VARCHAR(12) not null,
carnet_usuario INT not null
);

CREATE TABLE USUARIO_x_EVENTO(
carnet_usuario INT not null,
id_evento INT not null,
PRIMARY KEY CLUSTERED (carnet_usuario, id_evento)
);

CREATE TABLE EVENTO(
id_evento INT PRIMARY KEY not null,
titulo_evento VARCHAR(50) not null,
objetivo_evento VARCHAR(50) not null,
cantidad_evento INT not null, --EN ESTE APARTADO HAY DUDAS CON LO QUE ES EL TIPO DE VARIABLE
);

CREATE TABLE HORARIO_EVENTO(
id_horario_evento INT PRIMARY KEY not null,
f_h_inicio_horario_evento DATETIME not null,
f_h_final_horario_evento DATETIME not null,
id_evento INT not null
);

CREATE TABLE EVENTO_x_AREA(
id_evento INT not null,
id_area INT not null,
PRIMARY KEY CLUSTERED (id_evento, id_area)
);

CREATE TABLE AREA(
id_area INT PRIMARY KEY not null,
n_area VARCHAR(50) not null,
horario_area DATETIME not null,
n_r_area VARCHAR(50) not null
);

CREATE TABLE DESCRIPCION(
id_descripcion INT PRIMARY KEY not null,
n_descripcion VARCHAR(50) not null,
capacidad_descripcion VARCHAR(50) not null,
id_area INT not null
);

GO

ALTER TABLE COLECCION
ADD CONSTRAINT fk_COLECCIONxTIPO_COLECCION
FOREIGN KEY (id_tipo_coleccion) REFERENCES TIPO_COLECCION (id_tipo_coleccion)
;

ALTER TABLE GENERO_COLECCION
ADD CONSTRAINT fk_GENERO_COLECCIONxCOLECCION
FOREIGN KEY (id_coleccion) REFERENCES COLECCION (id_coleccion)
;

ALTER TABLE EJEMPLAR
ADD CONSTRAINT fk_EJEMPLARxEDITORIAL_EJEMPLAR
FOREIGN KEY (id_editorial_ejemplar) REFERENCES EDITORIAL_EJEMPLAR (id_editorial_ejemplar)
;

ALTER TABLE EJEMPLAR
ADD CONSTRAINT fk_EJEMPLARxCOLECCION
FOREIGN KEY (id_coleccion) REFERENCES COLECCION (id_coleccion)
;

ALTER TABLE EJEMPLAR
ADD CONSTRAINT fk_EJEMPLARxUSUARIO
FOREIGN KEY (carnet_usuario) REFERENCES USUARIO (carnet_usuario)
;

ALTER TABLE FORMATO_EJEMPLAR
ADD CONSTRAINT fk_FORMATO_EJEMPLARxEJEMPLAR
FOREIGN KEY (codigo_ejemplar) REFERENCES EJEMPLAR (codigo_ejemplar)
;

ALTER TABLE GENERO_EJEMPLAR
ADD CONSTRAINT fk_GENERO_EJEMPLARxEJEMPLAR
FOREIGN KEY (codigo_ejemplar) REFERENCES EJEMPLAR (codigo_ejemplar)
;

ALTER TABLE AUTOR_EJEMPLAR
ADD CONSTRAINT fk_AUTOR_EJEMPLARxEJEMPLAR
FOREIGN KEY (codigo_ejemplar) REFERENCES EJEMPLAR (codigo_ejemplar)
;

ALTER TABLE IDENTIFICADOR_EJEMPLAR
ADD CONSTRAINT fk_IDENTIFICADOR_EJEMPLARxEJEMPLAR
FOREIGN KEY (codigo_ejemplar) REFERENCES EJEMPLAR (codigo_ejemplar)
;

ALTER TABLE USUARIO
ADD CONSTRAINT fk_USUARIOxOCUPACION_USUARIO
FOREIGN KEY (id_ocupacion_usuario) REFERENCES OCUPACION_USUARIO (id_ocupacion_usuario)
;

ALTER TABLE USUARIO
ADD CONSTRAINT fk_USUARIOxINSTITUTO_USUARIO
FOREIGN KEY (id_instituto_usuario) REFERENCES INSTITUTO_USUARIO (id_instituto_usuario)
;

ALTER TABLE USUARIO
ADD CONSTRAINT fk_USUARIOxEVENTO
FOREIGN KEY (id_evento) REFERENCES EVENTO (id_evento)
;

ALTER TABLE USUARIO
ADD CONSTRAINT fk_USUARIOxEJEMPLAR
FOREIGN KEY (codigo_ejemplar) REFERENCES EJEMPLAR (codigo_ejemplar)
;

ALTER TABLE FOTOGRAFIA_USUARIO
ADD CONSTRAINT fk_FOTOGRAFIA_USUARIOxUSUARIO
FOREIGN KEY (carnet_usuario) REFERENCES USUARIO (carnet_usuario)
;

ALTER TABLE TELEFONO_USUARIO
ADD CONSTRAINT fk_TELEFONO_USUARIOxUSUARIO
FOREIGN KEY (carnet_usuario) REFERENCES USUARIO (carnet_usuario)
;

ALTER TABLE USUARIO_x_EVENTO
ADD CONSTRAINT fk_USUARIO_x_EVENTOxUSUARIO
FOREIGN KEY (carnet_usuario) REFERENCES USUARIO (carnet_usuario)
;

ALTER TABLE USUARIO_x_EVENTO
ADD CONSTRAINT fk_USUARIO_x_EVENTOxEVENTO
FOREIGN KEY (id_evento) REFERENCES EVENTO (id_evento)
;

ALTER TABLE HORARIO_EVENTO
ADD CONSTRAINT fk_HORARIO_EVENTOxEVENTO
FOREIGN KEY (id_evento) REFERENCES EVENTO (id_evento)
;

ALTER TABLE EVENTO_x_AREA
ADD CONSTRAINT fk_EVENTO_x_AREAxEVENTO
FOREIGN KEY (id_evento) REFERENCES EVENTO (id_evento)
;

ALTER TABLE EVENTO_x_AREA
ADD CONSTRAINT fk_EVENTO_x_AREAxAREA
FOREIGN KEY (id_area) REFERENCES AREA (id_area)
;

ALTER TABLE DESCRIPCION
ADD CONSTRAINT fk_DESCRIPCIONxAREA
FOREIGN KEY (id_area) REFERENCES AREA (id_area)
;





SELECT *
	FROM TIPO_COLECCION;

SELECT *
	FROM COLECCION;

SELECT *
	FROM GENERO_COLECCION;

SELECT *
	FROM EDITORIAL_EJEMPLAR;

SELECT *
	FROM EJEMPLAR;

SELECT *
	FROM FORMATO_EJEMPLAR;

SELECT *
	FROM GENERO_EJEMPLAR;

SELECT *
	FROM AUTOR_EJEMPLAR;

SELECT *
	FROM IDENTIFICADOR_EJEMPLAR;

SELECT *
	FROM OCUPACION_USUARIO;

SELECT *
	FROM INSTITUTO_USUARIO;

SELECT *
	FROM SESION;

SELECT *
	FROM USUARIO;

SELECT *
	FROM FOTOGRAFIA_USUARIO;

SELECT *
	FROM TELEFONO_USUARIO;

SELECT *
	FROM USUARIO_x_EVENTO;

SELECT *
	FROM EVENTO;

SELECT *
	FROM HORARIO_EVENTO;

SELECT *
	FROM EVENTO_x_AREA;

SELECT *
	FROM AREA;

SELECT *
	FROM DESCRIPCION;