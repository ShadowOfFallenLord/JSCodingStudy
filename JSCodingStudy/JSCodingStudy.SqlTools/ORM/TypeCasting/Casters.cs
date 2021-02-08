using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.SqlTools.ORM.TypeCasting
{
    public abstract class AbstractCaster
    {
        public abstract object Cast(object obj);
    }

    public class CasterToNullableInt : AbstractCaster
    {
        public override object Cast(object obj)
        {
            return obj as int?;
        }
    }

    public class CasterToInt : CasterToNullableInt
    {
        public override object Cast(object obj)
        {
            return base.Cast(obj) ?? -1;
        }
    }

    public class CasterToNullableDateTime : AbstractCaster
    {
        public override object Cast(object obj)
        {
            return obj as DateTime?;
        }
    }

    public class CasterToDateTime : CasterToNullableDateTime
    {
        public override object Cast(object obj)
        {
            return base.Cast(obj) ?? DateTime.MinValue;
        }
    }

    public class CasterToString : AbstractCaster
    {
        public override object Cast(object obj)
        {
            return obj as string;
        }
    }
}
