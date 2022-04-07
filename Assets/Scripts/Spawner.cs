using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GS.FloppyBirdFantasy2D
{
    public class Spawner : MonoBehaviour
    {
        public static Spawner Instance {get;private set;}

        [SerializeField] private Transform topPillerSpawnPos;
        [SerializeField] private Transform bottomPillerSpawnPos;

        [Header("Piller Gap Offsets")]
        [SerializeField] private float minGapBetweenPillersOffsetInXPos = 2.2f;
        [SerializeField] private float maxGapBetweenPillersOffsetInXPos = 2.8f;
         [SerializeField] private float minPillerHeightOffset = 1f;
        [SerializeField] private float maxPillerHeightOffset = 1.35f;

        [Header("Piller Objects")]
        [SerializeField] private List<GameObject> TopSidePillers;
        [SerializeField] private List<GameObject> BottomSidePillers;

        private Transform[] spawnPoints;    // Start from Index : 1 [Index 0 is actually parent position] 

        private float lastSpawnPosX = 0, gapBetweenPillersOffsetInXPos;
        private int spawnIndex = 0;

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
            spawnPoints = GetComponentsInChildren<Transform>();
            gapBetweenPillersOffsetInXPos = UnityEngine.Random.Range(minGapBetweenPillersOffsetInXPos,maxGapBetweenPillersOffsetInXPos);
        }

        private void Update()
        {
            if(GameManager.Instance.IsPlaying)
            {
                if(transform.position.x - lastSpawnPosX > gapBetweenPillersOffsetInXPos)
                {
                    float pillerHeightY = UnityEngine.Random.Range(minPillerHeightOffset,maxPillerHeightOffset);
                    //Instantiate Piller
                    if(spawnIndex % 2 == 0) // Activate Top Side Piller
                    {
                        
                        int pillerIndex = (spawnIndex / 2) % TopSidePillers.Count;

                        TopSidePillers[pillerIndex].transform.position = new Vector3(transform.position.x, 
                        TopSidePillers[pillerIndex].transform.position.y);
                        TopSidePillers[pillerIndex].transform.localScale = new Vector3(1f,pillerHeightY);
                        TopSidePillers[pillerIndex].SetActive(true);
                        spawnIndex++;
                    }
                    else    // Activate Bottom Side Piller
                    {
                        int pillerIndex = (spawnIndex / 2) % BottomSidePillers.Count;
                        BottomSidePillers[pillerIndex].transform.position = new Vector3(transform.position.x, 
                        BottomSidePillers[pillerIndex].transform.position.y);
                        BottomSidePillers[pillerIndex].transform.localScale = new Vector3(1f,pillerHeightY);
                        BottomSidePillers[pillerIndex].SetActive(true);
                        spawnIndex++;
                    }


                    lastSpawnPosX = transform.position.x;
                    gapBetweenPillersOffsetInXPos = UnityEngine.Random.Range(minGapBetweenPillersOffsetInXPos,maxGapBetweenPillersOffsetInXPos); 
                }
            }
        }
    }
}