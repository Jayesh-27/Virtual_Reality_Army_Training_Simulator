using Meta.WitAi;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunWorking : MonoBehaviour
{
    public Camera Camera;
    public GameObject muzzlePrefab;
    public GameObject MetalImpactPrefab;
    public GameObject Yo;
    public GameObject Yo2;
    public Transform ReloadingObject;
    //public Button Shoot;
    public TrailRenderer BulletTrail;
    public Color rayColor = Color.red;
    public bool hasShot = false;
    public float FirstReloadingPosition = 0f;
    private bool flag = false;
    public int i = 0;
    public GameObject sphere; 
    public GameObject TestPanel;
    public GameObject text;
    public GameObject start;
    GameObject duplicateObject;
    public int numberOfClones = 5;
    private List<GameObject> sphereClones = new List<GameObject>();
    public string hit_tag;
    private int x;
    private int y;
    private int z;
    public GameObject Shot;
    public GameObject notshot;
    public AudioSource src;
    public AudioClip reload, shoot;
    //private Balloons Balloons;

    void Start()
    {
        
        
    }

    void FixedUpdate()
    {
        // Check for index trigger input
        Debug.Log("Function called");
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !hasShot && flag && i < 6)
        {
            //Debug.Log("Function called");
            GunShoot();
            Debug.DrawLine(Camera.transform.position, Yo.transform.position, rayColor);
            duplicateObject = Instantiate(sphere);
            sphereClones.Add(duplicateObject);
            duplicateObject.transform.position = Yo2.transform.position;
            
        }
        
        if (i == 5)
        {
            text.SetActive(true);
            
        }

        

        else if(OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && !hasShot && i != 5)
        {
            //Debug.Log("Function called");
            GunShoot();
            Debug.DrawLine(Camera.transform.position, Yo.transform.position, rayColor);
        }

        // Check if the trigger is released to reset the flag
        if (OVRInput.GetUp(OVRInput.Button.SecondaryHandTrigger) && i != 5)
        {
            if (hasShot == true)
            {
                src.clip = reload;
                src.Play();
                hasShot = false;
            }
        }

        if (hasShot)
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

    void GunShoot()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(Camera.transform.position, Camera.transform.forward, out hit, 300))
        {
            TrailRenderer trail = Instantiate(BulletTrail, Camera.transform.position, Quaternion.identity);
            StartCoroutine(SpawnTrail(trail, hit));
            hit_tag = hit.collider.tag;
            //shot();
            src.clip = shoot;
            src.Play();

            if(flag)
            {
                i++;
            }

            if (!flag)
            {
                Destroy(duplicateObject);
            }

            start.SetActive(false);

            Yo.transform.position = new Vector3(hit.point.x - 0.1f, hit.point.y + 0.072f, hit.point.z);
            var flash = Instantiate(muzzlePrefab, Camera.transform);
            

            hasShot = true;


            if (hit.collider.tag == "Enemy_Head")
            {
                Debug.Log("Aiming Head");
                Debug.Log(hit.point);
                var Impact = Instantiate(MetalImpactPrefab, Yo.transform);
                Yo2.transform.localPosition = new Vector3(Yo.transform.localPosition.x, Yo.transform.localPosition.y - 0.15f, Yo.transform.localPosition.z);
            }
            else if (hit.collider.tag == "Enemy_Body")
            {
                Debug.Log("Aiming Body");
                Debug.Log(hit.transform);
                var Impact = Instantiate(MetalImpactPrefab, Yo.transform);
                Yo2.transform.localPosition = new Vector3(Yo.transform.localPosition.x, Yo.transform.localPosition.y - 0.15f, Yo.transform.localPosition.z);
            }
            else
            {
                Yo2.transform.localPosition = new Vector3(Yo.transform.localPosition.x + 111f, Yo.transform.localPosition.y - 0.15f, Yo.transform.localPosition.z);
            }
            if (hit.collider.tag == "Balloon" && flag)
            {
                //hit.collider.gameObject.SetActive(false);
                z = Random.Range(-20, 20);
                x = Random.Range(8, 20);
                y = Random.Range(2, 6);
                hit.collider.gameObject.transform.position = new Vector3(x, y, z);
            }

        }
        else
        {
            Debug.Log("Can't Find Enemy");
        }
    }

    private IEnumerator SpawnTrail(TrailRenderer Trail, RaycastHit Hit)
    {
        float time = 0;
        Vector3 startposition = Trail.transform.position;

        while (time < 1)
        {
            Trail.transform.position = Vector3.Lerp(startposition, Yo.transform.position, time);
            time += Time.deltaTime / Trail.time;

            yield return null;
        }
        Trail.transform.position = Hit.point;
        Destroy(Trail.gameObject, Trail.time);
    }
    
    public void Test()
    {
        flag = true;
        start.SetActive(true);
        TestPanel.SetActive(false);
    }

    public void EXIT_TEST()
    {
        flag = false;
        i = 0;
        TestPanel.SetActive(true);
        text.SetActive(false);
        foreach (GameObject duplicateObject in sphereClones)
        {
            Destroy(duplicateObject);
        }

    }
}
