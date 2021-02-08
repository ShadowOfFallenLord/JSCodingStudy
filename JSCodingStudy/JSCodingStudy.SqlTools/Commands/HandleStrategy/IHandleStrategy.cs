﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSCodingStudy.SqlTools.Commands.HandleStrategy
{
    public interface IHandleStrategy
    {
        void Execute(SqlCommand command);
    }
}
