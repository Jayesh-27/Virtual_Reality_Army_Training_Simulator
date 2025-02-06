using UnityEngine;

public class SetRange : MonoBehaviour
{
    public Transform Object;

    void Start()
    {
        
    }

    public void ShortRange() // Pass the new x-coordinate as a parameter
    {
        Vector3 newPosition = new Vector3(10.0f, Object.position.y, Object.position.z);
        Object.position = newPosition;
    }

    public void MidRange() // Pass the new x-coordinate as a parameter
    {
        Vector3 newPosition = new Vector3(20.0f, Object.position.y, Object.position.z);
        Object.position = newPosition;
    }

    public void LongRange() // Pass the new x-coordinate as a parameter
    {
        Vector3 newPosition = new Vector3(30.0f, Object.position.y, Object.position.z);
        Object.position = newPosition;
    }
}
