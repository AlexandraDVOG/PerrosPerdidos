CREATE OR REPLACE PROCEDURE eliminar_publicaciones_por_nombre_usuario(
    p_id_admin INT, -- Parámetro: ID del administrador que realiza la solicitud.
    p_nombre_usuario VARCHAR -- Parámetro: Nombre de usuario del perfil de usuario cuyas publicaciones deben eliminarse.
)
--inicializar parametros 
LANGUAGE plpgsql -- Especifica que el lenguaje utilizado para el procedimiento es PL/pgSQL.
AS $$
DECLARE
    v_es_admin BOOLEAN := FALSE; -- Variable local para verificar si el solicitante es un administrador.
    v_id_usuario INT; -- Variable local para almacenar el ID del usuario basado en el nombre de usuario proporcionado.
BEGIN
    -- Verificar si el solicitante es un administrador comparando el ID proporcionado con los registros en la tabla 'Administradores'.
   -- SELECT EXISTS(SELECT 1 FROM Administradores WHERE ID_Administrador = p_id_admin) INTO v_es_admin;
    
   -- IF NOT v_es_admin THEN -- Si el solicitante no es un administrador, se lanza una excepción.
     --   RAISE EXCEPTION 'El usuario que realiza la solicitud no tiene privilegios de administrador.';
    --END IF;
    
    -- Buscar el ID del usuario basado en el nombre de usuario proporcionado en la tabla 'USUARIO'.
    SELECT ID_USUARIO INTO v_id_usuario FROM USUARIO WHERE USUARIO = p_nombre_usuario;
    
    IF NOT FOUND THEN -- Si no se encuentra el usuario especificado, se lanza una excepción.
        RAISE EXCEPTION 'No se encontró el usuario especificado.';
    ELSE
        -- Eliminar todas las publicaciones asociadas al usuario. Esto se hace buscando todas las publicaciones cuyo 'ID_MASCOTA'
        -- esté vinculado a mascotas perdidas ('MASCOTAPERDIDA') que, a su vez, están asociadas con el 'ID_USUARIO' encontrado.
        DELETE FROM PUBLICACION WHERE ID_MASCOTA IN (
            SELECT ID_MASCOTA FROM MASCOTAPERDIDA WHERE ID_USUARIO = v_id_usuario
        );
        
        -- Emitir un aviso indicando que las publicaciones asociadas han sido eliminadas correctamente.
        RAISE NOTICE 'Todas las publicaciones asociadas al nombre de usuario % han sido eliminadas.', p_nombre_usuario;
    END IF;
END;
$$;
