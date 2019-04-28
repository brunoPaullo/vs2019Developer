CREATE PROCEDURE usp_GetAll
(
	@filterByName NVARCHAR(100)
)
AS
	BEGIN
		SELECT * FROM Artist
		WHERE Name LIKE @filterByName
	END
GO

EXEC usp_GetAll '%Aer%'
GO

CREATE PROCEDURE usp_InsertArtist
(
@pName VARCHAR(120)
)
AS
BEGIN
	-- DECLARE @NroRegistros INT
	-- SELECT @NroRegistros = COUNT(ArtistId) FROM Artist WHERE Name = @pName
	-- IF(@NroRegistros = 0)
	IF NOT EXISTS(SELECT ArtistId FROM Artist WHERE Name = @pName)
		BEGIN
			INSERT INTO Artist(Name) VALUES(@pName)
			SELECT SCOPE_IDENTITY()
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
GO

CREATE PROCEDURE usp_UpdateArtist
(
@pArtistId INT,
@pName VARCHAR(120)
)
AS
BEGIN
	IF NOT EXISTS(SELECT ArtistId FROM Artist WHERE Name = @pName)
		BEGIN
			UPDATE Artist
			SET Name = @pName
			WHERE ArtistId = @pArtistId
		END
END
GO

CREATE PROCEDURE usp_DeleteArtist
(
@pArtistId INT
)
AS
BEGIN
		DELETE FROM Artist
		WHERE ArtistId = @pArtistId
END
GO

SELECT * FROM Artist ORDER BY ArtistId DESC
GO

-- Consulta con datos no confirmados
SELECT * FROM Artist WITH (NOLOCK)  ORDER BY ArtistId DESC
GO

