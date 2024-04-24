DELIMITER //
CREATE PROCEDURE obtener_publicaciones_recientes()
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        -- Resignal the caught exception
        RESIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = '500 Internal Server Error: Se produjo un error interno en el servidor al procesar la solicitud.';
    END;

    SELECT
        u.usuario, 
        m.raza, 
        m.color,
        m.tamaño,
        m.sexo, 
        m.características,
        m.fecha_visto, 
        m.lugar_visto, 
        m.imagen 
    FROM
        mascotaperdida m
    

    INNER JOIN
        usuario u ON m.id_usuario = u.id_usuario
    
    ORDER BY
        m.fecha_visto DESC
    
    LIMIT 10;
    
END//
DELIMITER ;
