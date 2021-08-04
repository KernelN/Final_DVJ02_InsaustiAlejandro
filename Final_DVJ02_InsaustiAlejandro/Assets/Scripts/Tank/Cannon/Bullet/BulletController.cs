using UnityEngine;

public class BulletController : MonoBehaviour
{
    public BulletSO data;

    #region Unity Events
    private void Start()
    {
        //if there is a bullet model, change current mesh for data mesh
        if (data.model != null)
        {
            gameObject.GetComponent<MeshFilter>().mesh = data.model;
        }

        gameObject.AddComponent<MeshCollider>().convex = true;
        gameObject.GetComponent<Rigidbody>().mass *= data.gravityMod;
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (data.explosionRadius == 0)
        {
            IHittable collisionHit = collision.gameObject.GetComponent<IHittable>();
            if (collisionHit != null)
            {
                collisionHit.GetHitted();
            }
        }
        else
        {
            Explode();
        }
        Destroy(gameObject);
    }
    #endregion

    #region Methods
    void Move()
    {
        transform.Translate(Vector3.forward * data.speed);
    }
    void Explode()
    {
        RaycastHit[] hits = Physics.SphereCastAll(transform.position, data.explosionRadius, Vector3.zero, 0);
        foreach (RaycastHit hit in hits)
        {
            IHittable hitHittable = hit.transform.GetComponent<IHittable>();
            if (hitHittable != null)
            {
                hitHittable.GetHitted();
            }
        }
    }
    #endregion
}