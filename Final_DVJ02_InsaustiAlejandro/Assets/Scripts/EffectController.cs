using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] float explosionDuration;

    private void Start()
    {
        Invoke("DestroyGameobject", explosionDuration);
    }
    void DestroyGameobject()
    {
        Destroy(gameObject);
    }
}