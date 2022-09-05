using UnityEngine;
using UnityEngine.Events;

public class Basket : MonoBehaviour
{
    [SerializeField] Transform[] fruitSpots = new Transform[5];
    [SerializeField] int fruitsCollected;
    [SerializeField] int fruitsToCollect;

    [SerializeField] AudioSource appleCaughtSoundEffect;
    [SerializeField] UnityEvent onApplesCollected;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Apple"))
        {
            Destroy(collision.gameObject.GetComponent<Rigidbody>());
            Destroy(collision.gameObject.GetComponent<SphereCollider>());
            appleCaughtSoundEffect.Play();

            collision.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
            collision.transform.parent = fruitSpots[fruitsCollected];
            collision.transform.localPosition = new Vector3(0,0,0);

            fruitsCollected++;
            if (fruitsCollected >= fruitsToCollect)
            {
                onApplesCollected?.Invoke();
                return;
            }
        }
    }
}