DELIMITER //
DROP PROCEDURE IF EXISTS eliminar_publicaciones_por_nombre_usuario;
CREATE PROCEDURE eliminar_publicaciones_por_nombre_usuario(
    IN p_id_admin INT, -- Parámetro: ID del administrador que realiza la solicitud.
    IN p_nombre_usuario VARCHAR(255) -- Parámetro: Nombre de usuario del perfil de usuario cuyas publicaciones deben eliminarse.
)
BEGIN
    DECLARE v_es_admin BOOLEAN DEFAULT FALSE; -- Variable local para verificar si el solicitante es un administrador.
    DECLARE v_id_usuario INT; -- Variable local para almacenar el ID del usuario basado en el nombre de usuario proporcionado.

    -- Verificar si el solicitante es un administrador comparando el ID proporcionado con los registros en la tabla 'Administradores'.
    -- SELECT EXISTS(SELECT 1 FROM Administradores WHERE ID_Administrador = p_id_admin) INTO v_es_admin;
    
    -- IF NOT v_es_admin THEN -- Si el solicitante no es un administrador, se lanza una excepción.
    --    SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario que realiza la solicitud no tiene privilegios de administrador.';
    -- END IF;
    
    -- Buscar el ID del usuario basado en el nombre de usuario proporcionado en la tabla 'USUARIO'.
    SELECT ID_USUARIO INTO v_id_usuario FROM USUARIO WHERE USUARIO = p_nombre_usuario;
    
    IF v_id_usuario IS NULL THEN -- Si no se encuentra el usuario especificado, se lanza una excepción.
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'No se encontró el usuario especificado.';
    ELSE
        -- Eliminar todas las publicaciones asociadas al usuario. Esto se hace buscando todas las publicaciones cuyo 'ID_MASCOTA'
        -- esté vinculado a mascotas perdidas ('MASCOTAPERDIDA') que, a su vez, están asociadas con el 'ID_USUARIO' encontrado.
        DELETE FROM PUBLICACION WHERE ID_MASCOTA IN (
            SELECT ID_MASCOTA FROM MASCOTAPERDIDA WHERE ID_USUARIO = v_id_usuario
        );
        
        -- Emitir un aviso indicando que las publicaciones asociadas han sido eliminadas correctamente.
        SELECT CONCAT('Todas las publicaciones asociadas al nombre de usuario ', p_nombre_usuario, ' han sido eliminadas.') AS notice;
    END IF;
END //
DELIMITER ;
