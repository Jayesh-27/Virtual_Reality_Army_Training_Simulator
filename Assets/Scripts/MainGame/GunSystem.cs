using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunSystem : MonoBehaviour
{
    public float range;
    public int ammo;
    public bool shooting, readytoshoot, reloading;

    public Camera Camera;
    public Transform attackpoint;
    //public RaycastHit hit;
    public LayerMask whatisenemy;
    public Button Shoot;
    public GameObject Yo;



    void Start()
    {
        Shoot.onClick.AddListener(StartShooting);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
            if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, range, whatisenemy))
            {
                Debug.Log(hit.collider.name);
                Debug.Log("Hit Something");
                Yo.SetActive(false);

                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy Damaged");
                    
                }
            }
    }

    void StartShooting()
    {

    }
}
