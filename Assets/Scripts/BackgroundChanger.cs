using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GS.FloppyBirdFantasy2D
{
    public class BackgroundChanger : MonoBehaviour
    {
        public static BackgroundChanger Instance { get; private set; }

        [SerializeField] private SpriteRenderer[] bg;
        [SerializeField] private List<Sprite> backgroundSprites;

        private int lastBackgrounndIndex = -1;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {
           
        }

        public void SetBackgroundChilds()
        {
            bg = GetComponentsInChildren<SpriteRenderer>();
            ChangeBackground();
        }

        public void ChangeBackground()
        {
            if (backgroundSprites.Count > 0)
            {
                int backgroundIndex = UnityEngine.Random.Range(0, backgroundSprites.Count);
                while (backgroundIndex == lastBackgrounndIndex)
                {
                    backgroundIndex = UnityEngine.Random.Range(0, backgroundSprites.Count);
                }

                for (int i = 1; i <bg.Length; i++) // Index - 0 For Parents
                {
                    bg[i].sprite = backgroundSprites[backgroundIndex];
                }
            }
        }

    }
}