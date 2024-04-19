DELIMITER //
CREATE PROCEDURE iniciar_sesion_usuario(
    IN p_numero_celular VARCHAR(20), -- Parámetro que recibe el número de celular del usuario. Se ajusta a VARCHAR(20) según la definición de la tabla.
    IN p_contrasena VARCHAR(255) -- Parámetro que recibe la contraseña del usuario. Su tipo de datos es VARCHAR(255).
)
BEGIN
    DECLARE v_usuario_existente INT;

    SELECT COUNT(*)
    INTO v_usuario_existente
    FROM usuario
    WHERE numero_celular = p_numero_celular
      AND contraseña = p_contrasena;

    IF v_usuario_existente > 0 THEN
        SELECT 'Inicio de sesión exitoso' AS notice;
    ELSE
        SELECT 'Número de celular o contraseña incorrectos. Intente nuevamente más tarde.' AS error;
    END IF;
END//
DELIMITER ;
