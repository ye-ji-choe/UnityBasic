using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ex02 : MonoBehaviour
{

    public int quiz;
    public GameObject enterButton;
    public GameObject quizButton;

    public InputField input;
    public GameObject input2;
    public Text textUpDown;

    private void Start()
    {
        enterButton.SetActive(false);
        quizButton.SetActive(true);
        input2.SetActive(false);

    }

    public void EnterButton()
    {
        Debug.Log("Enter Button 누름");

        if (int.TryParse(input.text, out int result))
        {



                if (result > quiz)
                {
                    if (result > 1000)
                    {
                        textUpDown.text = "정해진 범위의 값이 아닙니다.";
                    }
                    else
                    {
                        textUpDown.text = "다운";
                    }
                }
                else if (result == quiz)
                {
                    textUpDown.text = "정답입니다";
                    quizButton.SetActive(true);
                    enterButton.SetActive(false);
                    input2.SetActive(false);
                    input.text = "";
                    return;
                }
                else
                {
                    textUpDown.text = "업";
                    
                }

        }

        


    }

   public void NewQuiz()
    {

        Debug.Log("Quiz Button 누름");
        int result = Random.Range(1, 1001);
        quiz = result;
        
        quizButton.SetActive(false);
        enterButton.SetActive(true);
        input2.SetActive(true);
        textUpDown.text = "";




    }

}
