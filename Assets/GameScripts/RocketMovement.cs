using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    private float turnSpeed = 2.5f;
    private float turnSpeedBoost;
    private bool turningRight = false;
    private bool turningLeft = false;    

    private float rocketPosY = -3;
    private float minPosX = -2.5f;
    private float maxPosX = 2.5f;

    private void Start()
    {
        turnSpeedBoost = PlayerPrefs.GetFloat("TurnSpeedBoost", 1f);
    }

    private void Update()
    {
        CheckRocketBounds();
        MoveControl();
    }

    private void CheckRocketBounds()
    {
        if (transform.position.x <= minPosX) { transform.position = new Vector3(minPosX, rocketPosY); }

        if (transform.position.x >= maxPosX) { transform.position = new Vector3(maxPosX, rocketPosY); }
    }
    private void MoveControl()
    {
        if (turningRight) { transform.position = new Vector3(transform.position.x + turnSpeed * turnSpeedBoost * Time.deltaTime, rocketPosY); }
        else if (turningLeft) { transform.position = new Vector3(transform.position.x - turnSpeed * turnSpeedBoost * Time.deltaTime, rocketPosY); }
    }
    
    public void OnDownRightButton() { turningRight = true; }
    public void OnDownLeftButton() { turningLeft = true; }
    public void OnUpRightButton() { turningRight = false; }
    public void OnUpLeftButton() { turningLeft = false; }

}
