using UnityEngine;
using System.Collections;

/*センサー処理*/
public class Sensor : MonoBehaviour {
    [SerializeField]
    private int sensorNum = 0;
    [SerializeField]
    private GameObject wallManagerObj;
    private WallManager wallManager;


    /*GetComponent処理*/
	void  Awake() {
        wallManager = wallManagerObj.GetComponent<WallManager>();
	}

    /*センサーON・OFF処理*/
    private void OnTriggerEnter(Collider collision){
        if (collision.gameObject.CompareTag("wall")){   //壁生成でセンサーONメソッドの呼び出し
            wallManager.sensorFlgOn(sensorNum);
        }
        else if (collision.gameObject.CompareTag("Enemy")){ //エネミー接触でセンサーOFFメソッドの呼び出し
            wallManager.sensorFlgOff(sensorNum);

        }
       
    }

    

}
