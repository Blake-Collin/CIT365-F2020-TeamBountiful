﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.PerformanceData;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaDesk1._0
{
    //Limit ourselves to these types

    public enum DeskMaterial
    {
        Pine,
        Laminate,
        Veneer,
        Oak,
        Rosewood
    }


    [JsonObject(MemberSerialization.OptIn)]
    public class Desk
    {
        //CONSTANT VARIABLES
        private static int MAXIMUMDEPTH = 48;
        private static int MINIMUUMDEPTH = 12;
        private static int MAXIMUMWIDTH = 96;
        private static int MINIMUUMWIDTH = 24;
        private static int MAXIMUMDRAWER = 7;
        private static int MINIMUMDRAWER = 0;

        //Variables All private to protect them via functions
        [JsonProperty]
        private int deskWidth;
        [JsonProperty]
        private int deskDepth;
        [JsonProperty]
        private int numOfDrawers;
        [JsonProperty]
        private DeskMaterial material;


        //Constructor        
        public Desk(int inWidth, int inDepth, int inDrawCount, DeskMaterial inMaterial)
        {
            setDeskWidth(inWidth);
            setDeskDepth(inDepth);
            setNumOfDrawers(inDrawCount);
            setMaterial(inMaterial);
        }

        [JsonConstructor]
        public Desk(int deskWidth, int deskDepth, int numOfDrawers, int material)
        {
            setDeskWidth(deskWidth);
            setDeskDepth(deskDepth);
            setNumOfDrawers(numOfDrawers);
            setMaterial((DeskMaterial)material);
        }

        //Default general creation
        public Desk()
        {
            setDeskWidth(MINIMUUMWIDTH);
            setDeskDepth(MINIMUUMDEPTH);
            setNumOfDrawers(MINIMUMDRAWER);
            setMaterial(DeskMaterial.Oak);
        }

        //Get and Set Functions 
        //Setters are set to private for the time being so they are purely set within the constructor of the desk.

        private void setDeskWidth(int _width)
        {
            if (_width <= MAXIMUMWIDTH && _width >= MINIMUUMWIDTH)
                deskWidth = _width;
            else
                throw (new Exception("Width must be between " + MINIMUUMWIDTH + "-" + MAXIMUMWIDTH + " inches!"));
        }

        public int GetDeskWidth()
        {
            return deskWidth;
        }

        private void setDeskDepth(int _depth)
        {

            if (_depth <= MAXIMUMDEPTH && _depth >= MINIMUUMDEPTH)
                deskDepth = _depth;
            else
                throw (new Exception("Depth must be between " + MINIMUUMDEPTH + "-" + MAXIMUMDEPTH + " inches!"));
        }

        public int GetDeskDepth()
        {           
            return deskDepth;
        }

        private void setNumOfDrawers(int _num)
        {
            if (_num <= MAXIMUMDRAWER && _num >= MINIMUMDRAWER)
            {
                numOfDrawers = _num;
            }
            else
                throw (new Exception("Drawers only allowed between " + MINIMUMDRAWER + "-" + MAXIMUMDRAWER + "!"));
        }

        public int GetNumOfDrawers()
        {
            return numOfDrawers;
        }

        private void setMaterial(DeskMaterial _material)
        {            
                material = _material;            
        }

        public DeskMaterial GetDeskMaterial()
        {
            return material;
        }


        //Getters for limiters
        public static int GetMaxDepth()
        {
            return MAXIMUMDEPTH;
        }
        public static int GetMinDepth()
        {
            return MINIMUUMDEPTH;
        }
        public static int GetMaxWidth()
        {
            return MAXIMUMWIDTH;
        }
        public static int GetMinWdith()
        {
            return MINIMUUMWIDTH;
        }
        public static int GetMaxDrawers()
        {
            return MAXIMUMDRAWER;
        }
        public static int GetMinDrawers()
        {
            return MINIMUMDRAWER;
        }
        
    }
}
