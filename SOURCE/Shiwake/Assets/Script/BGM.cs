using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	// BGM再生
	void Start () {
        SoundManager.Instance.PlayBGM(0);
	}
}
