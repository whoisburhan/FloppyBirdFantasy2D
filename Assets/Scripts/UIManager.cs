using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GS.FloppyBirdFantasy2D
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance {get;private set;}

        [Header("Canvas Groups")]
        [SerializeField] private CanvasGroup selectBirdMenuCanvasGroup;

        [Header("Animators")]
        [SerializeField] private Animator BirdUISelectAnimator;

        [Header("Buttons")]
        [SerializeField] private Button leftArrowButton;
        [SerializeField] private Button rightArrowButton;
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
            ButtonInit();
        }
        
        private void ButtonInit()
        {
            leftArrowButton.onClick.AddListener(()=>{ LeftArrowButtonFunc();});
            rightArrowButton.onClick.AddListener(()=>{RightArrowButtonFunc();});
        }

    #region Select Bird
        public void ActivateSelectBirdMenu()
        {
            selectBirdMenuCanvasGroup.alpha = 1f;
            selectBirdMenuCanvasGroup.blocksRaycasts = true;
            selectBirdMenuCanvasGroup.interactable = true;

            BirdUISelectAnimator.Play("BirdUI 0" + GameManager.Instance.CurrentlySelectedBirdIndex.ToString());
        }

        public void DeActivateSelectBirdMenu()
        {
            selectBirdMenuCanvasGroup.alpha = 0f;
            selectBirdMenuCanvasGroup.blocksRaycasts = false;
            selectBirdMenuCanvasGroup.interactable = false;
        }

        public void LeftArrowButtonFunc()
        {
            if(GameManager.Instance.CurrentlySelectedBirdIndex <= 1)
            {
                GameManager.Instance.CurrentlySelectedBirdIndex = 9;
            }
            else
            {
                GameManager.Instance.CurrentlySelectedBirdIndex--;
            }
            BirdUISelectAnimator.Play("BirdUI 0" + GameManager.Instance.CurrentlySelectedBirdIndex.ToString());
        }

        public void RightArrowButtonFunc()
        {
            if(GameManager.Instance.CurrentlySelectedBirdIndex >= 9)
            {
                GameManager.Instance.CurrentlySelectedBirdIndex = 0;
            }
            else
            {
                GameManager.Instance.CurrentlySelectedBirdIndex++;
            }
            BirdUISelectAnimator.Play("BirdUI 0" + GameManager.Instance.CurrentlySelectedBirdIndex.ToString());
        }
    #endregion
    }
}