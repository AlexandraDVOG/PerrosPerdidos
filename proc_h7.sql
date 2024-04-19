DELIMITER //
CREATE PROCEDURE actualizar_perfil_usuario(IN p_id_usuario INT, IN p_nuevo_celular VARCHAR(255), IN p_nueva_contraseña VARCHAR(255))
BEGIN
    IF p_nuevo_celular IS NOT NULL THEN
        UPDATE usuario
        SET numero_celular = p_nuevo_celular
        WHERE id_usuario = p_id_usuario;
    END IF;

    IF p_nueva_contraseña IS NOT NULL THEN
        UPDATE usuario
        SET contraseña = p_nueva_contraseña
        WHERE id_usuario = p_id_usuario;
    END IF;
END//
DELIMITER ;
