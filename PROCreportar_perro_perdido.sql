DELIMITER //
CREATE PROCEDURE reportar_perro_perdido(
    IN p_id_usuario INT, -- Asumiendo que necesitamos este valor
    IN p_celular INT, -- Asumiendo que necesitamos este valor
    IN p_raza VARCHAR(50),
    IN p_color VARCHAR(20),
    IN p_tamano VARCHAR(20),
    IN p_sexo CHAR(1),
    IN p_caracteristicas TEXT,
    IN p_fecha_visto DATE,
    IN p_lugar_visto VARCHAR(100),
    IN p_imagen BLOB -- Cambiando a BLOB para coincidir con la definición de la tabla
)
BEGIN
    -- Insertar el reporte del perro perdido
    INSERT INTO mascotaperdida (id_usuario, raza, color, tamaño, sexo, caracteristicas, fecha_visto, lugar_visto, celular, imagen)
    VALUES (p_id_usuario, p_raza, p_color, p_tamano, p_sexo, p_caracteristicas, p_fecha_visto, p_lugar_visto, p_celular, p_imagen);

    -- Devolver mensaje de éxito
    SELECT 'Reporte del perro perdido creado correctamente' AS notice;
END//
DELIMITER ;
