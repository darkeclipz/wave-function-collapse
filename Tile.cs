namespace WFC;

class Tile
{
    public int Index { get; set; }

    public List<int> North { get; set; } = new();
    public List<int> East { get; set; } = new();
    public List<int> South { get; set; } = new();
    public List<int> West { get; set; } = new();

    public Tile(int index)
    {
        Index = index;
    }

    public void MapNorth(params Tile[] tiles)
    {
        foreach (Tile tile in tiles)
        {
            if (!North.Contains(tile.Index))
            {
                North.Add(tile.Index);
            }

            if (!tile.South.Contains(Index))
            {
                tile.South.Add(Index);
            }
        }
    }

    public void MapEast(params Tile[] tiles)
    {
        foreach (Tile tile in tiles)
        {
            if (!East.Contains(tile.Index))
            {
                East.Add(tile.Index);
            }

            if (!tile.West.Contains(Index))
            {
                tile.West.Add(Index);
            }
        }
    }

    public void MapSouth(params Tile[] tiles)
    {
        foreach (Tile tile in tiles)
        {
            if (!South.Contains(tile.Index))
            {
                South.Add(tile.Index);
            }

            if (!tile.North.Contains(Index))
            {
                tile.North.Add(Index);
            }
        }
    }

    public void MapWest(params Tile[] tiles)
    {
        foreach (Tile tile in tiles)
        {
            if (!West.Contains(tile.Index))
            {
                West.Add(tile.Index);
            }

            if (!tile.East.Contains(Index))
            {
                tile.East.Add(Index);
            }
        }
    }

    public void MapAround(params Tile[] indices)
    {
        MapNorth(indices);
        MapEast(indices);
        MapSouth(indices);
        MapWest(indices);
    }
}