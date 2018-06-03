using System;
using System.Collections.Generic;
using System.Linq;

namespace FellerProbability
{
    public interface ITextBox
    {
        event EventHandler<string> TextEntered;
    }
    public interface IListBox
    {
        IList<string> Options { get; set; }
        void ClearSelection();
        void Select(int optionIndex);
    }
    public class QuickEntryMediator
    {
        private readonly ITextBox _textBox;
        private readonly IListBox _listBox;

        public QuickEntryMediator(ITextBox textBox, IListBox listBox)
        {
            _textBox = textBox;
            _listBox = listBox;
            _textBox.TextEntered += OnTextEntered;
        }

        private void OnTextEntered(object sender, string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                _listBox.ClearSelection();
                return;
            }

            var optionIndex = _listBox.Options
                .Select((opt, idx) => new { Option = opt, Index = idx })
                .FirstOrDefault(item => item.Option.StartsWith(input))
                ?.Index;

            if (optionIndex.HasValue)
                _listBox.Select(optionIndex.Value);
            else
                _listBox.ClearSelection();
        }
    }
}
