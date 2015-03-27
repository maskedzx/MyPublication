using UnityEngine;
using System.Collections;

public class efectSpawner : MonoBehaviour {
	public GameObject goodObj;
	public GameObject badObj;

	// Use this for initialization
	public void good () {
		Instantiate (goodObj, this.transform.localPosition, this.transform.localRotation);
	}
	
	// Update is called once per frame
	public void bad () {
		Instantiate (badObj, this.transform.localPosition, this.transform.localRotation);
	}
}
