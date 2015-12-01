using UnityEngine;
using System.Collections;

public class CamController : MonoBehaviour {
	
	public PlayerController target;  // The player
	public static Camera mainCam;
	
	private Vector3  offset;
	
	void Start () {
		
		// Change the z value of the offset
		// to something below the sprites.
		// Otherwise you can't see anything:
		offset = new Vector3(0f, 0f, -10f);
		mainCam = this.GetComponent<Camera>();
	}
	
	void Update () {
		
	}
	
	// Let's put the movement in LateUpdate (called after Update function)
	void LateUpdate() {
		// Change camera's position to the same as the player (with the z-value of -10)
		target = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex] as PlayerController;
		//Debug.Log(BoardManager.Boardo.currentPlayerIndex);
		transform.position = target.transform.position + offset;
	}
}