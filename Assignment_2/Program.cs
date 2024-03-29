﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_2
{
    class Program
    {
        public static List<Player> players = new List<Player>();
        public static List<PlayerForAnotherGame> other_players = new List<PlayerForAnotherGame>();
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            instantiatePlayers();
            Console.WriteLine(players.Count);
            checkDuplicatePlayers();

            foreach(Player p in players){
                ProcessEachItem(p, PrintItem);
            }
            players.ForEach(p => ProcessEachItem(p, PrintItem));

            Game<Player> game = new Game<Player>(players);
            foreach(Player p in game.GetTop10Players()){
                Console.WriteLine("Score:" + p.Score);
            }
            
            Game<PlayerForAnotherGame> anotherGame = new Game<PlayerForAnotherGame>(other_players);
            //gives error without players
            foreach(PlayerForAnotherGame p in anotherGame.GetTop10Players()){
                Console.WriteLine("Score:" + p.Score);
            }
        }

        private static void instantiatePlayers() {
            //should be 1000000
            for (int i = 0; i < 10; i++) {
                //instantiate player with random Guid
                Player p = new Player();
                p.Id = Guid.NewGuid();

                //Add item
                Item it = new Item();
                it.Id = Guid.NewGuid();
                it.Level = 1;
                p.Items = new List<Item>();
                p.Items.Add(it);

                players.Add(p);
            }
        }

        private static void checkDuplicatePlayers() {
            /*foreach(Player p in players){
                foreach(Player p2 in players){
                    if(p.Equals(p2))
                        continue;
                    if(p.Id.Equals(p2.Id))
                        Console.WriteLine("Found duplicate");
                }
            }*/
        }

        private static Item[] GetItems(Player p)
        {
            int c = p.Items.Count();
            Item[] array = new Item[c];
            for (int i = 0; i < c; i++)
            {
                array[i] = p.Items[i];
            }
            return array;
        }

        private static Item[] GetItemsWithLinq(Player p)
        {
            Item[] array = p.Items.ToArray();
            return array;
        }

        private static Item FirstItem(Player p)
        {
            if ((p.Items != null) && (!p.Items.Any()))
                return p.Items[0];
            else
                return null;
        }

        private static Item FirstItemWithLinq(Player p)
        {
            if ((p.Items != null) && (!p.Items.Any()))
                return p.Items.First();
            else
                return null;
        }

        private static void ProcessEachItem(Player player, Action<Item> process)
        {
            foreach(var item in player.Items)
            {
                process(item);
            }
        }

        private static void PrintItem(Item item){
            Console.WriteLine("Id:" + item.Id + ", Level:" + item.Level);
        }
    }
}
