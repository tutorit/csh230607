using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax
{
    internal struct Vector
    {
        private int _i=3;
        public int j { get; set ; }
        public int i
        {
            get
            {
                return _i;
            }
            set
            {
                _i = value;
            }
        }

        public Vector(int i=0,int j = 0)
        {
            _i = i;
            this.j = j;
        }
    }
}
