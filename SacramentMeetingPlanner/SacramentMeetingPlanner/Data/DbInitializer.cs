using SacramentMeetingPlanner.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Data
{
    public class DbInitializer
    {
        public static void Initialize(MeetingContext context)
        {
            context.Database.EnsureCreated();

            //Check Meetings are empty.        

            if(context.Meetings.Any())
            {
                return;
            }

            var meetings = new Meeting[]
            {
            new Meeting{Date=DateTime.Parse("2020-12-20"),
                        Conducting="Bishop Miller",
                        OpeningHymn="High on a mountain Top",
                        Invocation="Collin Blake",
                        SacramentHymn="With Humble Heart",
                        SacramentPrayer="John Michaels",
                        ClosingHymn="Press Forward, Saints",
                        Benediction="Charlie Smith"},
            new Meeting{Date=DateTime.Parse("2020-12-27"),
                        Conducting="Bishop Miller",
                        OpeningHymn="Put Your Shoulder to the Wheel",
                        Invocation="Joellen Knuth",
                        SacramentHymn="As Now We Take the Sacrament",
                        SacramentPrayer="Ron Knuth",
                        ClosingHymn="God Be with You Till We Meet Again",
                        Benediction="John Smith"}
            };

            foreach (Meeting m in meetings)
            {
                context.Meetings.Add(m);
            }

            context.SaveChanges();

            var speakers = new Speaker[]
            {
                new Speaker{Name="Amber Crockett", Topic="Forgiveness", MeetingID = meetings.Single(m => m.Benediction == "Charlie Smith").ID},
                new Speaker{Name="Kaladin Blake", Topic="Temples", MeetingID = meetings.Single(m => m.Benediction == "Charlie Smith").ID},
                new Speaker{Name="Ronin Blake", Topic="Faith", MeetingID = meetings.Single(m => m.Benediction == "John Smith").ID},
                new Speaker{Name="Johnathan Blake", Topic="Repentance", MeetingID = meetings.Single(m => m.Benediction == "John Smith").ID}
            };

            foreach (Speaker s in speakers)
            {
                context.Speakers.Add(s);                
            }

            context.SaveChanges();

            //var speakerEnrollment = new SpeakerEnrollment[] {
            //    new SpeakerEnrollment { MeetingID = meetings.Single(m => m.Benediction == "Charlie Smith").ID , SpeakerID = speakers.Single(s => s.Name == "Amber Crockett").ID},
            //    new SpeakerEnrollment { MeetingID = meetings.Single(m => m.Benediction == "Charlie Smith").ID , SpeakerID = speakers.Single(s => s.Name == "Kaladin Blake").ID},
            //    new SpeakerEnrollment { MeetingID = meetings.Single(m => m.Benediction == "John Smith").ID , SpeakerID = speakers.Single(s => s.Name == "Ronin Blake").ID},
            //    new SpeakerEnrollment { MeetingID = meetings.Single(m => m.Benediction == "John Smith").ID , SpeakerID = speakers.Single(s => s.Name == "Johnathan Blake").ID}
            //};

            //foreach (SpeakerEnrollment se in speakerEnrollment)
            //{
            //    context.SpeakerEnrollments.Add(se);
            //}

            //context.SaveChanges();            
        }
    }
}

