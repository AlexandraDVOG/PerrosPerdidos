CREATE OR REPLACE PROCEDURE iniciar_sesion_usuario(
    p_numero_celular VARCHAR(20), -- Parámetro que recibe el número de celular del usuario. Se ajusta a VARCHAR(20) según la definición de la tabla.
    p_contrasena VARCHAR(255) -- Parámetro que recibe la contraseña del usuario. Su tipo de datos es VARCHAR(255).
)
-- Este comando crea o reemplaza un procedimiento almacenado llamado `iniciar_sesion_usuario`, que acepta dos parámetros: el número de celular y la contraseña del usuario.

LANGUAGE plpgsql
-- Especifica que el lenguaje utilizado para este procedimiento almacenado es PL/pgSQL, el lenguaje de procedimientos de PostgreSQL.

AS $$
-- Inicia el bloque del cuerpo del procedimiento.

BEGIN
    -- Inicia el bloque principal de ejecución del procedimiento.

    DECLARE
        v_usuario_existente BOOLEAN;
        -- Declara una variable booleana `v_usuario_existente` para almacenar el resultado de la verificación de las credenciales del usuario.

    SELECT EXISTS (
        SELECT 1 
        FROM usuario
        WHERE numero_celular = p_numero_celular
          AND contraseña = p_contrasena
    ) INTO v_usuario_existente;
    -- Realiza una consulta a la tabla `usuario` para verificar si existe un registro que coincida con el número de celular y la contraseña proporcionados.
    -- La función EXISTS devuelve TRUE si se encuentra al menos una coincidencia, lo cual se almacena en la variable `v_usuario_existente`.

    IF v_usuario_existente THEN
        -- Si la variable `v_usuario_existente` es TRUE, significa que las credenciales son correctas.
        RAISE NOTICE 'Inicio de sesión exitoso';
        -- Se emite un aviso indicando que el inicio de sesión fue exitoso.
    ELSE
        -- Si no se encuentran coincidencias, la variable `v_usuario_existente` será FALSE.
        RAISE EXCEPTION 'Número de celular o contraseña incorrectos. Intente nuevamente más tarde.';
        -- Se lanza una excepción indicando que el número de celular o la contraseña son incorrectos.
    END IF;
    -- Finaliza la estructura condicional que verifica si las credenciales son correctas.

END;
-- Marca el final del bloque de ejecución del procedimiento.

$$;
-- Marca el final del cuerpo del procedimiento.
