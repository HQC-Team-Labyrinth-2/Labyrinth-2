namespace Labyrinth.ConsoleUI.Output
{
    using Labyrinth.Core.Common.Contracts;
    using Labyrinth.Core.Output.Contracts;
    using Labyrinth.Core.PlayField.Contracts;

    public class ConsoleRender : IRenderer
    {
        private IInfoRenderer infoPanel;
        private IPlayFieldRenderer playFieldPanel;
        private ILadderRenderer topScorePanel;

        public ConsoleRender(IInfoRenderer infoPanel, IPlayFieldRenderer playFieldPanel, ILadderRenderer topScorePanel)
        {
            this.infoPanel = infoPanel;
            this.playFieldPanel = playFieldPanel;
            this.topScorePanel = topScorePanel;
        }

        public void ShowInfoMessage(string message)
        {
            this.infoPanel.ShowInfo(message);
        }

        public void ShowScoreLadder(IScoreLadderContentProvider scoreProvider)
        {
            this.topScorePanel.ShowTopScores(scoreProvider);
        }

        public void ShowPlayField(IPlayField playField)
        {
            this.playFieldPanel.ShowPlayField(playField);
        }

        public void ClearPlayField()
        {
            this.playFieldPanel.ClearPlayField();
        }
    }
}
