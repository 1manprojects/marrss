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
using System.IO;

using MARRSS.Definition;
using MARRSS.Scheduler;
using MARRSS.Ground;
using MARRSS.Global;


namespace MARRSS.Drawer
{
/**
* \brief Contacts Drawer Class.
*
* This class draws the contact windows as bmp file wich will be displayed to the user.
* Each Satellite will be given its own color based on its hash-value and will be
* drawn as a rectangle with 10 sec. per pixel.
* 
*/
    class ContactsDrawer
    {
        public ContactsDrawer()
        {

        }

        //! Draw Conatact Windows.
        /*!
          \param ContactWindowsVector Contacts
          \param bool Draw All if false only scheduled contacts will be drawn
          \return Image bmp-Image
          Creates a bmp Image and returns it
        */
        public static Image drawContacts(ContactWindowsVector contacts, bool drawAll)
        {
            if (contacts != null)
            {

                //sort by Groundstations
                contacts.sort(Structs.sortByField.GROUNDSTATION);

                List<string> satNameList = contacts.getSatelliteNames();
                List<string> staNameList = contacts.getStationNames();

                int x_offset = 100;
                int y_offset = 20;
                int satBoxheight = 20;

                //calculate Size of Image
                double timeLength = contacts.getStopTime().getEpoch() - contacts.getStartTime().getEpoch();
                int imWidth = Convert.ToInt32(timeLength = 8640 * timeLength);
                int imHeight = satNameList.Count() * staNameList.Count() * 20;
                Image dest = new Bitmap(imWidth + x_offset, imHeight + y_offset);

                //Generate Front and Brusch for drawing
                System.Drawing.Graphics g;
                System.Drawing.Pen pen = new System.Drawing.Pen(Color.Black, 1F);
                Font drawFont = new Font("Arial", 10);
                SolidBrush brush = new SolidBrush(Color.Black);
                g = Graphics.FromImage(dest);
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;

                //Start Drawing Contact Windows
                for (int i = 0; i < contacts.Count(); i++)
                {
                    //Draw only if scheduled unless drawAll = true
                    if (contacts.getAt(i).getSheduledInfo() || drawAll)
                    {
                        int satPosY = satNameList.IndexOf(contacts.getAt(i).getSatName());
                        int staPosY = staNameList.IndexOf(contacts.getAt(i).getStationName());

                        int y = 0;
                        int x = 0;
                        int satBoxhWidth = 0;

                        y = satPosY * 20 + staPosY * satNameList.Count() * 20 + y_offset;
                        double satx = 8640 * (contacts.getAt(i).getStartTime().getEpoch() - contacts.getStartTime().getEpoch());
                        x = Convert.ToInt32(satx) + x_offset;
                        satBoxhWidth = Convert.ToInt32( contacts.getAt(i).getDuration() / 10.0 );

                        //brush = new SolidBrush(Color.FromArgb(contacts.getAt(i).getHash()));
                        if (drawAll && !contacts.getAt(i).getSheduledInfo())
                        {
                            brush = new SolidBrush(Color.FromArgb(215, 215, 215));
                            g.FillRectangle(brush, new Rectangle(x, y, satBoxhWidth, satBoxheight));
                            g.DrawString(contacts.getAt(i).getSatName(), drawFont, new SolidBrush(Color.DarkGray), x, y);
                        }
                        else
                        {
                            brush = new SolidBrush(Color.FromArgb(contacts.getAt(i).getHash()));
                            g.FillRectangle(brush, new Rectangle(x, y, satBoxhWidth, satBoxheight));
                            g.DrawString(contacts.getAt(i).getSatName(), drawFont, new SolidBrush(Color.Black), x, y);
                        }
                    }
                }

                System.Drawing.Pen stationPen;
                stationPen = new System.Drawing.Pen(Color.DarkGray, 1);

                g.DrawLine(stationPen, x_offset, 0, x_offset, imHeight);

                //Start Drawing Stations Names 
                for (int i = 0; i < staNameList.Count(); i++)
                {
                    int x1 = 0;
                    int y1 = (i + 1) * satNameList.Count() * 20;
                    int x2 = imWidth;
                    int y2 = (i + 1) * satNameList.Count() * 20;
                    g.DrawString(staNameList[i], drawFont, new SolidBrush(Color.Black), 5, y1 - ((satNameList.Count() / 2) * 20));
                    g.DrawLine(stationPen, x1, y1 + y_offset, x2, y2 + y_offset);
                }

                One_Sgp4.EpochTime time = new One_Sgp4.EpochTime(contacts.getStartTime());
                g.DrawString(contacts.getStartTime().ToString(), drawFont, new SolidBrush(Color.Black), x_offset, 5);

                for (int i = x_offset; i < imWidth; i += 180)
                {
                    g.DrawString(time.ToString(), drawFont, new SolidBrush(Color.Black), i, 5);
                    g.DrawLine(stationPen, i, 0, i, imHeight);
                    time.addTick(10 * 180);
                }

                //g.Dispose();
                drawFont.Dispose();
                brush.Dispose();
                pen.Dispose();

                dest.Save("Contacts.bmp");

                return dest;
            }
            else
            {
                int imWidth = 8640;
                int imHeight = 20;
                Image dest = new Bitmap(imWidth, imHeight);
                return dest;
            }
        }
    }
}
