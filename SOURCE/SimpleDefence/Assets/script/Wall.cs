using UnityEngine;
using System.Collections;

/*壁の処理*/
public class Wall : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) //エネミーと接触したら自壊
        {
            Destroy(this.gameObject);
        }
    }

}
