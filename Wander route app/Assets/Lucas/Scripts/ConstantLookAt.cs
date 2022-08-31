using UnityEngine;

public class ConstantLookAt : MonoBehaviour
{
    void Update()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
    }
}