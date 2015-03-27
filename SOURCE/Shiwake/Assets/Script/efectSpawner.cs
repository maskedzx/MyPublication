using UnityEngine;
using System.Collections;

public class efectSpawner : MonoBehaviour {
	public GameObject goodObj;
	public GameObject badObj;

	// 正解エフェクト生成
	public void good () {
		Instantiate (goodObj, this.transform.localPosition, this.transform.localRotation);
	}
	
	// 不正解エフェクト生成
	public void bad () {
		Instantiate (badObj, this.transform.localPosition, this.transform.localRotation);
	}
}
