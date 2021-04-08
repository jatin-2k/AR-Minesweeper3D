public enum BlockType
{
    Empty,
    Mine,
    Number
}

public static class GameSettings
{
    private static bool showMines = false;

    #region Properties
    public static bool ShowMines
    {
        get { return showMines; }
        set
        {
            showMines = value;
            if(showMines)
                UnityEngine.Object.FindObjectOfType<PlaySpaceGenerator>().minefield.ShowMines();
            else
                UnityEngine.Object.FindObjectOfType<PlaySpaceGenerator>().minefield.HideMines();
        }
    }
    #endregion
}