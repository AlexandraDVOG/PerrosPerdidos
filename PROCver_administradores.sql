-- Procedimiento almacenado para buscar un usuario como administrador usando el número de celular
DELIMITER //
CREATE PROCEDURE ver_administradores(IN p_celular BIGINT)
BEGIN
    -- Declarar una variable para verificar si el usuario es un administrador
    DECLARE isAdmin INT;

    -- Verificar si el usuario que realiza la solicitud es un administrador
    SELECT COUNT(*) INTO isAdmin FROM administradores WHERE celular = p_celular;

    -- Si el usuario es un administrador, buscar la información del usuario solicitado
    IF isAdmin > 0 THEN
        SELECT * FROM usuario WHERE numero_celular = p_celular;
    ELSE
        -- Si el usuario no es un administrador, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Unauthorized: The user making the request does not have administrator privileges to access this information.';
    END IF;
END //
DELIMITER ;
