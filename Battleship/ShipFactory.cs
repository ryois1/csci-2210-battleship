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
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Battleship
{
    public class ShipFactory
    {
        /// <summary>
        /// Verifies the given input for a ship is valid
        /// </summary>
        /// <param name="description">The text input</param>
        /// <returns>True if input is VALID, False if input is INVALID</returns>
        /// <exception cref="ArgumentException"></exception>
        static bool VerifyShipString(string description)
        {
            Regex regex = new Regex(@"(Carrier|Battleship|Destroyer|Submarine|Patrol Boat),\s*[0-9],\s*(v|h|V|H),\s*[0-9],\s*[0-9]");

            if (regex.IsMatch(description))
            {
                string[] parts = description.Split(',');
                if (parts.Length != 5) // Needs 5 parameters
                {
                    return false;
                    throw new ArgumentException("Invalid input format. Expected 5 parameters separated by commas.");
                }

                string type = parts[0].Trim();
                int length;
                if (!int.TryParse(parts[1].Trim(), out length) || length < 2 && length > 7) // 2 - 6
                {
                    return false;
                    throw new ArgumentException("Invalid ship length.");
                }

                string orientation = parts[2].Trim();
                if (orientation != "h" && orientation != "v") // Horizontal or Vertical ships
                {
                    return false;
                    throw new ArgumentException("Invalid orientation. It should be 'h' or 'v'.");
                }

                int xCoordinate;
                if (!int.TryParse(parts[3].Trim(), out xCoordinate) || xCoordinate < 0 || xCoordinate + (orientation == "h" ? length - 1 : 0) > 9) // Too Long X
                {
                    return false;
                    throw new ArgumentException("Invalid X coordinate.");
                }

                int yCoordinate;
                if (!int.TryParse(parts[4].Trim(), out yCoordinate) || yCoordinate < 0 || yCoordinate + (orientation == "v" ? length - 1 : 0) > 9) // Too Long Y
                {
                    return false;
                    throw new ArgumentException("Invalid Y coordinate.");
                }

                return true;

            } else
            {
                return false;
            }

        }

        /// <summary>
        /// Parse and return a new Ship
        /// </summary>
        /// <param name="description">Valid text input</param>
        /// <returns>A Ship instance if valid text input</returns>
        /// <exception cref="ArgumentException"></exception>
        static Ship ParseShipString(string description)
        {
            if (!VerifyShipString(description))
            {
                throw new ArgumentException("Invalid ship string format.");
            }

            string[] parts = description.Split(',');

            string type = parts[0].Trim();
            byte length = byte.Parse(parts[1].Trim());
            DirectionType direction = parts[2].Trim().ToLower() == "h" ? DirectionType.Horizontal : DirectionType.Vertical;
            int xCoordinate = int.Parse(parts[3].Trim());
            int yCoordinate = int.Parse(parts[4].Trim());


            switch(type.ToUpper())
            {
                case "CARRIER":
                    return new Ships.Carrier(new Coord2D(xCoordinate, yCoordinate), direction);
                case "BATTLESHIP":
                    return new Ships.Battleship(new Coord2D(xCoordinate, yCoordinate), direction);
                case "DESTROYER":
                    return new Ships.Destroyer(new Coord2D(xCoordinate, yCoordinate), direction);
                case "SUBMARINE":
                    return new Ships.Submarine(new Coord2D(xCoordinate, yCoordinate), direction);
                case "PATROL BOAT":
                    return new Ships.PatrolBoat(new Coord2D(xCoordinate, yCoordinate), direction);
                default: throw new ArgumentException();
            }

        }

        /// <summary>
        /// Input and parse a file to load a game
        /// </summary>
        /// <param name="filePath">Path of the text file</param>
        /// <returns>An array of ships</returns>
        public static Ship[] ParseShipFile(string filePath)
        {
            List<Ship> ships = new List<Ship>();

            StreamReader sr = new StreamReader(filePath);

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line == null) { continue ; }
                if (!line.TrimStart().StartsWith("#"))
                {
                    if (VerifyShipString(line))
                    {
                        Ship ship = ParseShipString(line);
                        ships.Add(ship);
                    }
                    else
                    {
                        Console.WriteLine($"Error: Invalid ship data in line: {line}");
                    }
                }
            }

            return ships.ToArray();
        }
    }
}
