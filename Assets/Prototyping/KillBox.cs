using UnityEngine;

// Destroy every object in area by tag
public class KillBox : MonoBehaviour
{
    public string tagToDestroy = "Enemy";

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == tagToDestroy)
        {
            Destroy(col.gameObject);
        }
    }
}