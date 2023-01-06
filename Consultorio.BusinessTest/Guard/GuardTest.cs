using Consultorio.Business.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Transversal.Guards;

namespace Consultorio.BusinessTest.Guard
{
    public class GuardTest
    {
        [Theory]
        [InlineData(5)]
        [InlineData(20)]
        public void ValidarHourBetween_Error_FueraDeLimit(int parametro)
        {
            var hora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, parametro,0,0).AddDays(1);
            Assert.Throws<ArgumentException>("hora", () => hora.HourBetween(8,19));
        }
        [Fact]
        public void ValidarHourBetween_DentroDeLimite()
        {
            var hora = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 12, 0, 0).AddDays(1);
            Assert.Equal(hora, hora.HourBetween(8, 19));
        }

        [Theory]
        [InlineData(7)]
        [InlineData(8)]
        public void ValidarLaborDays_Error(int parametro)
        {
            var dia = new DateTime(2023, 1, parametro);
            Assert.Throws<ArgumentException>("dia", () => dia.LaborDays());
        }

        [Fact]
        public void ValidarLaborDays_DiaValido()
        {
            var dia = new DateTime(2023, 1, 6);
            Assert.Equal(dia, dia.LaborDays());
        }
    }
}
