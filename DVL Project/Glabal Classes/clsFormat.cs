﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVL_Project.Glabal_Classes
{
    public class clsFormat
    {
        public static string DateToShort(DateTime dt)
        {
            return dt.ToString("dd/MMM/yyyy");
        }

    }
}
