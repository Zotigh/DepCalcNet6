/******************************************************
* Programmer: Lance Zotigh (lzotigh1@cnm.edu)
* Purpose: A simple program that calculates what the future depreciable value of an asset will be.
*******************************************************/
using System.ComponentModel.DataAnnotations;

namespace DepCalcNet6.Models
{
    public class DeprecationStraightLine
    {
        //Fields.
        private DateTime dateAddedToInventory;
        private DateTime dateRemovedFromInventory;
        private double endValue = 0;
        private double lifeTime = 0;
        private double startValue = 0;
        private double salvageValue = 0;
        private string title = "";
        private int position = -1;

        //Properties (Getters and Setters).
        [Required(ErrorMessage = "Please be sure to include a Date Added!")]
        public DateTime DateAddedToInventory
        {
            get { return dateAddedToInventory; }
            set { dateAddedToInventory = value; } 
            Calc(); }
        }
        [Required(ErrorMessage = "Please be sure to include a Date Removed!")]
        public DateTime DateRemovedFromInventory
        {
            get { return dateRemovedFromInventory; }
            set { dateRemovedFromInventory = value; }
        }
        [Required]
        [Range(1, double.MaxValue - 1, ErrorMessage = "Positive Numbers Only!")]
        public double EndValue
        {
            get { return Math.Round(endValue); }
            set { endValue = value; }
        }
        [Required]
        [Range(1, double.MaxValue - 1, ErrorMessage = "Positive Numbers Only!")]
        public double LifeTime
        {
            get { return lifeTime; }
            set { lifeTime = value; }
        }
        [Required]
        [Range(1, double.MaxValue - 1, ErrorMessage = "Positive Numbers Only!")]
        public double SalvageValue
        {
            get { return Math.Round(salvageValue, 2); }
            set { salvageValue = value; }
        }
        [Required]
        [Range(1, double.MaxValue - 1, ErrorMessage = "Positive Numbers Only!")]
        public double StartValue
        {
            get { return Math.Round(startValue, 2); }
            set { startValue = value; Calc(); }
        }
        [Required(ErrorMessage = "Please be sure to include a title!")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        [Required]
        [Range(1, int.MaxValue - 1, ErrorMessage = "Positive Numbers Only!")]
        public int Position
        {
            get { return position; }
            set { position = value; }
        }

        // Base/Overloaded class constructor.
        public DeprecationStraightLine() { }
        public DeprecationStraightLine(double lifetime, double salvageValue, double startValue, string title, DateTime dateAddedToInventory, DateTime dateRemovedFromInventory)
        {
            LifeTime = lifetime;
            SalvageValue = salvageValue;
            StartValue = startValue;
            Title = title;
            DateAddedToInventory = dateAddedToInventory;
            DateRemovedFromInventory = dateRemovedFromInventory;
        }
        /// <summary>
        /// Calculates the Straight Line Deprecation value and returns the calculated value.
        /// </summary>
        private void Calc()
        {
            endValue = (startValue -
                salvageValue) * (1 / lifeTime);
        }
    }
}
