CREATE OR REPLACE PROCEDURE eliminar_cuenta_usuario(p_id_usuario INT, p_confirmacion BOOLEAN)
-- Define un procedimiento llamado `eliminar_cuenta_usuario` con dos parámetros:
-- p_id_usuario: El ID del usuario cuya cuenta se desea eliminar.
-- p_confirmacion: Un valor booleano que debe ser TRUE para proceder con la eliminación.

LANGUAGE plpgsql
-- Especifica que el lenguaje utilizado para el procedimiento es PL/pgSQL.

AS $$
-- Inicia el bloque del cuerpo del procedimiento.

DECLARE
    v_es_admin BOOLEAN;
    -- Declara una variable local `v_es_admin` para almacenar si el usuario tiene privilegios de administrador.
    
BEGIN
    -- Inicia el bloque principal de ejecución del procedimiento.

    SELECT EXISTS(SELECT 1 FROM administradores WHERE id_usuario = p_id_usuario) INTO v_es_admin;
    -- Verifica si el usuario es un administrador consultando la tabla `administradores`.
    -- La consulta busca una coincidencia del `id_usuario` en la tabla `administradores` y almacena el resultado en `v_es_admin`.

    IF NOT v_es_admin THEN
        -- Si `v_es_admin` es FALSE (el usuario no es un administrador), se lanza una excepción.
        RAISE EXCEPTION 'El usuario no tiene los permisos adecuados para eliminar la cuenta.';
    ELSIF NOT p_confirmacion THEN
        -- Si `p_confirmacion` es FALSE (no se ha confirmado la eliminación), se lanza otra excepción.
        RAISE EXCEPTION 'Confirmación de eliminación requerida.';
    ELSE
        -- Si se pasan las verificaciones anteriores, se procede a eliminar la cuenta del usuario.
        DELETE FROM usuario WHERE id_usuario = p_id_usuario;
        -- Elimina la cuenta del usuario de la tabla `usuario` donde el `id_usuario` coincide con `p_id_usuario`.

        -- Puedes agregar aquí comandos adicionales DELETE para eliminar datos relacionados del usuario en otras tablas.
        
        RAISE NOTICE 'La cuenta se ha eliminado correctamente.';
        -- Muestra un aviso indicando que la cuenta se ha eliminado correctamente.
    END IF;
    -- Finaliza la estructura condicional.
    
END;
-- Finaliza el bloque principal de ejecución del procedimiento.
$$;
-- Finaliza el bloque del cuerpo del procedimiento.
