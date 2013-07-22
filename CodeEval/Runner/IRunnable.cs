using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Runner
{
    interface IRunnable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input">Input parameters</param>
        /// <returns>Output</returns>
        string Run(string input);
    }
}
