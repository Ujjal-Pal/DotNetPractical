namespace ColorShapesLibrary
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Abstract class for ColorShapes which holds common properties & methods
    /// </summary>
    public abstract class ColorShapes
    {
        /// <summary>
        /// Property to store Csv File Path
        /// </summary>
        protected string _csvFilePath { get; set; }
        /// <summary>
        /// Property to store ColorShape Object List
        /// </summary>
        protected List<ColorShapesModel> _colorShapesLists { get; set; }
        /// <summary>
        /// Property to store Resulted Organised ColorShapes to produce output Csv file
        /// </summary>
        protected StringBuilder _organisedColorShapes { get; set; }

        /// <summary>
        /// Constructor for ColorShape class
        /// </summary>
        protected ColorShapes()
        {
            _colorShapesLists = new List<ColorShapesModel>(); 
            _organisedColorShapes = new StringBuilder();
        }

        /// <summary>
        /// Method to Read Csv File Path from end user 
        /// </summary>
        protected void CsvFilePath()
        {
            try
            {
                Console.WriteLine("\t<..CSV File Path..>");
                Console.WriteLine("1. Use Custom CSV File");
                Console.WriteLine("2. Use Sample CSV File Provided"); 
                Console.Write("Enter your option : ");
                int choice = Convert.ToInt16(Console.ReadLine());
                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Console.Write("Please enter a valid csv file path : ");
                        _csvFilePath = Console.ReadLine();
                        Console.WriteLine(@"Given File Path : {0}", _csvFilePath);
                        break;
                    case 2:
                        _csvFilePath = Constants.SampleInputCSVFilePath;
                        break;
                    default:
                        Console.WriteLine("Error: Entered an In-Valid Options!!");
                        break;
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("CsvFilePath have Failed with Exceptions : {0}", ex.Message);
            }
        }

        /// <summary>
        /// Method to Read Csv File and convert to ColorShapes object List
        /// </summary>
        protected void CsvFileReader()
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(_csvFilePath))
                {
                    using (var reader = new StreamReader(_csvFilePath))
                    {
                        //Store the heading row of input csv file i.e Shape,Color 
                        _organisedColorShapes.AppendLine(reader.ReadLine());

                        //Reading csv file line by line and store in ColorShapeModel list
                        while (!reader.EndOfStream)
                        {
                            ColorShapesModel colorShapes = new ColorShapesModel();
                            var line = reader.ReadLine();
                            var values = line.Split(',');

                            //Validate CSV file Data
                            if (values.Length != 2)
                            {
                                Console.WriteLine("Error: Invalid CSV file..!! \nPlease add Only two columns i.e Shape and Color");
                                Console.ReadKey();
                                throw new Exception("Invalid CSV file.");
                            }

                            colorShapes.Shape = Convert.ToString(values[0]);
                            colorShapes.Color = Convert.ToString(values[1]);

                            _colorShapesLists.Add(colorShapes);
                        }
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
                Console.WriteLine("CsvFileReader have Failed with Exceptions : {0}", ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Method to Read Csv File Values
        /// </summary>
        protected void CsvFileValues()
        {
            Console.WriteLine("Shape -> Color");
            foreach (var colorShapesItem in _colorShapesLists)
                Console.WriteLine("{0} -> {1}", colorShapesItem.Shape,colorShapesItem.Color);
            Console.ReadKey();
        }

        /// <summary>
        /// Method to Create Output Csv File
        /// </summary>
        protected void OutputCsvFile()
        {
            try
            {
                Console.WriteLine("Press any key to Generate Output Organised ColorShapes CSV File");
                Console.ReadKey();
                if (!String.IsNullOrWhiteSpace(Convert.ToString(_organisedColorShapes)))
                {
                    var csvOutputFilePath = Constants.OutputCSVFilePath;
                    
                    File.WriteAllText(csvOutputFilePath, Convert.ToString(_organisedColorShapes));

                    Console.WriteLine();
                    Console.WriteLine("Successfully Generated Organised ColorShapes CSV File..!!");
                    Console.WriteLine("Output Path : {0}", Path.GetFullPath(csvOutputFilePath));
                }
                else
                {
                    Console.Write("Error, Input CSV File is Empty..!!");
                }
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("OutputCsvFile have Failed with Exceptions : {0}", ex.Message);
            }
        }
    }
}
