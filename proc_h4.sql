CREATE OR REPLACE PROCEDURE reportar_perro_perdido(
    p_id_usuario INT, -- Asumiendo que necesitamos este valor
    p_celular INT, -- Asumiendo que necesitamos este valor
    p_raza VARCHAR(50),
    p_color VARCHAR(20),
    p_tamano VARCHAR(20),
    p_sexo CHAR(1),
    p_caracteristicas TEXT,
    p_fecha_visto DATE,
    p_lugar_visto VARCHAR(100),
    p_imagen BYTEA -- Cambiando a BYTEA para coincidir con la definición de la tabla
)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Insertar el reporte del perro perdido
    INSERT INTO mascotaperdida (id_usuario, raza, color, tamaño, sexo, caracteristicas, fecha_visto, lugar_visto, celular, imagen)
    VALUES (p_id_usuario, p_raza, p_color, p_tamano, p_sexo, p_caracteristicas, p_fecha_visto, p_lugar_visto, p_celular, p_imagen);

    -- Devolver mensaje de éxito
    RAISE NOTICE 'Reporte del perro perdido creado correctamente';
END;
$$;
