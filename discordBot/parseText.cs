﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Discord;      // discord api
using RedditSharp;  // reddit api
using Tweetinvi;    // twitter api

namespace discordBot
{
    public class parseText
    {

        string[] dongers = new string[] { "⊂(▀¯▀⊂)","ᕙ(˵ ಠ ਊ ಠ ˵)ᕗ","( ͡↑ ͜ʖ ͡↑)","┌༼◉ل͟◉༽┐",
                                          "ᕕ( ՞ ᗜ ՞ )ᕗ","(ノ͡° ͜ʖ ͡°)ノ︵┻┻","╚═། ◑ ▃ ◑ །═╝","(V●ᴥ●V)",
                                          "┌༼ – _ – ༽┐","⋋| ◉ ͟ʖ ◉ |⋌", "¯\\_| ಠ ∧ ಠ |_/¯", "┌[ ◔ ͜ ʖ ◔ ]┐"
                                         };

        string[] lookAtMeImg = new string[] {"C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look.gif",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look1.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look2.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look3.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look4.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look5.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look6.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look7.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look8.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look9.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look10.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look11.jpg",
                                             "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\look12.jpg"};

        string[] danceImg = new string[] { "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\dance.gif",
                                           "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\dance1.gif",
                                           "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\dance3.gif",
                                           "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\dance4.gif",
                                           "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\dance5.gif",
                                           "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\dance6.gif",};


        string[] jokeTitle = new string[40];
        string[] jokeBody = new string[40];
        string[] pornTweets = new string[40];


        public void Start()
        {
            // Initial loading 
            Console.WriteLine("discordBot by Gage Langdon and Jason Odgers");
            Console.WriteLine("Loading...");
            getPornTweets();
            getRedditJokes();  
        }

        //variables for the quiz game
        private string[] questionsandanswers = { "" };
        private bool quizisrunning = false;
        private int randomindexnumber = 0;
        private DateTime quizstartime;

        public string[] ParseCommand(string msg, MessageEventArgs e)
        {
            // c = command
            string[] str_return = new string[2] { "c", " " };

            // main exception catch
            try {

                Random rand = new Random();
                int n; // used for random numbers

                // remove the leading '!'
                string[] parsedMsg = new string[1];
                parsedMsg[0] = msg.TrimStart('!');    // remove the excalamation mark 
                parsedMsg = parsedMsg[0].Split(' ');  // split apart in relation to spaces 


                parsedMsg[0] = parsedMsg[0].ToLower();

                switch (parsedMsg[0])
                {
                    case "help":
                        str_return[0] = "w"; // return msg as whisper 
                        str_return[1] = ("HI! I'M MR MEESEEKS! LOOK AT ME!\n" +
                                        "We are created to serve a singular purpose, for which we will go to any lengths to fulfill!\n" +
                                        "\n\n" +

                                        "When you type certain commands I might do something, Check out the commands you can use below\n\n" +
                                        "!help  - Recieve this help message\n" +
                                        "!promo - tell members about me!\n" +
                                        "!roll [max] - default is out of 100\n" +
                                        "!bunny - meow\n" +
                                        "!yay - celebrate!\n" +
                                        "!joke - recieve a random joke from /r/jokes\n" +
                                        "!cuckme - hope you like em big\n" +
                                        "!hug [@user] - cheer em up!\n" +
                                        "!quiz - recieve a random trivia question (@tapetape)\n" +
                                        "!members - number of users on server\n" +
                                        "!g [search] - LET ME GOOGLE THAT FOR YOU\n" +
                                        "!dongers - RAISE EM\n" +
                                        "!lookatme - LOOK AT ME!!!!11\n" +
                                        "!dance - gnn tss gnn tss\n" +
                                        "!porncomment - random porn comment\n" +
                                        "!fite [@user] - fite me irl br0\n" +
                                        "!tldr - TOO LONG DIDNT READ\n" +

                                        "\n\n" +
                                        "Mr.Meeseeks is being developed by @Grits, pm feedback"
                                        );

                        break;

                    case "bunny":
                        str_return[0] = "i"; // return msg as image
                        str_return[1] = "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\bunny.jpeg";
                        break;

                    case "yay":
                        str_return[0] = "i"; // return msg as image
                        str_return[1] = "C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\yay.gif";
                        e.Channel.SendFile("C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\cuck.jpg");
                        break;

                    case "cuckme":
                        e.Channel.SendMessage(e.Message.User.Mention + " got cucked");
                        e.Channel.SendFile("C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\cuck.jpg");
                        break;

                    case "roll":
                        if (parsedMsg.Length > 1)
                        {

                            int maxVal;

                            // see if user entered a valid number for the max value
                            if (!Int32.TryParse(parsedMsg[1], out maxVal))
                            {
                                // if not a valid param, default is 100
                                maxVal = 100;
                            }

                            int randNum = rand.Next(maxVal);

                            str_return[0] = "m"; // mention calling user
                            str_return[1] = " rolled " + randNum.ToString() + " out of " + maxVal.ToString();
                        }
                        else
                        {

                            int randNum = rand.Next(100);

                            str_return[0] = "m"; // mention calling user
                            str_return[1] = " rolled " + randNum.ToString() + " out of 100";
                        }
                        break;

                    //  Quiz and Answer wrote by Jason Odgers
                    case "quiz":
                        if (!quizisrunning || (e.Message.Timestamp >= quizstartime.AddSeconds(25)))
                        {
                            //Note the time of the start of the quiz
                            quizstartime = e.Message.Timestamp;
                            quizisrunning = true;

                            //Import the list of jokes from file and add them to a list
                            List<string[]> questionsandanswereslist = new List<string[]>();
                            string[] temparray = System.IO.File.ReadAllLines("C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\discordBot\\quizquestions\\questions.txt");
                            foreach (string lines in temparray)
                            {
                                questionsandanswereslist.Add(lines.Split('`'));
                            }

                            //Select a new index from the list of jokes through random number generation.
                            Random randomindexgenerator = new Random();
                            randomindexnumber = randomindexgenerator.Next(questionsandanswereslist.Count());
                            questionsandanswers = questionsandanswereslist.ElementAt(randomindexnumber);
                            e.Channel.SendMessage("You have 25 seconds to get the right answer. To answer, type !answer followed by the answer. \n\n " + questionsandanswers[0]); //+ " " +  questionsandanswers[1]);

                        }

                        else
                        {
                            return null;
                        }

                        break;

                    //  Quiz and Answer wrote by Jason Odgers
                    case "answer":
                        if (quizisrunning) {
                            string answer = " ";
                            string messagetext = e.Message.Text;

                            try {
                                answer = messagetext.Remove(0, 8).ToLower();
                            } catch (Exception) {
                                Console.WriteLine("ERROR: Answer has no argument");
                            }

                            // if no exception
                            if (answer != " ")
                            {
                                if (answer == questionsandanswers[1].ToLower() && e.Message.Timestamp <= quizstartime.AddSeconds(25))
                                {
                                    e.Channel.SendMessage("Congrats " + e.Message.User.Mention + ", You are correct!");
                                    randomindexnumber = 0;
                                    quizisrunning = false;
                                }
                                else
                                {
                                    return null;
                                }
                            }
                        }
                        // send answer to channel if time ended with not correct answer
                        //else if (e.Message.Timestamp >= quizstartime.AddSeconds(25))
                        //{
                        //    e.Channel.SendMessage("The correct answer was " + questionsandanswers[1]);
                        //}


                        break;

                    case "members":
                        int totalMemCount = e.Server.Users.Count();
                        int onlineMemCount = e.Server.Users.Count(x => x.Status == UserStatus.Online);
                        str_return[1] = e.Server.Name + "\n\n" +
                                        "Total members: " + totalMemCount + "\n" +
                                        "Online members: " + onlineMemCount;
                        break;

                    case "joke":
                        // return a random joke from the list
                        n = rand.Next(jokeTitle.Length - 1);
                        e.Channel.SendMessage(jokeTitle[n] + "\n\n" + jokeBody[n]);
                        break;

                    case "dongers":
                        n = rand.Next(dongers.Length - 1);
                        e.Channel.SendMessage(dongers[n]);
                        break;

                    case "g":
                        e.Channel.SendMessage("Here you go ");
                        string link = "https://www.google.com/search?q=";

                        for (int i = 1; i < parsedMsg.Length; i++)
                        {
                            link = link + parsedMsg[i] + "+";
                        }

                        e.Channel.SendMessage(link);
                        break;

                    case "promo":
                        e.Channel.SendFile("C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\promo.jpg");
                        break;

                    case "porncomment":
                        n = rand.Next(pornTweets.Length - 1);
                        e.Channel.SendMessage(pornTweets[n]);
                        break;

                    case "lookatme":
                        n = rand.Next(lookAtMeImg.Length - 1);
                        e.Channel.SendFile(lookAtMeImg[n]);
                        break;

                    case "dance":
                        n = rand.Next(danceImg.Length - 1);
                        e.Channel.SendFile(danceImg[n]);
                        break;

                    case "tldr":
                        e.Channel.SendFile("C:\\Users\\gagel\\Documents\\GitHub\\discordBot\\images\\tldr.gif");
                        break;

                    case "hug":
                        e.Channel.SendMessage(e.Message.User.Mention + " hugged " + e.Message.MentionedUsers.First().Mention);
                        break;

                    case "fite":
                        n = rand.Next(2);
                        if (n == 0)
                        {
                            e.Channel.SendMessage(e.Message.User.Mention + " won the fite against " + e.Message.MentionedUsers.First().Mention);
                        }
                        else
                        {
                            e.Channel.SendMessage(e.Message.MentionedUsers.First().Mention + " won the fite against " + e.Message.User.Mention);
                        }
                        break;

                    case "clear":

                       List<Discord.Message> m = e.Channel.Messages.ToList<Discord.Message> ();
                       int numMessages = m.Count();

                       string channelname = e.Channel.Name;
                       e.Server.GetChannel(e.Channel.Id).Delete();
                       e.Server.CreateChannel(channelname, ChannelType.Text);
                       List<Discord.Channel> newChannel = e.Server.FindChannels(channelname).ToList<Discord.Channel>();

                       // should only be one but the api pulls a list
                       foreach (Discord.Channel c in newChannel)
                       {
                           e.Server.GetChannel(c.Id).SendMessage(numMessages + " messages were deleted");
                       }

                       Console.WriteLine(numMessages + " messages were deleted");
                       break;

                    default:

                        return null;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: An exception occured in parseText.cs");
            }

            if (str_return[1] == " ")
            {
                return null;
            }
            return str_return;
        }

        // use for mentions of users
        public string ParseCommand(string msg, Discord.User[] user)
        {

            return " ";
        }

        public string[] ParseMessage(string msg,MessageEventArgs e)
        {

            string[] str_return = new string[2] { "c", " " };

            string[] parsedMsg = msg.Split(' ');


            for (int i = 0; i < parsedMsg.Length; i++)
            {
                // echoes message contents to console for debug purposes
                //Console.WriteLine(parsedMsg[i]);
                switch (parsedMsg[i])
                {

                    default:
                        str_return[0] = null;
                        break;

                }
            }

            if (str_return[1] == " ")
            {
                return null;
            }
            return str_return;
        }


        private void getRedditJokes()
        {
            Console.WriteLine("Caching /r/jokes");
            Reddit reddit = new Reddit();

            var subreddit = reddit.GetSubreddit("/r/jokes");

            // get 20 of the current hot jokes
            int i = 0;
            foreach (var post in subreddit.Hot.Take(40))
            {
                jokeTitle[i] = post.Title.ToString();
                if (post.SelfText.Any())
                {
                    jokeBody[i] = post.SelfText.ToString();
                }
                i++;
            }
        }


        private void getPornTweets()
        {
            Console.WriteLine("Caching porn comment tweets");

            try {
                // authenticate and connect to the twitter api
                Auth.SetUserCredentials("5bzCIcNofQXZ8kpCkwYLNo9Pp",
                    "DQ0YZLInDBUnWyCcte9KBs5G1wQriNSzAzCVsI3lG0LT9GXUW2",
                    "712137448994648065-D2tmKQq0Njn2dR8vB1tnHCB7Kk0KKPi",
                    "ct0WJYVEEAeXWYlzG52oAtvxz85QuCJindnI1VDUqCy6c");

                // get the top 40 tweets
                var tweets = Timeline.GetUserTimeline("wisewordsofporn", 40);

                for (int i = 0; i < tweets.Count(); i++)
                {
                    pornTweets[i] = tweets.ElementAt(i).Text;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("ERROR: exception thrown in getPornTweets()");
            }
            
        }







    }
}
