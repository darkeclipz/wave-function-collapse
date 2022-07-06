namespace WFC;

class TileConfiguration
{
    public List<Tile> Tiles { get; set; } = new();

    Tile CreateTile(int index)
    {
        Tile tile = new Tile(index);
        Tiles.Add(tile);
        return tile;
    }

    public TileConfiguration()
    {
        var grass = CreateTile(78);

        var roadLeftTop = CreateTile(11);
        var roadTop = CreateTile(12);
        var roadRightTop = CreateTile(13);
        var roadLeft = CreateTile(27);
        var road = CreateTile(28);
        var roadRight = CreateTile(29);
        var roadLeftBottom = CreateTile(43);
        var roadBottom = CreateTile(44);
        var roadRightBottom = CreateTile(45);
        var diagonalLeftTop = CreateTile(110);
        var diagonalRightTop = CreateTile(111);
        var diagonalLeftBottom = CreateTile(126);
        var diagonalRightBottom = CreateTile(127);

        var flower = CreateTile(167);
        var bush = CreateTile(168);
        var fern = CreateTile(151);

        grass.MapAround(grass);
        grass.MapNorth(roadLeftBottom, roadBottom, roadRightBottom);
        grass.MapSouth(roadLeftTop, roadTop, roadRightTop);
        grass.MapEast(roadLeftTop, roadLeft, roadLeftBottom);
        grass.MapWest(roadRightTop, roadRight, roadRightBottom);

        road.MapAround(road);
        road.MapNorth(roadTop);
        road.MapSouth(roadBottom);
        road.MapEast(roadRight);
        road.MapWest(roadLeft);

        roadTop.MapEast(roadRightTop);
        roadTop.MapWest(roadLeftTop);
        roadTop.MapEast(roadTop);
        roadTop.MapWest(roadTop);

        roadLeft.MapNorth(roadLeftTop);
        roadLeft.MapSouth(roadLeftBottom);
        roadLeft.MapNorth(roadLeft);
        roadLeft.MapSouth(roadLeft);

        roadRight.MapNorth(roadRightTop);
        roadRight.MapSouth(roadRightBottom);
        roadRight.MapNorth(roadRight);
        roadRight.MapSouth(roadRight);

        roadBottom.MapEast(roadRightBottom);
        roadBottom.MapWest(roadLeftBottom);
        roadBottom.MapEast(roadBottom);
        roadBottom.MapWest(roadBottom);

        roadLeftTop.MapEast(roadRightTop);
        roadRightTop.MapSouth(roadRightBottom);
        roadRightBottom.MapWest(roadLeftBottom);
        roadLeftBottom.MapNorth(roadLeftTop);

        diagonalLeftTop.MapNorth(roadLeftTop, roadLeft);
        diagonalLeftTop.MapEast(road, diagonalRightTop);
        diagonalLeftTop.MapSouth(road, diagonalLeftBottom);
        diagonalLeftTop.MapWest(roadTop, roadLeftTop);

        diagonalRightTop.MapNorth(roadRightTop, roadRight);
        diagonalRightTop.MapEast(roadTop, roadRightTop);
        diagonalRightTop.MapSouth(road, diagonalRightBottom);  
        diagonalRightTop.MapWest(road);          

        diagonalRightBottom.MapNorth(road);
        diagonalRightBottom.MapEast(roadBottom, roadRightBottom);
        diagonalRightBottom.MapSouth(roadRight, roadRightBottom);  
        diagonalRightBottom.MapWest(road, diagonalLeftBottom);  

        diagonalLeftBottom.MapNorth(road);
        diagonalLeftBottom.MapEast(road);
        diagonalLeftBottom.MapSouth(roadLeft, roadLeftBottom);
        diagonalLeftBottom.MapWest(roadBottom, roadLeftBottom);

        flower.MapAround(grass);
        flower.MapNorth(roadLeftBottom, roadBottom, roadRightBottom);
        flower.MapSouth(roadLeftTop, roadTop, roadRightTop);
        flower.MapEast(roadLeftTop, roadLeft, roadLeftBottom);
        flower.MapWest(roadRightTop, roadRight, roadRightBottom);
        
        fern.MapAround(grass);
        fern.MapNorth(roadLeftBottom, roadBottom, roadRightBottom);
        fern.MapSouth(roadLeftTop, roadTop, roadRightTop);
        fern.MapEast(roadLeftTop, roadLeft, roadLeftBottom);
        fern.MapWest(roadRightTop, roadRight, roadRightBottom);

        bush.MapAround(grass);
        bush.MapAround(bush);
        bush.MapNorth(roadLeftBottom, roadBottom, roadRightBottom);
        bush.MapSouth(roadLeftTop, roadTop, roadRightTop);
        bush.MapEast(roadLeftTop, roadLeft, roadLeftBottom);
        bush.MapWest(roadRightTop, roadRight, roadRightBottom);
    }
}