using UnityEngine;
using System.Collections;

public class CannonButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	public void onMouseDown () {
		PlayerController maBoi = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
		if (maBoi.attacking) {
			maBoi.attacking = false;
		} else {
			maBoi.attacking = true;
			maBoi.moving = false;
			maBoi.turning = false;
		}
	}
	
	}
