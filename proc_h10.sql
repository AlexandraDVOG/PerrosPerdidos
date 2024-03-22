CREATE OR REPLACE PROCEDURE buscar_usuario_por_nombre_usuario(
    p_id_admin INT, -- Parámetro de entrada: ID del administrador que realiza la solicitud.
    p_nombre_usuario VARCHAR -- Parámetro de entrada: Nombre de usuario del usuario que se busca.
)
LANGUAGE plpgsql -- Especifica que el lenguaje utilizado para este procedimiento almacenado es PL/pgSQL.
AS $$
DECLARE
    v_es_admin BOOLEAN := FALSE; -- Variable local para almacenar si el solicitante es administrador. Inicializada en FALSE.
    v_id_usuario INT; -- Variable local para almacenar el ID del usuario encontrado basado en el nombre de usuario.
    v_num_celular VARCHAR; -- Variable local para almacenar el número de celular del usuario encontrado.
BEGIN
    -- Consulta para verificar si el ID del administrador proporcionado corresponde a un administrador en la tabla 'Administradores'.
    SELECT EXISTS(SELECT 1 FROM Administradores WHERE ID_Administrador = p_id_admin) INTO v_es_admin;
    
    -- Comprobación de los privilegios de administrador del solicitante.
    IF NOT v_es_admin THEN
        -- Si el solicitante no es un administrador, se lanza una excepción indicando la falta de privilegios.
        RAISE EXCEPTION 'El usuario que realiza la solicitud no tiene privilegios de administrador.' USING ERRCODE = '22001';
    END IF;
    
    -- Consulta para buscar el ID y el número de celular del usuario basado en el nombre de usuario proporcionado.
    SELECT ID_USUARIO, NUMERO_CELULAR INTO v_id_usuario, v_num_celular FROM USUARIO WHERE USUARIO = p_nombre_usuario;
    
    -- Verificación de si se encontró el usuario especificado.
    IF NOT FOUND THEN
        -- Si no se encuentra el usuario, se lanza una excepción indicando que el usuario especificado no fue encontrado.
        RAISE EXCEPTION 'No se encontró el usuario especificado.' USING ERRCODE = '22002';
    ELSE
        -- Si se encuentra el usuario, se emite un aviso con el ID y el número de celular del usuario encontrado.
        RAISE NOTICE 'Usuario encontrado: ID %, Celular: %', v_id_usuario, v_num_celular;
    END IF;
END;
$$;
