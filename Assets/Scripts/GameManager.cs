using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GS.FloppyBirdFantasy2D
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get;private set;}
    
        [HideInInspector]public bool IsPlaying = true;
        [SerializeField] private Animator birdAnimator;
        public int CurrentlySelectedBirdIndex 
        {
            get 
            {
                return PlayerPrefs.GetInt("SelectedBirdIndex",1);
            }
            set
            {
                PlayerPrefs.SetInt("SelectedBirdIndex",value);
                if(birdAnimator != null) birdAnimator.Play("Bird 0" + value.ToString());
            }
        }
        private void Awake()
        {
            if(Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this);
            }
        }

        private void Start()
        {

        }

        public void Reset()
        {
            BackgroundLoop.Instance.Reset();
            BackgroundChanger.Instance.ChangeBackground();
        }

        
    }
}