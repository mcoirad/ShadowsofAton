using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SeaScore : MonoBehaviour {
	private Text thisText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	thisText = GetComponent<Text>();
	thisText.text = PlayerStats.myPlayer.Seamanship.ToString();
	}
	
	public void upSea () {
		if (PlayerStats.myPlayer.Spendables > 0) {
			PlayerStats.myPlayer.Seamanship++;
			PlayerStats.myPlayer.Spendables--;
		}
		
	}
		
	public void downSea () {
		if (PlayerStats.myPlayer.Spendables < 6 && PlayerStats.myPlayer.Seamanship > 1) {
			PlayerStats.myPlayer.Seamanship--;
			PlayerStats.myPlayer.Spendables++;
		}
	}
}
