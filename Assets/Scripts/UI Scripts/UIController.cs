using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIController : MonoBehaviour {

	public UIController UIguy;
	
	// Game text UI
	public Image TextHolder;
	public Text Texty;
	
	// Action buttons UI
	public Image Actions;
	
	// Portrait UI
	public Image PortraitBack;
	// Using a test portrait for now, next is the portrait prefab gen

	void Awake () {
			UIguy = this;
	}
	
	void InitialiseText() {
		// Creates the game text holder in bottom left hand corner
		TextHolder = (Instantiate(TextHolder, new Vector3(0,0,0), Quaternion.Euler(new Vector3()))) as Image;
		TextHolder.transform.SetParent(this.transform, false);
		TextHolder.rectTransform.anchorMax = new Vector2(0,0);
		TextHolder.rectTransform.anchorMin = new Vector2(0,0);
		TextHolder.rectTransform.anchoredPosition = new Vector2(240,45); 
		TextHolder.rectTransform.anchorMin = new Vector2(0,0);
		TextHolder.SetNativeSize();
		
		// Create the text itself
		Texty = (Instantiate(Texty, new Vector3(0,0,0), Quaternion.Euler(new Vector3()))) as Text;
		Texty.transform.SetParent(TextHolder.transform, false);
		Texty.rectTransform.anchorMax = new Vector2(0,0);
		Texty.rectTransform.anchorMin = new Vector2(0,0);
		Texty.rectTransform.anchoredPosition = new Vector2(226,75);
	}
	
	void InitialisePortrait() {
		// Generate Portrait in bottom right hand corner
		PortraitBack = (Instantiate(PortraitBack, new Vector3(0,0,0), Quaternion.Euler(new Vector3()))) as Image;
		PortraitBack.transform.SetParent(this.transform, false);
		PortraitBack.rectTransform.anchorMax = new Vector2(1,0);
		PortraitBack.rectTransform.anchorMin = new Vector2(1,0);
		PortraitBack.rectTransform.anchoredPosition = new Vector2(-50,50);
	}
	
	void InitialiseActions() {
		// Generate Action Buttons in top left corner
		Actions = (Instantiate(Actions, new Vector3(0,0,0), Quaternion.Euler(new Vector3()))) as Image;
		Actions.transform.SetParent(this.transform, false);
		Actions.rectTransform.anchorMax = new Vector2(0,1);
		Actions.rectTransform.anchorMin = new Vector2(0,1);
		Actions.rectTransform.anchoredPosition = new Vector2(640,-50);
	}
	
	// Use this for initialization
	void Start () {
		InitialiseText();
		InitialisePortrait();
		InitialiseActions();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
