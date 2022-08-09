using TestConsoleProgram;

namespace TestConsoleProgram // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext dataBase = new ApplicationContext())
            {                
                card cardFruit = new card { name = "Apple", idclass = 1 };
                card cardVegetables = new card { name = "Potato", idclass = 2 };
                cardclass cardclassFruits = new cardclass { name = "Fruits" };
                cardclass cardclassVegetables = new cardclass { name = "Vegetables" };
                cardspec cardspecFruits = new cardspec { idcard = 1, propname = "Country", propval = "Russia" };
                cardspec cardspecVegetables = new cardspec { idcard = 2, propname = "Quantity", propval = "10" };
                dataBase.Card.Add(cardFruit);
                dataBase.Card.Add(cardVegetables);
                dataBase.Cardclass.Add(cardclassFruits);
                dataBase.Cardclass.Add(cardclassVegetables);
                dataBase.Cardspec.Add(cardspecFruits);
                dataBase.Cardspec.Add(cardspecVegetables);
                dataBase.SaveChanges();
                Console.WriteLine("The database is saved");

                Console.Clear();
                var cardReturn = dataBase.Card.ToList();
                var cardclassReturn = dataBase.Cardclass.ToList();
                var cardspecReturn = dataBase.Cardspec.ToList();
                Console.WriteLine("Список объектов:");
                foreach (cardclass cardclassitem in cardclassReturn)
                {
                    Console.WriteLine($"{cardclassitem.id} | {cardclassitem.name}");
                }
                foreach (card carditem in cardReturn)
                {
                    Console.WriteLine($"{carditem.id} | {carditem.name} | {carditem.idclass}");
                }
                foreach (cardspec cardspecitem in cardspecReturn)
                {
                    Console.WriteLine($"{cardspecitem.idcard} | {cardspecitem.propname} | {cardspecitem.propval}");
                }
            }
        }
    }
}