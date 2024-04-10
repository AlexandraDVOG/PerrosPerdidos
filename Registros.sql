-- Insertar registros en la tabla administradores
INSERT INTO administradores (id_administrador, usuario, telefono, contraseña) VALUES
(1, 'admin1', 5512345678, 'password1'),
(2, 'admin2', 5523456789, 'password2'),
(3, 'admin3', 5534567890, 'password3'),
(4, 'admin4', 5545678901, 'password4'),
(5, 'admin5', 5556789012, 'password5');

-- Insertar registros en la tabla usuario
INSERT INTO usuario (id_usuario, numero_celular, contraseña, usuario) VALUES
(1, '5567890123', 'password1', 'user1'),
(2, '5578901234', 'password2', 'user2'),
(3, '5589012345', 'password3', 'user3'),
(4, '5590123456', 'password4', 'user4'),
(5, '5501234567', 'password5', 'user5');

-- Insertar registros en la tabla publicacion
INSERT INTO publicacion (id_publicacion, id_mascota, fecha_publicacion) VALUES
(1, 1, NOW()),
(2, 2, NOW()),
(3, 3, NOW()),
(4, 4, NOW()),
(5, 5, NOW());

-- Insertar registros en la tabla mascotaperdida
INSERT INTO mascotaperdida (id_mascota, id_usuario, raza, color, tamaño, sexo, celular, id_ubicacion, imagen) VALUES
(1, 1, 'Labrador', 'Negro', 'Grande', 'M', 5512345678, 'Ciudad de México', NULL),
(2, 2, 'Chihuahua', 'Blanco', 'Mini', 'F', 5523456789, 'Guadalajara', NULL),
(3, 3, 'Poodle', 'Café', 'Mediano', 'M', 5534567890, 'Monterrey', NULL),
(4, 4, 'Bulldog', 'Gris', 'Grande', 'F', 5545678901, 'Puebla', NULL),
(5, 5, 'Schnauzer', 'Plata', 'Gigante', 'M', 5556789012, 'Cancún', NULL);
