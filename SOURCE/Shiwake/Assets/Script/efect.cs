using UnityEngine;
using System.Collections;

public class efect : MonoBehaviour {
	[SerializeField]
	private int cnt = 6;

	// 正誤エフェクトの自壊処理
	void Update () {
		cnt--;
		if (cnt <= 0) {
			Destroy (gameObject);
		}
	}
}
