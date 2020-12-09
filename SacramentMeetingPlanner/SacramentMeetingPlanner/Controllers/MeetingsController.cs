using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SacramentMeetingPlanner.Data;
using SacramentMeetingPlanner.Models;

namespace SacramentMeetingPlanner.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly MeetingContext _context;

        public MeetingsController(MeetingContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Meetings.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .Include(e => e.Speakers)                    
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            List<Speaker> speakersList = new List<Speaker>();
            var speakers = _context.Speakers.Select(s => s).Where(s => s.MeetingID == meeting.ID);
            foreach (Speaker s in speakers)
            {
                speakersList.Add(s);
            }

            MeetingView newMeeting = new MeetingView { ID = meeting.ID, Date = meeting.Date, Conducting = meeting.Conducting, OpeningHymn = meeting.OpeningHymn, Invocation = meeting.Invocation, SacramentHymn = meeting.SacramentHymn, SacramentPrayer = meeting.SacramentPrayer, ClosingHymn = meeting.ClosingHymn, Benediction = meeting.Benediction, Speakers = speakersList };

            return View(newMeeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Conducting,OpeningHymn,Invocation,SacramentHymn,SacramentPrayer,ClosingHymn,Benediction,Speakers")] MeetingView meeting)
        {
            if (ModelState.IsValid)
            {                
                Meeting newMeeting = new Meeting { Date = meeting.Date, Conducting = meeting.Conducting, OpeningHymn = meeting.OpeningHymn, Invocation = meeting.Invocation, SacramentHymn = meeting.SacramentHymn, SacramentPrayer = meeting.SacramentPrayer, ClosingHymn = meeting.ClosingHymn, Benediction = meeting.Benediction};

                _context.Add(newMeeting);
                await _context.SaveChangesAsync();

                var speakers = meeting.Speakers.ToArray();

                foreach (Speaker s in speakers)
                {
                    s.MeetingID = newMeeting.ID;
                    _context.Speakers.Add(s);
                }

                await _context.SaveChangesAsync();

                //foreach(Speaker s in speakers)
                //{
                //    SpeakerEnrollment se = new SpeakerEnrollment {SpeakerID = s.ID, MeetingID = newMeeting.ID };
                //    _context.SpeakerEnrollments.Add(se);
                //}
                //await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);

            if (meeting == null)
            {
                return NotFound();
            }

            List<Speaker> speakersList = new List<Speaker>();
            var speakers = _context.Speakers.Select(s => s).Where(s => s.MeetingID == meeting.ID);
            foreach(Speaker s in speakers)
            {
                speakersList.Add(s);
            }

            MeetingView newMeeting = new MeetingView { ID = meeting.ID, Date = meeting.Date, Conducting = meeting.Conducting, OpeningHymn = meeting.OpeningHymn, Invocation = meeting.Invocation, SacramentHymn = meeting.SacramentHymn, SacramentPrayer = meeting.SacramentPrayer, ClosingHymn = meeting.ClosingHymn, Benediction = meeting.Benediction, Speakers = speakersList };


            return View(newMeeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Conducting,OpeningHymn,Invocation,SacramentHymn,SacramentPrayer,ClosingHymn,Benediction,Speakers")] MeetingView meeting)
        {
            if (id != meeting.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Meeting newMeeting = new Meeting { ID = meeting.ID, Date = meeting.Date, Conducting = meeting.Conducting, OpeningHymn = meeting.OpeningHymn, Invocation = meeting.Invocation, SacramentHymn = meeting.SacramentHymn, SacramentPrayer = meeting.SacramentPrayer, ClosingHymn = meeting.ClosingHymn, Benediction = meeting.Benediction };

                    _context.Update(newMeeting);
                    await _context.SaveChangesAsync();

                    //Remove Speakers
                    var removeSpeakers = _context.Speakers.Select(s => s).Where(s => s.MeetingID == id);
                    foreach (Speaker s in removeSpeakers)
                    {
                        _context.Remove(s);
                    }
                    await _context.SaveChangesAsync();

                    //Update Speakers
                    foreach (Speaker s in meeting.Speakers)
                    {
                        s.MeetingID = id;
                        _context.Speakers.Add(s);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .FirstOrDefaultAsync(m => m.ID == id);

            
            
            if (meeting == null)
            {
                return NotFound();
            }

            List<Speaker> speakersList = new List<Speaker>();
            var speakers = _context.Speakers.Select(s => s).Where(s => s.MeetingID == meeting.ID);
            foreach (Speaker s in speakers)
            {
                speakersList.Add(s);
            }

            MeetingView newMeeting = new MeetingView { ID = meeting.ID, Date = meeting.Date, Conducting = meeting.Conducting, OpeningHymn = meeting.OpeningHymn, Invocation = meeting.Invocation, SacramentHymn = meeting.SacramentHymn, SacramentPrayer = meeting.SacramentPrayer, ClosingHymn = meeting.ClosingHymn, Benediction = meeting.Benediction, Speakers = speakersList };

            return View(newMeeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var meeting = await _context.Meetings.FindAsync(id);
            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
            return _context.Meetings.Any(e => e.ID == id);
        }
    }
}
