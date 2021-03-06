﻿using DialogBeamProperties.CadInterfaces;
using DialogBeamProperties.Constants;
using DialogBeamProperties.Model;
using DialogBeamProperties.Model.ProfileFileData;
using DialogBeamProperties.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace DialogBeamProperties
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DialogBeamProperties : Window, IDisposable
    {
        private DialogBeamPropertiesViewModel viewModel;

        public DialogBeamProperties(DialogBeamPropertiesViewModel viewModel)
        {
            InitializeComponent();
            ProfileFileData allProfileFileData = ProfileFileData.Instance;
            InitMessenger();
            this.viewModel = viewModel;
            this.DataContext = viewModel;
        }

        private void InitMessenger()
        {
            Messenger.Default.Unregister<bool>(this,
                    MessengerToken.CLOSEBEAMPROPERTYWINDOW, CloseWindow);
            Messenger.Default.Register<bool>(this,
                MessengerToken.CLOSEBEAMPROPERTYWINDOW, CloseWindow);
        }

        private void CloseWindow(bool obj)
        {
            this.Close();
        }

        public void Dispose()
        {
            Messenger.Default.Unregister<bool>(this,
                    MessengerToken.CLOSEBEAMPROPERTYWINDOW, CloseWindow);
        }
    }
}