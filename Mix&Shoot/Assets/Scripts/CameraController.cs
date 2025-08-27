using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 defaultPos;
    [SerializeField] private float maxXOffset;
    [SerializeField] private float maxZOffset;
    [SerializeField] private Transform xLeftLimit;
    [SerializeField] private Transform xRightLimit;
    [SerializeField] private Transform zUpLimit;
    [SerializeField] private Transform zDownLimit;
    [SerializeField][Range(0.0f,1.0f)] private float lerpValue;


    // Start is called before the first frame update
    void Start()
    {
        defaultPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float xAverage = 0;
        float zAverage = 0;

        for (int i = 0; i < PlayerManager.Instance.PlayerList.Count; i++) 
        {
            xAverage += PlayerManager.Instance.PlayerList[i].transform.position.x;
            zAverage += PlayerManager.Instance.PlayerList[i].transform.position.z;
        }

        xAverage /= PlayerManager.Instance.PlayerList.Count;
        zAverage /= PlayerManager.Instance.PlayerList.Count;


        float xLerp = Mathf.InverseLerp(xLeftLimit.position.x, xRightLimit.position.x, xAverage);
        float zLerp = Mathf.InverseLerp(zDownLimit.position.z, zUpLimit.position.z, zAverage);

        transform.position = PlayerManager.Instance.PlayerList.Count <= 0 ? defaultPos : Vector3.Lerp(transform.position, defaultPos + new Vector3(Mathf.Lerp(-maxXOffset, maxXOffset, xLerp), 0, Mathf.Lerp(-maxZOffset, maxZOffset, zLerp)), lerpValue * Time.deltaTime);
    }
}
