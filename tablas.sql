-- Creación de la tabla administradores (si no existe)
CREATE TABLE IF NOT EXISTS administradores (
    id_administrador INT PRIMARY KEY,
    usuario VARCHAR(255),
    telefono INT,
    contraseña VARCHAR(255)
);

-- Creación de la tabla usuario (si no existe)
CREATE TABLE IF NOT EXISTS usuario (
    id_usuario INT PRIMARY KEY,
    numero_celular VARCHAR(20),
    contraseña VARCHAR(255),
    usuario VARCHAR(255)
);

-- Creación de la tabla publicacion (si no existe)
CREATE TABLE IF NOT EXISTS publicacion (
    id_publicacion INT PRIMARY KEY,
    id_mascota INT,
    fecha_publicacion TIMESTAMP
);

-- Creación de la tabla mascotaperdida (si no existe)
CREATE TABLE IF NOT EXISTS mascotaperdida (
    id_mascota INT PRIMARY KEY,
    id_usuario INT,
    raza VARCHAR(100),
    color VARCHAR(50),
    tamaño VARCHAR(20),
    sexo CHAR(1),
    celular INT,
    id_ubicacion VARCHAR(255),
    imagen BLOB
);
