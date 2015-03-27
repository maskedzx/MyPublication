using UnityEngine;
using System.Collections;

public class right : MonoBehaviour {
	private Vector2 rightSride;
	
	public void sride () {
		transform.localPosition = rightSride;
		rightSride.x += 12; 
	}

	void OnTriggerEnter2D(Collider2D col){ // 衝突判定
		if (col.gameObject.CompareTag("Destroy")) { 
			Destroy(gameObject);
		}
	}
}
