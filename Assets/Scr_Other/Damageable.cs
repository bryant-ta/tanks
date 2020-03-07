using System.Collections;
using UnityEngine;

[System.Serializable]
public class Damageable : MonoBehaviour
{
    [SerializeField] int hp;        // Health
    [SerializeField] int maxhp;

    bool isDmgFlashing = false;
    SpriteRenderer sr;

    public void Setup(int initHp = 0)
    {
        sr = GetComponent<SpriteRenderer>();
        if (initHp > 0)
            hp = initHp;
    }

    // Return true on death, false otherwise
    public bool DoDamage(int amt)
    {
        if (!isDmgFlashing)
            StartCoroutine("FlashSprite");

        // Do damage, then check if death
        hp -= amt;
        if (hp <= 0)
        {
            Die();
            return true;
        }
        return false;
    }

    IEnumerator FlashSprite()
    {
        isDmgFlashing = true;
        float min = 0.6f;
        for (float ft = 1f; ft >= min; ft -= 0.05f)
        {
            Color c = sr.color;
            c.a = ft;
            sr.color = c;
            yield return null;
        }

        for (float ft = min; ft <= 1; ft += 0.05f)
        {
            Color c = sr.color;
            c.a = ft;
            sr.color = c;
            yield return null;
        }
        isDmgFlashing = false;
    }

    // Health Functions

    // Return false if HP after adding is greater than MaxHP
    public bool AddHP(int amt)
    {
        hp += amt;
        if (hp > maxhp)
        {
            hp = maxhp;
            return false;
        }
        return true;
    }

    public void AddMaxHP(int amt)
    {
        maxhp += amt;
        hp += amt;
    }

    // Sets HP = 0
    public void ResetHP()
    {
        hp = 0;
    }

    // Death Functions

    public void Die()
    {
        if (gameObject.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().GameOver();
        }

        //////  PROJECT: Poly_Survival  ///////
        if (gameObject.tag == "Barricade")
            return;
        ///////////////////////////////////////
        
        Destroy(gameObject);
    }

    public int getHP() { return hp; }
    public int getMaxHP() { return maxhp; }
}
