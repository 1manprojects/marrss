/**
* DeepSpaceObjects.cs
*
* This class contains the contains help variables for orbit Calculation
* and correction of Deep Space Objects
* 
* 
* Code for Orbit-calculation is based on the SPACETRACK REPORT NO. 3
* Revisiting Spacetrack Report #3: Rev 2
* David A. Vallado, Paul Cawford, Richard Hujsak, T.S. Kelso
* http://www.celestrak.com/publications/AIAA/2006-6753/
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
    class DeepSpaceObjects
    {
        public int dso_irez;
        public double dso_d2201;
        public double dso_d2211;
        public double dso_d3210;
        public double dso_d3222;
        public double dso_d4410;
        public double dso_d4422;
        public double dso_d5220;
        public double dso_d5232;
        public double dso_d5421;
        public double dso_d5433;
        public double dso_dedt;
        public double dso_del1;
        public double dso_del2;
        public double dso_del3;
        public double dso_didt;
        public double dso_dmdt;
        public double dso_dnodt;
        public double dso_domdt;
        public double dso_e3;
        public double dso_ee2;
        public double dso_peo;
        public double dso_pgho;
        public double dso_pho;
        public double dso_pinco;
        public double dso_plo;
        public double dso_se2;
        public double dso_se3;
        public double dso_sgh2;
        public double dso_sgh3;
        public double dso_sgh4;
        public double dso_sh2;
        public double dso_sh3;
        public double dso_si2;
        public double dso_si3;
        public double dso_sl2;
        public double dso_sl3;
        public double dso_sl4;
        public double dso_gsto;
        public double dso_xfact;
        public double dso_xgh2;
        public double dso_xgh3;
        public double dso_xgh4;
        public double dso_xh2;
        public double dso_xh3;
        public double dso_xi2;
        public double dso_xi3;
        public double dso_xl2;
        public double dso_xl3;
        public double dso_xl4;
        public double dso_xlamo;
        public double dso_zmol;
        public double dso_zmos;
        public double dso_atime;
        public double dso_xli;
        public double dso_xni;

        public DeepSpaceObjects()
        {
            dso_irez = 0;
	        dso_d2201 = 0.0;
	        dso_d2211 = 0.0;
	        dso_d3210 = 0.0;
	        dso_d3222 = 0.0;
	        dso_d4410 = 0.0;
	        dso_d4422 = 0.0;
	        dso_d5220 = 0.0;
	        dso_d5232 = 0.0;
	        dso_d5421 = 0.0;
	        dso_d5433 = 0.0;
	        dso_dedt = 0.0;
	        dso_del1 = 0.0;
	        dso_del2 = 0.0;
	        dso_del3 = 0.0;
	        dso_didt = 0.0;
	        dso_dmdt = 0.0;
	        dso_dnodt = 0.0;
	        dso_domdt = 0.0;
	        dso_e3 = 0.0;
	        dso_ee2 = 0.0;
	        dso_peo = 0.0;
	        dso_pgho = 0.0;
	        dso_pho = 0.0;
	        dso_pinco = 0.0;
	        dso_plo = 0.0;
	        dso_se2 = 0.0;
	        dso_se3 = 0.0;
	        dso_sgh2 = 0.0;
	        dso_sgh3 = 0.0;
	        dso_sgh4 = 0.0;
	        dso_sh2 = 0.0;
	        dso_sh3 = 0.0;
	        dso_si2 = 0.0;
	        dso_si3 = 0.0;
	        dso_sl2 = 0.0;
	        dso_sl3 = 0.0;
	        dso_sl4 = 0.0;
	        dso_gsto = 0.0;
	        dso_xfact = 0.0;
	        dso_xgh2 = 0.0;
	        dso_xgh3 = 0.0;
	        dso_xgh4 = 0.0;
	        dso_xh2 = 0.0;
	        dso_xh3 = 0.0;
	        dso_xi2 = 0.0;
	        dso_xi3 = 0.0;
	        dso_xl2 = 0.0;
	        dso_xl3 = 0.0;
	        dso_xl4 = 0.0;
	        dso_xlamo = 0.0;
	        dso_zmol = 0.0;
	        dso_zmos = 0.0;
	        dso_atime = 0.0;
	        dso_xli = 0.0;
	        dso_xni = 0.0;
        }
    }
}
