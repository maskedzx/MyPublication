using UnityEngine;
using System.Collections;

public class hiyoko : MonoBehaviour {

	private Vector2 leftSride;
	private Vector2 rightSride;
	
	public void srideLest () {
		transform.localPosition = leftSride;
		leftSride.x -= 10; 
	}

	public void srideRight () {
		transform.localPosition = rightSride;
		rightSride.x += 10; 
	}

	void OnTriggerEnter2D(Collider2D col){ // 衝突判定
		if (col.gameObject.CompareTag("Destroy")) { 
			Destroy(gameObject);
		}
	}
}
