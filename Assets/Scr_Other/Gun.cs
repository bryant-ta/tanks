using UnityEngine;

// Note - all attack damage factor from gun
public class Gun : MonoBehaviour
{
    // Gun Attributes
    public int baseDmg = 1;
    public float baseCd = 1;                      // Lower is faster
    [Range(0, 100)] public float baseAcc = 100;    // 100=perfect accuracy

    public float bulletTrailLifetime = 0.8f;

    public LayerMask hitLayers;

    public GameObject bulletTrailObj;

    bool canFire = false;

    private void Awake()
    {
        
    }

    float nextFire = Constants.ACTIVATE_GUN_DELAY;
    private void Update()
    {
        // Check attack cooldown
        if (Time.time > nextFire)
        {
            canFire = true;
        }
    }

    public void Fire()
    {
        if (canFire)
        {
            // Simulate Gun accuracy
            float accRan = Random.Range(baseAcc - 100, 100 - baseAcc);
            Vector2 trajectory = transform.right + transform.up * accRan * 0.005f;

            // Shoot Gun
            RaycastHit2D hit = Physics2D.Raycast(transform.position, trajectory, 20, hitLayers);
            if (!hit)   // Didn't hit in range
            {
                // Set hit point to max range
                hit.point = transform.position + (Vector3)(trajectory * 20);
            }
            Debug.DrawLine(transform.position, hit.point, Color.red, 2);

            // Briefly instantiate line renderer as bullet trail
            GameObject inst_bulletTrailObj = Instantiate(bulletTrailObj, transform);
            LineRenderer bulletTrail = inst_bulletTrailObj.GetComponent<LineRenderer>();
            bulletTrail.SetPosition(0, transform.position);
            bulletTrail.SetPosition(1, hit.point);
            Destroy(inst_bulletTrailObj, bulletTrailLifetime);

            // Do Damage
            if (hit.collider && hit.collider.gameObject.GetComponent<Damageable>() != null)
            {
                Damageable hitDmgable = hit.collider.gameObject.GetComponent<Damageable>();
                hitDmgable.DoDamage(baseDmg);
            }

            // Reset attack cooldown
            nextFire = Time.time + baseCd;
            canFire = false;
        }
    }
}
