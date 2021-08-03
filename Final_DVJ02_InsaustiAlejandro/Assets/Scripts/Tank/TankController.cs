using UnityEngine;

public class TankController : MonoBehaviour
{
	internal TankData data;
	[SerializeField] float movementSpeed;
	[SerializeField] float rotationSpeed;
	[SerializeField] float headRotationSpeed;

    #region Unity Events
    private void FixedUpdate()
    {
        Move(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal"));
    }
    #endregion

    #region Methods
    internal void Move(float forwardMovement)
    {
		transform.Translate(Vector3.forward * forwardMovement * movementSpeed);
    }
	internal void Rotate(float horizontalMovement)
    {
		transform.Rotate(0, horizontalMovement * rotationSpeed, 0);
    }
	#endregion
}