using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoShellSpawner : MonoBehaviour
{
    public Transform Camera;
    public Transform AmmoShellSpawn;
    public GameObject AmmoShell;
    public bool SpawnAmmoShell;
    public Rigidbody Rigidbody;
    public float AmmoShellForce;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, 300))
        {
            if (SpawnAmmoShell == true)
            {
                SpawnAmmoShell = false;
                Instantiate(AmmoShellSpawn, AmmoShellSpawn.transform.position, Quaternion.identity);
                Rigidbody.AddForce(AmmoShellSpawn.transform.forward * AmmoShellForce, ForceMode.Impulse);
            }
        }
    }
}
