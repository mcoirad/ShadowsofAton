using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {

	public Vector2 gridPosition = Vector2.zero; 
	public bool cityPopup = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		PlayerController maBoi = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
		if (maBoi.gridPosition == this.gridPosition & !cityPopup) {
			cityPopup = true;
			cityUI();
		}
	}
	
	// Generate City Pop up
	void cityUI() {
		
	}
}
