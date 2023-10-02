namespace HighRiskCafeV2
{
    internal class Kaffebryggare
    {
        Random random = new Random();
        string coffeeRequest = "";
        List<string> failedTasks = new List<string>();
        List<string> coffeeTypes = new List<string>() { "Espresso", "Americano", "Macchiato", "Cortado", "Cappucino", "Mocca" };
        bool isOrdering = true;
        public void MakeCoffee()
        {

            while (isOrdering)
            {
                WelcomeImage();
                AskForCoffee();
                PrintSelection();
                AskForCoffeeType();
                Console.Clear();
                PutWaterInMachine();
                PutCoffeeInMachine();
                PlaceCupInMachine();
                StartMachine();
                ServeCoffeeToGuest();

                bool isDone = IsItDone();
                Kaffe kaffet = new Kaffe(coffeeRequest, isDone, failedTasks);
                Console.WriteLine($"You ordered: {kaffet.CoffeeType},  Errors occurred: {kaffet.IsDone}, {failedTasks.Count} in total. ");

                if (isDone)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    PrintFails();
                    Console.ResetColor();
                }

                Console.WriteLine("Do you wish to make another order? (y) or (n) ");
                string yesOrNo = Console.ReadLine();
                if (yesOrNo.Equals("n"))
                {
                    isOrdering = false;
                }
                Console.Clear();
                failedTasks.Clear();
                coffeeRequest = "";
            }
        }

        private void WelcomeImage()
        {
            Console.WriteLine("    (  )   (   )  )\r\n     ) (   )  (  (\r\n     ( )  (    ) )\r\n     _____________\r\n    <_____________> ___\r\n    |             |/ _ \\\r\n    |               | | |\r\n    |               |_| |\r\n ___|             |\\___/\r\n/    \\___________/    \\\r\n\\_____________________/");
            Console.WriteLine("^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^v^\n");
        }

        private void AskForCoffeeType()
        {
            Console.WriteLine("What coffee type would you like?");
            string answer = Console.ReadLine();
            bool a = ValidateCoffeeType(answer);
            while (!a)
            {
                Console.WriteLine("That coffee type does not exist, try again");
                answer = Console.ReadLine();
            }
        }

        private bool ValidateCoffeeType(string c)
        {

            bool b = false;
            if (!coffeeTypes.Contains(c))
            {
                b = false;
            }
            else if (coffeeTypes.Contains(c))
            {
                coffeeRequest = c;
                b = true;
            }
            return b;
        }

        public bool IsItDone()
        {
            if (failedTasks.Count > 0)
            {
                return true;
            }
            else if (failedTasks.Count == 0)
            {
                return false;
            }
            else
                return false;
        }

        private void AskForCoffee()
        {
            Console.WriteLine("Welcome! Are you looking for some coffee? ('yes' or 'no') ");
            string answer = Console.ReadLine();
            if (!string.Equals(answer, "yes", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Hint: Type 'yes' to continue!");
                answer = Console.ReadLine();
            }

        }


        private void PrintSelection()
        {
            foreach (var sel in coffeeTypes)
            {
                Console.WriteLine("-->  " + sel);
            }
        }

        private void PrintFails()
        {
            foreach (var fail in failedTasks)
            {
                Console.WriteLine(fail);
            }
        }

        private int CalculateSuccess()
        {
            int number = random.Next(1, 101);
            return number;
        }

        private void Evaluate(int randomNumber, string task)
        {
            if (randomNumber > 0 && randomNumber <= 20)
            {
                failedTasks.Add($"Failed to {task}");
            }
        }


        private void PutCoffeeInMachine()
        {
            string task = "Put coffee in Machine";
            int successOrFail = CalculateSuccess();
            Evaluate(successOrFail, task);

        }

        private void PutWaterInMachine()
        {
            string task = "Put water in Machine";
            int successOrFail = CalculateSuccess();
            Evaluate(successOrFail, task);

        }

        private void PlaceCupInMachine()
        {
            string task = "Place cup in Machine";
            int successOrFail = CalculateSuccess();
            Evaluate(successOrFail, task);
        }

        private void StartMachine()
        {
            string task = "Start Machine";
            int successOrFail = CalculateSuccess();
            Evaluate(successOrFail, task);
        }

        private void ServeCoffeeToGuest()
        {
            string task = "Serve Coffee to Guest";
            int successOrFail = CalculateSuccess();
            Evaluate(successOrFail, task);
        }

    }

}
