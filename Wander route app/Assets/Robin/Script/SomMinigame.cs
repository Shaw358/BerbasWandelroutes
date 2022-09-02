using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        SetNumbers();
    }

    void SetNumbers()
    {
        // X -6 tot 6 meter    Y maximaal 4 meter hoog  Z zelfde als X 
        //Random.Range(-6, 6), Random.Range(0, 4), Random.Range(-6,6)
        int tempnumb1;
        int tempnumb2;
        tempnumb1 = Random.Range(0, numbers.Length);
        Instantiate(numbers[tempnumb1], SetPosition(), transform.rotation);
        tempnumb2 = Random.Range(0, numbers.Length);
        Instantiate(numbers[tempnumb2], SetPosition(), transform.rotation);
        numb1 = tempnumb1 + 1;
        numb2 = tempnumb2 + 1;
        FindSolution();
    }
    Vector3 SetPosition()
    {
        int coordx = Random.Range(-7, 7);
        int coordy = Random.Range(0, 4);
        int coordz = Random.Range(-7, 7);
        if (coordx >= -1 && coordx <= 1)
        {
            coordx = Random.Range(-7, 7);
        }
        if (coordz >= -1 && coordz <= 1)
        {
            coordz = Random.Range(-7, 7);
        }
        return new Vector3(coordx, coordy, coordz);
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

    public void CheckSolution(int button)
    {
        //answers are pressed on from the UI, in cases where answers could be 10 and up, 2 buttons should be able to be pressed
        //check answer
        //for button control seperate the 2 digits if the solution is bigger than 9
        if (solution >= 10)
        {
            int solutionTen = solution / 10;
            int solutionSingle = solution % 10;
            int firstButton = 0;
            int secondButton = 0;
            if (firstButton != 0)
            {
                secondButton = button;
            }
            else
            {
                firstButton = button;
            }
            answerfield.text += firstButton;
            answerfield.text += secondButton;
            if (firstButton == solutionTen)
            {
                if (secondButton == solutionSingle)
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
        else
        {
            answerfield.text += button;
            if (solution == button)
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
}
