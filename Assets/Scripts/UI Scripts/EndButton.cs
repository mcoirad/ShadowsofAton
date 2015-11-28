using UnityEngine;
using System.Collections;

public class EndButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
		public void onMouseDown () {
		PlayerController maBoi = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
			maBoi.moving = false;
			maBoi.turning = false;
			maBoi.attacking = false;
			BoardManager.Boardo.nextTurn();
	}
}
