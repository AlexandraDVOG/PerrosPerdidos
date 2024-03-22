CREATE OR REPLACE PROCEDURE public.modificar_numero_celular(
	IN p_id_usuario integer,
	IN "p_contraseña" character varying,
	IN p_nuevo_numero_celular character varying)
LANGUAGE 'plpgsql'
AS $BODY$
DECLARE
    v_usuario_actual VARCHAR(255);
BEGIN
    SELECT usuario INTO v_usuario_actual
    FROM usuario
    WHERE id_usuario = p_id_usuario AND contraseña = p_contraseña;

    IF FOUND THEN
        PERFORM actualizar_numero_celular(p_id_usuario, p_nuevo_numero_celular);
        RAISE INFO 'Número de celular actualizado correctamente para el usuario %', v_usuario_actual;
    ELSE
        RAISE EXCEPTION 'Usuario no encontrado o contraseña incorrecta';
    END IF;
END;
$BODY$;
ALTER PROCEDURE public.modificar_numero_celular(integer, character varying, character varying)
    OWNER TO postgres;
