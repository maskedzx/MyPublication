using UnityEngine;
using System.Collections;

public class Spawns : MonoBehaviour {
	public GameObject[] Sets;
	private int setsNum;

	// 最初の組み合わせ設定
	void Awake () {
		setsNum = Random.Range (0, Sets.Length - 1);
	}
	
	// 出題メソッド
	public void spawnsSet() {
		setsNum = Random.Range (0, Sets.Length - 1);
		Instantiate (Sets[setsNum], this.transform.localPosition, this.transform.localRotation);
        SoundManager.Instance.PlaySE(0);
	}
}
