using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private int bananasCollected = 0;
    [SerializeField] private AudioSource collectibleSound;
    [SerializeField] private Text bananaText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            bananasCollected++;
            collectibleSound.Play();
            bananaText.text = "Bananas: " + bananasCollected;
        }
    }
}
