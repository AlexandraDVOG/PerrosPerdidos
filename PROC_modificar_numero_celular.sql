DELIMITER //
CREATE PROCEDURE modificar_numero_celular(IN p_id_usuario INT, IN p_contraseña VARCHAR(255), IN p_nuevo_numero_celular VARCHAR(255))
BEGIN
    DECLARE v_usuario_actual VARCHAR(255);
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        -- Resignal the caught exception
        RESIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '500 Internal Server Error: Se produjo un error interno en el servidor al procesar la solicitud.';
    END;

    IF p_contraseña IS NULL OR p_nuevo_numero_celular IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '400 Bad Request: Se produjo un error debido a una entrada incorrecta o insuficiente, como una contraseña actual incorrecta o un nuevo número de celular o contraseña no válidos.';
    END IF;

    SELECT usuario INTO v_usuario_actual
    FROM usuario
    WHERE id_usuario = p_id_usuario AND contraseña = p_contraseña;

    IF v_usuario_actual IS NOT NULL THEN
        CALL actualizar_numero_celular(p_id_usuario, p_nuevo_numero_celular);
        SELECT CONCAT('200 OK: La solicitud se procesó correctamente y la información de contacto se actualizó con éxito para el usuario ', v_usuario_actual);
    ELSE
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '401 Unauthorized: La contraseña actual proporcionada no coincide con la del usuario, por lo que no se permite la modificación de la información.';
    END IF;
END//
DELIMITER ;
