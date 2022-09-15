using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SomMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] numbers;
    [SerializeField] private GameObject add;
    [SerializeField] private GameObject minus;
    [SerializeField] private GameObject wrong;
    [SerializeField] private TextMeshProUGUI answerfield;
    [SerializeField] private GameObject endScreen;

    [SerializeField] private TextMeshProUGUI answerButton_1;
    [SerializeField] private TextMeshProUGUI answerButton_2;
    [SerializeField] private TextMeshProUGUI answerButton_3;
    [SerializeField] private TextMeshProUGUI answerButton_4;

    private GameObject instaNumb1;
    private GameObject instaNumb2;
    private GameObject calculationclone;

    private bool firstnumbfilled;
    private bool additive;
    private int numb1;
    private int numb2;
    private int solution;
    private int usedNumb1;
    private int usedNumb2;
    private int firstButton;
    private int secondButton;

    // Start is called before the first frame update
    void Start()
    {
        SetNumbers();
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, 8))
        {
            //check if it's number 1 or 2 and show it in bottom images if collided.
            //zet dit script op camera of zet camera.main voor transform.position
        }
    }
    private bool Randombool()
    {
        if (Random.value >= .5f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    void SetNumbers()
    {
        // X -6 tot 6 meter    Y maximaal 4 meter hoog  Z zelfde als X 
        //Random.Range(-6, 6), Random.Range(0, 4), Random.Range(-6,6)
        usedNumb1 = Random.Range(0, numbers.Length);
        usedNumb2 = Random.Range(0, numbers.Length);

        instaNumb1 = Instantiate(numbers[usedNumb1], SetPosition(), transform.rotation);
        instaNumb2 = Instantiate(numbers[usedNumb2], SetPosition(), transform.rotation);
        numb1 = usedNumb1;
        numb2 = usedNumb2;
        FindSolution();
        FillAnswerButtons();
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
        if (!additive)
        {
            solution = numb1 - numb2;
            Debug.Log(solution + " = " + numb1 + " - " + numb2);
            calculationclone = Instantiate(minus, SetPosition(), transform.rotation);
        }
        else
        {
            //solution = numb1 + 1 + numb2 + 1;
            solution = numb1 + numb2;
            Debug.Log(solution + " = " + numb1 + " + " + numb2);
            calculationclone = Instantiate(add, SetPosition(), transform.rotation);
        }
    }
    public void CheckSolution(int button)
    {
        //check elke button voor de correcte antwoord
    }
    private void FillAnswerButtons()
    { 
        switch (Random.Range(1, 4))
        {
            //temp solution rework to negate double answers - foreach case
            case 1:
                answerButton_1.text = solution.ToString();
                answerButton_2.text = Random.Range(0, 18).ToString();
                answerButton_3.text = Random.Range(0, 18).ToString();
                answerButton_4.text = Random.Range(0, 18).ToString();
                if (answerButton_2 == answerButton_1 || answerButton_3 == answerButton_1 || answerButton_4 == answerButton_1)
                {
                    answerButton_1.text = Random.Range(0, 18).ToString();
                    answerButton_3.text = Random.Range(0, 18).ToString();
                    answerButton_4.text = Random.Range(0, 18).ToString();
                }
                break;
            case 2:
                answerButton_2.text = solution.ToString();
                answerButton_1.text = Random.Range(0, 18).ToString();
                answerButton_3.text = Random.Range(0, 18).ToString();
                answerButton_4.text = Random.Range(0, 18).ToString();
                if (answerButton_1 == answerButton_2 || answerButton_3 == answerButton_2 || answerButton_4 == answerButton_2)
                {
                    answerButton_1.text = Random.Range(0, 18).ToString();
                    answerButton_3.text = Random.Range(0, 18).ToString();
                    answerButton_4.text = Random.Range(0, 18).ToString();
                }
                break;
            case 3:
                answerButton_3.text = solution.ToString();
                answerButton_1.text = Random.Range(0, 18).ToString();
                answerButton_2.text = Random.Range(0, 18).ToString();
                answerButton_4.text = Random.Range(0, 18).ToString();
                if (answerButton_2 == answerButton_3 || answerButton_1 == answerButton_3 || answerButton_4 == answerButton_3)
                {
                    answerButton_1.text = Random.Range(0, 18).ToString();
                    answerButton_3.text = Random.Range(0, 18).ToString();
                    answerButton_4.text = Random.Range(0, 18).ToString();
                }
                break;
            case 4:
                answerButton_4.text = solution.ToString();
                answerButton_1.text = Random.Range(0, 18).ToString();
                answerButton_2.text = Random.Range(0, 18).ToString();
                answerButton_3.text = Random.Range(0, 18).ToString();
                if (answerButton_1 == answerButton_4 || answerButton_2 == answerButton_4 || answerButton_3 == answerButton_4)
                {
                    answerButton_1.text = Random.Range(0, 18).ToString();
                    answerButton_3.text = Random.Range(0, 18).ToString();
                    answerButton_4.text = Random.Range(0, 18).ToString();
                }
                break;
        }
    }


    public void BacktoMap()
    {
        SceneManager.LoadSceneAsync(0);
    }
    private void EndgameScreen()
    {
        Debug.Log("Reached End");
        endScreen.SetActive(true);

    }
}
