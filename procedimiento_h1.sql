CREATE OR REPLACE PROCEDURE alta_administrador(
    p_usuario VARCHAR(255),
    p_telefono INT,
    p_contrasena VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
DECLARE
    v_admin_id INT;
BEGIN
    -- Verificar si el administrador principal está autorizado (puedes agregar lógica aquí)

    -- Insertar el nuevo administrador
    INSERT INTO administradores (usuario, telefono, contraseña)
    VALUES (p_usuario, p_telefono, p_contrasena)
    RETURNING id_administrador INTO v_admin_id;

    
    RAISE NOTICE 'Nuevo administrador creado con ID: %', v_admin_id;
END;
$$;
