namespace WFC;

class MapConfiguration
{
    public int Width { get; set; }
    public int Height { get; set; }
    public List<Tile> Tiles { get; set; }
    public List<int>[,] Domain { get; set; }
    public int[,] Map { get; set; }
    public int this[int x, int y] => Map[x, y];

    public MapConfiguration(int width, int height, TileConfiguration configuration)
    {
        Width = width;
        Height = height;
        Tiles = configuration.Tiles;
        
        InitializeMap();
        InitializeDomains();
    }

    public void Assign(int x, int y, int tileIndex)
    {
        Map[x, y] = tileIndex;
        PropagateCell(x, y, tileIndex);
    }

    public bool IsAssigned(int x, int y) => this[x, y] != -1;

    public void PropagateCell(int x, int y, int tileIndex)
    {
        Tile tile = Tiles.First(t => t.Index == tileIndex);

        if (x > 0)
        {
            PropagateEdge(x - 1, y, tile.West);
        }

        if (x < Width - 1)
        {
            PropagateEdge(x + 1, y, tile.East);
        }

        if (y > 0)
        {
            PropagateEdge(x, y - 1, tile.North);
        }

        if (y < Height - 1)
        {
            PropagateEdge(x, y + 1, tile.South);
        }
    }

    public void PropagateEdge(int x, int y, List<int> allowed)
    {
        List<int> domain = Domain[x, y];

        foreach (var value in domain.ToList())
        {
            if (!allowed.Contains(value))
            {
                if (domain.Contains(value))
                {
                    domain.Remove(value);
                }
            }
        }

        if (domain.Count == 1)
        {
            int value = domain.First();
            domain.Clear();
            Assign(x, y, value);
        }
    }

    void InitializeMap()
    {
        Map = new int[Width, Height];

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Map[i, j] = -1;
            }
        }
    }

    void InitializeDomains()
    {
        Domain = new List<int>[Width, Height];

        for (int i = 0; i < Width; i++)
        {
            for (int j = 0; j < Height; j++)
            {
                Domain[i, j] = new List<int>();

                foreach(Tile tile in Tiles)
                {
                    Domain[i, j].Add(tile.Index);
                }
            }
        }
    }
}