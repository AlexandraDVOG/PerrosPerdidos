
CREATE OR REPLACE PROCEDURE crear_cuenta_usuario(
    p_numero_celular VARCHAR(20), -- Ajustado a VARCHAR(20) para coincidir con la definición de la tabla
    p_contrasena VARCHAR(255),
    p_usuario VARCHAR(255) -- Cambiado de p_nombre_usuario a p_usuario y ajustado el tamaño
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Verificar si el número de celular ya está registrado
    IF EXISTS (SELECT 1 FROM usuario WHERE numero_celular = p_numero_celular) THEN
        RAISE EXCEPTION 'El número de celular ya está registrado.';
    END IF;

    -- Insertar el nuevo usuario
    INSERT INTO usuario (numero_celular, contraseña, usuario) -- Ajustado los nombres de las columnas
    VALUES (p_numero_celular, p_contrasena, p_usuario);

    -- Devolver el nombre de usuario proporcionado
    RAISE NOTICE 'Cuenta creada exitosamente. Nombre de usuario: %', p_usuario;
END;
$$;
