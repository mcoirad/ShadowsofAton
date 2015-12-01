using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tile : MonoBehaviour {
	
	public Vector2 gridPosition = Vector2.zero; 
	
	// Moveables
	public bool isOccupied = false;
	public bool isAdjacent = false;
	public bool isPassable = true;
	
	// Attackables
	public bool isUnderFire = false;
	public PlayerController playerHere;
	
	// Use for determining Player movement
	public int playerRelation;
	
	// Use for determining adjacent tiles
	public List<Tile> neighbors = new List<Tile>();
	
	// Use this for initialization
	void Start () {
		generateNeighbors();
	}
	
	
	// Update is called once per frame
	void Update () {
		// the idea here is that the ship can only move into spaces it is facing towards (by using the lastMoved variable)
		// this will be affected by its turning stat, maybe also the captains seamanship score
		
		// Grab current player
		// Is the player moving
		isAdjacent = false;
		isUnderFire = false;
		isOccupied = false;
		PlayerController maBoi = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
		if (maBoi.moving & maBoi.actionPoints > 0) {
			// Calculate Tile relation
			Vector2 maDiff = maBoi.gridPosition - this.gridPosition;
			if (maBoi.availMoves.Contains(maDiff)) {
				transform.GetComponent<Renderer>().material.color = Color.blue;
				
					// Clear Vars
					isAdjacent = true;
					
					
					// Debug.Log("maDiff is " + maDiff);
					if (maBoi.gridPosition.x % 2 == 0) {
						if (maDiff == Vector2.left) { // NE
								playerRelation = 1;
								}
						else if (maDiff == 2 * Vector2.left) { // E
								playerRelation = 2;
								}
						else if (maDiff == Vector2.left + Vector2.up) { // SE
								playerRelation = 3;
								}
						else if (maDiff == Vector2.up) { // S
								playerRelation = 4;
								}
						else if (maDiff == Vector2.right + Vector2.up) { // SE
								playerRelation = 5;
								}
						else if (maDiff == Vector2.right * 2) { // E
								playerRelation = 6;
								}
						else if (maDiff == Vector2.right) { // NE
								playerRelation = 7;
								}
						else if (maDiff == Vector2.down) { // N
								playerRelation = 0;
								}	
						// switch directions
					} else {
						if (maDiff == Vector2.left + Vector2.down) { // NE
								playerRelation = 1;
								}
						else if (maDiff == 2 * Vector2.left) { // E
								playerRelation = 2;
								}
						else if (maDiff == Vector2.left) { // SE
								playerRelation = 3;
								}
						else if (maDiff == Vector2.up) { // S
								playerRelation = 4;
								}
						else if (maDiff == Vector2.right) { // SE
								playerRelation = 5;
								}
						else if (maDiff == Vector2.right * 2) { // E
								playerRelation = 6;
								}
						else if (maDiff == Vector2.right + Vector2.down) { // NE
								playerRelation = 7;
								}
						else if (maDiff == Vector2.down) { // N
								playerRelation = 0;
								} 
					}
							// playerRelation = maDiff;
					} else {
						transform.GetComponent<Renderer>().material.color = Color.white;
							isAdjacent = false;
					}
		} 	else if (maBoi.turning & maBoi.actionPoints > 0) {
			// Calculate Tile relation
			Vector2 maDiff = maBoi.gridPosition - this.gridPosition;
			if (maBoi.availMoves.Contains(maDiff)) {
				transform.GetComponent<Renderer>().material.color = Color.green;
					isAdjacent = true;
					// Debug.Log("maDiff is " + maDiff);
				
				
				
					if (maBoi.gridPosition.x % 2 == 0) {
						if (maDiff == Vector2.left) { // NE
								playerRelation = 1;
								}
						else if (maDiff == 2 * Vector2.left) { // E
								playerRelation = 2;
								}
						else if (maDiff == Vector2.left + Vector2.up) { // SE
								playerRelation = 3;
								}
						else if (maDiff == Vector2.up) { // S
								playerRelation = 4;
								}
						else if (maDiff == Vector2.right + Vector2.up) { // SE
								playerRelation = 5;
								}
						else if (maDiff == Vector2.right * 2) { // E
								playerRelation = 6;
								}
						else if (maDiff == Vector2.right) { // NE
								playerRelation = 7;
								}
						else if (maDiff == Vector2.down) { // N
								playerRelation = 0;
								}	
						// switch directions
					} else {
						if (maDiff == Vector2.left + Vector2.down) { // NE
								playerRelation = 1;
								}
						else if (maDiff == 2 * Vector2.left) { // E
								playerRelation = 2;
								}
						else if (maDiff == Vector2.left) { // SE
								playerRelation = 3;
								}
						else if (maDiff == Vector2.up) { // S
								playerRelation = 4;
								}
						else if (maDiff == Vector2.right) { // SE
								playerRelation = 5;
								}
						else if (maDiff == Vector2.right * 2) { // E
								playerRelation = 6;
								}
						else if (maDiff == Vector2.right + Vector2.down) { // NE
								playerRelation = 7;
								}
						else if (maDiff == Vector2.down) { // N
								playerRelation = 0;
								} 
					}
							// playerRelation = maDiff;
					} else {
						transform.GetComponent<Renderer>().material.color = Color.white;
							isAdjacent = false;
					}
		} else if (maBoi.attacking & maBoi.actionPoints > 0) {
			Vector2 maDiff = maBoi.gridPosition - this.gridPosition;
			if (maBoi.availShots.Contains(maDiff)) {
				transform.GetComponent<Renderer>().material.color = Color.red;
					isAdjacent = true;
					isUnderFire = true;
			} else {
						transform.GetComponent<Renderer>().material.color = Color.white;
							isAdjacent = false;
							}
			
		}
		
		else {
						transform.GetComponent<Renderer>().material.color = Color.white;
							isAdjacent = false;
					}
					
		
		for (int i = 0; i < BoardManager.Boardo.players.Count; i++) {
			PlayerController player = BoardManager.Boardo.players[i];
			if (player.gridPosition == this.gridPosition) {
				this.isOccupied = true;
				playerHere = player;
				// Debug.Log(this.gridPosition);
				// Debug.Log("Player " + i + player.gridPosition);
			} 
		}
		
		/* if (maBoi.gridPosition.x % 2 == 0) { //if even column
		
		
			if (maDiff == (Vector2.up + Vector2.right) | maDiff == (Vector2.up + Vector2.left) | maDiff == (Vector2.right) | maDiff == (Vector2.left) // diagonals
				| maDiff == (Vector2.right * 2) | maDiff == (Vector2.left * 2) | maDiff == (Vector2.up) | maDiff == (Vector2.down) ) { // cardinals
				transform.GetComponent<Renderer>().material.color = Color.blue;
				isAdjacent = true;
				playerRelation = maDiff;
			} 
			else {
				transform.GetComponent<Renderer>().material.color = Color.white;
				isAdjacent = false;
				}
				
		} else {
			if (maDiff == (Vector2.down + Vector2.right) | maDiff == (Vector2.down + Vector2.left) | maDiff == (Vector2.right) | maDiff == (Vector2.left) // diagonals
				| maDiff == (Vector2.right * 2) | maDiff == (Vector2.left * 2) | maDiff == (Vector2.up) | maDiff == (Vector2.down)) {
				transform.GetComponent<Renderer>().material.color = Color.blue;
				isAdjacent = true;
				playerRelation = maDiff;
			} 
			else {
				transform.GetComponent<Renderer>().material.color = Color.white;
				isAdjacent = false;
			} 
		} */
	}
	
	void OnMouseDown() {
		PlayerController maBoiDoe = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
			//Debug.Log("my position is (" + gridPosition.x + "," + gridPosition.y);
		if (!isOccupied & isPassable & isAdjacent & maBoiDoe.moving) {
			BoardManager.Boardo.moveCurrentPlayer(this);
			
			maBoiDoe.gridPosition = this.gridPosition;
			maBoiDoe.lastMoved = playerRelation;
			//Debug.Log("playerRelation is " + playerRelation);
			
			maBoiDoe.actionPoints--;
		} else if (isAdjacent & maBoiDoe.turning) {
			maBoiDoe.lastMoved = playerRelation;
			maBoiDoe.actionPoints--;
		} else if (isAdjacent & isUnderFire & maBoiDoe.attacking & isOccupied) {
		//Debug.Log(isAdjacent & isUnderFire & maBoiDoe.attacking);
			BoardManager.Boardo.attackThisPlayer(playerHere);
			maBoiDoe.actionPoints--;
		}
	}
	
	public void generateNeighbors() {		
		neighbors = new List<Tile>();
		//Debug.Log(BoardManager.Boardo.map[0][1]);
		//Vector2 nn = new Vector2(gridPosition.x, gridPosition.y + 1);
		//	Debug.Log(nn);
			//neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		
		
		//N
		
		if (gridPosition.y != BoardManager.Boardo.mapWidth - 1) {
			Vector2 n = new Vector2(gridPosition.x, gridPosition.y + 1);
			// Debug.Log(n);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//NE
		if (gridPosition.x % 2 == 0 && gridPosition.x != BoardManager.Boardo.mapHeight - 1 && gridPosition.y != BoardManager.Boardo.mapWidth - 1) {
			Vector2 n = new Vector2(gridPosition.x + 1, gridPosition.y);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		} else if (gridPosition.x % 2 == 1  && gridPosition.y != BoardManager.Boardo.mapWidth - 1 && gridPosition.x != BoardManager.Boardo.mapHeight - 1) {
			Vector2 n = new Vector2(gridPosition.x + 1, gridPosition.y + 1);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//E
		if (gridPosition.x != BoardManager.Boardo.mapHeight - 1 && gridPosition.x != BoardManager.Boardo.mapHeight - 2) {
			Vector2 n = new Vector2(gridPosition.x + 2, gridPosition.y);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//SE
		if (gridPosition.x % 2 == 0 && gridPosition.y != 0 && gridPosition.x != BoardManager.Boardo.mapHeight - 1) {
			Vector2 n = new Vector2(gridPosition.x + 1, gridPosition.y - 1);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		} else if (gridPosition.x % 2 == 1 && gridPosition.x != BoardManager.Boardo.mapHeight - 1 ) {
			Vector2 n = new Vector2(gridPosition.x + 1, gridPosition.y);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//S
		if (gridPosition.y != 0) {
			Vector2 n = new Vector2(gridPosition.x, gridPosition.y - 1);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}
		//SW
		if (gridPosition.x % 2 == 0 && gridPosition.y != 0 && gridPosition.x != 0) {
			Vector2 n = new Vector2(gridPosition.x - 1, gridPosition.y - 1);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		} else if (gridPosition.x % 2 == 1 ) {
			Vector2 n = new Vector2(gridPosition.x - 1, gridPosition.y);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		}	
		//W
		if (gridPosition.x != 0 && gridPosition.x != 1 ) {
			Vector2 n = new Vector2(gridPosition.x - 2, gridPosition.y);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		} 
		//Nw
		if (gridPosition.x % 2 == 0 && gridPosition.x != 0 && gridPosition.y != BoardManager.Boardo.mapWidth - 1) {
			Vector2 n = new Vector2(gridPosition.x - 1, gridPosition.y);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		} else if (gridPosition.x % 2 == 1  && gridPosition.y != BoardManager.Boardo.mapWidth - 1) {
			Vector2 n = new Vector2(gridPosition.x - 1, gridPosition.y + 1);
			neighbors.Add(BoardManager.Boardo.map[(int)Mathf.Round(n.x)][(int)Mathf.Round(n.y)]);
		} 
		

	}
	
}
