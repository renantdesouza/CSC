public class GoToSequenceFromSaveChild : OptionExecutor
{
    private readonly TransitionService TransitionService = TransitionService.GetInstance();
    protected override void Execute()
    {
        TransitionService.Save(TransitionIndexes.SequenceFromSaveChild);
    }
}