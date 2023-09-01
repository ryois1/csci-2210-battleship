using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Ship
    {
        private Coord2D position;
        private byte Length;
        private DirectionType Direction;
        private Coord2D[] Points;
        private List<Coord2D> DamagedPoints;


        public Ship(Coord2D position, byte length, DirectionType direction)
        {
            this.position = position;
            Length = length;
            Direction = direction;
        }

        public bool CheckIfHit(Coord2D point)
        {
            // TO DO
        }

        public void TakeDamage(Coord2D point)
        { 
            // TO DO
        }

        public void TakeDamage(int amount)
        {
            throw new NotImplementedException();
        }

        public string GetName()
        {
            // TO DO
        }

        public byte GetMaxHealth()
        {
            // TO DO
        }

        public byte GetCurrentHealth()
        {
            // TO DO
        }

        public bool IsDead()
        {
            // TO DO
        }

        public bool CheckIfHit(Coord2D point)
        {
            // TO DO 
        }

    }
}
