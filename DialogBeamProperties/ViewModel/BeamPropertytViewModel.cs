﻿using DialogBeamProperties.CadInterfaces;
using DialogBeamProperties.Command;
using DialogBeamProperties.Constants;
using DialogBeamProperties.Model;
using DialogBeamProperties.Model.ProfileFileData;
using DialogBeamProperties.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DialogBeamProperties.ViewModel
{
    public class DialogBeamPropertiesViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Fields

        private IProperties _iproperties { get; set; }

        private readonly XDataWriter xDataWriter;
        private bool _selectAll = false;
        public ProfileFileData AllProfileFileData { get; set; }

        #endregion Fields

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

        #region INotifyPropertyChange Member

        #region LoadDataComboBox

        public List<string> LoadDataComboBox
        {
            get { return _loadDataComboBox; }
            set
            {
                if (value == _loadDataComboBox)
                    return;

                _loadDataComboBox = value;
                OnPropertyChangedAsync(nameof(LoadDataComboBox));
            }
        }

        private List<string> _loadDataComboBox { get; set; }

        #endregion LoadDataComboBox

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

        #region AttributesProfileText

        public string AttributesProfileText
        {
            get { return _attributesProfileText; }
            set
            {
                if (value == _attributesProfileText)
                    return;

                _attributesProfileText = value;

                IsSelectProfileButtonEnable = AttributesProfileText.Trim().Length > 1;
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

        public string AttributesClassText
        {
            get { return _attributesClassText; }
            set
            {
                if (value == _attributesClassText)
                    return;

                _attributesClassText = value;
                OnPropertyChangedAsync(nameof(AttributesClassText));
            }
        }

        private string _attributesClassText { get; set; }

        #endregion AttributesClassText

        #region IsPositionOnPlaneChecked

        public bool IsPositionOnPlaneChecked
        {
            get { return _isPositionOnPlaneChecked; }
            set
            {
                if (value == _isPositionOnPlaneChecked)
                    return;

                _isPositionOnPlaneChecked = value;
                OnPropertyChangedAsync(nameof(IsPositionOnPlaneChecked));
            }
        }

        private bool _isPositionOnPlaneChecked { get; set; }

        #endregion IsPositionOnPlaneChecked

        #region PositionOnPlaneComboBox

        public List<string> PositionOnPlaneComboBox
        {
            get { return _positionOnPlaneComboBox; }
            set
            {
                if (value == _positionOnPlaneComboBox)
                    return;

                _positionOnPlaneComboBox = value;
                OnPropertyChangedAsync(nameof(PositionOnPlaneComboBox));
            }
        }

        private List<string> _positionOnPlaneComboBox { get; set; }

        #endregion PositionOnPlaneComboBox

        #region SelectedDataInPositionOnPlaneComboBox

        public string SelectedDataInPositionOnPlaneComboBox
        {
            get { return _selectedDataInPositionOnPlaneComboBox; }
            set
            {
                if (value == _selectedDataInPositionOnPlaneComboBox)
                    return;

                _selectedDataInPositionOnPlaneComboBox = value;
                OnPropertyChangedAsync(nameof(SelectedDataInPositionOnPlaneComboBox));
            }
        }

        private string _selectedDataInPositionOnPlaneComboBox { get; set; }

        #endregion SelectedDataInPositionOnPlaneComboBox

        #region PositionOnPlaneText

        public string PositionOnPlaneText
        {
            get { return _positionOnPlaneText; }
            set
            {
                if (value == _positionOnPlaneText)
                    return;

                _positionOnPlaneText = value;
                OnPropertyChangedAsync(nameof(PositionOnPlaneText));
            }
        }

        private string _positionOnPlaneText { get; set; }

        #endregion PositionOnPlaneText

        #region IsPositionRotationChecked

        public bool IsPositionRotationChecked
        {
            get { return _isPositionRotationChecked; }
            set
            {
                if (value == _isPositionRotationChecked)
                    return;

                _isPositionRotationChecked = value;
                OnPropertyChangedAsync(nameof(IsPositionRotationChecked));
            }
        }

        private bool _isPositionRotationChecked { get; set; }

        #endregion IsPositionRotationChecked

        #region PositionRotationComboBox

        public List<string> PositionRotationComboBox
        {
            get { return _positionRotationComboBox; }
            set
            {
                if (value == _positionRotationComboBox)
                    return;

                _positionRotationComboBox = value;
                OnPropertyChangedAsync(nameof(PositionRotationComboBox));
            }
        }

        private List<string> _positionRotationComboBox { get; set; }

        #endregion PositionRotationComboBox

        #region SelectedDataInPositionRotationComboBox

        public string SelectedDataInPositionRotationComboBox
        {
            get { return _selectedDataInPositionRotationComboBox; }
            set
            {
                if (value == _selectedDataInPositionRotationComboBox)
                    return;

                _selectedDataInPositionRotationComboBox = value;
                OnPropertyChangedAsync(nameof(SelectedDataInPositionRotationComboBox));
            }
        }

        private string _selectedDataInPositionRotationComboBox { get; set; }

        #endregion SelectedDataInPositionRotationComboBox

        #region PositionRotationText

        public string PositionRotationText
        {
            get { return _positionRotationText; }
            set
            {
                if (value == _positionRotationText)
                    return;

                _positionRotationText = value;
                OnPropertyChangedAsync(nameof(PositionRotationText));
            }
        }

        private string _positionRotationText { get; set; }

        #endregion PositionRotationText

        #region IsPositionAtDepthChecked

        public bool IsPositionAtDepthChecked
        {
            get { return _isPositionAtDepthChecked; }
            set
            {
                if (value == _isPositionAtDepthChecked)
                    return;

                _isPositionAtDepthChecked = value;
                OnPropertyChangedAsync(nameof(IsPositionAtDepthChecked));
            }
        }

        private bool _isPositionAtDepthChecked { get; set; }

        #endregion IsPositionAtDepthChecked

        #region PositionAtDepthComboBox

        public List<string> PositionAtDepthComboBox
        {
            get { return _positionAtDepthComboBox; }
            set
            {
                if (value == _positionAtDepthComboBox)
                    return;

                _positionAtDepthComboBox = value;
                OnPropertyChangedAsync(nameof(PositionAtDepthComboBox));
            }
        }

        private List<string> _positionAtDepthComboBox { get; set; }

        #endregion PositionAtDepthComboBox

        #region SelectedDataInPositionAtDepthComboBox

        public string SelectedDataInPositionAtDepthComboBox
        {
            get { return _selectedDataInPositionAtDepthComboBox; }
            set
            {
                if (value == _selectedDataInPositionAtDepthComboBox)
                    return;

                _selectedDataInPositionAtDepthComboBox = value;
                OnPropertyChangedAsync(nameof(SelectedDataInPositionAtDepthComboBox));
            }
        }

        private string _selectedDataInPositionAtDepthComboBox { get; set; }

        #endregion SelectedDataInPositionAtDepthComboBox

        #region PositionAtDepthText

        public string PositionAtDepthText
        {
            get { return _positionAtDepthText; }
            set
            {
                if (value == _positionAtDepthText)
                    return;

                _positionAtDepthText = value;
                OnPropertyChangedAsync(nameof(PositionAtDepthText));
            }
        }

        private string _positionAtDepthText { get; set; }

        #endregion PositionAtDepthText

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

        #endregion INotifyPropertyChange Member

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

        #region Constructor

        public DialogBeamPropertiesViewModel(XDataWriter xDataWriter)
        {
            LoadDataComboBox = new List<string>();
            AllProfileFileData = new ProfileFileData();
            InitCommand();
            InitMessenger();
            Task.Factory.StartNew(() => LoadProfileFiles());
            this.xDataWriter = xDataWriter;
        }

        private void InitCommand()
        {
            ButtonCommand = new RelayCommand(new Action<object>(CloseWindow));
            ApplyButtonCommand = new RelayCommand(new Action<object>(ApplyButtonClick));
            ModifyButtonCommand = new RelayCommand(new Action<object>(ModifyButtonClick));
            GetButtonCommand = new RelayCommand(new Action<object>(GetButtonClick));
            SelectAllCheckBoxButtonCommand = new RelayCommand(new Action<object>(SelectAllCheckBoxButtonClick));
            SaveButtonCommand = new RelayCommand(new Action<object>(SaveButtonClick));
            LoadButtonCommand = new RelayCommand(new Action<object>(LoadButtonClick));
            SelectProfileButtonCommand = new RelayCommand(new Action<object>(SelectProfileButtonClick));
        }

        private void InitMessenger()
        {
            Messenger.Default.Unregister<string>(this,
                    MessengerToken.SELECTEDPROFILE, SelectedProfile);
            Messenger.Default.Register<string>(this,
                MessengerToken.SELECTEDPROFILE, SelectedProfile);
        }

        #endregion Constructor

        #region Public Methods

        public void SetProtertiesData(IProperties iproperties)
        {
            this._iproperties = iproperties;
            UpdateData(iproperties);
        }

        public IProperties GetPropertiesData()
        {
            return _iproperties;
        }

        #endregion Public Methods

        #region Private Methods

        #region Button Click

        private void CloseWindow(object obj)
        {
            Messenger.Default.Send(true, MessengerToken.CLOSEWINDOW);
        }

        private void ApplyButtonClick(object obj)
        {
            _iproperties.LoadDataComboBox = LoadDataComboBox;
            _iproperties.SelectedDataInLoadDataComboBox = SelectedDataInLoadDataComboBox;
            SaveNumberingData();
            SaveAttributesData();
            SavePositionData();

            xDataWriter.WriteXDataToLine(_iproperties.AttributesProfileText, 0);
        }

        private void ModifyButtonClick(object obj)
        {
        }

        private void GetButtonClick(object obj)
        {
        }

        private void SelectAllCheckBoxButtonClick(object obj)
        {
            IsNumberingSeriesPartPrefixChecked = !_selectAll;
            IsNumberingSeriesPartStartumberChecked = !_selectAll;
            IsNumberingSeriesAssemblyPrefixChecked = !_selectAll;
            IsNumberingSeriesAssemblyStartumberChecked = !_selectAll;
            IsAttributesNameChecked = !_selectAll;
            IsAttributesProfileChecked = !_selectAll;
            IsAttributesMaterialChecked = !_selectAll;
            IsAttributesFinishChecked = !_selectAll;
            IsAttributesClassChecked = !_selectAll;
            IsPositionOnPlaneChecked = !_selectAll;
            IsPositionRotationChecked = !_selectAll;
            IsPositionAtDepthChecked = !_selectAll;
            _selectAll = !_selectAll;
        }

        private void SaveButtonClick(object obj)
        {
        }

        private void LoadButtonClick(object obj)
        {
        }

        private void SelectProfileButtonClick(object obj)
        {
            SelectProfile selectProfile = new SelectProfile();
            selectProfile.SetData(AllProfileFileData, AttributesProfileText);
            selectProfile.ShowDialog();
        }

        #endregion Button Click

        #region Save Data

        private void SavePositionData()
        {
            _iproperties.IsPositionOnPlaneChecked = IsPositionOnPlaneChecked;
            if (_iproperties.IsPositionOnPlaneChecked)
            {
                _iproperties.PositionOnPlaneComboBox = PositionOnPlaneComboBox;
                _iproperties.SelectedDataInPositionOnPlaneComboBox = SelectedDataInPositionOnPlaneComboBox;
                _iproperties.PositionOnPlaneText = PositionOnPlaneText;
            }

            _iproperties.IsPositionRotationChecked = IsPositionRotationChecked;
            if (_iproperties.IsPositionRotationChecked)
            {
                _iproperties.PositionRotationComboBox = PositionRotationComboBox;
                _iproperties.SelectedDataInPositionRotationComboBox = SelectedDataInPositionRotationComboBox;
                _iproperties.PositionRotationText = PositionRotationText;
            }

            _iproperties.IsPositionAtDepthChecked = IsPositionAtDepthChecked;
            if (_iproperties.IsPositionAtDepthChecked)
            {
                _iproperties.PositionAtDepthComboBox = PositionAtDepthComboBox;
                _iproperties.SelectedDataInPositionAtDepthComboBox = SelectedDataInPositionAtDepthComboBox;
                _iproperties.PositionAtDepthText = PositionAtDepthText;
            }
        }

        private void SaveAttributesData()
        {
            _iproperties.IsAttributesNameChecked = IsAttributesNameChecked;
            if (_iproperties.IsAttributesNameChecked)
            {
                _iproperties.AttributesNameText = AttributesNameText;
            }

            _iproperties.IsAttributesProfileChecked = IsAttributesProfileChecked;
            if (_iproperties.IsAttributesProfileChecked)
            {
                _iproperties.AttributesProfileText = AttributesProfileText;
            }

            _iproperties.IsAttributesMaterialChecked = IsAttributesMaterialChecked;
            if (_iproperties.IsAttributesMaterialChecked)
            {
                _iproperties.AttributesMaterialText = AttributesMaterialText;
            }

            _iproperties.IsAttributesFinishChecked = IsAttributesFinishChecked;
            if (_iproperties.IsAttributesFinishChecked)
            {
                _iproperties.AttributesFinishText = AttributesFinishText;
            }

            _iproperties.IsAttributesClassChecked = IsAttributesClassChecked;
            if (_iproperties.IsAttributesClassChecked)
            {
                
                _iproperties.AttributesClassText = AttributesClassText;
            }
        }

        private void SaveNumberingData()
        {
            _iproperties.IsNumberingSeriesPartPrefixChecked = IsNumberingSeriesPartPrefixChecked;
            if (_iproperties.IsNumberingSeriesPartPrefixChecked)
            {
                _iproperties.NumberingSeriesPartPrefixText = NumberingSeriesPartPrefixText;
            }

            _iproperties.IsNumberingSeriesPartStartumberChecked = IsNumberingSeriesPartStartumberChecked;
            if (_iproperties.IsNumberingSeriesPartStartumberChecked)
            {
                _iproperties.NumberingSeriesPartStartNumberText = NumberingSeriesPartStartNumberText;
            }

            _iproperties.IsNumberingSeriesAssemblyPrefixChecked = IsNumberingSeriesAssemblyPrefixChecked;
            if (_iproperties.IsNumberingSeriesAssemblyPrefixChecked)
            {
                _iproperties.NumberingSeriesAssemblyPrefixText = NumberingSeriesAssemblyPrefixText;
            }

            _iproperties.IsNumberingSeriesAssemblyStartumberChecked = IsNumberingSeriesAssemblyStartumberChecked;
            if (_iproperties.IsNumberingSeriesAssemblyStartumberChecked)
            {
                _iproperties.NumberingSeriesAssemblyStartNumberText = NumberingSeriesAssemblyStartNumberText;
            }
        }

        #endregion Save Data

        #region Update Data

        private void UpdateData(IProperties iproperties)
        {
            LoadDataComboBox = iproperties.LoadDataComboBox;
            SelectedDataInLoadDataComboBox = iproperties.SelectedDataInLoadDataComboBox;
            UpdatePositionData();
            UpdateAttributesData();
            UpdateNumberingData();
        }

        private void UpdatePositionData()
        {
            IsPositionOnPlaneChecked = _iproperties.IsPositionOnPlaneChecked;
            PositionOnPlaneComboBox = _iproperties.PositionOnPlaneComboBox;
            SelectedDataInPositionOnPlaneComboBox = _iproperties.SelectedDataInPositionOnPlaneComboBox;
            PositionOnPlaneText = _iproperties.PositionOnPlaneText;

            IsPositionRotationChecked = _iproperties.IsPositionRotationChecked;
            PositionRotationComboBox = _iproperties.PositionRotationComboBox;
            SelectedDataInPositionRotationComboBox = _iproperties.SelectedDataInPositionRotationComboBox;
            PositionRotationText = _iproperties.PositionRotationText;

            IsPositionAtDepthChecked = _iproperties.IsPositionAtDepthChecked;
            PositionAtDepthComboBox = _iproperties.PositionAtDepthComboBox;
            SelectedDataInPositionAtDepthComboBox = _iproperties.SelectedDataInPositionAtDepthComboBox;
            PositionAtDepthText = _iproperties.PositionAtDepthText;
        }

        private void UpdateAttributesData()
        {
            IsAttributesNameChecked = _iproperties.IsAttributesNameChecked;
            AttributesNameText = _iproperties.AttributesNameText;
            IsAttributesProfileChecked = _iproperties.IsAttributesProfileChecked;
            AttributesProfileText = _iproperties.AttributesProfileText;
            IsAttributesMaterialChecked = _iproperties.IsAttributesMaterialChecked;
            AttributesMaterialText = _iproperties.AttributesMaterialText;
            IsAttributesFinishChecked = _iproperties.IsAttributesFinishChecked;
            AttributesFinishText = _iproperties.AttributesFinishText;
            IsAttributesClassChecked = _iproperties.IsAttributesClassChecked;
            AttributesClassText = _iproperties.AttributesClassText;
        }

        private void UpdateNumberingData()
        {
            IsNumberingSeriesPartPrefixChecked = _iproperties.IsNumberingSeriesPartPrefixChecked;
            NumberingSeriesPartPrefixText = _iproperties.NumberingSeriesPartPrefixText;
            IsNumberingSeriesPartStartumberChecked = _iproperties.IsNumberingSeriesPartStartumberChecked;
            NumberingSeriesPartStartNumberText = _iproperties.NumberingSeriesPartStartNumberText;
            IsNumberingSeriesAssemblyPrefixChecked = _iproperties.IsNumberingSeriesAssemblyPrefixChecked;
            NumberingSeriesAssemblyPrefixText = _iproperties.NumberingSeriesAssemblyPrefixText;
            IsNumberingSeriesAssemblyStartumberChecked = _iproperties.IsNumberingSeriesAssemblyStartumberChecked;
            NumberingSeriesAssemblyStartNumberText = _iproperties.NumberingSeriesAssemblyStartNumberText;
        }

        #endregion Update Data

        #region Load Profile Files Into List

        private void LoadProfileFiles()
        {
            string temp = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (File.Exists(Path.Combine(temp, "Files", "Profile", "beams.json")))
            {
                LoadFiles(Path.Combine(temp, "Files", "Profile", "beams.json"), ref AllProfileFileData.Beams);
            }

            if (File.Exists(Path.Combine(temp, "Files", "Profile", "china-profiles.json")))
            {
                LoadFiles(Path.Combine(temp, "Files", "Profile", "china-profiles.json"), ref AllProfileFileData.ChinaProfiles);
            }

            if (File.Exists(Path.Combine(temp, "Files", "Profile", "usimperial-profiles.json")))
            {
                LoadFiles(Path.Combine(temp, "Files", "Profile", "usimperial-profiles.json"), ref AllProfileFileData.UsimperialProfiles);
            }

            if (File.Exists(Path.Combine(temp, "Files", "Profile", "usmetric-profiles.json")))
            {
                LoadFiles(Path.Combine(temp, "Files", "Profile", "usmetric-profiles.json"), ref AllProfileFileData.UsmetricProfiles);
            }
        }

        private void LoadFiles(string filePath, ref List<ProfileData> list)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                JArray jsonArray = JArray.Parse(json);
                list = jsonArray.ToObject<List<ProfileData>>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion Load Profile Files Into List

        private void SelectedProfile(string obj)
        {
            AttributesProfileText = obj;
        }

        #endregion Private Methods
    }
}