using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public int diceRollCount = 0;
    public int finalSide = 0;

    // Array of dice sides sprites to load from Resources folder
    private Sprite[] diceSides;

    // Array of sounds
    public AudioSource audioSource;

    // Reference to sprite renderer to change sprites
    private SpriteRenderer rend;

    // Use this for initialization
    private void Start()
    {

        // Assign Renderer component
        rend = GetComponent<SpriteRenderer>();

        // Load dice sides sprites to array from DiceSides subfolder of Resources folder
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
    }

    private void Update()
    {
        if(diceRollCount == 1)
        {
            GameObject[] numbers = GameObject.FindGameObjectsWithTag("Number");

            foreach(GameObject num in numbers)
            {
                num.GetComponent<Collider2D>().enabled = true;
            }
        }
    }

    // If you left click over the dice then RollTheDice coroutine is started
    public void RollDice()
    {
        StartCoroutine("RollTheDice");
        diceRollCount++;
    }

    // Coroutine that rolls the dice
    private IEnumerator RollTheDice()
    {
        // Variable to contain random dice side number.
        // It needs to be assigned. Let it be 0 initially
        int randomDiceSide = 0;
        audioSource.time = 0.22f;
        audioSource.Play();

        // Loop to switch dice sides ramdomly
        // before final side appears. 20 itterations here.
        for (int i = 0; i <= 20; i++)
        {
            // Pick up random value from 0 to 5 (All inclusive)
            randomDiceSide = Random.Range(0, 6);

            // Set sprite to upper face of dice from array according to random value
            rend.sprite = diceSides[randomDiceSide];

            // Pause before next itteration
            yield return new WaitForSeconds(0.05f);
        }

        // Assigning final side so you can use this value later in your game
        // for player movement for example
        finalSide = randomDiceSide + 1;

        yield return new WaitForSeconds(0.01f);
        GameManager.Instance.CheckGameOver();
        GameManager.Instance.CheckWin();

        // Show final dice value in Console
        Debug.Log(finalSide);
    }
}
