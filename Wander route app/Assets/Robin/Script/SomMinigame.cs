using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class SomMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] numbers;
    [SerializeField] private GameObject multiply;
    [SerializeField] private GameObject add;
    [SerializeField] private GameObject wrong;
    [SerializeField] private TMP_InputField answerfield;

    private bool multiplied = false;
    
    private int numb1;
    private int numb2;
    private int solution;

    // Start is called before the first frame update
    void Start()
    {
        SetNumbers();
    }

    void SetNumbers()
    {
        // X -6 tot 6 meter    Y maximaal 4 meter hoog  Z zelfde als X 
        //Random.Range(-6, 6), Random.Range(0, 4), Random.Range(-6,6)
        int tempnumb1;
        int tempnumb2;
        tempnumb1 = Random.Range(0, numbers.Length);
        Instantiate(numbers[tempnumb1], new Vector3(Random.Range(-7, 7), Random.Range(0, 4), Random.Range(-7, 7)), transform.rotation);
        tempnumb2 = Random.Range(0, numbers.Length);
        Instantiate(numbers[tempnumb2], new Vector3(Random.Range(-7, 7), Random.Range(0, 4), Random.Range(-7, 7)), transform.rotation);
        numb1 = tempnumb1 + 1;
        numb2 = tempnumb2 + 1;
        FindSolution();
    }
    void FindSolution()
    {
        if (!multiplied)
        {
            solution = numb1 + numb2;
            Instantiate(add);
        }
        else
        {
            solution = numb1 * numb2;
            Instantiate(multiply);
        }
    }

    void CheckSolution()
    {
        //check answer
        print(int.Parse(answerfield.text));
        if (int.Parse(answerfield.text) == solution)
        {
            //Switch Scenes
            SceneManager.LoadScene("Map");
        }
        else
        {
            //red x over question
            Instantiate(wrong);
            SetNumbers();
            Destroy(wrong);
        }
    }

}
