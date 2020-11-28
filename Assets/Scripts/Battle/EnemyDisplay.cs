using System.Collections.Generic;

public class EnemyDisplay
{
    public readonly string DisplayContainerName;
    public readonly string[] ContainerNames;

    private static readonly List<EnemyDisplay> EnemyDisplays = new List<EnemyDisplay>()
    {
        new EnemyDisplay("OneEnemy", "FirstEnemy"),
        new EnemyDisplay("TwoEnemies", "FirstEnemy", "SecondEnemy"),
        new EnemyDisplay("ThreeEnemies", "FirstEnemy", "SecondEnemy", "ThirdEnemy")
    };

    private EnemyDisplay(string displayContainerName, params string[] containerNames)
    {
        DisplayContainerName = displayContainerName;
        ContainerNames = containerNames;
    }

    public static EnemyDisplay Get(int index)
    {
        return EnemyDisplays[index];
    }
}