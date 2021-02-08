﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.SqlTools.ORM.TypeCasting
{
    public static class CastersKeeper
    {
        public static CasterToNullableInt CasterToNullableInt { get; private set; } = new CasterToNullableInt();

        public static CasterToInt CasterToInt { get; private set; } = new CasterToInt();

        public static CasterToNullableDateTime CasterToNullableDateTime { get; private set; } = new CasterToNullableDateTime();

        public static CasterToDateTime CasterToDateTime { get; private set; } = new CasterToDateTime();

        public static CasterToString CasterToString { get; private set; } = new CasterToString();
    }
}