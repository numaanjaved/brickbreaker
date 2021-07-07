using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // config parameters 
    [SerializeField] AudioClip BreakSound;
    [SerializeField] GameObject BlockVFXeffect;
    [SerializeField] int maxHits;
    [SerializeField] Sprite[] hitBlocks;


    //Cached Memory
    Level level;
    GameSession Status;

    //state variables 
    [SerializeField] int timesHit; // only for Debug

    private void Start()
    {
        Status = FindObjectOfType<GameSession>();
        level = FindObjectOfType<Level>();
        level.CountBreakableBlocks();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (CompareTag("Breakable"))
        { 
            
            HandleHit(collision);

        }

    }

    private void HandleHit(Collision2D collision)
    {
        ++timesHit;
        if (timesHit >= maxHits)
        {
            DestroyBlock(collision);
            TriggerVFX();
        }
        else
        {
            DisplayHitBlocks();
        }
    }

    private void DisplayHitBlocks()
    {
        int hitBlockIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitBlocks[hitBlockIndex];
    }

    private void DestroyBlock(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(BreakSound, Camera.main.transform.position);
        Destroy(gameObject);
        level.BlockDestroyed();
        Status.AddToScore();
        Debug.Log(collision.gameObject.name);
    }
    private void TriggerVFX()
    {
        GameObject VFX = Instantiate(BlockVFXeffect, transform.position, transform.rotation);
        Destroy(VFX, 1f);
    }
}
