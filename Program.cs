namespace DotNetPracticals
{
    using System;

    /// <summary>
    /// Main Program Class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main Method to execute our Programme
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            try
            {
                MainMenu mainManu = new MainMenu();
                mainManu.MenuOptions();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Main Program have Failed with Exceptions : {0}", ex.Message);
            }
        }
    }
}
