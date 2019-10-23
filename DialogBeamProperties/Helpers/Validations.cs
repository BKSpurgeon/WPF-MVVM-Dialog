﻿using DialogBeamProperties.Model.ProfileFileData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static DialogBeamProperties.Model.ProfileFileData.ProfileFileData;

namespace DialogBeamProperties.Helpers
{
    public class Validations
    {
        public bool IsValidProfile(string attributesProfileText, List<ProfileData> profiles)
        {
            try
            {
                var beamdata = profiles.Where(i => i.Profile.ToUpper().StartsWith(attributesProfileText.ToUpper()));

                if (beamdata.Count() > 0 )
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }
    }
}
