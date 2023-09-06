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

namespace Battleship.Ships
{
    /// <summary>
    /// Carrier Ship overrides
    /// </summary>
    public class Carrier : Ship
    {
        public Carrier(Coord2D position, DirectionType direction) : base(position, direction, 5) { }

        public override string GetName()
        {
            return "Carrier";
        }
    }
}
