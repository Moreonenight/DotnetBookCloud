﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace DotnetBookCloud.Utils
{
    public class DateHelper
    {
        [DllImport(@"BookCloudWin32DLL.dll")]
        private static extern bool DateLengthCheck(int length);
        public static String FormatTime(String time)
        {
            String[]
            times = time.Split(":");

            if (!DateLengthCheck(time.Length))
            {
                throw new Exception(time + ":Time length is wrong!");
            }
            int i;
            String formattedTime = times[0];
            for (i = 1; i < times.Length; ++i)
            {
                formattedTime += ":" + times[i];
            }
            for (; i < 3; ++i)
            {
                formattedTime += ":00";
            }
            return formattedTime;
        }
    }
}
