using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Balloons : MonoBehaviour
{
    public GunWorking GunWorking;
    public GameObject BalloonsPrefab;
    //private int i = 0;
    private int x;
    private int y;
    private int z;
    private bool testFlag;
    public GameObject START_PANEL;
    public GameObject Start_text;
    public GameObject End_text;
    public GameObject Shot;
    public GameObject notshot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GunWorking.hasShot)
        {
            Shot.SetActive(true);
            notshot.SetActive(false);
        }
        else
        {
            Shot.SetActive(false);
            notshot.SetActive(true);
        }
    }

    public void shot()
    {
        if (GunWorking.hit_tag == "Balloon" && testFlag)
        {
            z = Random.Range(-20, 20);
            x = Random.Range(8, 20);
            y = Random.Range(0, 4);
            BalloonsPrefab.transform.position = new Vector3(x, y, z);
            Debug.Log(new Vector3(x, y, z));
            Start_text.SetActive(false);
        }

        if (!testFlag)
        {
            End_text.SetActive(false);
        }


    }

    public void start()
    {
        testFlag = true;
        START_PANEL.SetActive(false);
        Start_text.SetActive(true);
    }

    public void exit()
    {
        testFlag = false;
        START_PANEL.SetActive(true);
        End_text.SetActive(true);
        BalloonsPrefab.transform.position = new Vector3(8.39f, 0.4893118f, -0.04f);
    }
}
