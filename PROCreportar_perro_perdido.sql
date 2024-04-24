DELIMITER //
CREATE PROCEDURE reportar_perro_perdido(
    IN p_id_usuario INT,
    IN p_celular INT,
    IN p_raza VARCHAR(50),
    IN p_color VARCHAR(20),
    IN p_tamano VARCHAR(20),
    IN p_sexo CHAR(1),
    IN p_caracteristicas TEXT,
    IN p_fecha_visto DATE,
    IN p_lugar_visto VARCHAR(100),
    IN p_imagen BLOB
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        -- Resignal the caught exception
        RESIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '500 Internal Server Error: Se produjo un error interno en el servidor al procesar la solicitud.';
    END;

    IF p_id_usuario IS NULL OR p_celular IS NULL OR p_raza IS NULL OR p_color IS NULL OR p_tamano IS NULL OR p_sexo IS NULL OR p_caracteristicas IS NULL OR p_fecha_visto IS NULL OR p_lugar_visto IS NULL OR p_imagen IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '400 Bad Request: Se produjo un error debido a una entrada incorrecta o insuficiente, como campos obligatorios faltantes o datos incorrectos.';
    END IF;

    -- Insertar el reporte del perro perdido
    INSERT INTO mascotaperdida (id_usuario, raza, color, tamaño, sexo, caracteristicas, fecha_visto, lugar_visto, celular, imagen)
    VALUES (p_id_usuario, p_raza, p_color, p_tamano, p_sexo, p_caracteristicas, p_fecha_visto, p_lugar_visto, p_celular, p_imagen);

    -- Devolver mensaje de éxito
    SELECT '201 Created: El reporte del perro perdido se ha creado correctamente' AS notice;
END//
DELIMITER ;
