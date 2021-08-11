using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float degreesPerSecond = 45.0f;

    void Update()
    {
        transform.Rotate(new Vector3(degreesPerSecond, 0, 0) * Time.deltaTime);
    }
}
