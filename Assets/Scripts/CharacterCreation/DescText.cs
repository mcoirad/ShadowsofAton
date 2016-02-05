using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DescText : MonoBehaviour {
	private Text thisText;

	// Use this for initialization
	void Start () {
		thisText = GetComponent<Text>();
		thisText.text =  "Move  yer  cursor  onna  tag  to  view  tha  booty.";
	}
	
	// Update is called once per frame
	void Update () {
	
	
	}
	
	public void Seamanship () {
		thisText = GetComponent<Text>();
		thisText.text =  "Keeping  the  ship  moving,  or  at  least  afloat  is  an  important  skill  for  any  cap'n  on  the  seas.";	
	}
	public void Perception () {
		thisText = GetComponent<Text>();
		thisText.text =  "Its  not  always  possible  to  have eyes  in  the  back  of  yer  head,  but  an  eye  for  detail  is  almost  as  good.";	
	}	
	public void Leadership () {
		thisText = GetComponent<Text>();
		thisText.text =  "Pirating  isn't  the  easiest  life.  There  are  times  to  put  the  hand  to  the  steel  and  powder  to  the  cannon.";	
	}	
	public void Influence () {
		thisText = GetComponent<Text>();
		thisText.text =  "The  respect  of  yer  fellow  buccaneers  comes  in  handy  when  it  comes  to  the  division  of  booty.";	
	}
		

}
