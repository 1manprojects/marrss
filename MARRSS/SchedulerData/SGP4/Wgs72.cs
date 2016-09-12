/**
* ----------------------------------------------------------------
*
* WGS-72.cs
*
* this file contains the Constants for the WGS-72 Model
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
    class WGS_72
    {
        public const double radiusEarthKM = 6378.135;
        public const double mu = 398600.8;
        public const double j2 = 0.001082616;
        public const double j3 = -0.00000253881;
        public const double j4 = -0.00000165597;
    }
}
