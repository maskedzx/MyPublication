using UnityEngine;
using System.Collections;

/*エネミーに関する処理*/
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed = -0.1f;    
    [SerializeField]
    private int enemyHp = 1;    
    [SerializeField]
    private GameObject resultObj;
    private Result result;

    /*GetComponent処理*/
    void Awake(){
        resultObj = GameObject.Find("resultObj").gameObject;
        result = resultObj.GetComponent<Result>();
    }

    /*常時起動する処理*/
    void Update()
    {
        if (Time.timeScale != 0){   //timeScaleが0以上でエネミーが前進し続ける
            transform.Translate(0, speed, 0);
        }
    }


    //衝突処理
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("endLine")){ //プレイヤーの元まで到達したとき
            SoundManager.Instance.PlaySE(2);    //効果音再生
            result.damege();    //ライフ減少メソッドの呼び出し
            Destroy(this.gameObject);   //自壊処理
        }
        else if(collision.gameObject.CompareTag("wall")){  //壁にぶつかったとき
            SoundManager.Instance.PlaySE(1);    //効果音再生
            enemyHp--;  //エネミーの㏋減少
            if (enemyHp == 0){  //エネミーの㏋が0になったら自壊
                Destroy(this.gameObject);
            }
        }
    }
}
