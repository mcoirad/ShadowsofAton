using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	
	public Vector2 pos;
	
	// UI popups
	public GameObject PopBack;
	protected GameObject PopBack2;
	public Text PopText;
	protected Text PopText2;
	
	// Action vars
	public bool moving = false;
	public bool attacking = false;
	public bool turning = false;
	
	// Cartesian position
	public Vector2 gridPosition = Vector2.zero;
	
	// Moving
	public Vector3 moveDestination;
	public float moveSpeed = 10.0f;
	
	// Last moved
	public int lastMoved = 1;
	public List <Vector2> availMoves = new List <Vector2> ();
	public Vector2[] dirAtlas2 = new Vector2[] {
        new Vector2 (0, 0),
        new Vector2 (0, 0),
        new Vector2 (0, 0),
		new Vector2 (0, 0),
        new Vector2 (0, 0),
        new Vector2 (0, 0),
		new Vector2 (0, 0),
        new Vector2 (0, 0)
    };
	
	// Cannon range
	// (perpendicular mostly, but should have ability to mount front and back cannons)
	public List <Vector2> availShots = new List <Vector2> ();
	public List <Vector2> availShots2 = new List <Vector2> ();
	
	// Action Statistics
	public int actionPoints;
	public int maxActionPoints;
	
	// SHIP STATISTICS
	// movement
	public int speed; // Boat speed (action points used per movement?)  **NOT USED YET**
	public int turningSpeed= 1; // Which squares will be available to move into  **FINISHED**
	// shooting
	public int cannonSwivel; // Which squares will be available to shoot into **NOT USED YET**
	public int cannonRange;
	public float shootingAbility;
	public int numCannons;
	public bool frontCannon = false;
	public bool backCannon = false;
	// ship health
	public int health;

	void Awake (){
		moveDestination = transform.position;
		lastMoved = 1;// sets boat to bottom left orientation

	}
	
	void Start () {
		// First store our current position when the
		// script is initialized.
		pos = transform.position;
	}
	
	
	
	public virtual void Update () {
		CheckInput();

	}
	
	public virtual void AvailDir () {
	
	}
	
	public virtual void AvailSht () {
	
	}
	
	public virtual void OnMouseEnter () {
		
	}
	
	public virtual void OnMouseExit () {
	
	}
	
	public virtual void AImove () {
	
	}
	
	public virtual void AIturn () {
	
	}
	
	public virtual void CheckInput () {
	
		//Debug.Log("yo");
	}
	
	public virtual void TurnUpdate () {
		
	}
}
