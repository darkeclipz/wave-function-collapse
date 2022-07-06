# Wave function collapse demo

This project contains a small example of the wave function collapse algorithm. The solver is rather straightfoward, because it randomly selects a tile. Because it is very simple, it can't handle occurences where there is no tile available. In this case a backtracking algorithm should be used, which we were to lazy to implement.

![Map1](/test1.png)

# Usage

The algorithm uses the following data structures:

 1. A `Tileset` which is used to load in the image.
 2. A `TileConfiguration` which maps edges of tiles to other tiles. It basically tells the algorithm which tiles are possible next to each other.
 3. A `MapConfiguration` which creates a map for a `TileConfiguration`.
 4. A `WFCSolver` which uses the `MapConfiguration` and solves the map by randomly selecting a tile.

## Tile atlas

A tile atlas can be generated for any tileset with the `TilesetUtils.CreateAnnotatedAtlas(Tileset tileset)` method. It will overlay the borders and adds an index for each tile, that can be used to map the tile for the WFC algorithm.

![Atlas](/atlas.png)

# Improvements

The following ideas can be implemented to improve the algorithm:

 1. Give edges a weight, or a tile a weight, so we can control how much grass there is for example.
 2. Use a backtracking algorithm (with forward propagation) to always get a correct map, e.g., there are no missing tiles.
 3. Add additional functionality to quickly map tiles to other tiles.
   a. Use a default tile (e.g. grass) which can then be used to map all tiles that are mapped to grass, to each other also. This fixes a lot of weird configurations, and would otherwise be a lot of work to map.
   b. Select a region that is adjacent already, such as a tree, and indicate by which tile this should be mapped around, e.g. grass.
 4. Use additional algorithms to already generate a portion of the map, e.g. roads, and then let the WFC algorithm finish the map.
