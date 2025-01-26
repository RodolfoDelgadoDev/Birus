using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class WormController : MonoBehaviour
{

    private Animator animator;

    [SerializeField] private GameObject gameManager;

    private GameManager gameManagerScript;

    private float smallBulletResistance = 4f, bigBulletResistance = 0.3f;
    private float HP = 1f;


    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }


    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Bullet")
        {
            float bulletDamage = collider.transform.localScale.x;
            if (collider.transform.localScale.x <= 1f)
            {
                bulletDamage /= smallBulletResistance;
            }
            else
            {
                bulletDamage -= bigBulletResistance;
            }
            getDamage(bulletDamage);
            Destroy(collider.gameObject);

        }
    }
       public void getDamage(float damage)
    {
        HP-=damage;
        Debug.Log(HP);
        if (HP <= 0)
        {
            source.Play();
            animator.Play("Worm_Death");
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            gameManagerScript.WormDead();
        }
    }
}
