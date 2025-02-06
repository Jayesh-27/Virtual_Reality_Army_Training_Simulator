using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_UI : MonoBehaviour
{
    public GameObject shootingrange;
    public GameObject movingtarget;
    public GameObject balloon;
    public GameObject GUN;
    private bool setactive = false;

    public void ShootingRange()
    {
       shootingrange.SetActive(true);
       movingtarget.SetActive(false);
       balloon.SetActive(false);
    }

    public void MovingTarget()
    {
        shootingrange.SetActive(false);
        movingtarget.SetActive(true);
        balloon.SetActive(false);
    }

    public void BalloonTarget()
    {
        shootingrange.SetActive(false);
        movingtarget.SetActive(false);
        balloon.SetActive(true);
    }

    public void Gun()
    {
        GUN.SetActive(!setactive);
        setactive = !setactive;
    }
}
