using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GS.FloppyBirdFantasy2D
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get;private set;}
    
        [HideInInspector] public bool IsPlaying = true;
        [SerializeField] private Animator birdAnimator;

        [SerializeField] private GameObject bird;
        [SerializeField] private GameObject deathEffect;

        [SerializeField] private float scoreOffset = 1f;

        private int score;
        private float floatScore;
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

        public int BestScore
        {
            get
            {
                return PlayerPrefs.GetInt("BestScore", 0);
            }
            set
            {
                PlayerPrefs.SetInt("BestScore",value);
            }
        }

        public int LastScore
        {
            get
            {
                return PlayerPrefs.GetInt("LastScore",0);
            }
            set
            {
                PlayerPrefs.SetInt("LastScore",value);
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
            score = LastScore;
            Reset();
        }

        private void Update()
        {
            AddScore();
        }
        public void Reset()
        {
            bird.SetActive(false);
            LastScore = score;
            BestScore = score > BestScore ? score : BestScore;
            score = 0;
            floatScore = 0f;
            IsPlaying = false;
            BackgroundLoop.Instance.Reset();
            BackgroundChanger.Instance.ChangeBackground();
            UIManager.Instance.UpdateBestScoreText(BestScore);
            UIManager.Instance.UpdateLastScoreText(LastScore);
            UIManager.Instance.Reset();
        }

        public void Play()
        {
            bird.transform.localPosition = new Vector3(0f,0f,10f);
            bird.SetActive(true);
            deathEffect.SetActive(false);
            IsPlaying = true;
            CurrentlySelectedBirdIndex = CurrentlySelectedBirdIndex;
        }

        private void AddScore()
        {
            floatScore += Time.deltaTime * BackgroundLoop.Instance.scrollSpeed * scoreOffset;
            score = (int) floatScore;
            UIManager.Instance.UpdateGameScoreText(score);
        }

        public void ActiavteDeathEffect()
        {
            deathEffect.transform.position = new Vector3(bird.transform.position.x,bird.transform.position.y,bird.transform.position.z);
            deathEffect.SetActive(true);
        }
        
    }
}