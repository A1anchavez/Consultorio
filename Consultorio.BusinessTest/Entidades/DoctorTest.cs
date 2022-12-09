using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Business.Entidades;
using Consultorio.BusinessTest.Entidades;

namespace Consultorio.BusinessTest.Entidades
{
    public class DoctorTest
    {
        [Fact]
        public void DoctorValidation_CedulaLenght()
        {
            var doctor = new Doctor();
            Assert.Throws<ArgumentException>("Cedula", ()=> doctor.Cedula="1234567890123456");
        }

        [Fact]
        public void DoctorValidation_CedulaIsNumeric()
        {
            var doctor = new Doctor();
            //Assert.Throws<ArgumentException>("Cedula", ()=> doctor.Cedula=int.Parse("1234567890123456"));
        }

        [Fact]
        public void DoctorValidacion_CedulaNotNullOrWhiteSpace()
        {
            var doctor = new Doctor();
            Assert.Throws<ArgumentException>("Nombre", () => doctor.Cedula = "");

        }
    }
}
