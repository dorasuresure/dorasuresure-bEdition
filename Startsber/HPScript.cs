using UnityEngine;
using System.Collections;

public class HPScript : MonoBehaviour {
	RectTransform rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	public void HPDown(int ap){
		rt.sizeDelta -= new Vector2 (ap, 0);
	}
}
