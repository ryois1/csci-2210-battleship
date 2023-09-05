///////////////////////////////////////////////////////////////////////////////
//
// Author: Russell Payne, payner3@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Battleship Project 1 Refresher
// Description: Refresh concepts from previous classes with a take on
// the classic Battleship game.
//
///////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    /// <summary>
    /// Coord2D is a representation of (x, y) as integers
    /// </summary>
    public struct Coord2D
    {
        public int x { get;}
        public int y { get;}

        public Coord2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
