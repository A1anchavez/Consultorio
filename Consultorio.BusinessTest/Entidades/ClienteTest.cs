using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Consultorio.Business.Entidades;

namespace Consultorio.BusinessTest.Entidades
{
    public class ClienteTest
    {
        [Fact]
        public void ClienteCreateValidation_NotNullOrWhiteSpace()
        {
            var cliente = new Cliente();
            Assert.Throws<ArgumentException>("Nombre", () => cliente.Nombre = "");
            Assert.Throws<ArgumentException>("Apellido", () => cliente.Apellido = "");
        }

        [Fact]
        public void ClienteCreateValidation_NombreLength()
        {
            var cliente = new Cliente();
            Assert.Throws<ArgumentException>("Nombre", () => cliente.Nombre = "IA");
        }

        [Fact]
        public void ClienteCreateValidation_ApellidoLength()
        {
            var cliente = new Cliente();
            Assert.Throws<ArgumentException>("Apellido", () => cliente.Apellido = "IALOR");
        }

        [Fact]
        public void Cliente_GetDefaultId()
        {
            var cliente = new Cliente();

            Assert.NotNull(cliente.Id);
        }

    }
}
