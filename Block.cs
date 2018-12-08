using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    // Config params
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparkleVFX;
    [SerializeField] Sprite[] hitSprites;

    // cashed reference
    level level;
    GameSession gameSpeed;

    // State Variables
    [SerializeField] int timeHit; // Only for Debug purposes

    // Start game frame
    private void Start()
    {
        CountBreakableBlocks(); // initialate the blocks
    }

    // Count breakable Blocks
    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<level>();
        if (tag == "Breakable")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (tag == "Breakable")
        {
            timeHit++;
            int maxHits = hitSprites.Length + 1;
            if ( timeHit >= maxHits )
            {
                DestroyBlock();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
          
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timeHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void DestroyBlock()
    {
            PlayBlockDestorySFX();
            Destroy(gameObject);
            level.BlockDestroyed();
            TriggerSparkleVFX();      
    }

    private void PlayBlockDestorySFX()
    {
        FindObjectOfType<GameSession>().AddToScore();
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
    }

    private void TriggerSparkleVFX()
    {
        GameObject sparkles = Instantiate(blockSparkleVFX, transform.position, transform.rotation);
        Destroy(sparkles, 0.5f);
    }


}
