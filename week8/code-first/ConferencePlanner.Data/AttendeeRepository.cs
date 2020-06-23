using ConferencePlanner.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConferencePlanner.Data
{
    class AttendeeRepository : IAttendeeRepository
    {
        private ApplicationDbContext context;

        public AttendeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IEnumerable GetAttendees()
        {
            return context.Attendees.ToList();
        }

        public Attendee GetAttendeeByID(int attendeeId)
        {
            return context.Attendees.Find(attendeeId);
        }

        public void InsertAttendee(Attendee attendee)
        {
            context.Attendees.Add(attendee);
        }

        public void UpdateAttendee(Attendee attendee)
        {
            context.Attendees.Update(attendee);
        }

        public void DeleteAttendee(int attendeeId)
        {
           var attendee = context.Attendees.Find(attendeeId);
           context.Attendees.Remove(attendee);
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
