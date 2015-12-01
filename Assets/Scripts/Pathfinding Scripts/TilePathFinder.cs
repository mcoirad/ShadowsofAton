using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TilePathFinder : MonoBehaviour {
	/* public static List<Tile> FindPath(Tile originTile, Tile destinationTile) {
		return FindPath(originTile, destinationTile, new Vector2[0]);
	} */
	public static List<Tile> FindPath(Tile originTile, Tile destinationTile) {
		
		// Closed List will contain the path as we build it
		List<Tile> closed = new List<Tile>();
		
		// Open List will contain the available tiles
		List<TilePath> open = new List<TilePath>();
		
		// 
		TilePath originPath = new TilePath();
		originPath.addTile(originTile);
		
		open.Add(originPath);
		
		List<Tile> fuckPath = new List<Tile>();
		
		while (open.Count > 0) {
		//Debug.Log("Open Count is " + open.Count);
			//open = open.OrderBy(x => x.costOfPath).ToList();
			TilePath current = open[0];
			open.Remove(open[0]);
			//Debug.Log(current.lastTile.gridPosition);
			//Debug.Log(destinationTile.gridPosition);
			
			if (closed.Contains(current.lastTile)) {
				continue;
			} 
			if (current.lastTile == destinationTile) {
				current.listOfTiles.Distinct();
				current.listOfTiles.Remove(originTile);
				Debug.Log(current.listOfTiles.Count);
				fuckPath = current.listOfTiles;
				return (current.listOfTiles);
			}
			
			closed.Add(current.lastTile);
			// Debug.Log("Tile" + current.lastTile.gridPosition);
			// Debug.Log("Number of neighbors" + current.lastTile.neighbors.Count);
			foreach (Tile t in current.lastTile.neighbors) {
				//Debug.Log("neigh pos?  " + t.gridPosition);
				if (!t.isPassable || t.isOccupied) continue;
				TilePath newTilePath = new TilePath(current);
				newTilePath.addTile(t);
				open.Add(newTilePath);
				//Debug.Log("forEach");
			}
		}
		//Debug.Log("Dont Want this");
		return fuckPath;
	}
}
