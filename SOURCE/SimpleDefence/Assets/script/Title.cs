using UnityEngine;
using System.Collections;

/*タイトルの処理*/
public class Title : MonoBehaviour {

    /*BGMの再生*/
	void Start () {
        SoundManager.Instance.PlayBGM(0); 
	}
	
	/*Enterキーの入力監視*/
	void Update () {
        if (Input.GetKeyUp(KeyCode.Return)){
            Application.LoadLevel("main");  //メインシーンへ
        }
	}
}
