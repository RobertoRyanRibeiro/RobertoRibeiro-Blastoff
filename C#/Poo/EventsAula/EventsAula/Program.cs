using System;

namespace EventsAula
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var room = new Room(3);
            room.RoomSoldOutEvent += OnRoomSoldOut;
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
            room.ReserveSeat();
        }

        static void OnRoomSoldOut(Object sender,EventArgs e)
        {
            Console.WriteLine("Sala Lotada!");
        }
    }

    public class Room
    {
        public int Seats { get; set; }

        private int seatsInUse = 0;

        public Room(int seats)
        {
            Seats = seats;
            seatsInUse = 0;
        }

        public void ReserveSeat()
        {
            seatsInUse++;
            if (seatsInUse >= Seats)
            {
                //Evento Fechado!
                OnRoomSoldOut(EventArgs.Empty);
            }
            else
            {
                Console.WriteLine("Assento Reservado");
            }
        }


        public event EventHandler RoomSoldOutEvent;
        protected virtual void OnRoomSoldOut(EventArgs e)
        {
            EventHandler handler = RoomSoldOutEvent;    
            handler?.Invoke(this, e);
        }
    }
}
