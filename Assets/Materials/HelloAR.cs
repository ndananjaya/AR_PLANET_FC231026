using UnityEngine;
public class HelloAR : MonoBehaviour
{
    public float spinSpeed = 45f; // degrees per second
    void Update()
    {
        // spin slowly so we can see it is a real 3D object
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }
}