DELIMITER //
CREATE PROCEDURE actualizar_info_usuario(
    IN p_id_usuario INT, -- Input parameter: ID of the user whose information is to be updated.
    IN p_contraseña_actual VARCHAR(255), -- Input parameter: Current password of the user to verify their identity.
    IN p_nuevo_celular VARCHAR(255), -- Optional input parameter: New mobile number to update.
    IN p_nueva_contraseña VARCHAR(255) -- Optional input parameter: New password to update.
)
BEGIN
    -- Verify that the current password is correct by querying the 'usuario' table.
    IF NOT EXISTS (
        SELECT 1 
        FROM usuario
        WHERE id_usuario = p_id_usuario AND contraseña = p_contraseña_actual
    ) THEN
        -- If the current password does not match, an exception is thrown indicating that the provided current password is incorrect.
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'The provided current password is incorrect.';
    END IF;
    
    -- Update mobile number, only if a new value has been provided and it is not empty.
    IF p_nuevo_celular IS NOT NULL AND p_nuevo_celular <> '' THEN
        UPDATE usuario
        SET numero_celular = p_nuevo_celular -- Set the new mobile number in the database.
        WHERE id_usuario = p_id_usuario; -- Condition to ensure that the update affects only the correct user.
    END IF;
    
    -- Update password, only if a new password has been provided and it is not empty.
    IF p_nueva_contraseña IS NOT NULL AND p_nueva_contraseña <> '' THEN
        UPDATE usuario
        SET contraseña = p_nueva_contraseña -- Set the new password in the database.
        WHERE id_usuario = p_id_usuario; -- Condition to ensure that the update affects only the correct user.
    END IF;
    
    -- Emit a notice to indicate that the update operation has been successfully completed.
    SELECT 'The user contact information has been successfully updated.' AS notice;
END //
DELIMITER ;
