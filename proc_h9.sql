CREATE OR REPLACE PROCEDURE actualizar_info_usuario(
    p_id_usuario INT, -- Parámetro de entrada: ID del usuario cuya información se va a actualizar.
    p_contraseña_actual VARCHAR, -- Parámetro de entrada: Contraseña actual del usuario para verificar su identidad.
    p_nuevo_celular VARCHAR DEFAULT NULL, -- Parámetro de entrada opcional: Nuevo número de celular para actualizar.
    p_nueva_contraseña VARCHAR DEFAULT NULL -- Parámetro de entrada opcional: Nueva contraseña para actualizar.
)
LANGUAGE plpgsql -- Especifica que el lenguaje utilizado para este procedimiento almacenado es PL/pgSQL.
AS $$
BEGIN
    -- Verificar que la contraseña actual es correcta realizando una consulta a la tabla 'usuario'.
    IF NOT EXISTS (
        SELECT 1 
        FROM usuario
        WHERE id_usuario = p_id_usuario AND contraseña = p_contraseña_actual
    ) THEN
        -- Si la contraseña actual no coincide, se lanza una excepción indicando que la contraseña proporcionada no es correcta.
        RAISE EXCEPTION 'La contraseña actual proporcionada no es correcta.';
    END IF;
    
    -- Actualizar número de celular, solo si se ha proporcionado un nuevo valor y este no está vacío.
    IF p_nuevo_celular IS NOT NULL AND p_nuevo_celular <> '' THEN
        UPDATE usuario
        SET numero_celular = p_nuevo_celular -- Establecer el nuevo número de celular en la base de datos.
        WHERE id_usuario = p_id_usuario; -- Condición para asegurar que la actualización afecte solo al usuario correcto.
    END IF;
    
    -- Actualizar contraseña, solo si se ha proporcionado una nueva contraseña y esta no está vacía.
    IF p_nueva_contraseña IS NOT NULL AND p_nueva_contraseña <> '' THEN
        UPDATE usuario
        SET contraseña = p_nueva_contraseña -- Establecer la nueva contraseña en la base de datos.
        WHERE id_usuario = p_id_usuario; -- Condición para asegurar que la actualización afecte solo al usuario correcto.
    END IF;
    
    -- Emitir un aviso para indicar que la operación de actualización ha sido completada con éxito.
    RAISE NOTICE 'La información de contacto del usuario ha sido actualizada correctamente.';
END;
$$;
