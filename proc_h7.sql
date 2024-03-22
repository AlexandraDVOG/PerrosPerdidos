CREATE OR REPLACE PROCEDURE actualizar_perfil_usuario(
    p_id_usuario INT, -- Parámetro: ID del usuario cuyo perfil se va a actualizar.
    p_nuevo_celular VARCHAR DEFAULT NULL, -- Parámetro opcional: El nuevo número de celular para actualizar. Por defecto es NULL.
    p_nueva_contraseña VARCHAR DEFAULT NULL -- Parámetro opcional: La nueva contraseña para actualizar. Por defecto es NULL.
)
-- Esta declaración crea o reemplaza un procedimiento almacenado llamado `actualizar_perfil_usuario`. 
-- Los parámetros permiten al llamante especificar el ID del usuario a actualizar, y opcionalmente, un nuevo número de celular y/o una nueva contraseña.

LANGUAGE plpgsql
-- Especifica que el lenguaje utilizado para escribir este procedimiento es PL/pgSQL, el lenguaje procedimental de PostgreSQL.

AS $$
-- Inicia el cuerpo del procedimiento.

BEGIN
    -- Inicia el bloque de comandos del procedimiento.

    UPDATE usuario
    -- Instrucción UPDATE para modificar la tabla `usuario`.

    SET numero_celular = COALESCE(p_nuevo_celular, numero_celular),
    -- Establece el campo `numero_celular` al valor de `p_nuevo_celular` si este no es NULL. 
    -- Si `p_nuevo_celular` es NULL, mantiene el valor actual del campo `numero_celular`.

        contraseña = COALESCE(p_nueva_contraseña, contraseña)
    -- Establece el campo `contraseña` al valor de `p_nueva_contraseña` si este no es NULL.
    -- Si `p_nueva_contraseña` es NULL, mantiene el valor actual del campo `contraseña`.
    -- La función COALESCE selecciona el primer valor no NULL de sus argumentos, permitiendo actualizar los campos solo cuando se proporciona un nuevo valor.

    WHERE id_usuario = p_id_usuario;
    -- La cláusula WHERE asegura que solo se actualice el perfil del usuario cuyo `id_usuario` coincida con el valor del parámetro `p_id_usuario`.
    -- Esto previene la actualización accidental de múltiples registros y asegura que solo se actualice la información del usuario correcto.

END;
-- Marca el final del bloque de comandos del procedimiento.
$$;
-- Marca el final del cuerpo del procedimiento.
