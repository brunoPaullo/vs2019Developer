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
        private readonly AlumnoDapper alumnoDP = new AlumnoDapper();

        [TestMethod]
        public void GetAll()
        {
            var alumnos = alumnoDA.GetAll();

            Assert.IsTrue(alumnos.Count > 0);
        }

        [TestMethod]
        public void GetAlumnoIfo()
        {
            var alumnos = alumnoDP.GetAll("Primero","C#");

            Assert.IsTrue(alumnos.Count > 0);
        }

        [TestMethod]
        public void GetAllEntityFramework()
        {
            var alumnos = alumnoEF.GetAll();

            Assert.IsTrue(alumnos.Count > 0);
        }

        [TestMethod]
        public void Insert()
        {
            var alumno = new Alumno()
            {
                Nombres = "Fredy",
                Apellidos = "Galvez",
                Sexo = "M",
                FechaNacimiento = DateTime.Now,
                Direccion = "Los Alamos"
            };

           var result = alumnoDA.Insert(alumno);

            Assert.IsTrue(result > 0);
        }
    }
}
