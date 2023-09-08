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
    /// Abstract Class for Ship
    /// </summary>
    public abstract class Ship: IHealth, IInfomatic
    {
        protected List<Coord2D> Points { get; set; }
        public List<Coord2D> DamagedPoints { get; private set; } = new List<Coord2D>();
        public Coord2D Position { get; }
        public DirectionType Direction { get; }
        public byte Length { get; }


        /// <summary>
        /// Gets the max health of the ship
        /// </summary>
        /// <returns>Length as an integer</returns>
        public int GetMaxHealth()
        {
            return Length;
        }

        /// <summary>
        /// Ship constructor
        /// </summary>
        /// <param name="position">Position of the ship as Coord2D (x, y)</param>
        /// <param name="direction">DirectionType of the ship as Vertical or Horizontal</param>
        /// <param name="length">Length of the ship</param>
        public Ship(Coord2D position, DirectionType direction, byte length)
        {
            Position = position;
            Direction = direction;
            Length = length;
            GeneratePoints();
        }

        /// <summary>
        /// Abstract GetName method for the abstract Ship
        /// </summary>
        /// <returns></returns>
        public abstract string GetName();

        /// <summary>
        /// Gets currnet health of the ship
        /// </summary>
        /// <returns>Returns health of the ship as integer</returns>
        public int GetCurrentHealth()
        {
            return GetMaxHealth() - DamagedPoints.Count;
        }

        /// <summary>
        /// Boolean status of the ship
        /// </summary>
        /// <returns>True/False ship dead/alive</returns>
        public bool IsDead()
        {
            return GetCurrentHealth() <= 0;
        }

        /// <summary>
        /// Take health away from the ship
        /// </summary>
        /// <param name="point">Coord2D (x, y) representation of the location</param>
        public void TakeDamage(Coord2D point)
        {
            if (!DamagedPoints.Contains(point))
            {
                DamagedPoints.Add(point);
            }
        }

        /// <summary>
        /// Wrong Take Damage method, do not use
        /// </summary>
        /// <param name="amount"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void TakeDamage(int amount)
        {
            throw new NotImplementedException("TakeDamage(int) is not implemented.");
        }


        /// <summary>
        /// See if the given point has been hit
        /// </summary>
        /// <param name="point">Coord2D (x, y) representation of the location</param>
        /// <returns>True if hit, False if not</returns>
        public bool CheckIfHit(Coord2D point)
        {
            return Points.Contains(point);
        }

        /// <summary>
        /// Text form of the ship
        /// </summary>
        /// <returns>Text form</returns>
        public string GetInfo()
        {
            return $"Name: {GetName()}, Max Health: {GetMaxHealth()}, Current Health: {GetCurrentHealth()}, Is Dead: {IsDead()}, Position: ({Position.x}, {Position.y}), Length: {Length}, Direction: {Direction}";
        }

        /// <summary>
        /// From the initial position, add based on length
        /// </summary>
        private void GeneratePoints()
        {
            Points = new List<Coord2D>();

            int x = Position.x;
            int y = Position.y;

            for (int i = 0; i < Length; i++)
            {
                Points.Add(new Coord2D(x, y));
                if (Direction == DirectionType.Horizontal)
                {
                    x++;
                }
                else
                {
                    y++;
                }
            }
        }
    }
}
