using UnityEngine;

public class Orbit : MonoBehaviour
{
    public Transform center;
    public float orbitSpeed = 20f;
    public float spinSpeed = 50f;

    void Update()
    {
        // Move around the Sun.
        if (center != null)
        {
            transform.RotateAround(
                center.position,
                center.up,
                orbitSpeed * Time.deltaTime
            );
        }

        // Spin around the planet's own axis.
        transform.Rotate(
            0f,
            spinSpeed * Time.deltaTime,
            0f,
            Space.Self
        );
    }
}