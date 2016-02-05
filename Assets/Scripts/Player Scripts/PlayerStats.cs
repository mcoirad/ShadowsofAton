using UnityEngine;
using System.Collections;


public class PlayerStats : MonoBehaviour {
	public int Seamanship;
	public int Perception;
	public int Leadership;
	public int Influence;
	public int Spendables;
	public static PlayerStats myPlayer;
	
	
	// Use this for initialization
	void Start () {
		myPlayer = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
