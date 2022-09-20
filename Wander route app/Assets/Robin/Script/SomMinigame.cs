using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SomMinigame : MonoBehaviour
{
    [SerializeField] private GameObject[] numbers;
    [SerializeField] private GameObject[] types;
    [SerializeField] private GameObject add;
    [SerializeField] private GameObject minus;
    [SerializeField] private AudioSource wrongSoundEffect;
    [SerializeField] private GameObject endScreen;

    [SerializeField] private Answer[] answerButtons;
    [SerializeField] TextMeshProUGUI answerfield;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInNumbers();
    }

    bool firstNumberHit;
    bool secondNumberHit;
    bool typeHit;

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
        {}

        if(hit.transform == null)
        {
            return;
        }

        if (hit.transform.tag == "number1")
        {
            firstNumberHit = true;
        }
        if (hit.transform.tag == "number2")
        {
            secondNumberHit = true;
        }
        if (hit.transform.tag == "type")
        {
            typeHit = true;
        }

        string toShow1 = "?";
        string toShow2 = "?";
        if (firstNumberHit)
        {
            toShow1 = firstNum.ToString();
        }
        if (secondNumberHit)
        {
            toShow2 = secondNum.ToString();
        }

        string type = "?";
        if (typeHit)
        {
            switch (somType)
            {
                case SomType.plus:
                    type = "+";
                    break;
                case SomType.minus:
                    type = "-";
                    break;
            }
        }
        answerfield.text = toShow1 + " " + type + " " + toShow2;
    }

    int firstNum;
    int secondNum;
    SomType somType;

    enum SomType
    {
        plus,
        minus
    }

    GameObject number1;
    GameObject number2;
    GameObject type;

    public void SpawnInNumbers()
    {
        Destroy(number1);
        Destroy(number2);
        Destroy(type);

        somType = (SomType)Random.Range(0, 1);

        switch (somType)
        {
            case SomType.plus:
                firstNum = Random.Range(0, 9);
                secondNum = Random.Range(0, 9);
                break;
            case SomType.minus:
                firstNum = Random.Range(6, 10);
                secondNum = Random.Range(1, 6);
                break;
            default:
                break;
        }

        number1 = Instantiate(numbers[firstNum]);
        number2 = Instantiate(numbers[secondNum]);
        type = Instantiate(types[(int)somType]);

        number1.transform.position = SetPosition();
        number2.transform.position = SetPosition();
        type.transform.position = SetPosition();

        number1.gameObject.tag = "number1";
        number2.gameObject.tag = "number2";
        type.gameObject.tag = "type";

        GenerateAnswers();
    }

    private void GenerateAnswers()
    {
        switch (somType)
        {
            case SomType.plus:

                int indexOfRightAnswerPlus = Random.Range(0, 3);
                for (int i = 0; i < 4; i++)
                {
                    if (i == indexOfRightAnswerPlus)
                    {
                        answerButtons[indexOfRightAnswerPlus].mesh.text = (firstNum + secondNum).ToString();
                        answerButtons[indexOfRightAnswerPlus].answer = (firstNum + secondNum);
                    }
                    else
                    {
                        int val1 = Random.Range(0, 9);
                        int val2 = Random.Range(0, 9);
                        while ((val1 + val2) == (firstNum + secondNum))
                        {
                            val2 = Random.Range(0, 9);
                        }
                        int newFakeNumber = val1 + val2;
                        answerButtons[i].mesh.text = newFakeNumber.ToString();
                        answerButtons[i].answer = newFakeNumber;
                    }
                }
                break;
            case SomType.minus:
                int indexOfRightAnswerMinus = Random.Range(0, 3);
                for (int i = 0; i < 4; i++)
                {
                    if (i == indexOfRightAnswerMinus)
                    {
                        answerButtons[indexOfRightAnswerMinus].mesh.text = (firstNum - secondNum).ToString();
                        answerButtons[indexOfRightAnswerMinus].answer = (firstNum - secondNum);
                    }
                    else
                    {
                        int val1 = Random.Range(6, 10);
                        int val2 = Random.Range(1, 6);
                        while ((val1 - val2) == (firstNum - secondNum))
                        {
                            val2 = Random.Range(0, 9);
                        }
                        int newFakeNumber = val1 + val2;
                        answerButtons[i].mesh.text = newFakeNumber.ToString();
                        answerButtons[i].answer = newFakeNumber;
                    }
                }
                break;
            default:
                break;
        }
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

    public void CheckSolution(int button)
    {
        switch (somType)
        {
            case SomType.plus:
                Debug.Log(answerButtons[button].answer + " " + (firstNum + secondNum));
                if (answerButtons[button].answer == (firstNum + secondNum))
                {
                    EndgameScreen();
                }
                else
                {
                    wrongSoundEffect.Play();
                    StartCoroutine(ResetMinigame());
                }
                break;
            case SomType.minus:
                if (answerButtons[button].answer == (firstNum - secondNum))
                {
                    EndgameScreen();
                }
                else
                {
                    wrongSoundEffect.Play();
                    StartCoroutine(ResetMinigame());
                }
                break;
        }
    }

    private IEnumerator ResetMinigame()
    {
        yield return new WaitForSeconds(1);
        SpawnInNumbers();
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
