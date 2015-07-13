using UnityEngine;
using System.Collections;

public class BGM : MonoBehaviour {

	// ゲーム開始時にBGM再生
	void Start () {
        SoundManager.Instance.PlayBGM(0);
	}
}
