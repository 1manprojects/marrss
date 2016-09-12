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
    * \brief Structs Class definition.
    *
    * This class defines all necessary enumerators like satellite classification
    * priority and sorting types. Also the class point3D is defined here to hold
    * and store the velocity / position vectors of the satellites.
    * 
    */
    class Structs
    {
        /** Class point3D
        *  @brief 3D double vector
        */
        public class point3D
        {
            public double x, y, z; 
        };

        /** enum SatClass
        *  @brief enum class that represents the satellite classification
        */
        public enum satClass
        {
            UNCLASSIFIED = 0, //!< int 0 unclassified satellite 
            CLASSIFIED = 1, //!< int 1 classified satellite
            SECRET = 2 //!< int 2 secret satellite
        };

        /** enum priorty
        *  @brief enum class that represents the priority
        */
        public enum priority
        {
            CRITICAL = 0, //!< int 0 Critical
            HIGH = 1, //!< int 1 High
            NORMAL = 2, //!< int 2 Normal
            LOW = 3, //!< int 3 Low
            NONE = 4 //!< int 4 None
        };

        /** enum SortByField
        *  @brief enum class that represents how to sort ContactWindows
        */
        public enum sortByField
        {
            TIME = 0x0, //!< int 0 Sort by Time
            GROUNDSTATION = 0x1, //!< int 1 sort by groundstation 
            SATELLITE = 0x2, //!< int 2 sort by satellite
            DURATION = 0x3, //!< int 3 sort by duration
            FIRSTFINISCHED = 0x4 //!< int 4 sort by the first to be finisched
        };

        }
}
