using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Text;

namespace WFC;

#nullable disable

public class Program
{
    public const int TILE_SIZE = 32;

    static void Main(string[] args)
    {
        var tileset = new Tileset("tileset-grass-bg.png");
        TileConfiguration tileConfiguration = new TileConfiguration();
        MapConfiguration mapConfiguration = new MapConfiguration(40, 20, tileConfiguration);
        WFCSolver solver = new WFCSolver(mapConfiguration);
        solver.Solve();
        solver.Print();
        TilesetUtils.GenerateMapFromConfiguration(tileset, mapConfiguration);
    }
}