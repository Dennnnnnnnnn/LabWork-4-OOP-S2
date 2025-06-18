//Button.cs
using System;

namespace L4
{
    public class Button : IComparable<Button>, IEquatable<Button>
    {
        // Button's name
        public string ButtonName { get; set; }
        // Number of times the button was clicked
        public int TimesClicked { get; set; } 

        /// <summary>
        /// Initializes a new instance of the Button class.
        /// </summary>
        public Button()
        {

        }

        /// <summary>
        /// Initializes a new instance of the Button class with 
        /// specified name and click count.
        /// </summary>
        /// <param name="buttonName">The name of the button.</param>
        /// <param name="timesClicked">The number of times 
        /// the button was clicked.</param>
        public Button(string buttonName, int timesClicked)
        {
            ButtonName = buttonName;
            TimesClicked = timesClicked;
        }

        /// <summary>
        /// Compares this Button instance to another Button.
        /// </summary>
        /// <param name="other">The other Button to compare with.</param>
        /// <returns>An integer indicating the relative order.</returns>
        public int CompareTo(Button other)
        {
            return 0;
        }

        /// <summary>
        /// Determines whether this Button is equal to another Button.
        /// </summary>
        /// <param name="other">The other Button to compare with.</param>
        /// <returns>True if the Buttons are equal; 
        /// otherwise, false.</returns>
        public bool Equals(Button other)
        {
            return false;
        }

    }
}
