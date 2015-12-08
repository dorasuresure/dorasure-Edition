using UnityEngine;
using System.Collections;

public class HPScript : MonoBehaviour {

	RectTransform rt;

	// Use this for initialization
	void Start () {
		rt = GetComponent<RectTransform> ();
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void HPDown(int ap){
		rt.sizeDelta -= new Vector2 (ap, 0);
	}
}
