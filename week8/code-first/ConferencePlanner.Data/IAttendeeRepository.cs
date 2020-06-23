using ConferencePlanner.Data.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ConferencePlanner.Data
{
    interface IAttendeeRepository
    {
        IEnumerable GetAttendees();
        Attendee GetAttendeeByID(int attendeeId);
        void InsertAttendee(Attendee attendee);
        void DeleteAttendee(int attendeeId);
        void UpdateAttendee(Attendee attendee);
        void Save();
    }
}
