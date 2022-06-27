using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager Instance { get; private set; }

    // numbers variable
    public Numbers[] numbers;
    public int selectionSum;
    private int[] availableNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9};

    // dice variables
    public int sumDice = 0;
    public Dice dice1, dice2;

    public Button rollDiceButton;

    public bool canRoll = true;

    // game over variable
    public bool gameOver = false;

    //UI Button Variables
    public GameObject mainMenu;


    // Start is called before the first frame update
    void Awake()
    {
       if( Instance != null && Instance !=this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        CalculateSumDice();

        if (selectionSum != sumDice) { canRoll = false; }
        else { canRoll = true; }

        if (canRoll)
        {
            rollDiceButton.interactable = true;
        }
        else { rollDiceButton.interactable = false; }
    }

    public void CheckGameOver()
    {
        if (!isAvailable(sumDice, 9, availableNumbers)) gameOver = true;
        if (gameOver) mainMenu.SetActive(true);
    }

    public void NumSelect(int num)
    {
        selectionSum += num;
        availableNumbers[num - 1] = 0;
    }
    public void NumDeselect(int num)
    {
        selectionSum -= num;
        availableNumbers[num - 1] = num;
    }

    public void resetNumSelect()
    {
        selectionSum = 0;
    }

    public void ResetSumDice()
    {
        sumDice = 0;
    }

    public void CalculateSumDice()
    {
        sumDice = dice1.finalSide + dice2.finalSide;
    }

    public void DisableSelectedNum()
    {
        Debug.Log("Disabling called");

        foreach(Numbers num in numbers )
        {
            Debug.Log("In forLoop for num " + num.num );
            if(num.selected) { num.Disable(); }
        }
    }

    public bool isAvailable(int sum , int n, int[] availableNumbers)
    {
        // base cases
        if (sum == 0) return true;
        if (n == 0) return false;

        if (availableNumbers[n - 1] > sum)
            return isAvailable(sum, n - 1, availableNumbers);

        return isAvailable(sum, n - 1, availableNumbers) || isAvailable(sum - availableNumbers[n - 1],  n - 1, availableNumbers);
    }
 

}
