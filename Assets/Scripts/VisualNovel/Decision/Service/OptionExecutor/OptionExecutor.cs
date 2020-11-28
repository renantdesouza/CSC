using System.Collections.Generic;

public abstract class OptionExecutor
{
    protected abstract void Execute();

    private static readonly Dictionary<string, OptionExecutor> Dictionary = new Dictionary<string, OptionExecutor>
    {
        {DecisionType.GoToObserveChoice, new GoToObserveChoice()},
        {DecisionType.GoToAskArlene, new GoToAskArlene()},
        {DecisionType.GoToReproach, new GoToReproach()},
        {DecisionType.GoToVillage, new GoToVillage()},
        {DecisionType.GoToSaveBoth, new GoToSaveBoth()},
        {DecisionType.GoToSaveChild, new GoToSaveChild()},
        {DecisionType.GoToYouAreRight, new GoToYouAreRight()},
        {DecisionType.GoToItIsNotMyProblem, new GoToIsNotMyProblem()},
        {DecisionType.GoToPicNic, new GoToPicNic()},
        {DecisionType.GoToTheDeathOfLana, new GoToTheDeathOfLana()},
        {DecisionType.GoToWhatHappened, new GoToWhatHappened()},
        {DecisionType.GoToYesItWouldHaveBeen, new GoToYesItWouldHaveBeen()},
        {DecisionType.GoToDoNotWorry, new GoToDoNotWorry()},
        {DecisionType.GoToMaluExplanation, new GoToMaluExplanation()},
        {DecisionType.GoToFool, new GoToFool()},
        {DecisionType.GoToBrayanExplanation, new GoToBrayanExplanation()},
        {DecisionType.GoToSorry, new GoToSorry()},
        {DecisionType.GoToIsNecessary, new GoToIsNecessary()},
        {DecisionType.GoToAppendix, new GoToAppendix()},
        {DecisionType.GoToNarrations, new GoToNarrations()},
        {DecisionType.GoToSequenceFromSaveChild, new GoToSequenceFromSaveChild()},
        {DecisionType.GoToArriveAtTheVillage, new GoToArriveAtTheVillage()},
        {DecisionType.GoToGameOver, new GoToGameOver()},
        {DecisionType.GoToThereIsNothingYouCanDo, new GoToThereIsNothingYouCanDo()},
        {DecisionType.GoToDamnIt, new GoToDamnIt()},
        {DecisionType.GoToVillageMenu, new GoToVillageMenu()}
    };

    public static void Execute(string action)
    {
        Dictionary[action].Execute();
    }
}
