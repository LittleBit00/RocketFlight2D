using UnityEngine;

public class Environment : MonoBehaviour
{
    private float environmentSpeed = 2f;
    private float yPosLimit = -12;

    private void Update()
    {
        EnvironmentMove();
        DeleteUnnecessary();
    }

    private void DeleteUnnecessary()
    {
        if (transform.position.y <= yPosLimit)
        {
            Destroy(gameObject);
        }
    }
    private void EnvironmentMove()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y - environmentSpeed * Time.deltaTime);
    }
    
    public void SetEnvSpeed(float speed)
    {
        environmentSpeed = speed;
    }
}

