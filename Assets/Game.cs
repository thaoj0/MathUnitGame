using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject topView;
    public GameObject bottomView;
    public GameObject operationView;
    public GameObject answerView;
    public GameObject scoreView;
    public GameObject correctPanel;
    public GameObject digits;

    private int score = 0;
    private int topNumber = 0;
    private int bottomNumber = 0;
    private string operationString = "+";
    private int answerNumber = 0;
    private bool correctPanelActive = false;

    void Start()
    {
        Debug.Log("Game Launched...");
        generateProblem();
    }

    public void onClicked(int send)
    {
        if(!correctPanelActive)
        {
            answerNumber += send;
            gameUpdate();
        }
    }

    public void gameUpdate()
    {
        updateViews();
        updateScore();
    }

    private void updateViews()
    {
        topView.GetComponent<Text>().text = ""+ topNumber;
        bottomView.GetComponent<Text>().text = ""+ bottomNumber;
        operationView.GetComponent<Text>().text = operationString;
        answerView.GetComponent<Text>().text = ""+ answerNumber;
    }

    private void updateScore()
    {
        if ((operationString.Equals("+") && topNumber + bottomNumber == answerNumber) ||
            (operationString.Equals("-") && topNumber - bottomNumber == answerNumber))
        {
            score += 1;
            enableCorrectPanel();
        }
        scoreView.GetComponent<Text>().text = "Score: " + score;
    }

    public void generateProblem()
    {
        string value = (digits.GetComponent<Dropdown>().options)[digits.GetComponent<Dropdown>().value].text;
        int digitNumber = 0;
        if (value.Equals("Single"))
        {
            digitNumber = 10;
        }else if (value.Equals("Double"))
        {
            digitNumber = 100;
        }
        else if (value.Equals("Triple"))
        {
            digitNumber = 1000;
        }
        disableCorrectPanel();
        topNumber = (int) (Random.value * digitNumber);
        bottomNumber = (int) (Random.value * digitNumber);
        operationString = Random.value > 0.5 ? "+" : "-";
        answerNumber = 0;
        disableRandomButtons();
        updateViews();
    }

    private void disableRandomButtons()
    {
        // Unsolvable if -1 and +1 are disabled
        // first != second
        int first = Random.Range(1, 7);
        int secondMin = first == 4 ? 1 : 0;
        int second = Random.Range(secondMin, 7);
        while(first == second)
        {
            second = Random.Range(secondMin, 7);
        }
        enableButtons();
        buttons[first].SetActive(false);
        buttons[second].SetActive(false);
    }

    private void enableButtons()
    {
        foreach( GameObject i in buttons)
        {
            i.SetActive(true);
        }
    }

    private void enableCorrectPanel()
    {
        correctPanel.SetActive(true);
        correctPanelActive = true;
    }

    private void disableCorrectPanel()
    {
        correctPanel.SetActive(false);
        correctPanelActive = false;
    }

    public void gameMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
