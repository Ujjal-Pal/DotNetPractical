namespace ColorShapesLibrary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// ColorShapes Algorithm class inherited from ColorShapes abstract class which hold specific algorithmic method 
    /// </summary>
    public class ColorShapeAlgorithm : ColorShapes
    {
        /// <summary>
        /// Property to store Dictionary of ColorShape Frequency
        /// </summary>
        private Dictionary<string, int> _colorShapeFrequency { get; set; }

        /// <summary>
        /// Constructor for ColorShape Algorithm Class
        /// </summary>
        public ColorShapeAlgorithm()
        {
            _colorShapeFrequency = new Dictionary<string, int>();
        }

        /// <summary>
        /// Method ColorShapesObjectOrganiser to organised ColorShapes Object in specific order
        /// </summary>
        public void ColorShapesObjectOrganiser()
        {
            try
            {
                CsvFilePath();
                if (!String.IsNullOrWhiteSpace(_csvFilePath))
                {
                    CsvFileReader();
                    if (_colorShapesLists.Any() && _colorShapesLists.Count() > 0)
                    {
                        Organise();
                        OutputCsvFile();
                    }
                    else
                    {
                        Console.Write("Error, Input CSV File is Empty..!!");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Write("Error, Input CSV File Path is Empty..!!");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ColorShapes Object Organiser have Failed with Exceptions : {0}", ex.Message);
            }
        }

        /// <summary>
        /// Method which define the main Algorithm to organise ColorShape objects
        /// </summary>
        public void Organise()
        {
            try
            {
                CreateColorShapesFrequency();

                //Create a copy of Frequency to generate organised output list.
                var colorShapeFrequencyCopy = new Dictionary<string, int>(_colorShapeFrequency);
                //store the count of objects present in original List.
                int countColorShapesLists = _colorShapesLists.Count;

                //Loop around the original list
                while (countColorShapesLists > 0)
                {
                    //Loop around the unqiue combination of Shape and Color objects
                    //To generate Organised List
                    foreach (var colorShapeFrequencyItem in colorShapeFrequencyCopy)
                    {
                        if (_colorShapeFrequency[colorShapeFrequencyItem.Key] > 0)
                        {
                            _organisedColorShapes.AppendLine(colorShapeFrequencyItem.Key);
                            _colorShapeFrequency[colorShapeFrequencyItem.Key]--;
                            countColorShapesLists--;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Organise have Failed with Exceptions : {0}", ex.Message);
            }
        }

        /// <summary>
        /// Method to Create Dictionary to hold ColorShape object Frequency counts
        /// </summary>
        private void CreateColorShapesFrequency()
        {
            try
            {
                foreach (var colorShapeItem in _colorShapesLists)
                {
                    //Created a Unique combination using Shape and color of the object
                    var shapeColor = colorShapeItem.Shape + "," + colorShapeItem.Color;

                    //Calculating frequency of each unique shape and color combination
                    if (_colorShapeFrequency.ContainsKey(shapeColor))
                        _colorShapeFrequency[shapeColor]++;
                    else
                        _colorShapeFrequency.Add(shapeColor, 1);
                }

                _colorShapeFrequency = _colorShapeFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreateColorShape Frequency have Failed with Exceptions : {0}", ex.Message);
            }
        }
    }
}
