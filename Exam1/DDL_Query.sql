CREATE PROCEDURE usp_GetAllAlumnos
AS
BEGIN
	SELECT * FROM Alumno
END
GO



CREATE PROCEDURE usp_InsertAlumno
(
@pNombres VARCHAR(50),
@pApellidos VARCHAR(50), 
@Direccion VARCHAR(100), 
@Sexo VARCHAR(1), 
@FechaNacimiento DATETIME
)
AS
BEGIN
	IF NOT EXISTS(SELECT AlumnoId FROM Alumno WHERE Nombres = @pNOmbres)
		BEGIN
			INSERT INTO Alumno( Nombres, Apellidos, Direccion, Sexo, FechaNacimiento) 
			VALUES (@pNombres, @pApellidos, @Direccion, @Sexo, @FechaNacimiento)
			SELECT SCOPE_IDENTITY()
		END
	ELSE
		BEGIN
			SELECT 0
		END
END
GO

CREATE PROCEDURE usp_AlumnoInfo
(
 @pGrado NVARCHAR(10),
 @pCurso NVARCHAR(100)
)
AS
BEGIN
SELECT 
 G.Nivel Grado
,C.Nombre Curso
,A.Nombres + ' ' + A.Apellidos Alumno
,N.Nota Nota

FROM Alumno A JOIN Matricula M
ON A.AlumnoID = M.AlumnoID JOIN Grado G
ON M.GradoID = G.GradoID JOIN Curso C
ON G.GradoID = C.GradoID JOIN Notas N
ON A.AlumnoID = N.AlumnoID AND C.CursoID = N.CursoID
END
GO


usp_AlumnoInfo 'Primero', 'C#'
GO

CREATE PROCEDURE usp_InsertNotas
(
@AlumnoID INT, 
@CursoID INT, 
@Nota INT
)
AS
BEGIN
	INSERT INTO Notas (AlumnoID, CursoID, Nota) VALUES(@AlumnoID, @CursoID, @Nota)
END
GO