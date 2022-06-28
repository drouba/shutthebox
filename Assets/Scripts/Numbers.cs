using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Numbers : MonoBehaviour
{
    // variables for clicking 
    public bool selected = false;

    public SpriteRenderer nbrSprite;

    // info of this number
    public int num;

    // animation variables
    public Sprite up;
    public Sprite middle;
    public Sprite down;

    public BoxCollider2D collider;
    private Vector3 colliderMove = new Vector3(0, 1.0f, 0);

    // audio
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log(num + " = clicked");
        if(selected)
        {
            selected = false;
            //nbrSprite.color = unclicked;
            StartCoroutine("FlipUpAnim");
            GameManager.Instance.NumDeselect(num);
        }

        else
        {
            selected = true;
            //nbrSprite.color = clicked;
            StartCoroutine("FlipDownAnim");
            GameManager.Instance.NumSelect(num);
        }
    }

    public void Disable()
    {
        Debug.Log(num + "Disabled");
        GetComponent<Collider2D>().enabled = false;
    }

    public IEnumerator FlipDownAnim()
    {
        nbrSprite.sprite = middle;
        audioSource.time = 0.55f;
        audioSource.Play();
        yield return new WaitForSeconds(0.1f);
        nbrSprite.sprite = down;
        
        collider.transform.position -= colliderMove;
    }

    public IEnumerator FlipUpAnim()
    {
        nbrSprite.sprite = middle;
        audioSource.time = 0.55f;
        audioSource.Play();
        yield return new WaitForSeconds(0.1f);
        nbrSprite.sprite = up;
        
        collider.transform.position += colliderMove;
    }
}
