using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TilePathFinder : MonoBehaviour {

	public static List<Tile> FindPath(Tile originTile, Tile destinationTile) {
		
		// Closed List will contain the path as we build it
		List<Tile> closed = new List<Tile>();
		
		// Open List will contain the available tiles
		List<TilePath> open = new List<TilePath>();
		
		TilePath originPath = new TilePath();
		originPath.addTile(originTile);
		
		open.Add(originPath);
		
		
		while (open.Count > 0) {

			TilePath current = open[0];
			open.Remove(open[0]);
			//Debug.Log("Tile removed");

			
			if (closed.Contains(current.lastTile)) {
				continue;
			} 
			if (current.lastTile == destinationTile) {
				current.listOfTiles.Distinct();
				current.listOfTiles.Remove(originTile);
				Debug.Log("This is logged");
				Debug.Log("Number of Tiles is:" + current.listOfTiles.Count()); // 2 tiles
				return (current.listOfTiles);
				Debug.Log("This is not logged");
			}
			
			closed.Add(current.lastTile);
			
			foreach (Tile t in current.lastTile.neighbors) {
				
				if (!t.isPassable) continue;
				TilePath newTilePath = new TilePath(current);
				newTilePath.addTile(t);
				open.Add(newTilePath);
				
			}
		}
		Debug.Log("This is also logged");
		Debug.Log("And the function returns null");
		return null;
	}
}
