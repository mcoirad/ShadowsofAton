using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InfScore : MonoBehaviour {
	private Text thisText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	thisText = GetComponent<Text>();
	thisText.text = PlayerStats.myPlayer.Influence.ToString();
	}
	
	public void upInf () {
		if (PlayerStats.myPlayer.Spendables > 0) {
			PlayerStats.myPlayer.Influence++;
			PlayerStats.myPlayer.Spendables--;
		}
		
	}
		
	public void downInf () {
		if (PlayerStats.myPlayer.Spendables < 6 && PlayerStats.myPlayer.Influence > 1) {
			PlayerStats.myPlayer.Influence--;
			PlayerStats.myPlayer.Spendables++;
		}
	}
}
