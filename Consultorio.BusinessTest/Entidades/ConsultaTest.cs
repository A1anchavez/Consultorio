using Consultorio.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consultorio.BusinessTest.Entidades
{
    public class ConsultaTest
    {
        [Fact]
        public void ValidarFecha()
        {
            var consulta = new Consulta();
            var fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 4);
            Assert.Throws<ArgumentException>("FechaConsulta", () => consulta.FechaConsulta = fecha);
        }

        [Fact]
        public void ValidarHorarioLaboral()
        {
            var consulta = new Consulta();
            var hora = new DateTime(DateTime.Now.Hour);
            Assert.Throws<ArgumentException>("FechaConsulta", () => consulta.FechaConsulta = hora);
        }

        [Fact]
        public void ValidarFechaDesocupada()
        {

        }
    }
}
