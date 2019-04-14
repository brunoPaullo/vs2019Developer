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