﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "MASTER_VOLUME";
    const string DIFFICULTY_KEY = "DIFFICULTY";
    const string LEVEL_KEY = "LEVEL_UNLOCKED_";
    const string PLAYER_NAME_KEY = "PLAYER_NAME";

    public static void SetMasterVolume (float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range!");
        } 
    }

    public static float GetMasterVolume ()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY, .5f);
    }

    public static void UnlockLevel (int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order!");
        }
    }

    public static bool IsLevelUnlocked (int level)
    {
        if (level <= Application.levelCount - 1)
        {
            return PlayerPrefs.GetInt(LEVEL_KEY + level.ToString(), 0) == 1;
        }
        else
        {
            Debug.LogError("Trying to check level not in build order!");
            return false;
        }
    }

    public static void SetDifficulty (float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range!");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY, 2f);
    }
}