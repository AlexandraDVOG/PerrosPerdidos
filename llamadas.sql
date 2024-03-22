-- Insertar datos de ejemplo en las tablas

-- Insertar un administrador
INSERT INTO administradores (id_administrador, usuario, telefono, contraseña)
VALUES (1, 'admin', 123456789, 'adminpass');

-- Insertar un usuario
INSERT INTO usuario (id_usuario, numero_celular, contraseña, usuario)
VALUES (1, '555-1234', 'userpass', 'user');

-- Insertar una mascota perdida (asumiendo que el usuario con id 1 la reporta)
INSERT INTO mascotaperdida (id_mascota, id_usuario, raza, color, tamaño, sexo, celular, id_ubicacion, imagen)
VALUES (1, 1, 'Labrador', 'Negro', 'Grande', 'M', 5551234, 'Parque Central', '\x');

-- Insertar una publicación (asumiendo que la publicación es sobre la mascota perdida con id 1)
INSERT INTO publicacion (id_publicacion, id_mascota, fecha_publicacion)
VALUES (1, 1, NOW());

-- Llamadas a procedimientos

-- Registrar una mascota perdida
CALL registrar_mascota_perdida(1, 'Golden Retriever', 'Dorado', 'Mediano', 'F', 5551235, 'Parque del Este', '\x');

-- Iniciar sesión de usuario
CALL iniciar_sesion_usuario('555-1234', 'userpass');

-- Actualizar información de usuario
CALL actualizar_info_usuario(1, 'userpass', '555-4321', 'newpass');

-- Obtener publicaciones recientes (Utiliza un cursor para obtener los resultados)
BEGIN;
DECLARE recent_posts refcursor;
CALL obtener_publicaciones_recientes(recent_posts);
FETCH ALL IN recent_posts;
COMMIT;

-- Asegúrate de ajustar las llamadas a procedimientos con parámetros específicos según tus necesidades y los datos de tu entorno.

-- Nota: Para ejecutar correctamente el procedimiento que utiliza un cursor (obtener_publicaciones_recientes),
-- puede que necesites ajustar el método de llamada dependiendo de tu herramienta de administración de base de datos o entorno de desarrollo.
