﻿using System.Linq;
using Assets.GameJam.Scripts.Regular.General;
using UnityEngine;

namespace Assets.GameJam.Scripts.Regular.Controllers
{
    public class GameController : MyMonoBehaviour
    {
        public GameObject playerPrefab;
        #region Singleton
        private static GameController _instance;
        public static GameController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType(typeof(GameController)) as GameController;
                    if (_instance == null)
                        _instance = new GameObject("GameController Temporary Instance", typeof(GameController)).GetComponent<GameController>();
                }
                return _instance;
            }
        }

        void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }
        #endregion

        void OnServerInitialized()
        {
            SpawnPlayer();
        }

        void OnConnectedToServer()
        {
            SpawnPlayer();
        }

        private void SpawnPlayer()
        {
            Network.Instantiate(playerPrefab, new Vector3(0f, 2f, 0f), Quaternion.identity, 0);
        }

        public void Win()
        {
            
        }

        public void Lose()
        {
            
        }
    }
}
