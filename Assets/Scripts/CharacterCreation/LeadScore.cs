using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LeadScore : MonoBehaviour {
	private Text thisText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	thisText = GetComponent<Text>();
	thisText.text = PlayerStats.myPlayer.Leadership.ToString();
	}
	
	public void upLead () {
		if (PlayerStats.myPlayer.Spendables > 0) {
			PlayerStats.myPlayer.Leadership++;
			PlayerStats.myPlayer.Spendables--;
		}
		
	}
		
	public void downLead () {
		if (PlayerStats.myPlayer.Spendables < 6 && PlayerStats.myPlayer.Leadership > 1) {
			PlayerStats.myPlayer.Leadership--;
			PlayerStats.myPlayer.Spendables++;
		}
	}
}
