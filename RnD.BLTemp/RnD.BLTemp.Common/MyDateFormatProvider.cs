using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.BLTemp.Common
{
    public class MyDateFormatProvider : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }
            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg == null) throw new ArgumentNullException("arg");

            Type argType = arg.GetType();
            if (argType == typeof(DateTime))
            {
                DateTime date = (DateTime)arg;
                switch (format)
                {
                    case "mycustomformat":
                        switch (CultureInfo.CurrentCulture.Name)
                        {
                            case "en-GB":
                                return date.ToString("dd dd MMM");
                            default:
                                return date.ToString("dd MMM dd");
                        }
                    case "dd/mm/yyyy":
                        switch (CultureInfo.CurrentCulture.Name)
                        {
                            case "en-GB":
                                return date.ToString("dd dd MMM");
                            default:
                                return date.ToString("dd MMM dd");
                        }
                    default:
                        throw new FormatException();
                }
            }
            else if (argType == typeof(string))
            {
                DateTime date = (DateTime)arg;
                switch (format)
                {
                    case "mycustomformat":
                        switch (CultureInfo.CurrentCulture.Name)
                        {
                            case "en-GB":
                                return date.ToString("dd dd MMM");
                            default:
                                return date.ToString("dd MMM dd");
                        }
                    case "dd/mm/yyyy":
                        switch (CultureInfo.CurrentCulture.Name)
                        {
                            case "en-GB":
                                return date.ToString("dd dd MMM");
                            default:
                                return date.ToString("dd MMM dd");
                        }
                    default:
                        throw new FormatException();
                }
            }
            else return null;
        }
    }
}
