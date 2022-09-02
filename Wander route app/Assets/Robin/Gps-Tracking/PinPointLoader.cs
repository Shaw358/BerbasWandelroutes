using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PinPointLoader : MonoBehaviour
{
    [SerializeField] private int sceneNumb;
    [SerializeField] private string objectTag;
    private bool interactable;


    // Update is called once per frame
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == objectTag)
        {
            interactable = true;
        }
    }


    private void OnMouseEnter()
    {
        if (interactable)
        {
            SceneManager.LoadScene(sceneNumb);
        }
    }
}
