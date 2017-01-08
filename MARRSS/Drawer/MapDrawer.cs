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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.IO;

using MARRSS.Definition;
using MARRSS.Scheduler;
using MARRSS.Ground;
using MARRSS.Global;

namespace MARRSS.Drawer
{
    /**
* \brief Map Drawer Class.
*
* This class draws the ground stations in the Database to the Image of the
   earth and satellite paths over ground.
* 
*/
    class MapDrawer
    {
        //! Draw Stations from Database onto image.
        /*!
          \param DataGridViewRowCollections rows of stations to draw
          \param DataBase database that holds all the information
          \return Image bmp-Image
        */
        public static Image drawStation(DataGridViewRowCollection rows, DataBase.DataBase db)
        {
            Image imgStation = Properties.Resources.worldsmaller;

            Pen penRest = new Pen(Color.Orange, 2);
            using (var graphics = Graphics.FromImage(imgStation))
            {
                for (int i = 0; i < rows.Count; i++)
                {
                    Ground.Station item = db.getStationFromDB(rows[i].Cells[0].Value.ToString());
                    Point p = item.getGeoCoordinate().toPoint(imgStation.Width, imgStation.Height);
                    graphics.DrawRectangle(penRest, p.X - 10, p.Y - 10, 20, 20);
                }
            }

            return imgStation;
        }

        //! Draw selected satellite path to image.
        /*!
          \param One_Sgp4.Tle tle data from selected Satellite
          \return Image bmp-Image
        */
        public static Image drawSatellite(One_Sgp4.Tle tleData )
        {
            Image imgSatellite = Properties.Resources.worldsmaller;
            try
            {
                One_Sgp4.Sgp4 task = new One_Sgp4.Sgp4(tleData, Properties.Settings.Default.orbit_Wgs);
                One_Sgp4.EpochTime starttime = new One_Sgp4.EpochTime(DateTime.UtcNow);
                One_Sgp4.EpochTime stoptime = new One_Sgp4.EpochTime(DateTime.UtcNow.AddHours(4));
                task.setStart(starttime, stoptime, 30.0 / 60.0);
                Task thread = new Task(task.starThread);
                thread.Start();
                Task.WaitAll(thread);
                List<One_Sgp4.Sgp4Data> calcPposData = null;
                calcPposData = task.getRestults();

                Pen penRest = new Pen(Color.Red, 1);
                Pen penSat = new Pen(Color.Red, 10);
                using (var graphics = Graphics.FromImage(imgSatellite))
                {
                    for (int i = 0; i < calcPposData.Count; i++)
                    {

                        One_Sgp4.Coordinate oneSubPoint =
                            One_Sgp4.SatFunctions.calcSatSubPoint(starttime, calcPposData[i]);

                        Definition.GeoCoordinate subPoint = new Definition.GeoCoordinate(oneSubPoint.getLatetude(), oneSubPoint.getLongitude(), oneSubPoint.getHeight());

                        Point p = subPoint.toPoint(imgSatellite.Width, imgSatellite.Height);

                        graphics.DrawRectangle(penRest, p.X - 1, p.Y - 1, 2, 2);
                        if (i == 0)
                            graphics.DrawRectangle(penSat, p.X - 5, p.Y - 5, 2, 2);
                        starttime.addTick(30.0);
                    }
                }
            }
            catch
            {
                imgSatellite = Properties.Resources.worldsmaller;
            }
            return imgSatellite;
        }
    }
}
