using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRApp.Autotrim
{
    public sealed class AutotrimPixelShift
    {
        internal AutotrimPixelShift()
        {
            Bottom = 0;
            Left = 0;
            Right = 0;
            Top = 0;
        }

        /// <summary>
        /// Gets or sets the number of extra pixels to shift the trim of the bottom edge of the image.
        /// </summary>
        public int Bottom
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of extra pixels to shift the trim of the left edge of the image
        /// </summary>
        public int Left
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of extra pixels to shift the trim of the right edge of the image.
        /// </summary>
        public int Right
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the number of extra pixels to shift the trim of the top edge of the image.
        /// </summary>
        public int Top
        {
            get;
            set;
        }
    }
}
