using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	
	Text instruction;

	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
	PlayerController maBoi = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
	if (maBoi.gridPosition == new Vector2(1,1)) {
		this.instruction.text = "Your boy we goin to sea!";
	} else if (maBoi.gridPosition == new Vector2(2,0)) {
		this.instruction.text = "Hey son smoke weed everyday!";
	} else if (maBoi.gridPosition == new Vector2(2,2)) {
		this.instruction.text = "Yo a pirates life for me!";
	} else if (maBoi.gridPosition == new Vector2(3,1)) {
		this.instruction.text = "Where day rum at?";
	}
	}
	

}
