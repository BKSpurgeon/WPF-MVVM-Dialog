﻿using DialogBeamProperties.Constants;
using DialogBeamProperties.Model;
using DialogBeamProperties.Model.ProfileFileData;
using DialogBeamProperties.Model.Properties;
using DialogBeamProperties.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DialogBeamProperties.View
{
    /// <summary>
    /// Interaction logic for Column_Properties.xaml
    /// </summary>
    public partial class DialogColumnProperties : Window
    {
        private DialogColumnPropertiesViewModel viewModel;

        public DialogColumnProperties(DialogColumnPropertiesViewModel viewModel)
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
                    MessengerToken.CLOSECOLUMNPROPERTYWINDOW, CloseWindow);
            Messenger.Default.Register<bool>(this,
                MessengerToken.CLOSECOLUMNPROPERTYWINDOW, CloseWindow);
        }

        private void CloseWindow(bool obj)
        {
            this.Close();
        }

  

        public void Dispose()
        {
            Messenger.Default.Unregister<bool>(this,
                    MessengerToken.CLOSECOLUMNPROPERTYWINDOW, CloseWindow);
        }
    }
}