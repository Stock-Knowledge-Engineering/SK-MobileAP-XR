using UnityEngine;
using TMPro;

public class Mode2_ImpluseMomentumQuestionManager : MonoBehaviour
{
    

    [Header("DETAILS UI")]
    public GameObject[] details;
    public bool _isChange;

    
    [Header("QUESTIONS")]
    public TMP_Dropdown dropdownMenu;
    public TextMeshProUGUI question;
    public int dropdownValue;




    private void Update()
    {
        dropdownValue =  dropdownMenu.value ;

        for (int i = 0; i <= details.Length-1; i++)
        {
            if (dropdownMenu.value == i)
            {
                details[i].SetActive(true);

            }
            else
            {
                details[i].SetActive(false);
            }

        }

    }
    public void HandleInputData(int value)
    {
        switch (value)
        {
            case 0:
                question.text = "A 0.400-kg ball hits a wall with an initial velocity of 30 m/s, to the left. It rebounds with a final speed of 20 m/s, to the right";
                break;
            case 1:
                question.text = "What is the initial momentum of the ball?";
                break;
            case 2:
                question.text = "What is the final momentum of the ball?";
                break;
            case 3:
                question.text = "What is the impulse imparted on the ball?";
                break;
            case 4:
                question.text = "If the ball stays in contact with the wall for 0.0080s, what is the average force experienced by the ball?";
                break;

            default:
                break;
        }
    }


    public void AnswerOne()
    { 
    
    }

    public void AnswerTwo()
    { 
    
    }

    public void AnswerThree()
    { 
    
    }

    public void AnswerFour()
    { 
    
    }




}
