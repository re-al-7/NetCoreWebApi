#region

/* ****************************************************** */
/* GENERADO POR: ReAl ClassGenerator
/* SISTEMA: AP
/* AUTOR: R. Alonzo Vera
/* FECHA: 04/10/2010  -  18:15
/* ****************************************************** */



#endregion

using System.Globalization;

namespace Integrate.Utils
{
    using System;

    /// <summary>
	/// Common DateTime Methods.
	/// </summary>
	/// 
	public enum Quarter
    {
        First = 1,
        Second = 2,
        Third = 3,
        Fourth = 4
    }

    public enum Month
    {
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12
    }

    public class cFuncionesFechas
    {
        #region Quarter

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;

            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        #endregion

        #region Quarter

        public static DateTime GetStartOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)   // 1st Quarter = January 1 to March 31
                return new DateTime(Year, 1, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30
                return new DateTime(Year, 4, 1, 0, 0, 0, 0);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30
                return new DateTime(Year, 7, 1, 0, 0, 0, 0);
            else // 4th Quarter = October 1 to December 31
                return new DateTime(Year, 10, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfQuarter(int Year, Quarter Qtr)
        {
            if (Qtr == Quarter.First)   // 1st Quarter = January 1 to March 31
                return new DateTime(Year, 3, DateTime.DaysInMonth(Year, 3), 23, 59, 59, 999);
            else if (Qtr == Quarter.Second) // 2nd Quarter = April 1 to June 30
                return new DateTime(Year, 6, DateTime.DaysInMonth(Year, 6), 23, 59, 59, 999);
            else if (Qtr == Quarter.Third) // 3rd Quarter = July 1 to September 30
                return new DateTime(Year, 9, DateTime.DaysInMonth(Year, 9), 23, 59, 59, 999);
            else // 4th Quarter = October 1 to December 31
                return new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        public static Quarter GetQuarter(Month month)
        {
            if (month <= Month.March)   // 1st Quarter = January 1 to March 31
                return Quarter.First;
            else if ((month >= Month.April) && (month <= Month.June)) // 2nd Quarter = April 1 to June 30
                return Quarter.Second;
            else if ((month >= Month.July) && (month <= Month.September)) // 3rd Quarter = July 1 to September 30
                return Quarter.Third;
            else // 4th Quarter = October 1 to December 31
                return Quarter.Fourth;
        }

        public static DateTime GetEndOfLastQuarter()
        {
            if (DateTime.Now.Month <= (int)Month.March) //go to last quarter of previous year
                return GetEndOfQuarter(DateTime.Now.Year - 1, GetQuarter(Month.December));
            else //return last quarter of current year
                return GetEndOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetStartOfLastQuarter()
        {
            if (DateTime.Now.Month <= 3) //go to last quarter of previous year
                return GetStartOfQuarter(DateTime.Now.Year - 1, GetQuarter(Month.December));
            else //return last quarter of current year
                return GetStartOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetStartOfCurrentQuarter()
        {
            return GetStartOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }

        public static DateTime GetEndOfCurrentQuarter()
        {
            return GetEndOfQuarter(DateTime.Now.Year, GetQuarter((Month)DateTime.Now.Month));
        }
        #endregion

        #region Weeks
        public static DateTime GetStartOfLastWeek()
        {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek + 7;
            DateTime dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfLastWeek()
        {
            DateTime dt = GetStartOfLastWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }

        public static DateTime GetStartOfCurrentWeek()
        {
            int DaysToSubtract = (int)DateTime.Now.DayOfWeek;
            DateTime dt = DateTime.Now.Subtract(System.TimeSpan.FromDays(DaysToSubtract));
            return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfCurrentWeek()
        {
            DateTime dt = GetStartOfCurrentWeek().AddDays(6);
            return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
        }
        #endregion

        #region Months

        public static DateTime GetStartOfMonth(int Month, int Year)
        {
            return new DateTime(Year, Month, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfMonth(int Month, int Year)
        {
            return new DateTime(Year, Month, DateTime.DaysInMonth(Year, Month), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetStartOfMonth(12, DateTime.Now.Year - 1);
            else
                return GetStartOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
        }

        public static DateTime GetEndOfLastMonth()
        {
            if (DateTime.Now.Month == 1)
                return GetEndOfMonth(12, DateTime.Now.Year - 1);
            else
                return GetEndOfMonth(DateTime.Now.Month - 1, DateTime.Now.Year);
        }

        public static DateTime GetStartOfCurrentMonth()
        {
            return GetStartOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentMonth()
        {
            return GetEndOfMonth(DateTime.Now.Month, DateTime.Now.Year);
        }
        #endregion

        #region Years
        public static DateTime GetStartOfYear(int Year)
        {
            return new DateTime(Year, 1, 1, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfYear(int Year)
        {
            return new DateTime(Year, 12, DateTime.DaysInMonth(Year, 12), 23, 59, 59, 999);
        }

        public static DateTime GetStartOfLastYear()
        {
            return GetStartOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetEndOfLastYear()
        {
            return GetEndOfYear(DateTime.Now.Year - 1);
        }

        public static DateTime GetStartOfCurrentYear()
        {
            return GetStartOfYear(DateTime.Now.Year);
        }

        public static DateTime GetEndOfCurrentYear()
        {
            return GetEndOfYear(DateTime.Now.Year);
        }
        #endregion

        #region Days

        public static DateTime GetStartOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }

        public static DateTime GetEndOfDay(DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59, 999);
        }

        #endregion


        /// <summary>
        ///     FUncion que devuelve la diferencia de dias, horas, minutos o segundos entre dos fechas
        /// </summary>
        /// <param name="Fecha1" type="System.DateTime">
        ///     <para>
        ///         Fecha Inicial
        ///     </para>
        /// </param>
        /// <param name="Fecha2" type="System.DateTime">
        ///     <para>
        ///         Fecha Final
        ///     </para>
        /// </param>
        /// <param name="Type" type="string">
        ///     <para>
        ///         Tipo de diferencia: 
        ///             "ss" - segundos
        ///             "mm" - minutos
        ///             "hh" - horas
        ///             "dd" - dias
        ///     </para>
        /// </param>
        /// <returns>
        ///     A int value...
        /// </returns>
        public static int dateDiff(DateTime Fecha1, DateTime Fecha2, string Type)
        {
            TimeSpan span = Fecha1.Subtract(Fecha2);

            switch (Type)
            {
                case "ss":
                    return span.Seconds;
                case "mm":
                    return span.Minutes + (span.Hours * 60);
                case "hh":
                    return span.Hours + (span.Days * 24);
                case "dd":
                    return span.Days;
                default:
                    return 0;
            }
        }

        /// <summary>
        ///     Funcion que verifica di la primera fecha es mayor a la segunda (Evalua desde YEAR hasta SECOND)
        /// </summary>
        /// <param name="fecha1" type="DateTime">
        ///     <para>
        ///         Fecha 1 a evaluar
        ///     </para>
        /// </param>
        /// <param name="fecha2" type="DateTime">
        ///     <para>
        ///         Fecha 2 que se compara con la Fecha 1
        ///     </para>
        /// </param>
        public static bool dateEsMayor(DateTime fecha1, DateTime fecha2)
        {

            if (fecha1.Year > fecha2.Year)
                return true;
            if (fecha1.Year == fecha2.Year)
            {
                if (fecha1.Month > fecha2.Month)
                    return true;
                if (fecha1.Month == fecha2.Month)
                {
                    if (fecha1.Day > fecha2.Day)
                        return true;
                    if (fecha1.Day == fecha2.Day)
                    {
                        if (fecha1.Hour > fecha2.Hour)
                            return true;
                        if (fecha1.Hour == fecha2.Hour)
                        {
                            if (fecha1.Minute > fecha2.Minute)
                                return true;
                            if (fecha1.Minute == fecha2.Minute)
                            {
                                if (fecha1.Second >= fecha2.Second)
                                    return true;
                                return false;
                            }
                            return false;
                        }
                        return false;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        ///     Funcion que determina si una hora es Mayor o Igual a otra
        /// </summary>
        /// <param name="Hora1" type="System.DateTime">
        ///     <para>
        ///         Hora 1 a comparar
        ///     </para>
        /// </param>
        /// <param name="Hora2" type="System.DateTime">
        ///     <para>
        ///         Hora 2 a comparar
        ///     </para>
        /// </param>
        /// <returns>
        ///     TRUE si el primer parametro pasado es mayor o igual
        ///     FALSE si el segundo parametro es mayor
        /// </returns>
        public static bool dateHoraEsMayorIgualQue(DateTime Hora1, DateTime Hora2)
        {
            if (Hora1.Hour > Hora2.Hour)
                return true;
            if (Hora1.Hour == Hora2.Hour)
            {
                if (Hora1.Minute > Hora2.Minute)
                    return true;
                if (Hora1.Minute == Hora2.Minute)
                    return true;
                return false;
            }
            return false;
        }

        /// <summary>
        ///     Funcion que determina si una hora es mayor a otra
        /// </summary>
        /// <param name="Hora1" type="System.DateTime">
        ///     <para>
        ///         Hora 1 a comparar
        ///     </para>
        /// </param>
        /// <param name="Hora2" type="System.DateTime">
        ///     <para>
        ///         Hora 2 a comparar
        ///     </para>
        /// </param>
        /// <returns>
        ///     TRUE si el primer parametro pasado es Mayor
        ///     FALSE si el segundo parametro es mayor
        /// </returns>
        public static bool dateHoraEsMayorQue(DateTime Hora1, DateTime Hora2)
        {
            if (Hora1.Hour > Hora2.Hour)
                return true;
            if (Hora1.Hour == Hora2.Hour)
            {
                if (Hora1.Minute > Hora2.Minute)
                    return true;
                if (Hora1.Minute == Hora2.Minute)
                    return false;
                return false;
            }
            return false;
        }

        /// <summary>
        ///     Funcion que determina si una hora es Menor o Igual a otra
        /// </summary>
        /// <param name="Hora1" type="System.DateTime">
        ///     <para>
        ///         Hora 1 a comparar
        ///     </para>
        /// </param>
        /// <param name="Hora2" type="System.DateTime">
        ///     <para>
        ///         Hora 2 a comparar
        ///     </para>
        /// </param>
        /// <returns>
        ///     TRUE si el primer parametro pasado es menor o igual
        ///     FALSE si el segundo parametro es menor
        /// </returns>
        public static bool dateHoraEsMenorIgualQue(DateTime Hora1, DateTime Hora2)
        {
            if (Hora1.Hour < Hora2.Hour)
                return true;
            if (Hora1.Hour == Hora2.Hour)
            {
                if (Hora1.Minute < Hora2.Minute)
                    return true;
                if (Hora1.Minute == Hora2.Minute)
                    return true;
                return false;
            }
            return false;
        }

        /// <summary>
        ///     Funcion que determina si una hora es menor a otra
        /// </summary>
        /// <param name="Hora1" type="System.DateTime">
        ///     <para>
        ///         Hora 1 a comparar
        ///     </para>
        /// </param>
        /// <param name="Hora2" type="System.DateTime">
        ///     <para>
        ///         Hora 2 a comparar
        ///     </para>
        /// </param>
        /// <returns>
        ///     TRUE si el primer parametro pasado es menor
        ///     FALSE si el segundo parametro es menor
        /// </returns>
        public static bool dateHoraEsMenorQue(DateTime Hora1, DateTime Hora2)
        {
            if (Hora1.Hour < Hora2.Hour)
                return true;
            if (Hora1.Hour == Hora2.Hour)
            {
                if (Hora1.Minute < Hora2.Minute)
                    return true;
                if (Hora1.Minute == Hora2.Minute)
                    return false;
                return false;
            }
            return false;
        }

        /// <summary>
        ///     Funcion que determina si una hora esta entre dos horas
        /// </summary>
        /// <param name="Hora" type="System.DateTime">
        ///     <para>
        ///         Hora que se debe evaluar 
        ///     </para>
        /// </param>
        /// <param name="HoraInicio" type="System.DateTime">
        ///     <para>
        ///         Hora inicial del rango
        ///     </para>
        /// </param>
        /// <param name="HoraFinal" type="System.DateTime">
        ///     <para>
        ///         Hora final del rango
        ///     </para>
        /// </param>
        /// <returns>
        ///     TRUE:  si el primer parametro esta entre los otros dos parametros
        ///     FALSE: si el primer parametro NO esta entre los otros dos parametros
        /// </returns>
        public static bool dateHoraEstaEnRango(DateTime Hora, DateTime HoraInicio, DateTime HoraFinal)
        {
            return (dateEsMayor(Hora, HoraInicio) && dateEsMayor(HoraFinal, Hora));
        }
    }
}

