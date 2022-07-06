using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;

namespace WFC;

static class TilesetUtils
{
    const int TILE_SIZE = Program.TILE_SIZE;

    public static (int x, int y) GetCoordinatesFromTileIndex(Tileset tileset, int index, int tileSize)
    {
        int tileInXDirection = tileset.Image.Width / tileSize;
        int x = index % tileInXDirection;
        int y = index / tileInXDirection;
        return (x * tileSize, y * tileSize);
    }

    public static void GenerateMapFromConfiguration(Tileset tileset, MapConfiguration configuration)
    {
        var source = new Bitmap(tileset.Image);
        var target = new Bitmap(configuration.Width * TILE_SIZE, configuration.Height * TILE_SIZE);
        using Graphics g = Graphics.FromImage(target);

        for (int x = 0; x < configuration.Width; x++)
        {
            for (int y = 0; y < configuration.Height; y++)
            {
                (int sx, int sy) = GetCoordinatesFromTileIndex(tileset, configuration.Map[x, y], TILE_SIZE);
                var sourceRect = new RectangleF(sx, sy, TILE_SIZE, TILE_SIZE);
                var targetRect = new RectangleF(x * TILE_SIZE, y * TILE_SIZE, TILE_SIZE, TILE_SIZE);
                g.DrawImage(source, targetRect, sourceRect, GraphicsUnit.Pixel);
            }
        }

        // (int grassX, int grassY) = GetCoordinatesFromTileIndex(tileset, 78, 32);
        // var sourceRect = new RectangleF(grassX, grassY, TILE_SIZE, TILE_SIZE);

        // using Graphics g = Graphics.FromImage(target);

        // for (int y = 0; y < target.Height; y += TILE_SIZE)
        // {
        //     for (int x = 0; x < target.Width; x += TILE_SIZE)
        //     {
        //         var targetRect = new RectangleF(x, y, TILE_SIZE, TILE_SIZE);
        //         g.DrawImage(source, targetRect, sourceRect, GraphicsUnit.Pixel);
        //     }
        // }

        // var rect = new RectangleF(0, 0, target.Width, target.Height);
        // g.DrawImage(
        //     source, 
        //     rect, 
        //     rect, 
        //     GraphicsUnit.Pixel
        // );

        target.Save("test1.png");
    }

    public static void GrowGrass(Tileset tileset)
    {
        var source = new Bitmap(tileset.Image);
        var target = new Bitmap(tileset.Image);

        (int grassX, int grassY) = GetCoordinatesFromTileIndex(tileset, 78, 32);
        var sourceRect = new RectangleF(grassX, grassY, TILE_SIZE, TILE_SIZE);

        using Graphics g = Graphics.FromImage(target);

        for (int y = 0; y < target.Height; y += TILE_SIZE)
        {
            for (int x = 0; x < target.Width; x += TILE_SIZE)
            {
                var targetRect = new RectangleF(x, y, TILE_SIZE, TILE_SIZE);
                g.DrawImage(source, targetRect, sourceRect, GraphicsUnit.Pixel);
            }
        }

        var rect = new RectangleF(0, 0, target.Width, target.Height);
        g.DrawImage(
            source, 
            rect, 
            rect, 
            GraphicsUnit.Pixel
        );

        target.Save("tileset-grass-bg.png");
    }

    public static void CreateAnnotatedAtlas(Tileset tileset)
    {
        var source = new Bitmap(tileset.Image);
        var target = new Bitmap(tileset.Image);

        int index = 0;

        using Graphics g = Graphics.FromImage(target);
        SolidBrush fontColorBrush = new SolidBrush(Color.FromArgb(122, 255, 255, 0));
        
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        StringFormat format = new StringFormat()
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        
        for (int y = 0; y < tileset.Image.Height; y += TILE_SIZE)
        {
            for (int x = 0; x < tileset.Image.Width; x += TILE_SIZE)
            {
                target.SetPixel(x, y, Color.Red);

                for (int i = 0; i < TILE_SIZE; i++)
                {
                    target.SetPixel(x + i, y, Color.DarkGray);
                    target.SetPixel(x, y + i, Color.DarkGray);
                }

                g.DrawString(
                    index.ToString(), 
                    new Font("Tahoma", 8), 
                    fontColorBrush, 
                    new RectangleF(x + 1, y + 1, TILE_SIZE, TILE_SIZE), 
                    format
                );

                index++;
            }
        }

        for (int y = 0; y < tileset.Image.Height; y++)
        {
            target.SetPixel(target.Width - 1, y, Color.DarkGray);
        }
        
        for (int x = 0; x < tileset.Image.Width; x++)
        {
            target.SetPixel(x, target.Height - 1, Color.DarkGray);
        }

        g.Flush();
        target.Save("atlas.png");
    }

    public static void SplitIntoTile(Tileset tileset)
    {
        var source = new Bitmap(tileset.Image);

        int index = 0;

        for (int y = 0; y < tileset.Image.Height; y += TILE_SIZE)
        {
            for (int x = 0; x < tileset.Image.Width; x += TILE_SIZE)
            {
                using(Graphics g = Graphics.FromImage(tileset.Image))
                {
                    RectangleF rect = new (x, y, TILE_SIZE, TILE_SIZE);
                    Bitmap target = source.Clone(rect, PixelFormat.Format32bppArgb);
                    target.Save($"Tiles/tile_{index++}.png");
                }
            }
        }
    }
}