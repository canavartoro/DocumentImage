using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentImageCapture
{
    public static class ExtensionMethods
    {
        public static bool IsNull(this object Obj)
        {
            if (object.ReferenceEquals(Obj, null))
                return true;

            return false;
        }

        public static bool IsNotNull(this object Obj)
        {
            if (object.ReferenceEquals(Obj, null))
                return false;
            return true;
        }

        public static string GetString(this object Obj)
        {
            if (object.ReferenceEquals(Obj, null))
                return string.Empty;

            if (object.ReferenceEquals(Obj, DBNull.Value))
                return string.Empty;

            return Obj.ToString().Trim().TrimEnd().Replace("'", "`");
        }

        public static int GetNumber(this object Obj)
        {
            if (object.ReferenceEquals(Obj, null))
                return 0;

            if (object.ReferenceEquals(Obj, DBNull.Value))
                return 0;

            int outval = 0;
            int.TryParse(Obj.ToString(), out outval);

            return outval;
        }

        public static decimal GetDecimal(this object Obj)
        {
            if (object.ReferenceEquals(Obj, null))
                return 0;

            if (object.ReferenceEquals(Obj, DBNull.Value))
                return 0;

            decimal outval = 0;
            decimal.TryParse(Obj.ToString(), out outval);

            return outval;
        }
    }
}
