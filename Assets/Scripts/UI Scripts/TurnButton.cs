using UnityEngine;
using System.Collections;

public class TurnButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
		public void onMouseDown () {
		PlayerController maBoi = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
		if (maBoi.turning) {
			maBoi.turning = false;
		} else {
			maBoi.turning = true;
			maBoi.moving = false;
			maBoi.attacking = false;
		}
	}
}
