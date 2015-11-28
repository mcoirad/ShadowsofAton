using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextHider : MonoBehaviour {
	RectTransform thisIm;
	// Use this for initialization
	void Start () {
		thisIm = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OnMouseDown() {
		if (thisIm.anchoredPosition != new Vector2(240,-35)) {
			int newy = new int ();
			newy = -15;
			thisIm.anchoredPosition = new Vector2(240,-35);
			//Debug.Log("text hidden");
			} else {
				thisIm.anchoredPosition = new Vector2(240,45);
			}
	}

}
