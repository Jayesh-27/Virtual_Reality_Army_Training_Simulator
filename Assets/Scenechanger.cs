using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenechanger : MonoBehaviour
{
    public string targetSceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootingRange()
    {
        targetSceneName = "GUN";
    }

    public void MovingTarget()
    {
        targetSceneName = "MovingTarget";
    }

    public void MovingEnemy()
    {
        targetSceneName = "BALLOONS";
    }
}
