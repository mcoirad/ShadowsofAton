using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CannonButton : MonoBehaviour {
	public bool showGUI;
	public GameObject PopBack;
	private GameObject PopBack2;
	public Text PopText;
	private Text PopText2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public void onMouseDown () {
		PlayerController maBoi = BoardManager.Boardo.players[BoardManager.Boardo.currentPlayerIndex];
		if (maBoi.attacking) {
			maBoi.attacking = false;
		} else {
			maBoi.attacking = true;
			maBoi.moving = false;
			maBoi.turning = false;
		}
	}
	
	public void ponExitGUI()
		{
		DestroyImmediate(PopText2);
		DestroyImmediate(PopBack2);
		
			//onGUI();
		}
		
	public void ponGUI () {
		//if (PopBack2 != null) {Destroy(PopBack2);}
		PopBack2 = (Instantiate(PopBack, new Vector3(0,0,0), Quaternion.Euler(new Vector3()))) as GameObject;
		PopBack2.transform.SetParent(this.transform, false);
		RectTransform PopComponent = PopBack2.GetComponent<RectTransform>();
		PopComponent.anchoredPosition = new Vector2(118,-90);
		
		PopText2 = (Instantiate(PopText, new Vector3(0,0,0), Quaternion.Euler(new Vector3()))) as Text;
		PopText2.transform.SetParent(PopBack2.transform, false);
		PopText2.rectTransform.anchoredPosition = new Vector2(72,27);
		PopText2.text = "Fire Cannons";
		
		showGUI = true;
		//Debug.Log("Popup loaded!");
	
	}
}
