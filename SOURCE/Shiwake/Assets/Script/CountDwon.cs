using UnityEngine;
using System.Collections;

public class CountDwon : MonoBehaviour {
	public GameObject SpawnerObj;
	private Spawns sp;

    void Awake()
    {
        sp = SpawnerObj.GetComponent<Spawns>();
    }

//カウントダウン終了時にスポナー起動して自壊

	void OnAnimationFinish(){
		sp.spawnsSet();
		Destroy (gameObject);
	}
}
