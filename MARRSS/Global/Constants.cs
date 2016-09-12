/**
* ----------------------------------------------------------------
* Nikolai Jonathan Reed 
*
* 
* Copyright (c) 2015, Nikolai Reed, 1manprojects.de
* All rights reserved.
*
* Licensed under
* Creative Commons Attribution NonCommercial (CC-BY-NC)
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MARRSS.Global
{
/**
* \brief Constants definition.
*
* This class defines global constants that are used in multiple instances of the
* software. 
*/
    class Constants
    {
        public const double pi = Math.PI; //!< double constant Pi
        public const double twoPi = pi * 2.0; //!< double constant two Pi
        public const double toDegrees = 180.0 / pi; //!< double constant conversion to degree
        public const double toRadians = pi / 180.0; //!< double constant converstion to radians

        public const int maxInt = 2147483647; //!< int max integer value

        public const double deltaElevation = 0.005; //!< double elevation error wenn visible in radians
    }
}