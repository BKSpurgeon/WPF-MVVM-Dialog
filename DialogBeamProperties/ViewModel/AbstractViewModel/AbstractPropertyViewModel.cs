using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace DialogBeamProperties.ViewModel.AbstractViewModel
{
    public abstract class AbstractPropertyViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Fields

        protected const string ErrorProfileMessage = "Please enter valid profile.";
        protected const string ErrorAttributeClassMessage = "Attribute Class value should be between 0 - 100.";
        protected const string DefaultBorderColor = "#ABADB3";
        protected const string ErrorBorderColor = "Red";
        protected bool _selectAll = false;

        public List<string> LoadDataComboBox { get; set; }

        #endregion Fields

        #region INotifyPropertyChange Member

        #region SelectedDataInLoadDataComboBox

        public string SelectedDataInLoadDataComboBox
        {
            get { return _selectedDataInLoadDataComboBox; }
            set
            {
                if (value == _selectedDataInLoadDataComboBox)
                    return;

                _selectedDataInLoadDataComboBox = value;
                OnPropertyChangedAsync(nameof(SelectedDataInLoadDataComboBox));
            }
        }

        private string _selectedDataInLoadDataComboBox { get; set; }

        #endregion SelectedDataInLoadDataComboBox

        #region IsNumberingSeriesPartPrefixChecked

        public bool IsNumberingSeriesPartPrefixChecked
        {
            get { return _isNumberingSeriesPartPrefixChecked; }
            set
            {
                if (value == _isNumberingSeriesPartPrefixChecked)
                    return;

                _isNumberingSeriesPartPrefixChecked = value;
                OnPropertyChangedAsync(nameof(IsNumberingSeriesPartPrefixChecked));
            }
        }

        private bool _isNumberingSeriesPartPrefixChecked { get; set; }

        #endregion IsNumberingSeriesPartPrefixChecked

        #region NumberingSeriesPartPrefixText

        public string NumberingSeriesPartPrefixText
        {
            get { return _numberingSeriesPartPrefixText; }
            set
            {
                if (value == _numberingSeriesPartPrefixText)
                    return;

                _numberingSeriesPartPrefixText = value;
                IsNumberingSeriesPartPrefixChecked = NumberingSeriesPartPrefixText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(NumberingSeriesPartPrefixText));
            }
        }

        private string _numberingSeriesPartPrefixText { get; set; }

        #endregion NumberingSeriesPartPrefixText

        #region IsNumberingSeriesPartStartumberChecked

        public bool IsNumberingSeriesPartStartumberChecked
        {
            get { return _isNumberingSeriesPartStartumberChecked; }
            set
            {
                if (value == _isNumberingSeriesPartStartumberChecked)
                    return;

                _isNumberingSeriesPartStartumberChecked = value;
                OnPropertyChangedAsync(nameof(IsNumberingSeriesPartStartumberChecked));
            }
        }

        private bool _isNumberingSeriesPartStartumberChecked { get; set; }

        #endregion IsNumberingSeriesPartStartumberChecked

        #region NumberingSeriesPartStartNumberText

        public string NumberingSeriesPartStartNumberText
        {
            get { return _numberingSeriesPartStartNumberText; }
            set
            {
                if (value == _numberingSeriesPartStartNumberText)
                    return;

                _numberingSeriesPartStartNumberText = value;
                IsNumberingSeriesPartStartumberChecked = NumberingSeriesPartStartNumberText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(NumberingSeriesPartStartNumberText));
            }
        }

        private string _numberingSeriesPartStartNumberText { get; set; }

        #endregion NumberingSeriesPartStartNumberText

        #region IsNumberingSeriesAssemblyPrefixChecked

        public bool IsNumberingSeriesAssemblyPrefixChecked
        {
            get { return _isNumberingSeriesAssemblyPrefixChecked; }
            set
            {
                if (value == _isNumberingSeriesAssemblyPrefixChecked)
                    return;

                _isNumberingSeriesAssemblyPrefixChecked = value;
                OnPropertyChangedAsync(nameof(IsNumberingSeriesAssemblyPrefixChecked));
            }
        }

        private bool _isNumberingSeriesAssemblyPrefixChecked { get; set; }

        #endregion IsNumberingSeriesAssemblyPrefixChecked

        #region NumberingSeriesAssemblyPrefixText

        public string NumberingSeriesAssemblyPrefixText
        {
            get { return _numberingSeriesAssemblyPrefixText; }
            set
            {
                if (value == _numberingSeriesAssemblyPrefixText)
                    return;

                _numberingSeriesAssemblyPrefixText = value;
                IsNumberingSeriesAssemblyPrefixChecked = NumberingSeriesAssemblyPrefixText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(NumberingSeriesAssemblyPrefixText));
            }
        }

        private string _numberingSeriesAssemblyPrefixText { get; set; }

        #endregion NumberingSeriesAssemblyPrefixText

        #region IsNumberingSeriesAssemblyStartumberChecked

        public bool IsNumberingSeriesAssemblyStartumberChecked
        {
            get { return _isNumberingSeriesAssemblyStartumberChecked; }
            set
            {
                if (value == _isNumberingSeriesAssemblyStartumberChecked)
                    return;

                _isNumberingSeriesAssemblyStartumberChecked = value;
                OnPropertyChangedAsync(nameof(IsNumberingSeriesAssemblyStartumberChecked));
            }
        }

        private bool _isNumberingSeriesAssemblyStartumberChecked { get; set; }

        #endregion IsNumberingSeriesAssemblyStartumberChecked

        #region NumberingSeriesAssemblyStartNumberText

        public string NumberingSeriesAssemblyStartNumberText
        {
            get { return _numberingSeriesAssemblyStartNumberText; }
            set
            {
                if (value == _numberingSeriesAssemblyStartNumberText)
                    return;

                _numberingSeriesAssemblyStartNumberText = value;
                IsNumberingSeriesAssemblyStartumberChecked = NumberingSeriesAssemblyStartNumberText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(NumberingSeriesAssemblyStartNumberText));
            }
        }

        private string _numberingSeriesAssemblyStartNumberText { get; set; }

        #endregion NumberingSeriesAssemblyStartNumberText

        #region IsAttributesNameChecked

        public bool IsAttributesNameChecked
        {
            get { return _isAttributesNameChecked; }
            set
            {
                if (value == _isAttributesNameChecked)
                    return;

                _isAttributesNameChecked = value;
                OnPropertyChangedAsync(nameof(IsAttributesNameChecked));
            }
        }

        private bool _isAttributesNameChecked { get; set; }

        #endregion IsAttributesNameChecked

        #region AttributesNameText

        public string AttributesNameText
        {
            get { return _attributesNameText; }
            set
            {
                if (value == _attributesNameText)
                    return;

                _attributesNameText = value;
                IsAttributesNameChecked = AttributesNameText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(AttributesNameText));
            }
        }

        private string _attributesNameText { get; set; }

        #endregion AttributesNameText

        #region IsAttributesProfileChecked

        public bool IsAttributesProfileChecked
        {
            get { return _isAttributesProfileChecked; }
            set
            {
                if (value == _isAttributesProfileChecked)
                    return;

                _isAttributesProfileChecked = value;
                OnPropertyChangedAsync(nameof(IsAttributesProfileChecked));
            }
        }

        private bool _isAttributesProfileChecked { get; set; }

        #endregion IsAttributesProfileChecked

        #region IsSelectProfileButtonEnable

        public bool IsSelectProfileButtonEnable
        {
            get { return _isSelectProfileButtonEnable; }
            set
            {
                if (value == _isSelectProfileButtonEnable)
                    return;

                _isSelectProfileButtonEnable = value;
                OnPropertyChangedAsync(nameof(IsSelectProfileButtonEnable));
            }
        }

        private bool _isSelectProfileButtonEnable { get; set; }

        #endregion IsSelectProfileButtonEnable

        #region AttributesProfileText

        public string AttributesProfileText
        {
            get { return _attributesProfileText; }
            set
            {
                if (value == _attributesProfileText)
                    return;

                _attributesProfileText = value;
                ProfileBorderColor = DefaultBorderColor;
                IsSelectProfileButtonEnable = AttributesProfileText.Trim().Length >= 1;
                IsAttributesProfileChecked = AttributesProfileText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(AttributesProfileText));
            }
        }

        private string _attributesProfileText { get; set; }

        #endregion AttributesProfileText

        #region IsAttributesMaterialChecked

        public bool IsAttributesMaterialChecked
        {
            get { return _isAttributesMaterialChecked; }
            set
            {
                if (value == _isAttributesMaterialChecked)
                    return;

                _isAttributesMaterialChecked = value;
                OnPropertyChangedAsync(nameof(IsAttributesMaterialChecked));
            }
        }

        private bool _isAttributesMaterialChecked { get; set; }

        #endregion IsAttributesMaterialChecked

        #region AttributesMaterialText

        public string AttributesMaterialText
        {
            get { return _attributesMaterialText; }
            set
            {
                if (value == _attributesMaterialText)
                    return;

                _attributesMaterialText = value;
                IsAttributesMaterialChecked = AttributesMaterialText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(AttributesMaterialText));
            }
        }

        private string _attributesMaterialText { get; set; }

        #endregion AttributesMaterialText

        #region IsAttributesFinishChecked

        public bool IsAttributesFinishChecked
        {
            get { return _isAttributesFinishChecked; }
            set
            {
                if (value == _isAttributesFinishChecked)
                    return;

                _isAttributesFinishChecked = value;
                OnPropertyChangedAsync(nameof(IsAttributesFinishChecked));
            }
        }

        private bool _isAttributesFinishChecked { get; set; }

        #endregion IsAttributesFinishChecked

        #region AttributesFinishText

        public string AttributesFinishText
        {
            get { return _attributesFinishText; }
            set
            {
                if (value == _attributesFinishText)
                    return;

                _attributesFinishText = value;
                IsAttributesFinishChecked = AttributesFinishText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(AttributesFinishText));
            }
        }

        private string _attributesFinishText { get; set; }

        #endregion AttributesFinishText

        #region IsAttributesClassChecked

        public bool IsAttributesClassChecked
        {
            get { return _isAttributesClassChecked; }
            set
            {
                if (value == _isAttributesClassChecked)
                    return;

                _isAttributesClassChecked = value;
                OnPropertyChangedAsync(nameof(IsAttributesClassChecked));
            }
        }

        private bool _isAttributesClassChecked { get; set; }

        #endregion IsAttributesClassChecked

        #region AttributesClassText

        public int AttributesClassText
        {
            get { return _attributesClassText; }
            set
            {
                if (value == _attributesClassText)
                    return;

                _attributesClassText = value;
                IsAttributesClassChecked = AttributesClassText > 0;
                OnPropertyChangedAsync(nameof(AttributesClassText));
            }
        }

        private int _attributesClassText { get; set; }

        #endregion AttributesClassText

        #region SelectedTabIndex

        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (value == _selectedTabIndex)
                    return;

                _selectedTabIndex = value;
                OnPropertyChangedAsync(nameof(SelectedTabIndex));
            }
        }

        private int _selectedTabIndex = 0;

        #endregion SelectedTabIndex

        #region ErrorText

        public string ErrorText
        {
            get { return _errorText; }
            set
            {
                if (value == _errorText)
                    return;

                _errorText = value;
                IsErrorVisible = ErrorText.Trim().Length > 0;
                OnPropertyChangedAsync(nameof(ErrorText));
            }
        }

        private string _errorText { get; set; }

        #endregion ErrorText

        #region IsErrorVisible

        public bool IsErrorVisible
        {
            get { return _isErrorVisible; }
            set
            {
                if (value == _isErrorVisible)
                    return;

                _isErrorVisible = value;
                OnPropertyChangedAsync(nameof(IsErrorVisible));
            }
        }

        private bool _isErrorVisible { get; set; }

        #endregion IsErrorVisible

        #region ProfileBorderColor

        public string ProfileBorderColor
        {
            get { return _profileBorderColor; }
            set
            {
                if (value == _profileBorderColor)
                    return;

                _profileBorderColor = value;
                OnPropertyChangedAsync(nameof(ProfileBorderColor));
            }
        }

        private string _profileBorderColor = DefaultBorderColor;

        #endregion ProfileBorderColor

        #region AttributesClassBorderColor

        public string AttributesClassBorderColor
        {
            get { return _attributesClassBorderColor; }
            set
            {
                if (value == _attributesClassBorderColor)
                    return;

                _attributesClassBorderColor = value;
                OnPropertyChangedAsync(nameof(AttributesClassBorderColor));
            }
        }

        private string _attributesClassBorderColor = DefaultBorderColor;

        #endregion AttributesClassBorderColor

        #endregion INotifyPropertyChange Member

        public AbstractPropertyViewModel()
        {
            LoadDataComboBox = new List<string>() { "a", "b", "c", "d" };
            SelectedDataInLoadDataComboBox = LoadDataComboBox[0];
        }

        #region Button Command

        #region Close Button Command

        private ICommand m_ButtonCommand;

        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }

        #endregion Close Button Command

        #region OK Buttom Command

        private ICommand _okButtonCommand;

        public ICommand OkButtonCommand
        {
            get
            {
                return _okButtonCommand;
            }
            set
            {
                _okButtonCommand = value;
            }
        }

        #endregion OK Buttom Command

        #region EnterKeyCommand

        private ICommand _enterKeyCommand;

        public ICommand EnterKeyCommand
        {
            get
            {
                return _enterKeyCommand;
            }
            set
            {
                _enterKeyCommand = value;
            }
        }

        #endregion EnterKeyCommand

        #region Apply Buttom Command

        private ICommand _applyButtonCommand;

        public ICommand ApplyButtonCommand
        {
            get
            {
                return _applyButtonCommand;
            }
            set
            {
                _applyButtonCommand = value;
            }
        }

        #endregion Apply Buttom Command

        #region Modify Buttom Command

        private ICommand _modifyButtonCommand;

        public ICommand ModifyButtonCommand
        {
            get
            {
                return _modifyButtonCommand;
            }
            set
            {
                _modifyButtonCommand = value;
            }
        }

        #endregion Modify Buttom Command

        #region Get Buttom Command

        private ICommand _getButtonCommand;

        public ICommand GetButtonCommand
        {
            get
            {
                return _getButtonCommand;
            }
            set
            {
                _getButtonCommand = value;
            }
        }

        #endregion Get Buttom Command

        #region SelectAllCheckBox Buttom Command

        private ICommand _selectAllCheckButtonCommand;

        public ICommand SelectAllCheckBoxButtonCommand
        {
            get
            {
                return _selectAllCheckButtonCommand;
            }
            set
            {
                _selectAllCheckButtonCommand = value;
            }
        }

        #endregion SelectAllCheckBox Buttom Command

        #region Save Buttom Command

        private ICommand _saveButtonCommand;

        public ICommand SaveButtonCommand
        {
            get
            {
                return _saveButtonCommand;
            }
            set
            {
                _saveButtonCommand = value;
            }
        }

        #endregion Save Buttom Command

        #region Load Buttom Command

        private ICommand _loadButtonCommand;

        public ICommand LoadButtonCommand
        {
            get
            {
                return _loadButtonCommand;
            }
            set
            {
                _loadButtonCommand = value;
            }
        }

        #endregion Load Buttom Command

        #region SelectProfile Buttom Command

        private ICommand _selectButtonCommand;

        public ICommand SelectProfileButtonCommand
        {
            get
            {
                return _selectButtonCommand;
            }
            set
            {
                _selectButtonCommand = value;
            }
        }

        #endregion SelectProfile Buttom Command

        #endregion Button Command

        #region PropertyChanged

        public new event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChangedAsync([CallerMemberName]string propertyName = null)
        {
            try
            {
                try
                {
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                }
                catch { }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion PropertyChanged

        #region Check Is Data Valid

        protected void SetErrorOnScreenIfProfileError(bool validProfile)
        {
            if (!validProfile)
            {
                SetErrorText(ErrorProfileMessage);
                ProfileBorderColor = ErrorBorderColor;
            }
            else
            {
                ProfileBorderColor = DefaultBorderColor;
            }
        }

        protected void SetErrorOnScreenIsAttributesClassError(bool valid)
        {
            if (!valid)
            {
                SetErrorText(ErrorAttributeClassMessage);
                AttributesClassBorderColor = ErrorBorderColor;
            }
            else
            {
                AttributesClassBorderColor = DefaultBorderColor;
            }
        }

        protected void SetErrorText(string error)
        {
            if (string.IsNullOrEmpty(ErrorText))
            {
                ErrorText = error;
            }
            else
            {
                ErrorText = ErrorText + "\r\n" + error;
            }
        }

        #endregion Check Is Data Valid

        #region Check is Valid Deciamil

        public bool IsValidDecimal(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return true;
            }

            double result;
            if (Double.TryParse(value, out result))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion Check is Valid Deciamil
    }
}