﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestGiver : MonoBehaviour {

    public Quest quest;

    public QuestManager questManager;

    public GameObject questWindow;

    public int fameValue;

    public void Start()
    {
       fameValue = PlayerPrefs.GetInt("fame");
        Debug.Log("Fame Value: " + fameValue);
    }

    public TMP_Text questTitle;
    public TMP_Text questDescription;
    public TMP_Text fameReward;
    public TMP_Text goldReward;

    public int enterRequirement;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        questTitle.text = quest.questName;
        questDescription.text = quest.questDesc;
        fameReward.text = quest.fameReward.ToString();
        goldReward.text = quest.goldReward.ToString();

       

    }
       
    public void QuestAccepted()
    {
        
        enterRequirement = quest.enterRequirement;
        Debug.Log("Enter Requirement: " + enterRequirement);
        if (fameValue >= enterRequirement)
            
        {
            questWindow.SetActive(false);
            quest.progress = Quest.QuestProgress.ACCEPTED;
            SceneManager.LoadScene("PrepPhase");
            Debug.Log("Prepartion Phase Loaded");
        }

        else if (fameValue < enterRequirement)
        {
            Debug.Log("Not enough Fame");
        }

    }

    public void QuestDeclined()
    {
        questWindow.SetActive(false);
        quest.progress = Quest.QuestProgress.DECLINED;

    }
}
