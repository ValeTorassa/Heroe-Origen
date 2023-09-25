USE MASTER
GO
DROP DATABASE DBHeroe

GO
CREATE DATABASE DBHeroe

GO
USE DBHeroe

--#REGION (TABLAS)

-- ORIGENES
CREATE TABLE Origenes (
    OrigenID INT NOT NULL IDENTITY PRIMARY KEY,
    NombreHistoria NVARCHAR(50) UNIQUE,
    Lugar NVARCHAR(50),
    Historia NVARCHAR(MAX),
    --HeroeID INT,
    Estado Bit NULL
);


-- HEROES
CREATE TABLE Heroes (
    HeroeID INT NOT NULL IDENTITY PRIMARY KEY,
    Nombre NVARCHAR(50) UNIQUE,
    Clase NVARCHAR(50),
    Nivel INT,
    OrigenID INT,
    FOREIGN KEY (OrigenID) REFERENCES Origenes(OrigenID),
    Estado Bit NULL
);

---ALTER TABLE Origenes
---ADD FOREIGN KEY (HeroeID) REFERENCES Heroes

--#ENDREGION


--#REGION (Heroe)

--SPs de Heroe
GO
CREATE PROCEDURE SP_AGREGARHEROE
    @Nombre NVARCHAR(50),
    @Clase NVARCHAR(50),
    @Nivel INT,
    @NombreHistoria NVARCHAR(50)
AS
BEGIN
    DECLARE @ID_HEROE INT
    SET @ID_HEROE = (SELECT HeroeID FROM Heroes WHERE Nombre = @Nombre)
    IF (@ID_HEROE IS NULL)
    BEGIN
        INSERT INTO Heroes (Nombre, Clase, Nivel, OrigenID, Estado)
        VALUES (@Nombre, @Clase, @Nivel, (SELECT OrigenID FROM Origenes where NombreHistoria = @NombreHistoria), NULL)
    END
    ELSE
    BEGIN
        UPDATE Heroes
        SET Clase = @Clase, Nivel = @Nivel, OrigenID = (SELECT OrigenID FROM Origenes where NombreHistoria = @NombreHistoria), Estado = NULL
        WHERE (Nombre = @Nombre)
    END
END;

GO
CREATE PROCEDURE SP_RECUPERARHEROE 
AS BEGIN
    SELECT 
        H.Nombre,
        H.Clase,
        H.Nivel,
        O.NombreHistoria
    FROM Heroes AS H
    INNER JOIN
        Origenes AS O ON H.OrigenID = O.OrigenID
    WHERE H.Estado IS NULL
END;

GO
CREATE PROCEDURE SP_ELIMINARHEROE @Nombre NVARCHAR(20) 
AS BEGIN
    UPDATE Heroes
    SET Estado = 1
    WHERE HeroeID = (SELECT HeroeID FROM Heroes WHERE Nombre = @Nombre)
END;

GO
CREATE PROCEDURE SP_MODIFICARHEROE
    @Nombre NVARCHAR(50),
    @Clase NVARCHAR(50),
    @Nivel INT,
    @NombreHistoria NVARCHAR(50)
AS
BEGIN
    UPDATE Heroes
    SET Clase = @Clase, Nivel = @Nivel, OrigenID = (SELECT OrigenID FROM Origenes where NombreHistoria = @NombreHistoria)
    WHERE Nombre = @Nombre AND Estado IS NULL
END;
--#ENDREGION


--#REGION (Origen)

--SPs de Origen
GO
CREATE PROCEDURE SP_AGREGARORIGEN
    @NombreHistoria NVARCHAR(50),
    @Lugar NVARCHAR(50),
    @Historia NVARCHAR(MAX)
AS
BEGIN
    DECLARE @ID_ORIGEN INT
    SET @ID_ORIGEN = (SELECT OrigenID FROM Origenes WHERE NombreHistoria = @NombreHistoria)
    IF (@ID_ORIGEN IS NULL)
    BEGIN
        INSERT INTO Origenes (NombreHistoria, Lugar, Historia, Estado)
        VALUES (@NombreHistoria, @Lugar, @Historia, NULL)
    END
    ELSE
    BEGIN
        UPDATE Origenes
        SET Lugar = @Lugar, Historia = @Historia, Estado = NULL
        WHERE (NombreHistoria = @NombreHistoria)
    END
END;


GO
CREATE PROCEDURE SP_RECUPERARORIGEN 
AS BEGIN
    SELECT 
        NombreHistoria,
        Lugar,
        Historia
    FROM Origenes
    WHERE Estado IS NULL
END;


GO
CREATE PROCEDURE SP_ELIMINARORIGEN @NombreHistoria NVARCHAR(20) 
AS BEGIN
    UPDATE Origenes
    SET Estado = 1
    WHERE OrigenID = (SELECT OrigenID FROM Origenes where NombreHistoria = @NombreHistoria)
END;


GO
CREATE PROCEDURE SP_MODIFICARORIGEN
    @NombreHistoria NVARCHAR(50),
    @Lugar NVARCHAR(50),
    @Historia NVARCHAR(MAX)
AS
BEGIN
    UPDATE Origenes
    SET Lugar = @Lugar, Historia = @Historia
    WHERE NombreHistoria = @NombreHistoria AND Estado IS NULL
END;

--#ENDREGION

-- #REGION (PRUEBAS)
-- Recuperar Todos los Héroes
SELECT * FROM Heroes;
-- Recuperar Héroes (incluyendo los deshabilitados)
EXEC SP_RECUPERARHEROE;
-- Agregar un Héroe
EXEC SP_AGREGARHEROE 'Superman', 'Superhéroe', 10, 'Murcielago';
EXEC SP_AGREGARHEROE 'Batman', 'Detective', 9, 'Extraterrestre';
-- Eliminar un Héroe (Baja lógica)
EXEC SP_ELIMINARHEROE 1;
-- Modificar un Héroe
EXEC SP_MODIFICARHEROE 2, 'Batman', 'Vigilante', 9, 'Origen2';
-- Recuperar los Héroes eliminados
EXEC SP_RECUPERARHEROELIMINADOS;
-- #ENDREGION

-- #REGION (PRUEBAS PARA ORIGENES)
-- Recuperar Todos los Orígenes
SELECT * FROM Origenes;
-- Recuperar Orígenes (incluyendo los deshabilitados)
EXEC SP_RECUPERARORIGEN;
-- Agregar un Origen
EXEC SP_AGREGARORIGEN 'Murcielago', 'Ciudad de Metrópolis', 'Historia de Superman';
EXEC SP_AGREGARORIGEN 'Extraterrestre', 'Ciudad de Gotham', 'Historia de Batman';
-- Eliminar un Origen (Baja lógica)
EXEC SP_ELIMINARORIGEN 1;
-- Modificar un Origen
EXEC SP_MODIFICARORIGEN 'Origen2', 'Ciudad de Gotham', 'Nueva historia de Batman';
-- Recuperar los Orígenes eliminados
EXEC SP_RECUPERARORIGENESELIMINADOS;
-- #ENDREGION


DROP PROCEDURE SP_AGREGARORIGEN