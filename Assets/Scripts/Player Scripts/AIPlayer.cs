using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AIPlayer : PlayerController {

	// AI pathfinding
	PlayerController closestPlayer;
	public Vector2 closestPlayerPosition;
	public List<Tile> path;
	
	// AI combat priority vars
	public float sailNum = 0.7f;
	// float turnNum = 0.3;
	public float shotNum = 0.5f;
	// float crewNum = 0.5;
		
	// Use this for initialization
	void Start () {
		TurnUpdate () ;
		
	}
	
	public override void Update () {
				if (BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex] == this) {
					chooseAction();
				}
			
	}
	
	// Update is called once per frame
	public override void TurnUpdate () {
	
	if (Vector2.Distance(moveDestination, transform.position) > 0.1f) {
			transform.position += (moveDestination - transform.position).normalized * moveSpeed * Time.deltaTime;
			
			if (Vector2.Distance(moveDestination, transform.position) <= 0.1f) {
				transform.position = moveDestination;
				//BoardManager.Boardo.nextTurn();
			}
		}
		
		base.TurnUpdate ();
		

		}
		
	void chooseAction () {
		// So, does the CPU want to move, turn, fire cannon, or start crew combat?
		// Priorities:
		// 1. If enemy in cannon range, fire
		// 2. If enemy in boarding range, and health at a certain point, board
		// 3. If enemy out of cannon range, move to get in range
		//		o This involves turning if necessary
		// For now the enemy fights to the death but this might change later
		
		// For now we will settle for moving towards player while using actionpoints
		while (actionPoints > 0) {
			AImove();
			actionPoints--;
		}
		
	}	
	
	public override void AImove () {
	
		// Search thru list of players and choose closest one
		
		closestPlayerPosition = new Vector2(100,100);
		foreach(PlayerController prey in BoardManager.Boardo.players.Where (y => y.GetType() != typeof(AIPlayer))) {
			Debug.Log(prey.GetType());
			if (prey.gridPosition.sqrMagnitude < closestPlayerPosition.sqrMagnitude) {
				this.closestPlayer = prey;
				//Debug.Log(prey);
				
				this.closestPlayerPosition = prey.gridPosition;
			}
		}
	
		moving = true;
		attacking = false;
		//Debug.Log(closestPlayer);	

		// Calculate the path to the player
		path = TilePathFinder.FindPath (BoardManager.Boardo.map[(int)gridPosition.x][(int)gridPosition.y],BoardManager.Boardo.map[(int)closestPlayer.gridPosition.x][(int)closestPlayer.gridPosition.y]);
			Debug.Log(path); // Why is it returning null?
			//path.Reverse();
			path.ToArray();
			if (path[0] != null && path.Count > 1) { // If null, is next to player
				Debug.Log("AI moving to" + path[0].gridPosition);
				BoardManager.Boardo.moveCurrentPlayer(path[0]);
				this.gridPosition = path[0].gridPosition;
			} else {
				// if next to player turn cannons towards player
				AIturn();
				
			}
	}
	
	public override void AIturn () {
	
	}
	
	public override void AvailDir() {
	// Create an array of 2D vectors that the ship can move into
	// expanding or contracting based on ship turning speed
	/*
	            ^
	          /   \
	        ^   0   ^
	      /   \   /   \
	    ^   7   x   1   ^
	  /   \   /   \   /   \
	<   6   x Playr x   2   >
	  \   /   \   /   \   /
 	    v   5   x   3   v
		  \   /   \   /
		    v   4   v
			  \   /
			    v
	
	*/
	availMoves.Clear();
	Vector2[] dirAtlas = new Vector2[8];
	// Create the 'Atlas'
		if (gridPosition.x % 2 == 0) {
			
			dirAtlas[0] = Vector2.down;  // N
			dirAtlas[1] = Vector2.left;  // NE
			dirAtlas[2] = Vector2.left * 2;  //E
			dirAtlas[3] = Vector2.left + Vector2.up; // SE
			dirAtlas[4] = Vector2.up; // S
			dirAtlas[5] = Vector2.right + Vector2.up; // SW
			dirAtlas[6] = Vector2.right * 2; // W
			dirAtlas[7] = Vector2.right; // NW
			
		}
		else {
		
			dirAtlas[0] = Vector2.down; // N
			dirAtlas[1] = Vector2.left + Vector2.down; // NE
			dirAtlas[2] = Vector2.left * 2; // E
			dirAtlas[3] = Vector2.left; // SE
			dirAtlas[4] = Vector2.up;   // S
			dirAtlas[5] = Vector2.right; // SW
			dirAtlas[6] = Vector2.right * 2;  //W
			dirAtlas[7] = Vector2.right + Vector2.down; // NW
			
		
		}

		// need to assign lastMoved a int 0-7 instead of vec2
		// because the vec2 is too relative of a measure
		
		
		int dirDir = lastMoved;
		// Debug.Log("Last Moved is " + lastMoved);
		//Debug.Log(dirAtlas[1]);
		for (int i= turningSpeed * -1; i <= turningSpeed; i++) {
			//Debug.Log((i + dirDir) % 8);
			availMoves.Add(dirAtlas[BoardManager.Boardo.modu((i + dirDir), 8)]);
			//Debug.Log(BoardManager.Boardo.modu((i + dirDir), 8));
		}
		
	}
	
	public override void AvailSht() {
		availShots.Clear();
		Vector2[] dirAtlas = new Vector2[8];
		Vector2[] shtAtlas = new Vector2[16];
			if (gridPosition.x % 2 == 0) {
						
						dirAtlas[0] = Vector2.down;  // N
						dirAtlas[1] = Vector2.left;  // NE
						dirAtlas[2] = Vector2.left * 2;  //E
						dirAtlas[3] = Vector2.left + Vector2.up; // SE
						dirAtlas[4] = Vector2.up; // S
						dirAtlas[5] = Vector2.right + Vector2.up; // SW
						dirAtlas[6] = Vector2.right * 2; // W
						dirAtlas[7] = Vector2.right; // NW
						
						// Further away spaces (normal range for cannon?)
						shtAtlas[0] = Vector2.down * 2; //NNN
						shtAtlas[1] = Vector2.left + Vector2.down; //NNE
						shtAtlas[2] = Vector2.left * 2 + Vector2.down; //NE
						shtAtlas[3] = Vector2.left * 3; // NEE
						shtAtlas[4] = Vector2.left * 4; //EEE
						shtAtlas[5] = Vector2.left * 3 + Vector2.up; // SEE
						shtAtlas[6] = Vector2.left * 2 + Vector2.up; //SE
						shtAtlas[7] = Vector2.left + Vector2.up * 2; //SSe
						shtAtlas[8] = Vector2.up * 2; //SSS
						shtAtlas[9] = Vector2.right + Vector2.up * 2; //SSW
						shtAtlas[10] = Vector2.right * 2 + Vector2.up; //SW
						shtAtlas[11] = Vector2.right * 3 + Vector2.up; // SWW
						shtAtlas[12] = Vector2.right * 4; //WWW
						shtAtlas[13] = Vector2.right * 3; // NWW
						shtAtlas[14] = Vector2.right * 2 + Vector2.down; //NW
						shtAtlas[15] = Vector2.right + Vector2.down; //NNW
						

						
					}
					else {
					
						dirAtlas[0] = Vector2.down; // N
						dirAtlas[1] = Vector2.left + Vector2.down; // NE
						dirAtlas[2] = Vector2.left * 2; // E
						dirAtlas[3] = Vector2.left; // SE
						dirAtlas[4] = Vector2.up;   // S
						dirAtlas[5] = Vector2.right; // SW
						dirAtlas[6] = Vector2.right * 2;  //W
						dirAtlas[7] = Vector2.right + Vector2.down; // NW
						
						// Further away spaces (normal range for cannon?)
						
						shtAtlas[0] = Vector2.down * 2; //NNN
						shtAtlas[1] = Vector2.left + Vector2.down * 2; //NNE
						shtAtlas[2] = Vector2.left * 2 + Vector2.down; //NE
						shtAtlas[3] = Vector2.left * 3 + Vector2.down; // NEE
						shtAtlas[4] = Vector2.left * 4; //EEE
						shtAtlas[5] = Vector2.left * 3; // SEE
						shtAtlas[6] = Vector2.left * 2 + Vector2.up; //SE
						shtAtlas[7] = Vector2.left + Vector2.up; //SSe
						shtAtlas[8] = Vector2.up * 2; //SSS
						shtAtlas[9] = Vector2.right + Vector2.up; //SSW
						shtAtlas[10] = Vector2.right * 2 + Vector2.up; //SW
						shtAtlas[11] = Vector2.right * 3; // SWW
						shtAtlas[12] = Vector2.right * 4; //WWW
						shtAtlas[13] = Vector2.right * 3 + Vector2.down; // NWW
						shtAtlas[14] = Vector2.right * 2 + Vector2.down; //NW
						shtAtlas[15] = Vector2.right + Vector2.down * 2; //NNW
					}
			// currently cannon range and maneuverability is set and does not change
			// in the future consider using a for loop to generate these values
			int dirDir = lastMoved;
			
			// Starboard Cannon Range
			availShots.Add(dirAtlas[BoardManager.Boardo.modu((2 + dirDir), 8)]);
			availShots.Add(shtAtlas[BoardManager.Boardo.modu((2 + dirDir) * 2, 16)]);
			availShots.Add(shtAtlas[BoardManager.Boardo.modu((2 + dirDir) * 2 + 1, 16)]);
			availShots.Add(shtAtlas[BoardManager.Boardo.modu((2 + dirDir) * 2 - 1, 16)]);
			
			// Port Cannon Range
			availShots.Add(dirAtlas[BoardManager.Boardo.modu((-2 + dirDir), 8)]);
			availShots.Add(shtAtlas[BoardManager.Boardo.modu((-2 + dirDir) * 2, 16)]);
			availShots.Add(shtAtlas[BoardManager.Boardo.modu((-2 + dirDir) * 2 + 1, 16)]);
			availShots.Add(shtAtlas[BoardManager.Boardo.modu((-2 + dirDir) * 2 - 1, 16)]);
			
	}
}
