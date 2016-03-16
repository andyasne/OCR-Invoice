using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRApp.Autotrim
{
    public enum WhiteboardEnhancements
    {
        /// <summary>
        /// No ehancement
        /// </summary>
        None = 0,

        /// <summary>
        /// Stretch
        /// </summary>
        Stretch = 1,

        /// <summary>
        /// White balance
        /// </summary>
        Whitebalance = 2,

        /// <summary>
        /// Stretch and whitebalance.
        /// </summary>
        Both = Stretch | Whitebalance
    }
}
