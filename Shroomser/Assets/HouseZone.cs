using UnityEngine;

public class HouseZone : MonoBehaviour
{
    Camera mainCamera;
    public Transform CameraStartPos;
    public Transform CameraFocusPos;
    bool focus;

    public float speed;
    float t = 0;
    void Start()
    {
        focus = false;
        mainCamera = Camera.main;

    }

    private void Update()
    {
        if (focus && t < 1)
        {
            t += Time.deltaTime * speed;
            mainCamera.transform.position = Vector3.Lerp(CameraStartPos.position, CameraFocusPos.position, t);
        }

        if (!focus && t >= 0)
        {
            t -= Time.deltaTime * speed;
            mainCamera.transform.position = Vector3.Lerp(CameraStartPos.position, CameraFocusPos.position, t);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            focus = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            focus = false;

        }
    }

}
