DELIMITER //
CREATE PROCEDURE modificar_caracteristicas_perro_perdido(
    IN p_id_mascota INT,
    IN p_nuevas_caracteristicas TEXT
)
BEGIN
    DECLARE v_id_mascota_actual INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        -- Resignal the caught exception
        RESIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '500 Internal Server Error: Se produjo un error interno en el servidor al procesar la solicitud.';
    END;

    IF p_nuevas_caracteristicas IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '400 Bad Request: Se produjo un error debido a una entrada incorrecta o insuficiente, como campos obligatorios faltantes o datos incorrectos.';
    END IF;

    SELECT id_mascota INTO v_id_mascota_actual
    FROM mascotaperdida
    WHERE id_mascota = p_id_mascota;

    IF v_id_mascota_actual IS NOT NULL THEN
        UPDATE mascotaperdida
        SET caracteristicas = p_nuevas_caracteristicas
        WHERE id_mascota = p_id_mascota;
        SELECT '200 OK: Las características del perro perdido se han modificado correctamente' AS notice;
    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '404 Not Found: No se encontró el perro perdido con el ID proporcionado.';
    END IF;
END//
DELIMITER ;
