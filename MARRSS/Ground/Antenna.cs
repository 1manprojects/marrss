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

namespace MARRSS.Ground
{
    /**
    * \brief Antenna Class definition.
    *
    * This class defines the antenna object of a ground station.
    * Each ground station has one or mutliple antennas and each antenna
    * can be diffrent. 
    * Currently this class is not being used and is only here so the software
    * can be expanded in the futur. 
    */
    class Antenna
    {
        private double area; //!< double area size of the Antenna
        private double diameter; //!< double diameter of the antenna in meter
        private double wavelengh; //!< double wavelenght of the antenna 
        private double efficiency; //!< double efficency of the antenna
        private double beamwidth; //!< double beamwitdh of the antenna

        private double minElevation; //!< double min elevation of the antenna

        private double minAzimuth; //!< double min azimuth of antenna
        private double maxAzimuth; //!< double max azimuth of antenna

        public Antenna()
        {

        }

    }
}
