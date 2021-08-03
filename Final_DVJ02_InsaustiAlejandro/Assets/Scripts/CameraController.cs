using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] Transform player;
    [SerializeField] Vector3 positionOffset;

    private void Start()
    {
        player.GetComponent<TankController>().tankMoved += FollowPlayer;
        FollowPlayer();
    }
    void FollowPlayer()
    {
        //Calculate the offset taking in account player's direction
        Vector3 xOffset = player.right * positionOffset.x;
        Vector3 yOffset = player.up * positionOffset.y;
        Vector3 zOffset = player.forward * positionOffset.z;

        Vector3 fixedOffset = xOffset + yOffset + zOffset; //Combine offsets

        //Apply to Transform
        transform.position = player.position - fixedOffset;
        transform.LookAt(player);
    }
}