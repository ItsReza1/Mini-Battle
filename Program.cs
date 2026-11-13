using System;
using System.Reflection.PortableExecutable;
class program
{
    static void Main(string[] args)
    {
        Random rand = new Random();

        // Vi skapar en spelare och en fiende
        Character player = new Character("Spelare", 100, 15, 10);
        Character enemy = new Character("fiende", 100, 13, 10);

        Console.WriteLine($"Du möter {enemy.Name}");



        // Spelets huvudlopp, vi kontrollera att deras poäng är 0 och kör spelet efter om det stämmer.
        while (player.CurrentHp > 0 && enemy.CurrentHp > 0)
        {
            // Börja med att visa deras Hp i consolen
            Console.WriteLine($"Ditt Hp {player.CurrentHp}/ {player.MaxHp} | Fiendens Hp är {enemy.CurrentHp}/{enemy.MaxHp}");

            Console.WriteLine("Välj [A] för att attackera eller [H] för att Heala:");
            char choice = Console.ReadKey().KeyChar;

            if (choice == 'a' || choice == 'A')
            {
                player.Attack(enemy,rand);
            }
            else if (choice == 'h' || choice == 'H')
            {
                player.Heal();
            }
            else
            {
                System.Console.WriteLine("Fel knapp, välj A eller H");
            }

            if(enemy.CurrentHp <= 0) break;

            
            Console.WriteLine("Nu är det fiendens tur");
            int enemyChoice = rand.Next(1,11);
            if(enemyChoice >= 5)
            {
                enemy.Attack(player,rand);
            }
            else
            {
                enemy.Heal();
            }
            enemy.checkRage(); //Vi kollar rage mode för fienden

             Console.WriteLine("Tryck på valfri tanget för att starta nästa rad");
             Console.ReadKey();
        
        }
        
        if(player.CurrentHp > 0)
        {
            Console.WriteLine("Grattis, du vann och besegrade fineden!");
        }
        else
        {
            Console.WriteLine("Du förlorade tvär!");
        }
       

    } 
}