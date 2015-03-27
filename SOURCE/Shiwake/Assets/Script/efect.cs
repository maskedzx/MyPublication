using UnityEngine;
using System.Collections;

public class efect : MonoBehaviour {
	[SerializeField]
	private int cnt = 6;

	// Update is called once per frame
	void Update () {
		cnt--;
		if (cnt <= 0) {
			Destroy (gameObject);
		}
	}
}
