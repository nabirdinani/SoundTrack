using UnityEngine;
using System.Collections;

public class CollectibleScript : MonoBehaviour {

    public GameObject camera;

    public RuntimeAnimatorController[] collectibleAnimators;

    void Start()
    {
        int random = Random.Range(0, 3);

        if (random == 0)
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = collectibleAnimators[0];
        }
        else if (random == 1)
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = collectibleAnimators[1];
        }
        if (random == 2)
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = collectibleAnimators[2];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            camera.GetComponent<HoleMovement>().addScore(50f);
            Destroy(gameObject);
        }
    }
}
