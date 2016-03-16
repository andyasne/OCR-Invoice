using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRApp.TextCleaner
{
    public sealed class TextCleanerCropOffset
    {
        internal TextCleanerCropOffset()
        {
            Bottom = 0;
            Left = 0;
            Right = 0;
            Top = 0;
        }

        internal bool IsSet
        {
            get
            {
                return Bottom != 0 || Left != 0 || Right != 0 || Top != 0;
            }
        }

        internal bool IsValid
        {
            get
            {
                return Bottom >= 0 && Left >= 0 && Right >= 0 && Top >= 0;
            }
        }

        /// <summary>
        /// Gets or sets the width, in pixels, of the lower side of the bounding rectangle.
        /// </summary>
        public int Bottom
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the width, in pixels, of the left side of the bounding rectangle.
        /// </summary>
        public int Left
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the width, in pixels, of the right side of the bounding rectangle.
        /// </summary>
        public int Right
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the width, in pixels, of the upper side of the bounding rectangle.
        /// </summary>
        public int Top
        {
            get;
            set;
        }
    }
}
