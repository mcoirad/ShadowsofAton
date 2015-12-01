using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TileHighlight {
	
	public TileHighlight () {
		
	}

	/* public static List<Tile> FindHighlight(Tile originTile, int movementPoints) {
		return FindHighlight(originTile, movementPoints, new Vector2[0], false);
	}
	public static List<Tile> FindHighlight(Tile originTile, int movementPoints, bool staticRange) {
		return FindHighlight(originTile, movementPoints, new Vector2[0], staticRange);
	}
	public static List<Tile> FindHighlight(Tile originTile, int movementPoints, Vector2[] occupied) {
		return FindHighlight(originTile, movementPoints, occupied, false);
	} */

	public static List<Tile> FindHighlight(Tile originTile, int movementPoints) {
		List<Tile> closed = new List<Tile>();
		List<TilePath> open = new List<TilePath>();
		
		TilePath originPath = new TilePath();
		//if (staticRange) originPath.addStaticTile(originTile);
		//else 
		originPath.addTile(originTile);
		
		open.Add(originPath);
		
		while (open.Count > 0) {
			TilePath current = open[0];
			open.Remove(open[0]);
			
			if (closed.Contains(current.lastTile)) {
				continue;
			} 
			// each tile cost is 1, could change this later
			if (1 > movementPoints + 1) {
				continue;
			}
			
			closed.Add(current.lastTile);
			
			foreach (Tile t in current.lastTile.neighbors) {	
				if (!t.isPassable || t.isOccupied) continue;
				TilePath newTilePath = new TilePath(current);
				//if (staticRange) newTilePath.addStaticTile(t);
				//else 
				newTilePath.addTile(t);
				open.Add(newTilePath);
			}
		}
		closed.Remove(originTile);
		closed.Distinct();
		return closed;
	}
}
