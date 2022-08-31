using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] numbers;
    private bool multiplied;
    
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
        }
        else
        {
            solution = numb1 * numb2;
        }
    }

}
