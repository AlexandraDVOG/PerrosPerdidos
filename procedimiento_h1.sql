CREATE PROCEDURE alta_administrador(
    IN p_usuario VARCHAR(255),
    IN p_telefono BIGINT,
    IN p_contrasena VARCHAR(255)
)
BEGIN
    -- Insertar el nuevo administrador
    INSERT INTO administradores (usuario, celular, contraseña)
    VALUES (p_usuario, p_telefono, p_contrasena);

    -- Obtener el ID del nuevo administrador
    SET @v_admin_id = LAST_INSERT_ID();

    -- Imprimir el ID del nuevo administrador
    SELECT CONCAT('Nuevo administrador creado con ID: ', @v_admin_id) AS mensaje;
END;
