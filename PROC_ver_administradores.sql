DELIMITER //
CREATE PROCEDURE ver_administradores(IN p_celular BIGINT)
BEGIN
    -- Declarar una variable para verificar si el usuario es un administrador
    DECLARE isAdmin INT;
    DECLARE v_usuario VARCHAR(255);
    DECLARE CONTINUE HANDLER FOR SQLEXCEPTION
    BEGIN
        -- Resignal the caught exception
        RESIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '500 Internal Server Error: Se produjo un error interno en el servidor al procesar la solicitud.';
    END;

    -- Verificar si el usuario que realiza la solicitud es un administrador
    SELECT COUNT(*) INTO isAdmin FROM administradores WHERE celular = p_celular;

    -- Si el usuario es un administrador, buscar la información del usuario solicitado
    IF isAdmin > 0 THEN
        SELECT usuario INTO v_usuario FROM usuario WHERE numero_celular = p_celular;
        IF v_usuario IS NOT NULL THEN
            SELECT * FROM usuario WHERE numero_celular = p_celular;
            SELECT CONCAT('200 OK: La solicitud se procesó correctamente y se devuelve la información del usuario solicitado. Usuario: ', v_usuario) AS mensaje;
        ELSE
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '404 Not Found: No se encontró el usuario especificado.';
        END IF;
    ELSE
        -- Si el usuario no es un administrador, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '401 Unauthorized: El usuario que realiza la solicitud no tiene privilegios de administrador para acceder a esta información.';
    END IF;
END //
DELIMITER ;
