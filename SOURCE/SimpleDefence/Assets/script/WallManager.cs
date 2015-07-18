using UnityEngine;
using System.Collections;

public class WallManager : MonoBehaviour {
    [SerializeField]
    private GameObject costManagerObj;
    private CostManager costManager;
    [SerializeField]
    private GameObject[] wall;
    private int[] checkLine = { 0, 5, 10, 15, 20, 25, 30 };
    private int[] checkEnd = { 5, 10, 15, 20, 25, 30, 35 };
    private float[] wallLine = { -15, -10, -5, 0, 5, 10, 15};
    private float[] wallRow = { -10, -20, -30, -40, -50 };
    private int[] sensorFlg = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

    /*GetComponent処理*/
    void Awake(){
        costManager = costManagerObj.GetComponent<CostManager>();
    }

    /*センサーONの処理*/
    public void sensorFlgOn(int Num){
        sensorFlg[Num] = 1;
        Debug.Log("ON");
    }

    /*センサーOFFの処理*/
    public void sensorFlgOff(int Num){
        sensorFlg[Num] = 0;
        Debug.Log("OFF");
    }

    /*
     * １～７キーで列別に壁生成処理の起動
     * 奥側からセンサーがOFFの場所をチェック
     * ヒットした位置に壁を生成
     */
    public void spawnWall(int num){
        switch (num){
            case 1:
                for (int line = checkLine[0]; line < checkEnd[0]; line++){
                    if (sensorFlg[line] == 0)
                    {
                        SoundManager.Instance.PlaySE(0);
                        Instantiate(wall[0], new Vector3(wallLine[0], 3,wallRow[line]), this.transform.localRotation);
                        costManager.costSub();
                        break;
                    }
                }
                break;

            case 2:
                for (int line = checkLine[1]; line < checkEnd[1]; line++)
                {
                    if (sensorFlg[line] == 0)
                    {
                        Instantiate(wall[1], new Vector3(wallLine[1], 3, wallRow[line - checkLine[1]]), this.transform.localRotation);
                        SoundManager.Instance.PlaySE(0); 
                        costManager.costSub();
                        break;
                    }
                }
                break;

            case 3:
                for (int line = checkLine[2]; line < checkEnd[2]; line++)
                {
                    if (sensorFlg[line] == 0)
                    {
                        Instantiate(wall[2], new Vector3(wallLine[2], 3, wallRow[line - checkLine[2]]), this.transform.localRotation);
                        SoundManager.Instance.PlaySE(0);
                        costManager.costSub();
                        break;
                    }
                }
                break;

            case 4:
                for (int line = checkLine[3]; line < checkEnd[3]; line++)
                {
                    if (sensorFlg[line] == 0)
                    {
                        Instantiate(wall[3], new Vector3(wallLine[3], 3, wallRow[line - checkLine[3]]), this.transform.localRotation);
                        SoundManager.Instance.PlaySE(0);
                        costManager.costSub();
                        break;
                    }
                }
                break;

            case 5:
                for (int line = checkLine[4]; line < checkEnd[4]; line++)
                {
                    if (sensorFlg[line] == 0)
                    {
                        Instantiate(wall[4], new Vector3(wallLine[4], 3, wallRow[line - checkLine[4]]), this.transform.localRotation);
                        SoundManager.Instance.PlaySE(0);
                        costManager.costSub();
                        break;
                    }
                }
                break;

            case 6:
                for (int line = checkLine[5]; line < checkEnd[5]; line++)
                {
                    if (sensorFlg[line] == 0)
                    {
                        Instantiate(wall[5], new Vector3(wallLine[5], 3, wallRow[line - checkLine[5]]), this.transform.localRotation);
                        SoundManager.Instance.PlaySE(0);
                        costManager.costSub();
                        break;
                    }
                }
                break;

            case 7:
                for (int line = checkLine[6]; line < checkEnd[6]; line++)
                {
                    if (sensorFlg[line] == 0)
                    {
                        Instantiate(wall[6], new Vector3(wallLine[6], 3, wallRow[line - checkLine[6]]), this.transform.localRotation);
                        SoundManager.Instance.PlaySE(0);
                        costManager.costSub();
                        break;
                    }
                }
                break;
        }
    }
}
