using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;


public class ActivateGooServices : MonoBehaviour {
    
    private Data data;
    void Start () {
        data = GameObject.Find("Data").GetComponent<Data>();
        if (data == null) {
            Debug.Log("Nu a gasit data");
        }

        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
        
        Social.localUser.Authenticate((bool success) => {
            if (success) {
                data.loggedInGPG = true;
            } else {
                data.loggedInGPG = false;
            }
        });
    }


    static public void UnlockAchievement(string ach) {
        Social.ReportProgress(ach, 100.0f, (bool success) => {
            // handle success or failure
            if (success) {
              Debug.Log("succes!");
            } else {
              Debug.Log("failed!");
            }
         });
    }

    static public void IncrementAchievement(string ach, int points) {
        PlayGamesPlatform.Instance.IncrementAchievement(ach, points, (bool success) => {
            // handle success or failure
            if (success) {
                Debug.Log("succes!");
            } else {
                Debug.Log("failed!");
            }
        });
    }
	
    public void PostScore() {
        Social.ReportScore(data.scoreToPost, GPGSIDs.leaderboard_main_leaderboard, (bool success) => {
            if (success) {
                ShowLeaderboardUI();
            }
        });
    }
	
    public void ShowAchievementUI() {
        if (!data.loggedInGPG) {
            Social.localUser.Authenticate((bool success) => {
                if (success) {
                    data.loggedInGPG = true;
                } else {
                    data.loggedInGPG = false;
                }
            });
        }
        if (data.loggedInGPG) {
            Social.ShowAchievementsUI();
        }
    }

    public void ShowLeaderboardUI() {
        if (!data.loggedInGPG) {
            Social.localUser.Authenticate((bool success) => {
                if (success) {
                    data.loggedInGPG = true;
                } else {
                    data.loggedInGPG = false;
                }
            });
        }
        if (data.loggedInGPG) {
            Social.ShowLeaderboardUI();
        }
    }
}
