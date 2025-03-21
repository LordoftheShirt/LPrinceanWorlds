using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    [SerializeField] private InputController input = null;
    [SerializeField] private TextMeshProUGUI numberDisplay;
    private string inputText;
    void Start()
    {
        inputText = string.Empty;
        MatchDisplay();
    }

    // Update is called once per frame
    void Update()
    {

        MatchDisplay();
    }

    public void MatchDisplay()
    {
        if (numberDisplay.text != inputText)
        {
            numberDisplay.text = inputText;
        }
    }

    private void PlayerInput()
    {
        if (input.RetrieveNum0Input()) inputText += 0;
        if (input.RetrieveNum1Input()) inputText += 1;
        if (input.RetrieveNum2Input()) inputText += 2;
        if (input.RetrieveNum3Input()) inputText += 3;
        if (input.RetrieveNum4Input()) inputText += 4;
        if (input.RetrieveNum5Input()) inputText += 5;
        if (input.RetrieveNum6Input()) inputText += 6;
        if (input.RetrieveNum7Input()) inputText += 7;
        if (input.RetrieveNum8Input()) inputText += 8;
        if (input.RetrieveNum9Input()) inputText += 9;
    }
}
