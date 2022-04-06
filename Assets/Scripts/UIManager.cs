using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GS.FloppyBirdFantasy2D
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance {get;private set;}
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
    }
}