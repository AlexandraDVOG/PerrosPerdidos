DELIMITER //
CREATE PROCEDURE registrar_mascota_perdida(
    IN p_id_usuario INT,
    IN p_raza VARCHAR(100), -- Ajustado al tamaño según tu definición de tabla
    IN p_color VARCHAR(50), -- Ajustado al tamaño según tu definición de tabla
    IN p_tamaño VARCHAR(20), -- Asegurándose de que el tamaño se ajuste y usando minúsculas
    IN p_sexo CHAR(1),
    IN p_celular INT,
    IN p_id_ubicacion VARCHAR(255), -- Ajustado al tamaño según tu definición de tabla
    IN p_imagen BLOB
)
BEGIN
    INSERT INTO mascotaperdida (id_usuario, raza, color, tamaño, sexo, celular, id_ubicacion, imagen)
    VALUES (p_id_usuario, p_raza, p_color, p_tamaño, p_sexo, p_celular, p_id_ubicacion, p_imagen);
END//
DELIMITER ;
