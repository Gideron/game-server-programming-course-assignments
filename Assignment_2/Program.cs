using System;

namespace Assignment_2
{
    class Program
    {
        public List<Player> players;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            instantiatePlayers();
            Console.WriteLine(players.count());
        }

        private void instantiatePlayers(){
            for(int i = 0; i < 1000000;i++){
                //instantiate player with random Guid
                Player p = new Player(Id = Guid.NewGuid());
                players.add(p);
            }
        }

        private void checkDuplicatePlayers(){
            foreach(Player p in players){
            }
            //or lambda?
        }
    }
}
