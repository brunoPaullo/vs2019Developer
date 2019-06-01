using System;
using App.Data.DataAcces;
using App.Entities.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Data.UnitTest
{
    [TestClass]
    public class AlumnoUnitTest
    {
        private readonly AlumnoDA alumnoDA = new AlumnoDA();
        private readonly AlumnoEntityFramework alumnoEF = new AlumnoEntityFramework();
        private readonly AlumnoDapper alumnoDapper = new AlumnoDapper();

        #region Ejercicio 2
        [TestMethod]
        public void Insert()
        {
            var alumno = new Alumno()
            {
                Nombres = "Diego",
                Apellidos = "Crus",
                Sexo = "M",
                FechaNacimiento = DateTime.Now,
                Direccion = "Los Nogales 455"
            };

            var result = alumnoDA.Insert(alumno);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public void GetAll()
        {
            var alumnos = alumnoDA.GetAll();

            Assert.IsTrue(alumnos.Count > 0);
        }
        #endregion

        #region Ejercicio 3
        [TestMethod]
        public void InsertNotas()
        {
            var nota = new Notas()
            {
                AlumnoID = 4,
                CursoID = 4,
                Nota = 17
            };

            var result = alumnoDapper.InsertNotas(nota);

            Assert.IsTrue(result > 0);
        }
        #endregion

        #region Ejercicio 4
        [TestMethod]
        public void GetAlumnoInfo()
        {
            var alumnos = alumnoDapper.GetAll("Primero", "Base de Datos");

            Assert.IsTrue(alumnos.Count > 0);
        }
        #endregion

        #region Ejercicio 5
        [TestMethod]
        public void GetAllEntityFramework()
        {
            var alumnos = alumnoEF.GetAll();

            Assert.IsTrue(alumnos.Count > 0);
        } 
        #endregion

    }
}
