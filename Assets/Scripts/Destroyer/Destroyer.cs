using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out PoolableObject poolableObject))
            poolableObject.OnReset();
    }
}
