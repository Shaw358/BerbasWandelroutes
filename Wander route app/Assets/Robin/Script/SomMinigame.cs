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

    [SerializeField] private TextMeshProUGUI[] answerButtons;

    private GameObject instaNumb1;
    private GameObject instaNumb2;
    private GameObject calculationclone;

    private bool additive;
    private int solutionButtonNumb;
    private int numb1;
    private int numb2;
    private int[] fakeAnswerValue;
    private int solution;
    private int usedNumb1;
    private int usedNumb2;

    // Start is called before the first frame update
    void Start()
    {
        Randombool();
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
    private void Randombool()
    {
        if (Random.value >= .5f)
        {
            additive = true;
        }
        else
        {
            additive = false;
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
        if (button == solutionButtonNumb)
        {

        }
        else
        {
            Instantiate(wrong);
            Destroy(instaNumb1);
            Destroy(instaNumb2);
            Destroy(wrong);
            Randombool();
            SetNumbers();
        }
    }

    private void FillAnswerButtons()
    {
        int answerSlot = Random.Range(1, 4);
        solutionButtonNumb = answerSlot;
        for (int i = 0; i < 4; i++)
        {
            if (i == answerSlot)
            {
                answerButtons[i].text = solution.ToString();
            }
            else
            {
                fakeAnswerValue[i] = Random.Range(0, 18);
                if (fakeAnswerValue[i] == solution)
                {
                    fakeAnswerValue[i] = Random.Range(0, 18);
                }
            }
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
