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

/*========== Album ==========*/

CREATE PROCEDURE usp_GetAlbum
(
@pAlbumId INT
)
AS
BEGIN
	SELECT AlbumId, Title, ArtistId FROM Album WHERE AlbumId = @pAlbumId
END
GO

CREATE PROCEDURE usp_GetAllAlbum
(
@pTitle VARCHAR(160)
)
AS
BEGIN
	SELECT AlbumId, Title, ArtistId FROM Album WHERE Title LIKE @pTitle
END
GO

CREATE PROCEDURE usp_InsertAlbum
(
@pTitle VARCHAR(160),
@pArtistId INT
)
AS
BEGIN
	IF NOT EXISTS(SELECT AlbumId FROM Album WHERE Title = @pTitle)
	BEGIN
		INSERT INTO Album (Title, ArtistId) VALUES (@pTitle, @pArtistId)
		SELECT SCOPE_IDENTITY()
	END
	ELSE
	BEGIN
		SELECT 0
	END
END
GO

CREATE PROCEDURE usp_UpdateAlbum
(
@pAlbumId INT,
@pTitle VARCHAR(160),
@pArtistId INT
)
AS
BEGIN
	IF NOT EXISTS(SELECT AlbumId FROM Album WHERE Title = @pTitle)
	BEGIN
		UPDATE  Album
		SET Title = @pTitle, ArtistId = @pArtistId
		WHERE AlbumId = @pAlbumId
	END
END
GO

CREATE PROCEDURE usp_DeleteAlabum
(
@pAlbumId INT
)
AS
BEGIN
	DELETE FROM Album
	WHERE AlbumId = @pAlbumId
END
GO

/*========== Genre ==========*/

CREATE PROCEDURE usp_GetGenre
(
@pGenreId INT
)
AS
BEGIN
	SELECT GenreId, Name FROM Genre WHERE GenreId = @pGenreId
END
GO

CREATE PROCEDURE usp_GetAllGenre
(
@pName VARCHAR(120)
)
AS
BEGIN
	SELECT GenreId, Name FROM Genre WHERE Name LIKE @pName
END
GO

CREATE PROCEDURE usp_InsertGenre
(
@pName VARCHAR(120)
)
AS
BEGIN
	IF NOT EXISTS(SELECT GenreId FROM Genre WHERE Name = @pName)
		BEGIN
			INSERT INTO Genre (Name) VALUES (@pName)
			SELECT SCOPE_IDENTITY()
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
GO

CREATE PROCEDURE usp_UpdateGenre
(
@pGenreId INT,
@pName VARCHAR(120)
)
AS
BEGIN
	IF NOT EXISTS(SELECT GenreId FROM Genre WHERE Name = @pName)
		BEGIN
			UPDATE Genre
			SET Name = @pName
			WHERE GenreId =  @pGenreId
		END
END
GO

CREATE PROCEDURE usp_DeleteGenre
(
@pGenreId INT
)
AS
BEGIN
	DELETE FROM Genre WHERE GenreId = @pGenreId
END
GO

/*========== Invoice ==========*/

CREATE PROCEDURE usp_InsertInvoice
(
 @CustomerId INT, 
 @InvoiceDate DATETIME, 
 @BillingAddress NVARCHAR(70), 
 @BillingCity NVARCHAR(40), 
 @BillingState NVARCHAR(40), 
 @BillingCountry NVARCHAR(40), 
 @BillingPostalCode NVARCHAR(10), 
 @Total NUMERIC(10,2)
)
AS
BEGIN
	INSERT INTO Invoice (CustomerId, InvoiceDate, BillingAddress, BillingCity, BillingState, BillingCountry, BillingPostalCode, Total)
	VALUES(@CustomerId, @InvoiceDate, @BillingAddress, @BillingCity, @BillingState, @BillingCountry, @BillingPostalCode, @Total)
	SELECT SCOPE_IDENTITY()
END
GO

/*========== Invoice Line ==========*/

CREATE PROCEDURE usp_InsertInoviceLine
(
@InvoiceId INT, 
@TrackId INT, 
@UnitPrice NUMERIC(10,2), 
@Quantity INT
)
AS
BEGIN
	INSERT INTO InvoiceLine (InvoiceId, TrackId, UnitPrice, Quantity)
	VALUES(@InvoiceId, @TrackId, @UnitPrice, @Quantity)
END
GO


CREATE PROCEDURE usp_GetTracks
(
@trackName NVARCHAR(200)
)
AS
BEGIN
SELECT 
	B.TrackId, 
	B.Name AS TrackName, 
	A.Title AS AlbumTitle, 
	D.Name AS MediaTypeName, 
	C.Name AS GenreName, 
	B.Composer, 
	B.Milliseconds, 
	B.Bytes,
	B.UnitPrice
FROM	dbo.Album AS A INNER JOIN
        dbo.Track AS B ON A.AlbumId = B.AlbumId INNER JOIN
        dbo.Genre AS C ON B.GenreId = C.GenreId INNER JOIN
        dbo.MediaType AS D ON B.MediaTypeId = D.MediaTypeId
WHERE B.Name LIKE @trackName
ORDER BY TrackName
END
GO

EXEC usp_GetTracks '%VOLTA%'

