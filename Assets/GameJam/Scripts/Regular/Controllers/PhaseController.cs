﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.GameJam.Scripts.Regular.General;
using UnityEngine;

namespace Assets.GameJam.Scripts.Regular.Controllers
{
    public class PhaseController : MyMonoBehaviour
    {
        public int TotalRounds;
        public int TotalPhases;
        private int RoundNumber = 3;
        private int PhaseNumber = 3;
        public float RoundTime = 15f;

        void Start()
        {
            
        }

        IEnumerator StartTimer()
        {
            Debug.Log("Started Timer");
            yield return new WaitForSeconds(RoundTime);
            CycleRound();
        }

        public void CycleRound()
        {
            foreach (var player in StateController.Instance.PlayerStats)
            {
                IChoice[] choices = player.gameObject.GetComponents(typeof (IChoice)) as IChoice[];

                foreach (IChoice choice in choices.Where(i => i.DoExecute == true))
                {
                    choice.Execute();
                }
            }

            if (RoundNumber < TotalRounds)
            {
                RoundNumber++;
                //StateController New Round
            }
            else
            {
                RoundNumber = 0;
                CyclePhase();
                //StateController NewPhas
            }
        }

        public void CyclePhase()
        {
            foreach (var scenario in StateController.Instance.Scenarios)
            {
                scenario.Execute();
            }

            if (PhaseNumber < TotalPhases)
            {
                PhaseNumber++;
                //StateController InitiatePHase
            }
            else
            {
                //END GAME
            }
        }
    }
}
