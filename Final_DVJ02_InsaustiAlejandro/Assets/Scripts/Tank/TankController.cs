using System;
using System.Collections;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public Action tankMoved;
    [SerializeField] internal TankData data;
    [SerializeField] Transform head;
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float headRotationSpeed;
    float headRotationTimer = 0;
    RaycastHit cannonTargetHit;

    #region Unity Events
    private void FixedUpdate()
    {
        Move(Input.GetAxis("Vertical"));
        Rotate(Input.GetAxis("Horizontal"));
        if (Input.GetMouseButton(0))
        {
            headRotationTimer = 0;
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out cannonTargetHit);
        }
        else if (headRotationTimer <= headRotationSpeed)
        {
            Shoot(cannonTargetHit.point);
        }
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
    internal void Shoot(Vector3 shootPosition)
    {
        //if rotation almost over, shoot in direction
        if (headRotationTimer / headRotationSpeed > 0.5f)
        {
            data.cannon.Shoot(shootPosition - head.position);
        }

        //Rotate Head in direction
        shootPosition = new Vector3(shootPosition.x, head.position.y, shootPosition.z);
        Vector3 shootDirection = shootPosition - head.position;
        Quaternion toRotation = Quaternion.LookRotation(shootDirection, head.up);
        headRotationTimer += Time.deltaTime;
        head.rotation = Quaternion.Lerp(head.rotation, toRotation, headRotationTimer / headRotationSpeed);       
    }
    #endregion
}