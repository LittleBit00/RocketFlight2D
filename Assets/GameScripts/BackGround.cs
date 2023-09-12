using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField] private GameObject[] SpaceBG;
    private float spaceSpeed = 0.5f;

    private float upperSpacePosY = 20;
    private float lowerSpacePosY = -20;

    private void Update()
    {
        ChangingSpaceBG();
    }

    private void ChangingSpaceBG()
    {
        foreach (GameObject space in SpaceBG) 
        {
            if (space.transform.position.y <= lowerSpacePosY) { space.transform.position = new Vector3(0, upperSpacePosY, 0); }
            space.transform.position = new Vector3(0 , space.transform.position.y - spaceSpeed * Time.deltaTime);            
        }       
    }
}
