DELIMITER //
CREATE PROCEDURE eliminar_publicaciones_por_nombre_usuario(
    IN p_id_admin INT, -- Parameter: ID of the administrator making the request.
    IN p_nombre_usuario VARCHAR(255) -- Parameter: Username of the user profile whose posts should be deleted.
)
BEGIN
    DECLARE v_es_admin BOOLEAN DEFAULT FALSE; -- Local variable to check if the requester is an administrator.
    DECLARE v_id_usuario INT; -- Local variable to store the user ID based on the provided username.

    -- Verify if the requester is an administrator by comparing the provided ID with the records in the 'Administradores' table.
    SELECT EXISTS(SELECT 1 FROM Administradores WHERE ID_Administrador = p_id_admin) INTO v_es_admin;
    
    IF NOT v_es_admin THEN -- If the requester is not an administrator, an exception is thrown.
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '401 Unauthorized: The user making the request does not have administrator privileges.';
    END IF;
    
    -- Search for the user ID based on the provided username in the 'USUARIO' table.
    SELECT ID_USUARIO INTO v_id_usuario FROM USUARIO WHERE USUARIO = p_nombre_usuario;
    
    IF v_id_usuario IS NULL THEN -- If the specified user is not found, an exception is thrown.
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '404 Not Found: The specified user was not found.';
    ELSE
        -- Delete all posts associated with the user. This is done by searching for all posts whose 'ID_MASCOTA'
        -- is linked to lost pets ('MASCOTAPERDIDA') which, in turn, are associated with the found 'ID_USUARIO'.
        DELETE FROM PUBLICACION WHERE ID_MASCOTA IN (
            SELECT ID_MASCOTA FROM MASCOTAPERDIDA WHERE ID_USUARIO = v_id_usuario
        );
        
        -- Emit a notice indicating that the associated posts have been successfully deleted.
        SELECT CONCAT('204 No Content: All posts associated with the username ', p_nombre_usuario, ' have been deleted.') AS notice;
    END IF;
    
    -- Handle any unexpected errors that may occur during the execution of the procedure.
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '500 Internal Server Error: An internal error occurred while processing the request.';
    END;
END //
DELIMITER ;
