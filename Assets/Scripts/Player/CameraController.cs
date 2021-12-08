using UnityEngine;

public class CameraController : MonoBehaviour
{
    //Kamera Ruangan
    [SerializeField] private float speed;
    private float currentPostX;
    private Vector3 velocity = Vector3.zero;

    //Follow Player
    [SerializeField] private Transform player;
    [SerializeField] private float aheadDistance;
    [SerializeField] private float upDistance;
    [SerializeField] private float cameraSpeed;
    private float lookAhead;
    private float lookUp;

    private void Update()
    {
        //Kamera Ruangan
        ///transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPostX, transform.position.y, transform.position.z),ref velocity, speed );

        //Follow Player
        transform.position = new Vector3(player.position.x + lookAhead, player.position.y + lookUp, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), Time.deltaTime * cameraSpeed);
        lookUp = Mathf.Lerp(lookUp, (upDistance * player.localScale.y), Time.deltaTime * cameraSpeed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPostX = _newRoom.position.x;
    }
     
}
