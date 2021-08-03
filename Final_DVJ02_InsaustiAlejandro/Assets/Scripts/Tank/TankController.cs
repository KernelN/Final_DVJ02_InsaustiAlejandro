using System;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Action tankMoved;
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
        if (Mathf.Abs(forwardMovement) < 0.1f) { return; }
		transform.Translate(Vector3.forward * forwardMovement * movementSpeed);
        tankMoved?.Invoke();
    }
	internal void Rotate(float horizontalMovement)
    {
        if (Mathf.Abs(horizontalMovement) < 0.1f) { return; }
		transform.Rotate(0, horizontalMovement * rotationSpeed, 0);
        tankMoved?.Invoke();
    }
    #endregion
}