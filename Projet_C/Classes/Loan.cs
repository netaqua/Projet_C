using Projet_C.Classes;
using Projet_C.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_C.Classes
{
    internal class Loan
    {
        private int idLoan;
        private DateTime startDate;
        private DateTime endDate;
        private bool onGoing;
        private Copy copy;
        private Player hirer;
        private Player tenant;

        public int IdLoan
        {
            get { return idLoan; }
            set { idLoan = value; }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        public bool OnGoing { get { return onGoing; } set { onGoing = value; } }

        public Copy Copy { get { return copy; } set { copy = value; } }
        public Player Hirer { get { return hirer; } set { hirer = value; } }

        public Player Tenant { get { return tenant; } set { tenant = value; } }

        public Loan(int idLoan, DateTime startDate, DateTime endDate, bool onGoing, Player hirer, Player tenant)
        {
            IdLoan = idLoan;
            StartDate = startDate;
            EndDate = endDate;
            OnGoing = onGoing;
            Hirer = hirer;
            Tenant = tenant;
        }

        public Loan()
        {
        }

        public static List<Loan> GetLoans()
        {
            LoanDB dB = new LoanDB();
            return dB.ReadAll();
        }

    }
}