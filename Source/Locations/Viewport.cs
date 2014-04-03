﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TurnItUp.Tmx;
using System.Tuples;
using TurnItUp.Characters;
using TurnItUp.Components;
using TurnItUp.Interfaces;
using Entropy;
using TurnItUp.Pathfinding;
using TurnItUp.Randomization;

namespace TurnItUp.Locations
{
    public class Viewport : IViewport
    {
        public Level Level { get; set; }
        public Position MapOrigin { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Viewport(Level level, int mapOriginX, int mapOriginY, int width, int height)
        {
            Level = level;
            MapOrigin = new Position(mapOriginX, mapOriginY);
            Width = width;
            Height = height;
        }

        public void Move(Direction direction)
        {
            Position oldMapOrigin = MapOrigin.DeepClone();

            switch (direction)
            {
                case Direction.North:
                    MapOrigin.Y++;
                    break;
                case Direction.South:
                    MapOrigin.Y--;
                    break;
                case Direction.West:
                    MapOrigin.X--;
                    break;
                case Direction.East:
                    MapOrigin.X++;
                    break;
                case Direction.NorthEast:
                    MapOrigin.X++;
                    MapOrigin.Y++;
                    break;
                case Direction.NorthWest:
                    MapOrigin.X--;
                    MapOrigin.Y++;
                    break;
                case Direction.SouthEast:
                    MapOrigin.X++;
                    MapOrigin.Y--;
                    break;
                case Direction.SouthWest:
                    MapOrigin.X--;
                    MapOrigin.Y--;
                    break;
                default:
                    return;
            }

            if (!IsMapOriginValid())
            {
                MapOrigin.X = oldMapOrigin.X;
                MapOrigin.Y = oldMapOrigin.Y;
            }
        }

        public bool IsMapOriginValid()
        {
            return !(MapOrigin.X < 0 || MapOrigin.Y < 0 || (MapOrigin.X + Width) > (Level.Map.Width - 1) || (MapOrigin.Y + Height) > (Level.Map.Height - 1));
        }
    }
}