using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class AIPlayer : PlayerController {

	// AI pathfinding
	PlayerController closestPlayer;
	Vector2 closestPlayerPosition = new Vector2(100,100);
		
		
	// Use this for initialization
	void Start () {
		TurnUpdate () ;
	}
	
	public override void Update () {
					if (!moving) {
				AImove();
				moving = false;
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
		
	public override void AImove () {
		// Search thru list of players and choose closest one
		
		
		foreach(PlayerController prey in BoardManager.Boardo.players.Where (y => y.GetType() != typeof(AIPlayer))) {
			if (prey.gridPosition.sqrMagnitude < closestPlayerPosition.sqrMagnitude) {
				this.closestPlayer = prey;
				//Debug.Log(prey);
				
				this.closestPlayerPosition = prey.gridPosition;
			}
		moving = true;
		attacking = false;
		//Debug.Log(closestPlayer);	

		// Calculate the path to the player
		List<Tile> path = TilePathFinder.FindPath (BoardManager.Boardo.map[(int)gridPosition.x][(int)gridPosition.y],BoardManager.Boardo.map[(int)closestPlayer.gridPosition.x][(int)closestPlayer.gridPosition.y]);
			Debug.Log(path.Count); // Why is it returning null?
			path.ToList();
			BoardManager.Boardo.moveCurrentPlayer(path[0]);
			
			/* if (path.Count() > 1) {
					List<Tile> actualMovement = TileHighlight.FindHighlight(BoardManager.Boardo.map[(int)gridPosition.x][(int)gridPosition.y], actionPoints);
					path.Reverse();
					if (path.Where(x => actualMovement.Contains(x)).Count() > 0) {
						BoardManager.Boardo.moveCurrentPlayer(path.Where (x => actualMovement.Contains(x)).First());
					}
				}	*/
		}
	
		//if (!moving && movementTilesInRange.Where(x => GameManager.instance.players.Where (y => y.GetType() != typeof(AIPlayer) && y.HP > 0 && y != this && y.gridPosition == x.gridPosition).Count() > 0).Count () > 0) {
	}
}
