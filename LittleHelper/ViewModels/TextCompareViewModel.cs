using LittleHelper.Bases;
using LittleHelper.Operations;
using System;
using System.Collections.ObjectModel;

namespace LittleHelper.ViewModels
{
    public class TextCompareViewModel : BindableBase
    {
        private string _currentText;
        private ObservableCollection<string> _textCollection;
        private TextCompareOperations _compareOperations;
        private bool? _isIdentical;

        public bool? IsIdentical
        {
            get { return _isIdentical; }
            set { SetProperty(ref _isIdentical, value); }
        }

        public ObservableCollection<string> TextCollection
        {
            get { return _textCollection; }
            set 
            { 
                SetProperty(ref _textCollection, value);
                RaiseCanExecuteChanged();  
            }
        }
        public string CurrentText
        {
            get { return _currentText; }
            set 
            { 
                SetProperty(ref _currentText, value);
                RaiseCanExecuteChanged();
            }
        }

        public TextCompareViewModel()
        {
            AddTextCommand = new RelayCommand(OnAddText, CanAddText);
            ClearCommand = new RelayCommand(OnClear, CanClear);
            CurrentText = string.Empty;
            TextCollection = new ObservableCollection<string>();
            _compareOperations = new TextCompareOperations();
        }
        public RelayCommand AddTextCommand { get; private set; }
        public RelayCommand ClearCommand { get; private set; }

        public event Action Done = delegate { };

        private void RaiseCanExecuteChanged()
        {
            AddTextCommand.RaiseCanExecuteChanged();
            ClearCommand.RaiseCanExecuteChanged();
        }

        public void OnAddText()
        {
            if (CurrentText == null)
                return;

            TextCollection.Add(CurrentText);
            CurrentText = string.Empty;
            if (TextCollection.Count == 2)
            {
                Compare();
            }
            Done();
        }

        public bool CanAddText()
        {
            return !string.IsNullOrEmpty(CurrentText);
        }

        public void OnClear()
        {
            TextCollection.Clear();
            CurrentText = string.Empty;
            IsIdentical = null;
            Done();
        }

        public bool CanClear()
        {
            return !string.IsNullOrEmpty(CurrentText) || TextCollection.Count > 0;
        }

        private void Compare()
        {
            IsIdentical = _compareOperations.CompareTexts(TextCollection);
            //merge text into one if identical
            if (IsIdentical == true)
                TextCollection.RemoveAt(0);
        }






    }
}
