using System;
using UnityEngine.SceneManagement;

public static class GameState
{
    public static void UnpauseGame()
    {
        isPaused = false;
        timePaused = 0.0f;
    }

    public static void PauseGame(float currentTime)
    {
        if (isPaused)
            return; 

        isPaused = true;
        timePaused = currentTime;

        UpdateHighScoreIfAppropriate();
    }

    private static void UpdateHighScoreIfAppropriate()
    {
        var activeScene = SceneManager.GetActiveScene();

        var updateHighScore = false;

        switch (activeScene.name)
        {
            case "Endless":
                updateHighScore = true;
                break;
        }

        if (updateHighScore && (timePaused > highScore))
        {
            highScore = timePaused;
        }
    }

    public static float TimePaused()
    {
        return timePaused;
    }

    public static bool IsPaused()
    {
        return isPaused;
    }

    public static float HighScore()
    {
        return highScore;
    }

    private static float timePaused = 0.0f;
    private static bool isPaused = false;

    private static float highScore = 0.0f;
}
