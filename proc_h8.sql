DELIMITER //
CREATE PROCEDURE eliminar_cuenta_usuario(IN p_id_usuario INT, IN p_confirmacion BOOLEAN)
BEGIN
    DECLARE v_es_admin BOOLEAN;

    SELECT EXISTS(SELECT 1 FROM administradores WHERE id_usuario = p_id_usuario) INTO v_es_admin;

    IF NOT v_es_admin THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario no tiene los permisos adecuados para eliminar la cuenta.';
    ELSEIF NOT p_confirmacion THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Confirmación de eliminación requerida.';
    ELSE
        DELETE FROM usuario WHERE id_usuario = p_id_usuario;
        SELECT 'La cuenta se ha eliminado correctamente.' AS notice;
    END IF;
END//
DELIMITER ;
