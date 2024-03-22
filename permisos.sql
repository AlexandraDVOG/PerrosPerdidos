

-- Agregar permisos de administrador a los administradores sobre los usuarios
CREATE ROLE administradores;

GRANT ALL PRIVILEGES ON ALL TABLES IN SCHEMA public TO Administradores;


