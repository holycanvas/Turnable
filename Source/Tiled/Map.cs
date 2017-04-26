﻿using System;
using System.Xml;

namespace Turnable.Tiled
{
    public class Map
    {
        public string Version { get; set; }
        public Orientation Orientation { get; set; }
        public RenderOrder RenderOrder { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int TileWidth { get; set; }
        public int TileHeight { get; set; }
        public int NextObjectId { get; set; }

        public static Map Load(string fullPath)
        {
            var map = new Map();
            var tiledMapDocument = new XmlDocument();
            tiledMapDocument.Load(fullPath);

            // REF: http://doc.mapeditor.org/reference/tmx-map-format/#map
            var mapNode = tiledMapDocument.DocumentElement.SelectSingleNode("/map");
            map.Version = mapNode.Attributes["version"].Value;
            map.Width = Convert.ToInt32(mapNode.Attributes["width"].Value);
            map.Height = Convert.ToInt32(mapNode.Attributes["height"].Value);
            map.TileWidth = Convert.ToInt32(mapNode.Attributes["tilewidth"].Value);
            map.TileHeight = Convert.ToInt32(mapNode.Attributes["tileheight"].Value);
            map.NextObjectId = Convert.ToInt32(mapNode.Attributes["nextobjectid"].Value);

            return map;
        }
    }
}
