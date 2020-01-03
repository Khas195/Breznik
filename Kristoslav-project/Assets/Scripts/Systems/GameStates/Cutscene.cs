public class Cutscene : GameState
{
    public override void OnPopped()
    {
        base.OnPopped();
    }

    public override void OnPressed()
    {
        base.OnPressed();
    }

    public override void OnPushed()
    {
        base.OnPushed();
        CutsceneSystem.GetInstance().PlayNext();
    }

    public override void OnReturnPeek()
    {
        base.OnReturnPeek();
    }
}
