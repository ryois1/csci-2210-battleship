///////////////////////////////////////////////////////////////////////////////
//
// Author: Russell Payne, payner3@etsu.edu
// Course: CSCI-2210-001 - Data Structures
// Assignment: Battleship Project 1 Refresher
// Description: Refresh concepts from previous classes with a take on
// the classic Battleship game.
//
///////////////////////////////////////////////////////////////////////////////


using Battleship;
using System;
using System.Collections.Generic;

class Program
{
    static List<Ship> ships = new List<Ship>();

    static void Main(string[] args)
    {

        // Check if a file path was provided as a command line argument
        string filePath = null;
        if (args.Length > 0)
        {
            filePath = args[0];
        }
        else
        {
            Console.Write("Enter the file path for the ship data: ");
            filePath = Console.ReadLine().Replace("\"", "");
        }

        // Check if the file exists and can be opened
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found or cannot be opened. Exiting.");
            return;
        }

        // Parse ships from the specified file
        ships = ShipFactory.ParseShipFile(filePath).ToList();

        // ships.Add(new Carrier(new Coord2D(0, 0), DirectionType.Horizontal));
        // ships.Add(new Destroyer(new Coord2D(5, 3), DirectionType.Horizontal));

        bool allShipsDead = false;

        while (!allShipsDead)
        {
            Console.WriteLine("Enter a command (info, X, Y, or exit): ");
            string command = Console.ReadLine().ToLower();

            switch (command)
            {
                case "info":
                    ListShipInfo();
                    break;
                case "exit":
                    Console.WriteLine("Exiting the program.");
                    return;
                default:
                    ProcessAttackCommand(command);
                    break;
            }

            // Check if all ships are dead
            allShipsDead = ships.TrueForAll(ship => ship.IsDead());
        }

        Console.WriteLine("All ships are destroyed. Game over!");
    }

    static void ListShipInfo()
    {
        Console.WriteLine("Ship Info:");
        foreach (var ship in ships)
        {
            Console.WriteLine(ship.GetInfo());
        }
    }

    static void ProcessAttackCommand(string command)
    {
        string[] coordinates = command.Split(',');
        if (coordinates.Length != 2 || !int.TryParse(coordinates[0], out int x) || !int.TryParse(coordinates[1], out int y))
        {
            Console.WriteLine("Command not recognized.");
            return;
        }

        Coord2D targetPosition = new Coord2D(x, y);

        foreach (var ship in ships)
        {
            if (ship.CheckIfHit(targetPosition))
            {
                ship.TakeDamage(targetPosition);
                Console.WriteLine($"Hit! {ship.GetName()} at ({x}, {y}) takes damage.");
                if (ship.IsDead())
                {
                    Console.WriteLine($"{ship.GetName()} is destroyed!");
                }
                return;
            }
        }

        Console.WriteLine($"Miss! No ship at ({x}, {y}).");
    }
}
