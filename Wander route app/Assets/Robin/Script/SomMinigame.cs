using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SomMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] numbers;
    [SerializeField] private GameObject multiply;
    [SerializeField] private GameObject add;
    [SerializeField] private GameObject wrong;
    [SerializeField] private TextMeshProUGUI answerfield;

    private bool multiplied = false;
    
    private int numb1;
    private int numb2;
    private int solution;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetNumbers()
    {
        int tempnumb1;
        int tempnumb2;
        tempnumb1 = Random.Range(0, numbers.Length);
        Instantiate(numbers[tempnumb1]);
        tempnumb2 = Random.Range(0, numbers.Length);
        Instantiate(numbers[tempnumb2]);
        numb1 = tempnumb1 + 1;
        numb2 = tempnumb2 + 1;
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
        print(int.Parse(answerfield.text));
        if (int.Parse(answerfield.text) == solution)
        {
            //close minigame and give letter
        }
        else
        {
            //red x over question
            Instantiate(wrong);
            answerfield.text = "";

        }
    }

}
