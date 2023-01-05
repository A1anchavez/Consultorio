using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Transversal.Guards
{
    public static class Guard
    {
        #region Metodos de Extension
        public static string HasValue(this string value, string property)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("El nombre del Cliente debe contener un valor", property);
            }
            return value;
        }
        public static string GreaterThan(this string value, int min, string property)
        {
            if (value.Length <= min)
            {
                throw new ArgumentException(
                    $"El nombre del Cliente debe ser mayor a {min} caracteres",
                    property);
            }

            return value;
        }

        public static int Between(this int value, int min, int max, [CallerArgumentExpression("value")] string property = "")
        {
            if (value >= min && value <= max)
                throw new ArgumentException("Valor no permitido", property);


            return value;
        }

        public static DateTime HourBetween(this DateTime value, int min, int max, [CallerArgumentExpression("value")] string property = "")
        {
            if (value.Hour >= min && value.Hour <= max)
                throw new ArgumentException("Valor no permitido", property);


            return value;
        }

        public static DateTime? NotNull(this DateTime? value, [CallerArgumentExpression("value")] string property = "")
        {
            if (value is null)
                throw new ArgumentException("La fecha debe contener un valor", property);

            return value;
        }

        public static DateTime LaborDays(this DateTime value, bool includeSaturday = true, [CallerArgumentExpression("value")] string property = "")
        {
            if (value.DayOfWeek == DayOfWeek.Sunday || (value.DayOfWeek == DayOfWeek.Saturday && includeSaturday))
                throw new ArgumentException("La fecha fuera de horario laboral", property);

            return value;
        }

        public static DateTime AfterNow(this DateTime value, Period periodo = Period.Hour, [CallerArgumentExpression("value")] string property = "")
        {
            var newDate = periodo switch
            {
                Period.Hour => value.AddHours(1),
                Period.Day => value.AddDays(1),
                Period.Month => value.AddMonths(1),
                Period.Year => value.AddYears(1),
                _ => throw new ArgumentException("Opción fuera del indice", nameof(periodo))
            };

            if (newDate >= DateTime.Now)
                throw new ArgumentException("Fecha fuera del intervalo", property);

            return value;


        }

        public enum Period
        {
            Hour, Day, Month, Year
        }
        #endregion

        #region Metodos Estaticos
        public static class Against
        {
            public static string NotNull(string value, string property)
            {
                if (String.IsNullOrWhiteSpace(value) && value.Length > 2)
                {
                    throw new ArgumentException("El nombre del Cliente debe contener un valor", property);
                }
                return value;
            }
            public static string GreaterThan(string value, int min, string property)
            {
                if (value.Length < min)
                {
                    throw new ArgumentException(
                        $"El nombre del Cliente debe ser mayo a {min} caracteres",
                        property);
                }
                return value;
            }
        }
        #endregion

        #region tarea 

        public static string LowerThan(this string value, int max, string property)
        {
            if (value.Length >= max)
            {
                throw new ArgumentException($"El nombre del cliente debe ser menor a {max} caracteres", property);
            }
            return value;
        }
        public static string EqualsNumber(this string value, int equal, string property)
        {
            if (value.Length != equal)
            {
                throw new ArgumentException($"Debe contener {equal} caracteres ", property);
            }
            return value;
        }


        public static string HasWhiteSpace(this string value, string property)
        {
            if (value.Contains(" "))
            {
                throw new ArgumentException("No debe llevar espacios en blanco", property);
            }
            return value;
        }

        public static string IsNumber(this string value, string property)
        {
            long isNumber;
            bool isTrue = (long.TryParse(value, out isNumber));
            if (isTrue == false)
            {
                throw new ArgumentException("Solo debe contener numeros", property);
            }

            return value;
        }

        public static string HasDash(this string value, string property)
        {
            if (value.Contains("-") || value.Contains("_"))
            {
                throw new ArgumentException("No debe llevar guion", property);
            }
            return value;
        }
        public static DateTime? HasProperAge(this DateTime? value, string property)
        {
            DateTime FechaMinima = new DateTime(1920, 01, 01, 8, 0, 0);


            if (value>DateTime.Now || value<FechaMinima)
            {
                throw new ArgumentException("Fechas ingresadas no permitidas", property);
            }
            return value;
        }
        #endregion
    }
}
