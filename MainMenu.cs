namespace DotNetPracticals
{
    using System;
    using ColorShapesLibrary;

    /// <summary>
    /// MainMenu Class
    /// </summary>
    public class MainMenu
    {
        /// <summary>
        /// MenuOptions method which produce Menu Options 
        /// </summary>
        public void MenuOptions()
        {
            try
            {
                Console.WriteLine("<<<<____DotNet Practicals____>>>>");

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("\t<<__MAIN Menu__>>");
                    Console.WriteLine("1. Color Shapes");
                    Console.WriteLine("2. Exit");
                    Console.Write("Enter your option : ");
                    int choice = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine();
                    switch (choice)
                    {
                        case 1:
                            ColorShapeAlgorithm colorShapes = new ColorShapeAlgorithm();
                            colorShapes.ColorShapesObjectOrganiser();
                            break;
                        case 2:
                            Console.WriteLine("Thank you, Visit Again..");
                            return;
                        default:
                            Console.WriteLine("Error, Please enter a Valid Options!!");
                            break;
                    }
                    Console.WriteLine();
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("MainMenu have Failed with Exceptions : {0}", ex.Message);
            }
        }
    }
}
