using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PercScore : MonoBehaviour {
	private Text thisText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	thisText = GetComponent<Text>();
	thisText.text = PlayerStats.myPlayer.Perception.ToString();
	}
	
	public void upPerc () {
		if (PlayerStats.myPlayer.Spendables > 0) {
			PlayerStats.myPlayer.Perception++;
			PlayerStats.myPlayer.Spendables--;
		}
		
	}
		
	public void downPerc () {
		if (PlayerStats.myPlayer.Spendables < 6 && PlayerStats.myPlayer.Perception > 1) {
			PlayerStats.myPlayer.Perception--;
			PlayerStats.myPlayer.Spendables++;
		}
	}
}
