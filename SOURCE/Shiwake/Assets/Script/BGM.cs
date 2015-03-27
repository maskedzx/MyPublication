using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SoundManager.Instance.PlayBGM(0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
