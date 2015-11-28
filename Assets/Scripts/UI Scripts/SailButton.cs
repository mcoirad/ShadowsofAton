using UnityEngine;
using System.Collections;

public class SailButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void onMouseDown () {
		PlayerController maBoi = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
		if (maBoi.moving) {
			maBoi.moving = false;
		} else {
			maBoi.moving = true;
			maBoi.turning = false;
			maBoi.attacking = false;
		}
	}
}
