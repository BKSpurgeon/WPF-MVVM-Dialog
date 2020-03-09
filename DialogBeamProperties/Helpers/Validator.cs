using DialogBeamProperties.Model;
using DialogBeamProperties.Model.ProfileFileData;
using DialogBeamProperties.Model.Properties;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;

namespace DialogBeamProperties.Helpers
{
    public class Validator
    {
        public bool IsBeamValid(string attributesProfileText)
        {
            return IsValidProfile(attributesProfileText);
        }

        public bool IsColumnValid(string attributesProfileText, double positionLevelsTop, double positionLevelsBottom)
        {
            return IsValidProfile(attributesProfileText) && AreTopAndBottomPositionsValid(positionLevelsTop, positionLevelsBottom);
        }

        public bool IsValidProfile(string attributesProfileText)
        {
            try
            {
                var profiles = ProfileFileData.Instance;
                if (!string.IsNullOrEmpty(attributesProfileText))
                {
                    var beams = profiles.Beams.Where(i => i.Profile.ToUpper().Equals(attributesProfileText.ToUpper()));
                    var chinaProfiles = profiles.ChinaProfiles.Where(i => i.Profile.ToUpper().Equals(attributesProfileText.ToUpper()));
                    var usimperialProfiles = profiles.UsimperialProfiles.Where(i => i.Profile.ToUpper().Equals(attributesProfileText.ToUpper()));
                    var usmetricProfiles = profiles.UsmetricProfiles.Where(i => i.Profile.ToUpper().Equals(attributesProfileText.ToUpper()));
                    if (beams.Count() > 0 || chinaProfiles.Count() > 0 ||
                        usimperialProfiles.Count() > 0 || usmetricProfiles.Count() > 0 || isRod(attributesProfileText))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private bool isRod(string attributesProfileText)
        {
            Regex regex = new Regex(@"^ROD\d+$");

            if (regex.IsMatch(attributesProfileText))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AreTopAndBottomPositionsValid(double positionLevelsTop, double positionLevelsBottom)
        {
            return (Math.Abs(positionLevelsTop - positionLevelsBottom) > 0.01) &&
                   (positionLevelsTop > positionLevelsBottom);
        }

        internal bool IsValidAttributesClass(int attributesClassText)
        {
            return attributesClassText >= 0 && attributesClassText < 100;
        }
    }
}