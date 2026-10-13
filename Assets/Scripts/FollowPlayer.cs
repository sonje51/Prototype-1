using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //public variables
    public GameObject player;

    // private variables
    private Vector3 offset = new Vector3(0, 6, -7);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
