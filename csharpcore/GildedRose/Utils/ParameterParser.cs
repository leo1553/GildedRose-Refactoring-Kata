using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using Mono.Options;
using System;
using System.Linq;

namespace GildedRoseKata.Utils {
    public static class ParameterParser {
        public static IProgramOptions GetOptions(string[] args) {
            if(args is null)
                throw new ArgumentNullException(nameof(args));
            IProgramOptions programOptions = new ProgramOptions();
            OptionSet options = null;
            options = new OptionSet() {
                { "d|days=", "The amount of days to simulate.",
                    value => {
                        if(value != null)
                            programOptions.DaysToSimulate = ParameterParser.ParseDays(value);
                    }
                },
                { "l|log=", "The desired logger strategy.",
                    value => {
                        if(value != null)
                            programOptions.LogStrategy = ParameterParser.ParseLog(value);
                    }
                },
                { "h|help", "Displays this message.",
                    value => {
                        if(value != null)
                            ParameterParser.DisplayLog(options);
                    }
                }
            };
            try {
                options.Parse(args);
            }
            catch(OptionException e) {
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine($"Try {AppDomain.CurrentDomain.FriendlyName} --help for more information.");
                Environment.Exit(-1);
            }
            return programOptions;
        }

        private static int ParseDays(string daysString) {
            if(!int.TryParse(daysString, out int days)) 
                throw new OptionException($"\"{daysString}\" is not a number.", "days"); 
            if(days < 1) 
                throw new OptionException($"Value should be greather than zero", "days");
            return days;
        }

        private static LogStrategies ParseLog(string logString) {
            if(!Enum.TryParse(typeof(LogStrategies), logString, true, out object logStrategy))
                throw new OptionException($"Invalid log strategy name.", "log");
            return (LogStrategies)logStrategy;
        }

        private static void DisplayLog(OptionSet options) {
            Console.WriteLine($"Usage: {AppDomain.CurrentDomain.FriendlyName} [options]+");
            Console.WriteLine("Options:");
            options.WriteOptionDescriptions(Console.Out);
            Console.WriteLine("Log strategies:");
            Console.WriteLine($"  {string.Join(", ", Enum.GetNames(typeof(LogStrategies)).Select(name => name.ToLower()))}");
            Environment.Exit(0);
        }
    }
}
