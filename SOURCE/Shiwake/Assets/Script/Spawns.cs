using UnityEngine;
using System.Collections;

public class Spawns : MonoBehaviour {
	public GameObject[] Sets;
	private int setsNum;

	// Use this for initialization
	void Awake () {
		setsNum = Random.Range (0, Sets.Length - 1);
	}
	
	// Update is called once per frame
	public void spawnsSet() {
		setsNum = Random.Range (0, Sets.Length - 1);
		Instantiate (Sets[setsNum], this.transform.localPosition, this.transform.localRotation);
        SoundManager.Instance.PlaySE(0);
	}
}
