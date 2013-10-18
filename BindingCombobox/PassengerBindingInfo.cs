using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;


namespace FlightCentre.TudFaregateProvider.Common
{
    public class PassengerBaggageInfo
    {
        public ObservableCollection<BaggageOption> BaggageOptions { get; set; }
        public string Sector { get; set; }
        public string SelectedBaggageCode { get; set; }
        /// <summary>
        /// Price including tax
        /// </summary>
        public decimal Price { get; set; }

        public decimal Tax { get; set; }
        public decimal MaxWeight { get; set; }
        public int SegmentIndex { get; set; }

        public string TravellerName { get; set; }
    }

    public class PassengerInfo : IDataErrorInfo
    {
        private string dateOfBirth;
        private string selectedCompanionName;
        private int selectedCompanionIndex;

        public int TravellerIndex { get; set; }
        public string TravellerTitle { get; set; }
        public string TravellerFirstName { get; set; }
        public string TravellerSurname { get; set; }
        
        /// <summary>
        /// Date of Birth
        /// </summary>
      
        public string Key { get; set; }
      
       
        public List<string> Titles { get; set; }
        public PassengerInfo(DateTime finalTravelDate)
        {
            FinalTravelDate = finalTravelDate;
        }
        /// <summary>
        /// Used for validation purposes
        /// </summary>
        protected DateTime? FinalTravelDate { get; set; }

        private List<PassengerBaggageInfo> baggageInfos = new List<PassengerBaggageInfo>();
        public List<PassengerBaggageInfo> BaggageInfos
        {
            get { return baggageInfos; }
            set { baggageInfos = value; }
        }

     
     
        public string this[string columnName]
        {
            get
            {
                return validate(columnName);
            }
        }

        private string validate(string columnName)
        {
            StringBuilder result = new StringBuilder();
            bool checkAllProperties = string.IsNullOrWhiteSpace(columnName);

            if (checkAllProperties || (columnName.Contains("SelectedCompanion")))
            {
                
            }

           
            if (checkAllProperties || columnName == "TravellerTitle")
            {
                if (string.IsNullOrWhiteSpace(TravellerTitle))
                    result.AppendLine("Title must be provided for all passengers");
            }

            return result.ToString();
        }

        public string Error
        {
            get { return validate(null); }
        }

        public string TravellerName
        {
            get { return string.Format("{0} {1}", this.TravellerFirstName, this.TravellerSurname); }
        }
    }
}