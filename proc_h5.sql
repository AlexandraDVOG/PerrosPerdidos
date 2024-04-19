DELIMITER //
CREATE PROCEDURE obtener_publicaciones_recientes()
BEGIN
    SELECT
        u.usuario, -- Selecciona el nombre de usuario del usuario que reportó la mascota perdida.
        m.raza, -- Selecciona la raza de la mascota perdida.
        m.color, -- Selecciona el color de la mascota perdida.
        m.tamaño, -- Selecciona el tamaño de la mascota perdida.
        m.sexo, -- Selecciona el sexo de la mascota perdida.
        m.características, -- Selecciona cualquier característica adicional de la mascota perdida.
        m.fecha_visto, -- Selecciona la fecha en que la mascota fue vista por última vez.
        m.lugar_visto, -- Selecciona el lugar donde la mascota fue vista por última vez.
        m.imagen -- Selecciona una foto de la mascota perdida.
    FROM
        mascotaperdida m
    -- Indica que la consulta seleccionará datos de la tabla `mascotaperdida`.

    INNER JOIN
        usuario u ON m.id_usuario = u.id_usuario
    -- Realiza una unión interna con la tabla `usuario` para relacionar cada mascota perdida con el usuario que la reportó,
    -- basándose en el `id_usuario`.

    ORDER BY
        m.fecha_visto DESC
    -- Ordena los resultados por la fecha en que la mascota fue vista por última vez, de manera descendente,
    -- para obtener las publicaciones más recientes primero.

    LIMIT 10;
    -- Limita los resultados a las 10 publicaciones más recientes de mascotas perdidas.
END//
DELIMITER ;
