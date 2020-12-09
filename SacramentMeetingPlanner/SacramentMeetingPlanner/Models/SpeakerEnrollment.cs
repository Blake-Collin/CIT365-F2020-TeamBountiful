using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SacramentMeetingPlanner.Models
{
    public class SpeakerEnrollment
    {
        public int SpeakerEnrollmentID { get; set; }
        public int MeetingID { get; set; }
        public int SpeakerID { get; set; }
    }
}
