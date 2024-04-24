DELIMITER //
CREATE PROCEDURE alta_administrador(
    IN p_usuario VARCHAR(255),
    IN p_telefono BIGINT,
    IN p_contrasena VARCHAR(255)
)
BEGIN
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        -- Resignal the caught exception
        RESIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '500 Internal Server Error: Se produjo un error interno en el servidor al procesar la solicitud.';
    END;

    IF p_usuario IS NULL OR p_telefono IS NULL OR p_contrasena IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '400 Bad Request: Se produjo un error debido a una entrada incorrecta o insuficiente. Puede ser que falte el correo electrónico del nuevo administrador o que esté en un formato incorrecto.';
    END IF;

    -- Insertar el nuevo administrador
    INSERT INTO administradores (usuario, telefono, contraseña)
    VALUES (p_usuario, p_telefono, p_contrasena);

    -- Obtener el ID del nuevo administrador
    SET @v_admin_id = LAST_INSERT_ID();

    -- Imprimir el ID del nuevo administrador
    SELECT CONCAT('200 OK: La solicitud se procesó correctamente, y se envió una invitación al correo electrónico proporcionado. Nuevo administrador creado con ID: ', @v_admin_id) AS mensaje;
END//
DELIMITER ;

