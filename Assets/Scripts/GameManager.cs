using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GS.FloppyBirdFantasy2D
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get;private set;}

        public bool IsPlaying = true;

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

        public void Reset()
        {
            
        }

        
    }
}