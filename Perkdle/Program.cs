using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using Perks;
using PerkSetup;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static List<Perk> PerkList = new List<Perk>();
        static void Main(string[] args)
        {
            /*
            2016
                Dwight          Trapper
                Meg             Wraith
                Claude          Billy
                Jake
                Nea             Nurse
                Laurie          Myers
                Ace             Hag

            2017
                Bill
                Feng            Doctor
                David           Huntress
                                Bubba
                Quentin         Freddy

            2018
                Tapp            Pig
                Kate            Clown
                Adam            Spirit
                Jeff            Legion

            2019
                Jane            Plague
                Ash
                                Ghost Face
                Steve           Demo
                Nancy
                Yui             Oni

            2020
                Zarina          Deathslinger
                Cheryl          Pyramid Head
                Felix           Blight
                Elodie          Twins

            2021
                Yun-Jin       Trickster
                Leon            Nemi
                Jill
                                Pinhead
                Mikaela
                Jonah           Artist

            2022
                Yoichi          Onryo
                Haddie          Dredge
                Ada             Wesker
                Rebecca
                Vittorio        Knight

            2023
                Thalita         Skull Merchant
                Renato
                Gabriel         Singularity
                Nicolas
                -------------------------------
                Ellen           Xenomorph
                                Good Guy
                Alan
            2024
                Sable           Unknown
                Aestri          Lich
                Up to 8.0.0 (Before Lara Croft)
            */
            //Item/Exhaustion/Aura/Healing/Hook/Pallet/Gen/Skill Check/Obsession/Carrying/Totem/Haste/Scratch Marks/Locker/Recovery/Window/Scream/Injured/Healthy/Broken/Terror Radius/Undedectable/End Game/Blood/Grunts of Pain/Exposed/Oblivious/Endurance/Blinds/Crow
            //Scratch Marks, Grunts of Pain, Blood, and Crouching one category??? Stealth????


            //Make mode where it gives you the effects of perk and u need to guess which one it is, it gives hints with bad guesses

            //Blocked Gens category?

            PerkList.Add(new Perk("Ace in the Hole", "Survivor", "Ace", new List<string> { "Item" }, 2016));
            PerkList.Add(new Perk("Adrenaline", "Survivor", "Meg", new List<string> { "Healing", "Exhaustion", "End Game" }, 2016));
            PerkList.Add(new Perk("Aftercare", "Survivor", "Jeff", new List<string> { "Aura", "Healing", "Hook" }, 2018));
            PerkList.Add(new Perk("Alert", "Survivor", "Feng", new List<string> { "Aura" }, 2017));
            PerkList.Add(new Perk("Any Means Necessary", "Survivor", "Yui", new List<string> { "Pallet", "Aura" }, 2019));
            PerkList.Add(new Perk("Appraisal", "Survivor", "Elodie", new List<string> { "Item" }, 2020));
            PerkList.Add(new Perk("Autodidact", "Survivor", "Adam", new List<string> { "Healing", "Skill Check" }, 2018));
            PerkList.Add(new Perk("Babysitter", "Survivor", "Steve", new List<string> { "Scratch Marks", "Haste", "Aura", "Hook", "Blood" }, 2019));
            PerkList.Add(new Perk("Background Player", "Survivor", "Renato", new List<string> { "Exhaustion" }, 2023));
            PerkList.Add(new Perk("Balanced Landing", "Survivor", "Nea", new List<string> { "Exhaustion" }, 2016));

            PerkList.Add(new Perk("Bardic Inspiration", "Survivor", "Aestri", new List<string> { "Gen", "Skill Check" }, 2024));
            PerkList.Add(new Perk("Better Together", "Survivor", "Nancy", new List<string> { "Gen", "Aura" }, 2019));
            PerkList.Add(new Perk("Better than New", "Survivor", "Rebecca", new List<string> { "Healing" }, 2022));
            PerkList.Add(new Perk("Bite the Bullet", "Survivor", "Leon", new List<string> { "Healing", "Grunts of Pain" }, 2021));
            PerkList.Add(new Perk("Blast Mine", "Survivor", "Jill", new List<string> { "Gen", "Aura", "Blind" }, 2021));
            PerkList.Add(new Perk("Blood Pact", "Survivor", "Cheryl", new List<string> { "Obsession", "Haste", "Aura", "Injured" }, 2020));
            PerkList.Add(new Perk("Blood Rush", "Survivor", "Renato", new List<string> { "Exhaustion", "Broken", "Healthy" }, 2023));
            PerkList.Add(new Perk("Boil Over", "Survivor", "Kate", new List<string> { "Aura", "Carrying" }, 2018));
            PerkList.Add(new Perk("Bond", "Survivor", "Dwight", new List<string> { "Aura" }, 2016));
            PerkList.Add(new Perk("Boon: Circle of Healing", "Survivor", "Mikaela", new List<string> { "Totem", "Healing", "Aura", "Injured" }, 2021));
            
            PerkList.Add(new Perk("Boon: Dark Theory", "Survivor", "Yoichi", new List<string> { "Totem", "Haste" }, 2022));
            PerkList.Add(new Perk("Boon: Exponential", "Survivor", "Jonah", new List<string> { "Totem", "Recovery" }, 2021));
            PerkList.Add(new Perk("Boon: Illumination", "Survivor", "Alan", new List<string> { "Totem", "Aura", "Item", "Gen" }, 2023));
            //Item instead of Chest which would fit better?
            PerkList.Add(new Perk("Boon: Shadow Step", "Survivor", "Mikaela", new List<string> { "Totem", "Aura", "Scratch Marks" }, 2021));
            PerkList.Add(new Perk("Borrowed Time", "Survivor", "Bill", new List<string> { "Hook", "Haste", "Endurance" }, 2017));
            PerkList.Add(new Perk("Botany Knowledge", "Survivor", "Claudette", new List<string> { "Healing" }, 2016));
            PerkList.Add(new Perk("Breakdown", "Survivor", "Jeff", new List<string> { "Hook", "Aura" }, 2018));
            PerkList.Add(new Perk("Breakout", "Survivor", "Yui", new List<string> { "Carrying", "Haste" }, 2019));
            PerkList.Add(new Perk("Buckle Up", "Survivor", "Ash", new List<string> { "Recovery", "Aura", "Haste" }, 2019));
            PerkList.Add(new Perk("Built to Last", "Survivor", "Felix", new List<string> { "Item", "Locker"}, 2020));

            PerkList.Add(new Perk("Calm Spirit", "Survivor", "Jake", new List<string> { "Totem", "Scream" }, 2016));
            PerkList.Add(new Perk("Camaraderie", "Survivor", "Steve", new List<string> { "Hook" }, 2019));
            //^^^ also bad
            PerkList.Add(new Perk("Champion of Light", "Survivor", "Alan", new List<string> { "Item", "Haste", "Blind" }, 2023));
            //Maybe add hindered as a possible category
            PerkList.Add(new Perk("Chemical Trap", "Survivor", "Ellen", new List<string> { "Pallet", "Gen", "Aura" }, 2023));
            PerkList.Add(new Perk("Clairvoyance", "Survivor", "Mikaela", new List<string> { "Totem", "Hatch" }, 2021));
            PerkList.Add(new Perk("Corrective Action", "Survivor", "Jonah", new List<string> { "Skill Check" }, 2021));
            PerkList.Add(new Perk("Counterforce", "Survivor", "Jill", new List<string> { "Totem", "Aura" }, 2021));
            PerkList.Add(new Perk("Cut Loose", "Survivor", "Thalita", new List<string> { "Window", "Pallet" }, 2023));
            PerkList.Add(new Perk("Dance With Me", "Survivor", "Kate", new List<string> { "Window", "Pallet", "Scratch Marks" }, 2018));
            PerkList.Add(new Perk("Dark Sense", "Survivor", "Universal", new List<string> { "Gen", "Aura" }, 2016));

            PerkList.Add(new Perk("Dead Hard", "Survivor", "David", new List<string> { "Exhaustion", "Injured", "Endurance" }, 2017));
            PerkList.Add(new Perk("Deadline", "Survivor", "Alan", new List<string> { "Gen", "Skill Check", "Injured", "Healing" }, 2023));
            PerkList.Add(new Perk("Deception", "Survivor", "Elodie", new List<string> { "Locker", "Scratch Marks", "Blood" }, 2020));
            PerkList.Add(new Perk("Decisive Strike", "Survivor", "Laurie", new List<string> { "Carrying", "Skill Check", "Obsession" }, 2016));
            PerkList.Add(new Perk("Deliverance", "Survivor", "Adam", new List<string> { "Hook", "Broken" }, 2018));
            PerkList.Add(new Perk("Desperate Measures", "Survivor", "Felix", new List<string> { "Healing", "Hook" }, 2020));
            PerkList.Add(new Perk("Detective's Hunch", "Survivor", "Tapp", new List<string> { "Aura", "Totem", "Gen" }, 2018));
            PerkList.Add(new Perk("Distortion", "Survivor", "Jeff", new List<string> { "Terror Radius", "Aura", "Scratch Marks" }, 2018));
            PerkList.Add(new Perk("Diversion", "Survivor", "Adam", new List<string> { "Terror Radius", "Scratch Marks" }, 2018));
            PerkList.Add(new Perk("Dramaturgy", "Survivor", "Nicolas", new List<string> { "Exhaustion", "Haste", "Item", "Scream", "Healthy", "Exposed" }, 2023));
            
            PerkList.Add(new Perk("Deja Vu", "Survivor", "Universal", new List<string> { "Aura", "Gen" }, 2016));
            PerkList.Add(new Perk("Empathic Connection", "Survivor", "Yoichi", new List<string> { "Aura", "Healing", "Injured" }, 2022));
            PerkList.Add(new Perk("Empathy", "Survivor", "Claudette", new List<string> { "Aura", "Healing","Injured" }, 2016));
            PerkList.Add(new Perk("Fast Track", "Survivor", "Yun-Jin", new List<string> { "Skill Check", "Gen" }, 2021));
            PerkList.Add(new Perk("Fixated", "Survivor", "Nancy", new List<string> { "Scratch Marks" }, 2019));
            PerkList.Add(new Perk("Flashbang", "Survivor", "Leon", new List<string> { "Gen", "Locker" }, 2021));
            PerkList.Add(new Perk("Flip-Flop", "Survivor", "Ash", new List<string> { "Recovery", "Carrying" }, 2019));
            PerkList.Add(new Perk("Fogwise", "Survivor", "Vittorio", new List<string> { "Aura", "Skill Check", "Gen" }, 2022));
            PerkList.Add(new Perk("For the People", "Survivor", "Zarina", new List<string> { "Healing", "Obsession", "Broken", "Healthy" }, 2020));
            PerkList.Add(new Perk("Friendly Competition", "Survivor", "Thalita", new List<string> { "Gen" }, 2023));

            PerkList.Add(new Perk("Head On", "Survivor", "Jane", new List<string> { "Locker", "Exhaustion" }, 2019));
            PerkList.Add(new Perk("Hope", "Survivor", "Universal", new List<string> { "Haste", "End Game" }, 2016));
            PerkList.Add(new Perk("Hyperfocus", "Survivor", "Rebecca", new List<string> { "Gen", "Skill Check"}, 2022));
            PerkList.Add(new Perk("Inner Focus", "Survivor", "Haddie", new List<string> { "Scratch Marks", "Aura" }, 2022));
            PerkList.Add(new Perk("Inner Strength", "Survivor", "Nancy", new List<string> { "Totem", "Healing","Injured"}, 2019));
            PerkList.Add(new Perk("Invocation: Weaving Spiders", "Survivor", "Sable", new List<string> { "Broken", "Gen", "Aura" }, 2024));
            //Add basement for huntress basement perk, monstrous shrine + sable perks?
            PerkList.Add(new Perk("Iron Will", "Survivor", "Jake", new List<string> { "Exhaustion", "Injured", "Grunts of Pain"}, 2016));
            PerkList.Add(new Perk("Kindred", "Survivor", "Universal", new List<string> { "Hook", "Aura"}, 2016));
            PerkList.Add(new Perk("Leader", "Survivor", "Dwight", new List<string> { "Totem", "Healing", "Hook"}, 2016));
            PerkList.Add(new Perk("Left Behind", "Survivor", "Bill", new List<string> { "Aura", "End Game" }, 2017));

            PerkList.Add(new Perk("Light-Footed", "Survivor", "Ellen", new List<string> { "Footsteps", "Window" }, 2023));
            //Unique effect no footsteps anywhere in this game (maybe add?)
            PerkList.Add(new Perk("Lightweight", "Survivor", "Universal", new List<string> { "Scratch Marks" }, 2016));
            PerkList.Add(new Perk("Lithe", "Survivor", "Feng", new List<string> { "Exhaustion", "Window", "Pallet" }, 2017));
            PerkList.Add(new Perk("Low Profile", "Survivor", "Ada", new List<string> { "Scratch Marks", "End Game", "Blood", "Grunts of Pain" }, 2022));
            PerkList.Add(new Perk("Lucky Break", "Survivor", "Yui", new List<string> { "Scratch Marks", "Injured", "Blood" }, 2019));
            PerkList.Add(new Perk("Lucky Star", "Survivor", "Ellen", new List<string> { "Grunts of Pain", "Blood", "Locker", "Gen", "Aura" }, 2023));
            PerkList.Add(new Perk("Made for This", "Survivor", "Gabriel", new List<string> { "Haste", "Injured", "Endurance"}, 2023));
            PerkList.Add(new Perk("Mettle of Man", "Survivor", "Ash", new List<string> { "Obsession", "Aura", "Injured" }, 2019));
            PerkList.Add(new Perk("Mirrored Illusion", "Survivor", "Aestri", new List<string> { "Gen", "Item", "Totem" }, 2024));
            PerkList.Add(new Perk("No Mither", "Survivor", "David", new List<string> { "Broken", "Recovery", "Blood", "Grunts of Pain" }, 2017));
            
            PerkList.Add(new Perk("No One Left Behind", "Survivor", "Universal", new List<string> { "Hook", "Healing", "Haste", "Aura", "End Game" }, 2016));
            PerkList.Add(new Perk("Object of Obsession", "Survivor", "Laurie", new List<string> { "Obsession", "Aura" }, 2016));
            PerkList.Add(new Perk("Off the Record", "Survivor", "Zarina", new List<string> { "Hook", "Aura", "Grunts of Pain", "Endurance" }, 2020));
            PerkList.Add(new Perk("Open-Handed", "Survivor", "Ace", new List<string> { "Aura" }, 2016));
            PerkList.Add(new Perk("Overcome", "Survivor", "Jonah", new List<string> { "Exhaustion", "Injured" }, 2021));
            PerkList.Add(new Perk("Overzealous", "Survivor", "Haddie", new List<string> { "Totem", "Gen", "Healthy" }, 2022));
            PerkList.Add(new Perk("Parental Guidance", "Survivor", "Yoichi", new List<string> { "Scartch Mark", "Pallet", "Blood", "Grunts of Pain" }, 2022));
            PerkList.Add(new Perk("Pharmacy", "Survivor", "Quentin", new List<string> { "Item" }, 2017));
            PerkList.Add(new Perk("Plot Twist", "Survivor", "Nicolas", new List<string> { "Injured", "Recvoery", "Haste", "Grunts of Pain", "Blood" }, 2023));
            PerkList.Add(new Perk("Plunder's Instinct", "Survivor", "Universal", new List<string> { "Item", "Aura" }, 2016));
            
            PerkList.Add(new Perk("Poised", "Survivor", "Jane", new List<string> { "Gen", "Scratch Marks" }, 2019));
            PerkList.Add(new Perk("Potential Energy", "Survivor", "Vittorio", new List<string> { "Gen", "Healthy" }, 2022));
            PerkList.Add(new Perk("Power Struggle", "Survivor", "Elodie", new List<string> { "Aura", "Pallet", "Carrying" }, 2020));
            PerkList.Add(new Perk("Premonition", "Survivor", "Universal", new List<string> { "Aura" }, 2016));
            //^^ This just doesnt fit but what do I do????
            PerkList.Add(new Perk("Prove Thyself", "Survivor", "Dwight", new List<string> { "Gen" }, 2016));
            PerkList.Add(new Perk("Quick and Quiet", "Survivor", "Meg", new List<string> { "Window", "Pallet", "Locker" }, 2016));
            PerkList.Add(new Perk("Quick Gambit", "Survivor", "Vittorio", new List<string> { "Gen", "Aura" }, 2022));
            PerkList.Add(new Perk("Reactive Healing", "Survivor", "Ada", new List<string> { "Healing", "Injured" }, 2022));
            PerkList.Add(new Perk("Reassurance", "Survivor", "Rebecca", new List<string> { "Hook", "Skill Check" }, 2022));
            PerkList.Add(new Perk("Red Herring", "Survivor", "Zarina", new List<string> { "Gen", "Aura", "Locker" }, 2020));

            PerkList.Add(new Perk("Repressed Alliance", "Survivor", "Cheryl", new List<string> { "Gen", "Aura" }, 2020));
            PerkList.Add(new Perk("Residual Manifest", "Survivor", "Haddie", new List<string> { "Item", "Aura", "Blind" }, 2022));
            PerkList.Add(new Perk("Resilience", "Survivor", "Universal", new List<string> { "Injured", "Gen", "Totems", "Healing", "Hook", "Window", "Pallet" }, 2016));
            PerkList.Add(new Perk("Resurgence", "Survivor", "Jill", new List<string> { "Hook", "Healing" }, 2021));
            PerkList.Add(new Perk("Rookie Spirit", "Survivor", "Leon", new List<string> { "Gen", "Skill Check", "Aura" }, 2021));
            PerkList.Add(new Perk("Saboteur", "Survivor", "Jake", new List<string> { "Carrying", "Aura"}, 2016));
            PerkList.Add(new Perk("Scavenger", "Survivor", "Gabriel", new List<string> { "Item", "Skill Check", "Gen" }, 2023));
            PerkList.Add(new Perk("Scene Partner", "Survivor", "Nicolas", new List<string> { "Terror Radius", "Scream", "Aura" }, 2023));
            PerkList.Add(new Perk("Second Wind", "Survivor", "Steve", new List<string> { "Healing", "Hook", "Broken", "Healthy" }, 2019));
            PerkList.Add(new Perk("Self-Care", "Survivor", "Claudette", new List<string> { "Healing" }, 2016));

            PerkList.Add(new Perk("Self-Preservation", "Survivor", "Yun-Jin", new List<string> { "Injured", "Scratch Marks", "Grunts of Pain", "Blood" }, 2021));
            PerkList.Add(new Perk("Slippery Meat", "Survivor", "Universal", new List<string> { "Hook" }, 2016));
            PerkList.Add(new Perk("Small Game", "Survivor", "Universal", new List<string> { "Totem" }, 2016));
            PerkList.Add(new Perk("Smash Hit", "Survivor", "Yun-Jin", new List<string> { "Exhaustion", "Pallet" }, 2021));
            PerkList.Add(new Perk("Sole Survivor", "Survivor", "Laurie", new List<string> { "Gen", "Obsession", "End Game" }, 2016));
            PerkList.Add(new Perk("Solidarity", "Survivor", "Jane", new List<string> { "Healing" }, 2019));
            PerkList.Add(new Perk("Soul Guard", "Survivor", "Cheryl", new List<string> { "Recovery", "Totem", "Endurance" }, 2020));
            PerkList.Add(new Perk("Spine Chill", "Survivor", "Universal", new List<string> { "Gen", "Healing", "Hook", "Totem" }, 2016));
            PerkList.Add(new Perk("Sprint Burst", "Survivor", "Meg", new List<string> { "Exhaustion" }, 2016));
            PerkList.Add(new Perk("Stake Out", "Survivor", "Tapp", new List<string> { "Gen", "Healing", "Skill Check", "Terror Radius" }, 2018));
            
            PerkList.Add(new Perk("Still Sight", "Survivor", "Aestri", new List<string> { "Aura", "Gen", "Item" }, 2024));
            PerkList.Add(new Perk("Streetwise", "Survivor", "Nea", new List<string> { "Item" }, 2016));
            PerkList.Add(new Perk("Strength in Shadows", "Survivor", "Sable", new List<string> { "Healing", "Aura" }, 2024));
            PerkList.Add(new Perk("Teamwork: Collective Stealth", "Survivor", "Renato", new List<string> { "Healing", "Scratch Marks" }, 2023));
            PerkList.Add(new Perk("Teamwork: Power of Two", "Survivor", "Thalita", new List<string> { "Healing", "Haste" }, 2023));
            PerkList.Add(new Perk("Technician", "Survivor", "Feng", new List<string> { "Gen", "Skill Check" }, 2017));
            PerkList.Add(new Perk("Tenacity", "Survivor", "Tapp", new List<string> { "Recovery", "Grunts of Pain" }, 2018));
            PerkList.Add(new Perk("This is Not Happening", "Survivor", "Universal", new List<string> { "Gen", "Healing", "Skill Check" }, 2016));
            PerkList.Add(new Perk("Troubleshooter", "Survivor", "Gabriel", new List<string> { "Gen", "Aura", "Pallet" }, 2023));
            PerkList.Add(new Perk("Unbreakable", "Survivor", "Bill", new List<string> { "Recovery" }, 2017));
            
            PerkList.Add(new Perk("Up the Ante", "Survivor", "Ace", new List<string> { "Luck" }, 2016));
            PerkList.Add(new Perk("Urban Evasion", "Survivor", "Nea", new List<string> { "Crouch" }, 2016));
            //^^^ uhhhhhhhhhhhh
            PerkList.Add(new Perk("Vigil", "Survivor", "Quentin", new List<string> { "Exhaustion", "Exposed", "Oblivious", "Blind" }, 2017));
            PerkList.Add(new Perk("Visionary", "Survivor", "Felix", new List<string> { "Gen", "Aura" }, 2020));
            PerkList.Add(new Perk("Wake Up!", "Survivor", "Quentin", new List<string> { "Aura", "End Game" }, 2017));
            PerkList.Add(new Perk("We'll Make It", "Survivor", "Universal", new List<string> { "Hook", "Healing" }, 2016));
            PerkList.Add(new Perk("We're Gonna Live Forever", "Survivor", "David", new List<string> { "Hook", "Recovery", "Endurance", "Blind" }, 2017));
            PerkList.Add(new Perk("Wicked", "Survivor", "Sable", new List<string> { "Aura", "Hook" }, 2024));
            PerkList.Add(new Perk("Windows of Opportunity", "Survivor", "Kate", new List<string> { "Aura", "Pallet", "Window" }, 2018));
            PerkList.Add(new Perk("Wiretap", "Survivor", "Ada", new List<string> { "Gen", "Aura" }, 2022));




            PerkList.Add(new Perk("A Nurse's Calling", "Killer", "Nurse", new List<string> { "Aura", "Healing" }, 2016));
            PerkList.Add(new Perk("Agitation", "Killer", "Trapper", new List<string> { "Carrying", "Haste", "Terror Radius" }, 2016));
            PerkList.Add(new Perk("Alien Instinct", "Killer", "Xenomorph", new List<string> { "Aura", "Oblivious" }, 2023));
            PerkList.Add(new Perk("Awakened Awareness", "Killer", "Mastermind", new List<string> { "Carrying", "Aura" }, 2022));
            PerkList.Add(new Perk("Bamboozle", "Killer", "Clown", new List<string> { "Window" }, 2018));
            PerkList.Add(new Perk("Barbecue & Chilli", "Killer", "Cannibal", new List<string> { "Hook", "Aura" }, 2017));
            PerkList.Add(new Perk("Batteries Included", "Killer", "Good Guy", new List<string> { "Gen", "Haste" }, 2023));
            PerkList.Add(new Perk("Beast of Prey", "Killer", "Huntress", new List<string> { "Undetectable" }, 2017));
            PerkList.Add(new Perk("Bitter Murmur", "Killer", "Universal", new List<string> { "Gen", "Aura" }, 2016));
            PerkList.Add(new Perk("Blood Echo", "Killer", "Oni", new List<string> { "Hook", "Exhaustion" }, 2019));

            PerkList.Add(new Perk("Blood Warden", "Killer", "Nightmare", new List<string> { "End Game", "Aura" }, 2017));
            PerkList.Add(new Perk("Bloodhound", "Killer", "Wraith", new List<string> { "Blood" }, 2016));
            PerkList.Add(new Perk("Brutal Strength", "Killer", "Trapper", new List<string> { "Pallet", "Gen" }, 2016));
            PerkList.Add(new Perk("Call of Brine", "Killer", "Onryo", new List<string> { "Gen", "Aura" }, 2022));
            PerkList.Add(new Perk("Corrupt Intervention", "Killer", "Plague", new List<string> { "Gen", "Recovery" }, 2019));
            PerkList.Add(new Perk("Coulrophobia", "Killer", "Clown", new List<string> { "Healing", "Skill Check" }, 2018));
            PerkList.Add(new Perk("Coup de Grace", "Killer", "Twins", new List<string> { "Gen" }, 2020));
            //^^bad
            PerkList.Add(new Perk("Cruel Limits", "Killer", "Demogorgon", new List<string> { "Gen", "Window", "Aura" }, 2019));
            PerkList.Add(new Perk("Dark Arrogance", "Killer", "Lich", new List<string> { "Window", "Blind", "Pallet" }, 2024));
            PerkList.Add(new Perk("Dark Devotion", "Killer", "Plague", new List<string> { "Obsession", "Terror Radius", "Undetectable" }, 2019));

            PerkList.Add(new Perk("Darkness Revealed", "Killer", "Dredge", new List<string> { "Locker", "Aura" }, 2022));
            PerkList.Add(new Perk("Dead Man's Switch", "Killer", "Deathslinger", new List<string> { "Gen", "Aura" }, 2020));
            PerkList.Add(new Perk("Deadlock", "Killer", "Cenobite", new List<string> { "Gen", "Aura" }, 2021));
            PerkList.Add(new Perk("Deathbound", "Killer", "Executioner", new List<string> { "Healing", "Scream", "Oblivious" }, 2020));
            PerkList.Add(new Perk("Deerstalker", "Killer", "Universal", new List<string> { "Aura", "Recovery" }, 2016));
            PerkList.Add(new Perk("Discordance", "Killer", "Legion", new List<string> { "Gen", "Aura" }, 2018));
            PerkList.Add(new Perk("Dissolution", "Killer", "Dredge", new List<string> { "Injured", "Pallet", "Terror Radius" }, 2022));
            PerkList.Add(new Perk("Distressing", "Killer", "Universal", new List<string> { "Terror Radius" }, 2016));
            PerkList.Add(new Perk("Dragon's Grip", "Killer", "Blight", new List<string> { "Gen", "Scream", "Exposed" }, 2020));
            PerkList.Add(new Perk("Dying Light", "Killer", "Shape", new List<string> { "Obsession", "Gen", "Healing" }, 2016));

            PerkList.Add(new Perk("Enduring", "Killer", "Hillbilly", new List<string> { "Pallet" }, 2016));
            PerkList.Add(new Perk("Eruption", "Killer", "Nemesis", new List<string> { "Gen", "Aura", "Scream", "Recovery" }, 2021));
            PerkList.Add(new Perk("Fire Up", "Killer", "Nightmare", new List<string> { "Gen", "Window", "Pallet" }, 2017));
            PerkList.Add(new Perk("Forced Hesitation", "Killer", "Singularity", new List<string> { "Recovery" }, 2023));
            PerkList.Add(new Perk("Forced Penance", "Killer", "Executioner", new List<string> { "Injured" }, 2020));
            PerkList.Add(new Perk("Franklin's Demise", "Killer", "Cannibal", new List<string> { "Item", "Injured", "Aura" }, 2017));
            PerkList.Add(new Perk("Friends 'til the End", "Killer", "Good Guy", new List<string> { "Aura", "Exposed", "Obsession", "Scream" }, 2023));
            PerkList.Add(new Perk("Furtive Chase", "Killer", "Ghost Face", new List<string> { "Obsession", "Hook", "Terror Radius", "Haste" }, 2019));
            PerkList.Add(new Perk("Game Afoot", "Killer", "Skull Merchant", new List<string> { "Haste", "Obsession", "Pallet", "Gen" }, 2023));
            PerkList.Add(new Perk("Gearhead", "Killer", "Deathslinger", new List<string> { "Injured", "Skill Check", "Aura" }, 2020));

            PerkList.Add(new Perk("Genetic Limits", "Killer", "Singularity", new List<string> { "Exhaustion", "Healing" }, 2023));
            PerkList.Add(new Perk("Grim Embrace", "Killer", "Artist", new List<string> { "Hook", "Gen", "Aura" }, 2021));
            PerkList.Add(new Perk("Hex: Blood Favour", "Killer", "Blight", new List<string> { "Totem", "Pallet", "Injured" }, 2020));
            PerkList.Add(new Perk("Hex: Crowd Control", "Killer", "Trickster", new List<string> { "Totem", "Window" }, 2021));
            PerkList.Add(new Perk("Hex: Devour Hope", "Killer", "Hag", new List<string> { "Totem", "Exposed", "Haste", "Hook" }, 2016));
            PerkList.Add(new Perk("Hex: Face the Darkness", "Killer", "Knight", new List<string> { "Totem", "Injured", "Scream" }, 2022));
            PerkList.Add(new Perk("Hex: Haunted Ground", "Killer", "Spirit", new List<string> { "Totem", "Exposed" }, 2018));
            PerkList.Add(new Perk("Hex: Huntress Lullaby", "Killer", "Huntress", new List<string> { "Totem", "Healing", "Gen", "Skill Check" }, 2017));
            PerkList.Add(new Perk("Hex: No One Escapes Death", "Killer", "Universal", new List<string> { "Totem", "End Game", "Exposed", "Aura" }, 2016));
            PerkList.Add(new Perk("Hex: Pentimento", "Killer", "Artist", new List<string> { "Totem", "Gen", "Healing" }, 2021));

            PerkList.Add(new Perk("Hex: Plaything", "Killer", "Cenobite", new List<string> { "Totem", "Aura", "Oblivious" }, 2021));
            PerkList.Add(new Perk("Hex: Retribution", "Killer", "Deathslinger", new List<string> { "Totem", "Aura", "Oblivious" }, 2020));
            PerkList.Add(new Perk("Hex: Ruin", "Killer", "Hag", new List<string> { "Totem", "Gen" }, 2016));
            PerkList.Add(new Perk("Hex: The Third Seal", "Killer", "Hag", new List<string> { "Totem", "Injured", "Blind" }, 2016));
            PerkList.Add(new Perk("Hex: Thrill of the Hunt", "Killer", "Universal", new List<string> { "Totem" }, 2016));
            PerkList.Add(new Perk("Hex: Two Can Play", "Killer", "Good Guy", new List<string> { "Totem", "Blind" }, 2023));
            PerkList.Add(new Perk("Hex: Undying", "Killer", "Blight", new List<string> { "Totem" }, 2020));
            PerkList.Add(new Perk("Hoarder", "Killer", "Twins", new List<string> { "Item" }, 2020));
            PerkList.Add(new Perk("Hubris", "Killer", "Knight", new List<string> { "Exposed", "Pallet", "Locker" }, 2022));
            PerkList.Add(new Perk("Hysteria", "Killer", "Nemesis", new List<string> { "Injured", "Oblivious" }, 2021));

            PerkList.Add(new Perk("I'm All Ears", "Killer", "Ghost Face", new List<string> { "Pallet", "Window", "Aura" }, 2019));
            PerkList.Add(new Perk("Infectious Fright", "Killer", "Plague", new List<string> { "Recovery", "Scream" }, 2019));
            PerkList.Add(new Perk("Insidious", "Killer", "Universal", new List<string> { "Undetectable" }, 2016));
            PerkList.Add(new Perk("Iron Grasp", "Killer", "Universal", new List<string> { "Carrying" }, 2016));
            PerkList.Add(new Perk("Iron Maiden", "Killer", "Legion", new List<string> { "Locker", "Exposed" }, 2018));
            PerkList.Add(new Perk("Knock Out", "Killer", "Cannibal", new List<string> { "Recovery", "Aura", "Blind" }, 2017));
            PerkList.Add(new Perk("Languid Touch", "Killer", "Lich", new List<string> { "Exhaustion", "Crow" }, 2024));
            PerkList.Add(new Perk("Lethal Pursuer", "Killer", "Nemesis", new List<string> { "Aura" }, 2021));
            PerkList.Add(new Perk("Leverage", "Killer", "Skull Merchant", new List<string> { "Hook", "Healing" }, 2023));
            PerkList.Add(new Perk("Lightborn", "Killer", "Hillbilly", new List<string> { "Aura", "Blind" }, 2016));

            PerkList.Add(new Perk("Machine Learning", "Killer", "Singularity", new List<string> { "Gen", "Haste", "Undetectable" }, 2023));
            PerkList.Add(new Perk("Mad Grit", "Killer", "Legion", new List<string> { "Carrying" }, 2018));
            PerkList.Add(new Perk("Make Your Choice", "Killer", "Pig", new List<string> { "Hook", "Scream", "Exposed" }, 2018));
            PerkList.Add(new Perk("Merciless Storm", "Killer", "Onryo", new List<string> { "Gen", "Skill Check" }, 2022));
            PerkList.Add(new Perk("Mindbreaker", "Killer", "Demogorgon", new List<string> { "Gen", "Exhaustion", "Blind" }, 2019));
            PerkList.Add(new Perk("Monitor and Abuse", "Killer", "Doctor", new List<string> { "Terror Radius" }, 2017));
            PerkList.Add(new Perk("Nemesis", "Killer", "Oni", new List<string> { "Obsession", "Pallet", "Oblivious", "Aura", "Blind" }, 2019));
            PerkList.Add(new Perk("No Way Out", "Killer", "Trickster", new List<string> { "End Game", "Hook" }, 2021));
            PerkList.Add(new Perk("Nowhere to Hide", "Killer", "Knight", new List<string> { "Gen", "Aura" }, 2022));
            PerkList.Add(new Perk("Opression", "Killer", "Twins", new List<string> { "Gen", "Skill Check" }, 2020));

            PerkList.Add(new Perk("Overcharge", "Killer", "Doctor", new List<string> { "Gen", "Skill Check" }, 2017));
            PerkList.Add(new Perk("Overwhelming Presence", "Killer", "Doctor", new List<string> { "Terror Radius", "Item" }, 2017));
            PerkList.Add(new Perk("Play with Your Food", "Killer", "Shape", new List<string> { "Obsession", "Haste" }, 2016));
            PerkList.Add(new Perk("Pop Goes the Weasel", "Killer", "Clown", new List<string> { "Hook", "Gen" }, 2018));
            PerkList.Add(new Perk("Predator", "Killer", "Wraith", new List<string> { "Scratch Marks" }, 2016));
            PerkList.Add(new Perk("Rancor", "Killer", "Spirit", new List<string> { "End Game", "Exposed", "Aura", "Obsession" }, 2018));
            PerkList.Add(new Perk("Rapid Brutality", "Killer", "Xenomorph", new List<string> { "Haste", "Injured" }, 2023));
            //Add bloodlust category for this and beast of prey?
            PerkList.Add(new Perk("Remember Me", "Killer", "Nightmare", new List<string> { "End Game", "Injured", "Obsession" }, 2017));
            PerkList.Add(new Perk("Save the Best for Last", "Killer", "Shape", new List<string> { "Obsession", "Injured" }, 2016));
            PerkList.Add(new Perk("Scourge Hook: Floods of Rage", "Killer", "Onryo", new List<string> { "Hook", "Aura" }, 2022));

            PerkList.Add(new Perk("Scourge Hook: Gift of Pain", "Killer", "Cenobite", new List<string> { "Hook", "Healing", "Gen" }, 2021));
            PerkList.Add(new Perk("Scourge Hook: Hangman's Trick", "Killer", "Pig", new List<string> { "Hook", "Aura", "Carrying" }, 2018));
            PerkList.Add(new Perk("Scourge Hook: Monstrous Shrine", "Killer", "Universal", new List<string> { "Hook" }, 2016));
            PerkList.Add(new Perk("Scourge Hook: Pain Resonance", "Killer", "Artist", new List<string> { "Hook", "Gen", "Scream" }, 2021));
            PerkList.Add(new Perk("Septic Touch", "Killer", "Dredge", new List<string> { "Terror Radius", "Exhaustion", "Healing", "Blind" }, 2022));
            PerkList.Add(new Perk("Shadowborn", "Killer", "Wraith", new List<string> { "Haste", "Blind" }, 2016));
            PerkList.Add(new Perk("Shattered Hope", "Killer", "Universal", new List<string> { "Totem", "Aura" }, 2022));
            PerkList.Add(new Perk("Sloppy Butcher", "Killer", "Universal", new List<string> { "Injured", "Healing", "Blood" }, 2016));
            PerkList.Add(new Perk("Spies from the Shadows", "Killer", "Universal", new List<string> { "Crow" }, 2016));
            PerkList.Add(new Perk("Spirit Fury", "Killer", "Spirit", new List<string> { "Pallet" }, 2018));

            PerkList.Add(new Perk("Starstruck", "Killer", "Trickster", new List<string> { "Exposed", "Carrying", "Terror Radius" }, 2021));
            PerkList.Add(new Perk("Stridor", "Killer", "Nurse", new List<string> { "Grunts of Pain" }, 2016));
            PerkList.Add(new Perk("Superior Anatomy", "Killer", "Mastermind", new List<string> { "Window" }, 2022));
            PerkList.Add(new Perk("Surge", "Killer", "Demogorgon", new List<string> { "Gen", "Recovery" }, 2019));
            PerkList.Add(new Perk("Surveillance", "Killer", "Pig", new List<string> { "Aura", "Gen" }, 2018));
            PerkList.Add(new Perk("THWACK!", "Killer", "Skull Merchant", new List<string> { "Pallet", "Scream", "Hook" }, 2023));
            PerkList.Add(new Perk("Terminus", "Killer", "Mastermind", new List<string> { "End Game", "Broken" }, 2022));
            PerkList.Add(new Perk("Territorial Imperative", "Killer", "Huntress", new List<string> { "Aura" }, 2017));
            PerkList.Add(new Perk("Thanatophobia", "Killer", "Nurse", new List<string> { "Injured", "Healing" }, 2016));
            PerkList.Add(new Perk("Thrilling Tremors", "Killer", "Ghost Face", new List<string> { "Carrying", "Gen", "Aura" }, 2019));

            PerkList.Add(new Perk("Tinkerer", "Killer", "Hillbilly", new List<string> { "Gen", "Undetectable" }, 2016));
            PerkList.Add(new Perk("Trail of Torment", "Killer", "Executioner", new List<string> { "Undetectable", "Aura" }, 2020));
            PerkList.Add(new Perk("Ultimate Weapon", "Killer", "Xenomorph", new List<string> { "Locker", "Scream", "Blind" }, 2023));
            PerkList.Add(new Perk("Unbound", "Killer", "Unknown", new List<string> { "Haste", "Injured", "Window" }, 2024));
            PerkList.Add(new Perk("Undone", "Killer", "Unknown", new List<string> { "Skill Check", "Gen" }, 2024));
            //Add gen blocking category?
            PerkList.Add(new Perk("Unforeseen", "Killer", "Unknown", new List<string> { "Gen", "Undetectable", "Terror Radius" }, 2024));
            PerkList.Add(new Perk("Unnerving Presence", "Killer", "Trapper", new List<string> { "Terror Radius", "Skill Check" }, 2016));
            PerkList.Add(new Perk("Unrelenting", "Killer", "Universal", new List<string> { "Basic Attacks" }, 2016));
            //^^^ bad
            PerkList.Add(new Perk("Weave Attunement", "Killer", "Lich", new List<string> { "Item", "Aura", "Oblivious" }, 2024));
            PerkList.Add(new Perk("Whispers", "Killer", "Universal", new List<string> { "Terror Radius" }, 2016));
            //^^^ Not true

            PerkList.Add(new Perk("Zanshin Tactics", "Killer", "Oni", new List<string> { "Window", "Pallet", "Aura" }, 2019));

            var CorrectAnswerIndex = 0;
            var GuessEffect = false;
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Welcome to Perkdle");
            //Console.WriteLine("Would you like to do the (D)aily Perkdle (changes daily) or try a (R)andom one?");
            Console.WriteLine("Would you like to play the....");
            Console.WriteLine("(D)aily Perkdle");
            Console.WriteLine("(R)andom Perkdle");
            Console.WriteLine("Guess by (E)ffect");
            var UserWant = Console.ReadLine();
            if (UserWant == "R")
            {
                Random rng= new Random();
                CorrectAnswerIndex = rng.Next(0, 264);
            }
            else if (UserWant == "D")
            {
                Random rng = new Random(DateTime.Now.Day);
                CorrectAnswerIndex = rng.Next(0, 264);
            }
            else
            {
                GuessEffect = true;
                Random rng = new Random();
                CorrectAnswerIndex = rng.Next(0, 264);
            }

            List<int> PreviousGuesses = new List<int>();
            var Win = false;
            while (Win == false)
            {
                if (GuessEffect == false)
                {
                    Console.WriteLine("Please Enter a Perk: ");
                    var UserQuery = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Number of Guesses: " + (PreviousGuesses.Count + 1));
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    int index = PerkList.FindIndex(a => a.Name == UserQuery);
                    if (index != -1)
                    {
                        if (PreviousGuesses.Count != 0)
                        {
                            for (int i = 0; i < PreviousGuesses.Count; i++)
                            {
                                var TempIndex = PreviousGuesses[i];
                                var Trash = DisplayPerks(TempIndex, true);
                            }
                        }
                        PreviousGuesses.Add(index);
                        Win = DisplayPerks(index, true);
                    }
                    /*Console.WriteLine("{0, -30} {1,10} {2,16} {3,7} {4,3}\n", "Perk Name", "Role", "Character", "Year", "Tags");
                    for (int i = 0; i < PerkList.Count; i++)
                    {
                        var state = (i % 3) + 1;
                        ColorChangingFuction(state);
                        Console.WriteLine("{0, -30} {1,10} {2,16} {3,7} {4,3}\n", PerkList[i].Name, PerkList[i].Role, PerkList[i].Character, PerkList[i].Year, string.Join(", ", PerkList[i].Type));
                
                    }*/
                    Console.ResetColor();
                    if (Win == true)
                    {
                        Console.WriteLine("Congrats you Win! The Correct answer was " + PerkList[index].Name + " and you got it in " + PreviousGuesses.Count + " guesses");
                        Console.WriteLine("Would you like to play again with a random perk? Y/N");
                        var Choice = Console.ReadLine();
                        if (Choice == "Y")
                        {
                            Win = false;
                            Random rng = new Random();
                            CorrectAnswerIndex = rng.Next(0, 238);
                            PreviousGuesses.Clear();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("This Perk has the Effect: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(string.Join(", ", PerkList[CorrectAnswerIndex].Type));
                    Console.ResetColor();
                    Console.WriteLine("Please Enter a Perk: ");
                    var UserQuery = Console.ReadLine();
                    Console.Clear();
                    Console.WriteLine("Number of Guesses: " + (PreviousGuesses.Count + 1));
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    Console.WriteLine(" ");
                    int index = PerkList.FindIndex(a => a.Name == UserQuery);
                    if (index != -1)
                    {
                        if (PreviousGuesses.Count != 0)
                        {
                            for (int i = 0; i < PreviousGuesses.Count; i++)
                            {
                                var TempIndex = PreviousGuesses[i];
                                var Trash = DisplayPerks(TempIndex, false);
                            }
                        }
                        PreviousGuesses.Add(index);
                        Win = DisplayPerks(index, false);
                    }

                    Console.ResetColor();
                    if (Win == true)
                    {
                        Console.WriteLine("Congrats you Win! The Correct answer was " + PerkList[index].Name + " and you got it in " + PreviousGuesses.Count + " guesses");
                        Console.WriteLine("Would you like to play again with a random perk? Y/N");
                        var Choice = Console.ReadLine();
                        if (Choice == "Y")
                        {
                            Win = false;
                            Random rng = new Random();
                            CorrectAnswerIndex = rng.Next(0, 238);
                            PreviousGuesses.Clear();
                        }
                    }
                }
            }


            void ColorChangingFuction(int state)
            {
                if (state == 1)                                             //Correct
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                if (state == 2)                                             //Incorrect
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                if (state == 3)                                             //Partially Correct
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                }
            }


            bool DisplayPerks(int index, bool ShowTags)
            {
                int IsName=0;
                int IsRole =0;
                int IsCharacter =0;
                int IsYear =0;
                int IsTag =0;

                var Name = PerkList[index].Name;
                var Role = PerkList[index].Role;
                var Character = PerkList[index].Character;
                var Year = PerkList[index].Year;
                string YearArrow= "\u9786";
                var Tags = PerkList[index].Type;

                var CorrectName = PerkList[CorrectAnswerIndex].Name;
                var CorrectRole = PerkList[CorrectAnswerIndex].Role;
                var CorrectCharacter = PerkList[CorrectAnswerIndex].Character;
                var CorrectYear = PerkList[CorrectAnswerIndex].Year;
                var CorrectTags = PerkList[CorrectAnswerIndex].Type;

                if (Name == CorrectName)
                {
                    IsName = 1;
                }
                else
                {
                    IsName = 2;
                }

                if (Role == CorrectRole)
                {
                    IsRole = 1;
                }
                else
                {
                    IsRole = 2;
                }

                if (Character == CorrectCharacter)
                {
                    IsCharacter = 1;
                }
                else
                {
                    IsCharacter = 2;
                }

                if (Year == CorrectYear)
                {
                    IsYear = 1;
                }
                else
                {
                    if (Year < CorrectYear)
                    {
                        YearArrow = "\u2191";
                    }
                    else
                    {
                        YearArrow = "\u2193";
                    }
                    IsYear = 2;
                }
                int Counter = 0;
                int TagsNum=Tags.Count;
                int CorrectTagsNum=CorrectTags.Count;
                for (int i=0; i<Tags.Count; i++)
                {
                    for (int j = 0; j < CorrectTags.Count; j++)
                    {
                        if (Tags[i] == CorrectTags[j])
                        {
                            Counter++;
                        }
                    }
                }
                if (TagsNum == CorrectTagsNum) 
                {
                    if (TagsNum == Counter)
                    {
                        IsTag = 1;
                    }
                    else if (Counter > 0)
                    {
                        IsTag = 3;
                    }
                    else
                    {
                        IsTag = 2;
                    }
                }
                else if (Counter > 0)
                {
                    IsTag = 3;
                }
                else
                {
                    IsTag = 2;
                }
                /*Console.WriteLine("---");
                Console.WriteLine("| |");
                Console.WriteLine("---");*/
                ColorChangingFuction(IsName);
                int NameLength = 32 - Name.Length;
                Console.Write(Name);
                for (int i = 0; i < NameLength;  i++)
                {
                    Console.Write(" ");
                }
                Console.ResetColor();

                ColorChangingFuction(IsRole);
                int RoleLength = 10 - Role.Length;
                Console.Write(Role);
                for (int i = 0; i < RoleLength; i++)
                {
                    Console.Write(" ");
                }
                Console.ResetColor();

                ColorChangingFuction(IsCharacter);
                int CharacterLength = 16 - Character.Length;
                Console.Write(Character);
                for (int i = 0; i < CharacterLength; i++)
                {
                    Console.Write(" ");
                }
                Console.ResetColor();

                ColorChangingFuction(IsYear);
                if (YearArrow!= "\u9786")
                {
                    Console.Write(YearArrow);
                }
                else
                {
                    Console.Write("  ");
                }
                Console.Write(Year);
                Console.Write("  ");
                Console.ResetColor();
                if (ShowTags == true)
                {
                    ColorChangingFuction(IsTag);
                    Console.Write(string.Join(", ", Tags));
                }
                Console.Write("\n");
                Console.ResetColor();

                if (IsName == 1 && IsRole == 1 && IsCharacter == 1 && IsTag == 1 && IsYear== 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            Console.WriteLine("Press any button to quit");
            Console.ReadLine();
        }
    }
}