/**
* ----------------------------------------------------------------
*
* WGS-82.cs
*
* this file contains the Constants for the WGS-82 Model
*
* code for Bachelor Thesis
*
* Copyright (c) 2015, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution-NoDerivatives 4.0 International Public
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARRSS.SGP4
{
    class WGS_84
    {
        public const double radiusEarthKM = 6378.137;
        public const double mu = 398600.5;
        public const double j2 = 0.00108262998905;
        public const double j3 = -0.00000253215306;
        public const double j4 = -0.00000161098761;
    }
}
