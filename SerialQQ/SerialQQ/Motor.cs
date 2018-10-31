using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialQQ
{
    class Motor
    {
        public int iAngle;// angle to keep motor absoule steps
        public int iVelocity;// velocity to keep motor current velocity
        public int[] aAngle; // array for one process angle
        public int[] aVelocity;// array for one process velocity
        public int[] atSG_RESULT;
        public int iPICount;// pi count
    }
}
