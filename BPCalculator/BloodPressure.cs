using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace BPCalculator
{
    // BP categories
    public enum BPCategory
    {
        [Display(Name="Low Blood Pressure")] Low,
        [Display(Name="Ideal Blood Pressure")]  Ideal,
        [Display(Name="Pre-High Blood Pressure")] PreHigh,
        [Display(Name ="High Blood Pressure")]  High
    };

    public class BloodPressure
    {
        public const int SystolicMin = 70;
        public const int SystolicMax = 190;
        public const int DiastolicMin = 40;
        public const int DiastolicMax = 100;

        [Range(SystolicMin, SystolicMax, ErrorMessage = "Invalid Systolic Value")]
        public int Systolic { get; set; }                       // mmHG

        [Range(DiastolicMin, DiastolicMax, ErrorMessage = "Invalid Diastolic Value")]
        public int Diastolic { get; set; }                      // mmHG

        // calculate BP category
        public BPCategory Category
        {
            get
            {
                // implement as part of project
                //throw new NotImplementedException("not implemented yet");
                switch (Systolic, Diastolic)
                {

                //1. High Blood Pressure: Systolic >= 140 or Diastolic >= 90    
                    case ( >= 140, _):
                    case (_, >= 90):
                        return BPCategory.High;

                //2. Pre-High Blood Pressure: Systolic >= 120 or Diastolic >= 80   
                    case (>= 120, _):
                    case (_, >= 80):
                        return BPCategory.PreHigh;

                //3. Low Blood Pressure: Systolic < 90 or Diastolic < 60
                    case (< 90, < 60):
                        return BPCategory.Low;

                //4. Ideal Blood Pressure: Systolic < 120 and Diastolic < 80
                    case (< 120, < 80):
                        return BPCategory.Ideal;

                //5. Invalid Blood Pressure: Any other combination of Systolic and Diastolic values
                    default:
                        throw new InvalidOperationException("Invalid blood pressure values.");
                }
                //return new BPCategory();                       // replace this
            }
        }
    }
}
