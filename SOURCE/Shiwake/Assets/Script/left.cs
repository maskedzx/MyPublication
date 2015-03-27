using UnityEngine;
using System.Collections;

public class left : MonoBehaviour {
	private Vector2 leftSride;
		
	public void sride () {
		transform.localPosition = leftSride;
		leftSride.x -= 10; 
	}

	void OnTriggerEnter2D(Collider2D col){ // 衝突判定
		if (col.gameObject.CompareTag("Destroy")) { 
			Destroy(gameObject);
		}
	}
}
